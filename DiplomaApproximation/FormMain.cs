using DiplomaApproximation.Distributions;
using DiplomaApproximation.Web;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiplomaApproximation
{
    public partial class FormMain : Form
    {
        private Network network;

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

            chartHystogram.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;

            form = this;
        }

        private double FindMinAndMax(double[] array, out double max)
        {
            double min = array[0];
            max = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > max)
                {
                    max = array[i];
                }
                else if (array[i] < min)
                {
                    min = array[i];
                }
            }

            return min;
        }

        private void MiniMax(double[] array)
        {
            double min = FindMinAndMax(array, out double max);
            double difference = max - min;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = (array[i] - min) / difference;
            }
        }

        public void Generate(double[] arrayDistribution, string name, bool isInitialize)
        {
            int countIntervals = network.CountNeurons;
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

            /*List<double> newArrX, newArrY;
            //while(!CorrectingArray(arrayOfX, arrayOfY, out newArrX, out newArrY, step))
            CorrectingArray(arrayOfX, arrayOfY, out newArrX, out newArrY, step);
            {
                arrayOfX = newArrX.ToArray();
                arrayOfY = newArrY.ToArray();
            }

            arrayOfX = newArrX.ToArray();
            arrayOfY = newArrY.ToArray();*/

            for (int i = 0; i < countIntervals; i++)
            {
                arrayOfY[i] /= step;
            }

            MiniMax(arrayOfY);
            MiniMax(arrayOfX);
            chartHystogram.Series["Выборка"].Points.DataBindXY(arrayOfX, arrayOfY);

            ArrayX = arrayOfX;
            ArrayY = arrayOfY;

            if (isInitialize)
            {
                nameDistribution = name;

                learnedX = ArrayX;
                learnedY = ArrayY;

                network.InitCenters(countIntervals, learnedX);

                chartHystogram.Series["Выборка"].Points.DataBindXY(learnedX, learnedY);

                learnedProbability = buf;
            }
            else
            {
                probability = new double[countIntervals];

                sum = 0;
                MiniMax(arrayDistribution);

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

        public void InitializeNetwork(int countLearningItterations, double learningCoefficient, double momentum, double error, int countNeurons)
        {
            network = new Network();
            network.Init(countLearningItterations, learningCoefficient, momentum, error, countNeurons);
        }

        public int GetCountNeurons()
        {
            return network.CountNeurons;
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
                        Generate(arr, "", isInitialize);
                    }

                    learnNetworkToolStripMenuItem.Enabled = true;
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

        private void SetNewValue(double[] arrayX, double[] arrayY)
        {
            chartHystogram.Series["Выборка"].Points.DataBindXY(arrayX, arrayY);
        }

        private void Compute()
        {
            /*for (int i = 1; i < 30; i++)
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                path += "\\" + nameDistribution + "\\";

                path += i.ToString() + ".txt";
                Random rand = new Random();
                array = new ExponentialOneway(rand.NextDouble(), 5000).Generate();

                string[] arr = new string[array.Length];
                for (int j = 0; j < array.Length; j++)
                {
                    arr[j] = array[j].ToString();
                }

                System.IO.File.WriteAllLines(path, arr);

            }*/

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
                    Generate(array, "", false);
                    values = new double[countNeurons];
                    for (int i = 0; i < countNeurons; i++)
                    {
                        double value = network.OutputValue(ArrayX[i]);
                        values[i] = value;
                        error += Math.Pow(value - ArrayY[i], 2);
                    }

                    errors.Add(Math.Sqrt(error / (countNeurons - 1)));
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
            Compute();
        }

        private void GeneratorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormParametrs form = new FormParametrs(this);
            this.Hide();
            form.ShowDialog();
            this.Show();

            if(array != null)
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
                textBoxCurrentError.Text = error.ToString();
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

            for (int i = 0; i < countNeurons; i++)
            {
                if(learnedProbability[i] == 0)
                {
                    continue;
                }
                result += Math.Pow(learnedProbability[i] - probability[i], 2) / learnedProbability[i];
                //result += Math.Pow(count[i] / array.Length - probability[i], 2) / probability[i];
            }

            //result *= array.Length;

            double delta, lyambda, max = 0;

            for (int i = 0; i < countNeurons; i++)
            {
                delta = Math.Abs(learnedProbability[i] - probability[i]);
                if (delta > max)
                {
                    max = delta;
                }
            }

            lyambda = max * Math.Sqrt(countNeurons);

            new CheckForm(result, countNeurons, lyambda).ShowDialog();
        }

        private void ToolStripMenuItemWorking_Click(object sender, EventArgs e)
        {
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
                    Generate(array, "", false);
                    values = new double[countNeurons];
                    for (int i = 0; i < countNeurons; i++)
                    {
                        double value = network.OutputValue(ArrayX[i]);
                        values[i] = value;
                        error += Math.Pow(value - ArrayY[i], 2);
                    }

                    res = Math.Sqrt(error / (countNeurons - 1));
                    SetNewValue(ArrayX, ArrayY);

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

            SwitchButton(true);
        }
    }
}
