using DiplomaApproximation.Web;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiplomaApproximation
{
    public partial class FormMain : Form
    {
        public Network network;

        public double[] ArrayX { get; set; }
        public double[] ArrayY { get; set; }

        private string nameDistribution;

        private double[] array = null;

        private double[] learnedX,
            learnedY;

        private double[] learnedProbability;

        private double[] probability;

        public FormMain()
        {
            InitializeComponent();

            chartHystogram.Series["Выборка"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["Сеть"].ChartType = SeriesChartType.Line;
            chartHystogram.Series["Сеть"].BorderDashStyle = ChartDashStyle.Dash;
            chartHystogram.Series["Сеть"].BorderWidth = 3;

            chartHystogram.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;

            form = this;
        }

        public void Generate(double[] arrayDistribution, string name, bool isInitialize, int countIntervals)
        {
            if (countIntervals == 0)
            {
                countIntervals = (learnedX != null) ? learnedX.Length : 15;
            }
            array = new double[arrayDistribution.Length];

            Array.Copy(arrayDistribution, array, arrayDistribution.Length);

            Array.Sort(arrayDistribution);

            double[] arrayOfX = new double[countIntervals],
                arrayOfY = new double[countIntervals];

            double minX = arrayDistribution[0];
            double maxX = arrayDistribution[arrayDistribution.Length - 1];
            double step = (maxX - minX) / countIntervals;

            arrayOfX[0] = minX;
            int sum = 0;
            for (int i = 1; i < countIntervals; i++)
            {
                arrayOfX[i] = arrayOfX[i - 1] + step;
            }

            for (int i = 0; i < arrayDistribution.Length; i++)
            {
                for (int j = 0; j < countIntervals - 1; j++)
                {
                    if (arrayDistribution[i] >= arrayOfX[j] && arrayDistribution[i] < arrayOfX[j + 1])
                    {
                        arrayOfY[j]++;
                        sum++;
                        break;
                    }
                }
            }

            arrayOfY[arrayOfY.Length - 1] = arrayDistribution.Length - sum;

            for (int i = 0; i < countIntervals; i++)
            {
                arrayOfY[i] /= arrayDistribution.Length;
            }

            double[] buf = new double[countIntervals];
            Array.Copy(arrayOfY, buf, arrayOfY.Length);

            for (int i = 0; i < countIntervals; i++)
            {
                arrayOfY[i] /= step;
            }

            double s = Tools.Square(arrayDistribution);

            //double sq = Tools.SquareSimpson(step, arrayOfY, network.CountNeurons);

            Tools.MiniMax(arrayOfY);
            Tools.MiniMax(arrayOfX);
            chartHystogram.Series["Выборка"].Points.DataBindXY(arrayOfX, arrayOfY);

            ArrayX = arrayOfX;
            ArrayY = arrayOfY;
            
            if (isInitialize)
            {

                nameDistribution = name;

                learnedX = ArrayX;
                learnedY = ArrayY;

                network.InitCenters(learnedX);

                chartHystogram.Series["Выборка"].Points.DataBindXY(learnedX, learnedY);

                learnedProbability = buf;
            }
            else
            {
                probability = new double[countIntervals];

                sum = 0;
                Tools.MiniMax(arrayDistribution);

                for (int i = 0; i < arrayDistribution.Length; i++)
                {
                    for (int j = 0; j < countIntervals - 1; j++)
                    {
                        if (arrayDistribution[i] >= ArrayX[j] && arrayDistribution[i] < ArrayX[j + 1])
                        {
                            probability[j]++;
                            sum++;
                            break;
                        }
                    }
                }

                probability[probability.Length - 1] = arrayDistribution.Length - sum;

                for (int i = 0; i < countIntervals; i++)
                {
                    probability[i] /= arrayDistribution.Length;
                }
            }
        }

        public void DrawError(double[] errors, int[] massX)
        {
            if (MessageBox.Show("Показать график ошибки обучения?", "Ошибка обучения", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                new FormError(errors, massX).ShowDialog();
            }
        }

        public void InitializeNetwork(int countLearningItterations, double learningCoefficient, double momentum, double error, int countNeurons, string typeInit, double[] param)
        {
            network = new Network();
            network.Init(countLearningItterations, learningCoefficient, momentum, error, countNeurons, typeInit, param);
        }

        static FormMain form;
        public static void Set(double[] arrayX, double[] arrayY)
        {
            form.Invoke((MethodInvoker)delegate
            {
                form.chartHystogram.Series["Сеть"].Points.DataBindXY(arrayX, arrayY);
            });
        }

        private double[] Download(bool isInitialize)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Текстовый документ (*.txt)|*.txt"
            };
            double[] arr = null;

            try
            {
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] array = System.IO.File.ReadAllLines(fileDialog.FileName);

                    arr = new double[array.Length];

                    for (int i = 0; i < array.Length; i++)
                    {
                        arr[i] = Double.Parse(array[i]);
                    }

                    if (isInitialize)
                    {
                        Generate(arr, "", isInitialize, 0);
                    }

                    learnNetworkToolStripMenuItem.Enabled = true;

                    labelCurrentIteration.Visible = false;
                    textBoxCurrentIteration.Visible = false;
                    labelError.Visible = false;
                    textBoxCurrentError.Visible = false;

                    labelErrorWorking.Visible = false;
                    textBoxErrorWorking.Visible = false;
                }
            }
            catch { arr = null; }

            return arr;
        }

        private double[] Download(string name)
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            path += "\\" + nameDistribution;

            double[] arr = null;

            try
            {
                string[] array = System.IO.File.ReadAllLines(path + "\\" + name + ".txt");

                arr = new double[array.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    arr[i] = Double.Parse(array[i]);
                }
            }
            catch { arr = null; }

            return arr;
        }

        public void SetNewValue(double[] arrayX, double[] arrayY)
        {
            form.Invoke((MethodInvoker)delegate
            {
                form.chartHystogram.Series["Выборка"].Points.DataBindXY(arrayX, arrayY);
            });
        }

        private void Compute()
        {
            System.Collections.Generic.List<double> errors = new System.Collections.Generic.List<double>();
            double[] values;
            int j = 0;
            double error;

            while (j++ < 29)
            {
                error = 0;

                double[] array = Download(j.ToString());
                if (array != null)
                {
                    int countNeurons = network.CountNeurons;
                    Generate(array, "", false, 0);
                    values = new double[ArrayX.Length];
                    for (int i = 0; i < ArrayX.Length; i++)
                    {
                        double value = network.OutputValue(ArrayX[i]);
                        values[i] = value;
                        error += Math.Pow(value - ArrayY[i], 2);
                    }

                    if (countNeurons > 1)
                    {
                        error = Math.Sqrt(error / (countNeurons - 1));
                    }

                    errors.Add(error);

                    SetNewValue(ArrayX, ArrayY);
                }
                else
                {
                    break;
                }
            }

            if (errors.Count > 0)
            {
                errors.Sort();
                try
                {
                    textBoxErrorWorking.Invoke((MethodInvoker)delegate { textBoxErrorWorking.Text = errors.ToArray()[errors.Count - 1].ToString(); });
                }
                catch { }
            }
        }

        private void DownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Download(true);
        }

        private void TestNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelErrorWorking.Visible = true;
            textBoxErrorWorking.Visible = true;

            Compute();
        }

        private void GeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormParametrs form = new FormParametrs(this);
            this.Hide();
            form.ShowDialog();
            this.Show();

            if (array != null)
            {
                chartHystogram.Series["Сеть"].Points.Clear();
                learnNetworkToolStripMenuItem.Enabled = true;
            }
        }

        private void NetworkParametrsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormNetwork form = new FormNetwork(this);
            this.Hide();
            form.ShowDialog();
            this.Show();
            if (form.DialogResult == DialogResult.OK)
            {
                chartHystogram.Series["Сеть"].Points.Clear();
                chartHystogram.Series["Выборка"].Points.Clear();

                ArrayX = null;
                ArrayY = null;
                learnedX = null;
                learnedY = null;
                array = null;

                fileToolStripMenuItem.Enabled = true;
                generatorToolStripMenuItem.Enabled = true;

                learnNetworkToolStripMenuItem.Enabled = false;
                testNetworkToolStripMenuItem.Enabled = false;
                workingToolStripMenuItem.Enabled = false;

                labelCurrentIteration.Visible = false;
                textBoxCurrentIteration.Visible = false;
                labelError.Visible = false;
                textBoxCurrentError.Visible = false;

                labelErrorWorking.Visible = false;
                textBoxErrorWorking.Visible = false;
            }
        }

        public void SetCurrentIteration(int iteration)
        {
            form.Invoke((MethodInvoker)delegate
            {
                textBoxCurrentIteration.Text = iteration.ToString();
            });
        }

        public void SetCurrentError(double error)
        {
            form.Invoke((MethodInvoker)delegate
            {
                textBoxCurrentError.Text = error.ToString("0.000000");
            });
        }

        public void SwitchButton(bool on)
        {
            form.Invoke((MethodInvoker)delegate ()
            {
                generatorToolStripMenuItem.Enabled = on;
                fileToolStripMenuItem.Enabled = on;
                networkParametrsToolStripMenuItem.Enabled = on;
                learnNetworkToolStripMenuItem.Enabled = on;
                testNetworkToolStripMenuItem.Enabled = on;
                workingToolStripMenuItem.Enabled = on;

                stopLearningToolStripMenuItem.Enabled = !on;
            });
        }
        
        private Thread learningThread;
        private void LearnNetworkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelCurrentIteration.Visible = true;
            textBoxCurrentIteration.Visible = true;
            labelError.Visible = true;
            textBoxCurrentError.Visible = true;

            learningThread = new Thread(() =>
            {
                network.Learning(this, learnedX, learnedY);
            }
            );

            SwitchButton(false);
            chartHystogram.Series["Сеть"].Points.Clear();

            learningThread.Start();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (array != null)
            {
                SaveFileDialog fileDialog = new SaveFileDialog
                {
                    Filter = "Текстовый документ (*.txt)|*.txt"
                };
                if (fileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] arr = new string[array.Length];
                    for (int i = 0; i < array.Length; i++)
                    {
                        arr[i] = array[i].ToString();
                    }

                    System.IO.File.WriteAllLines(fileDialog.FileName, arr);
                }
            }
            else
            {
                MessageBox.Show("Выборка не создана");
            }

        }

        private void Check()
        {
            int countNeurons = network.CountNeurons;
            double result = 0.0;

            try
            {
                for (int i = 0; i < learnedX.Length; i++)
                {
                    if (learnedProbability[i] == 0)
                    {
                        continue;
                    }
                    result += Math.Pow(learnedProbability[i] - probability[i], 2) / learnedProbability[i];
                }
            }
            catch
            {
                return;
            }

            double delta, lyambda, max = 0;

            for (int i = 0; i < learnedProbability.Length; i++)
            {
                delta = Math.Abs(learnedProbability[i] - probability[i]);
                if (delta > max)
                {
                    max = delta;
                }
            }

            lyambda = max * Math.Sqrt(learnedProbability.Length);

            new CheckForm(result, learnedProbability.Length, lyambda).ShowDialog();
        }

        private void ToolStripMenuItemWorking_Click(object sender, EventArgs e)
        {
            labelErrorWorking.Visible = true;
            textBoxErrorWorking.Visible = true;

            double[] values;
            double error;
            double res = 0;
            int countNeurons = network.CountNeurons;

            while (true)
            {
                error = 0;

                double[] array = Download(false);
                if (array != null)
                {
                    Generate(array, "", false, 0);

                    SetNewValue(ArrayX, ArrayY);

                    values = new double[ArrayX.Length];
                    for (int i = 0; i < ArrayX.Length; i++)
                    {
                        double value = network.OutputValue(ArrayX[i]);
                        values[i] = value;
                        error += Math.Pow(value - ArrayY[i], 2);
                    }

                    res = Math.Sqrt(error / (countNeurons - 1));
                    Set(ArrayX, values);

                    try
                    {
                        textBoxErrorWorking.Invoke((MethodInvoker)delegate { textBoxErrorWorking.Text = res.ToString(); });
                    }
                    catch { }

                    Check();

                    var result = MessageBox.Show("Результат: " + res.ToString() + "\nЗагрузить следующий?", "Работоспособность сети", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        private void StopLearningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            learningThread.Abort();

            DrawError(Network.errorsList.ToArray(), Network.XList.ToArray());

            SwitchButton(true);
        }
    }
}
