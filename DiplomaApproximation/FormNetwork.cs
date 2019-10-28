using System;
using System.Windows.Forms;

namespace DiplomaApproximation
{
    public partial class FormNetwork : Form
    {
        private FormMain formMain;

        public FormNetwork(FormMain formMain)
        {
            InitializeComponent();

            this.formMain = formMain;
        }

        private void ButtonAccept_Click(object sender, EventArgs e)
        {
            double[] arrayOfParametrs = null;

            try
            {
                textBoxError.Text = textBoxError.Text.Replace('.', ',');
                textBoxCoefficient.Text = textBoxCoefficient.Text.Replace('.', ',');
                textBoxMoment.Text = textBoxMoment.Text.Replace('.', ',');

                if(comboBoxInit.SelectedItem.ToString().Equals("Имитация отжига"))
                {
                    textBoxStartTemperature.Text = textBoxStartTemperature.Text.Replace('.', ',');
                    textBoxStopTemperature.Text = textBoxStopTemperature.Text.Replace('.', ',');
                    textBoxKoefficientTemperature.Text = textBoxKoefficientTemperature.Text.Replace('.', ',');

                    arrayOfParametrs = new double[3];

                    double param = double.Parse(textBoxStartTemperature.Text);
                    if(param <= 0 || param > 1)
                    {
                        throw new Exception("Диапазон начальной температуры от 0 до 1");
                    }

                    arrayOfParametrs[0] = param;

                    param = double.Parse(textBoxStopTemperature.Text);
                    if (param <= 0 || param >= arrayOfParametrs[0])
                    {
                        throw new Exception("Конечная температура - положительное число, меньшее, чем стартовая температура");
                    }

                    arrayOfParametrs[1] = param;

                    param = double.Parse(textBoxKoefficientTemperature.Text);
                    if (param <= 0 || param >= 1)
                    {
                        throw new Exception("Коэффициент уменьшения температуры от 0 до 1");
                    }

                    arrayOfParametrs[2] = param;
                }
                else if (comboBoxInit.SelectedItem.ToString().Equals("Рой частиц"))
                {
                    textBoxStartTemperature.Text = textBoxStartTemperature.Text.Replace('.', ',');
                    textBoxStopTemperature.Text = textBoxStopTemperature.Text.Replace('.', ',');
                    textBoxKoefficientTemperature.Text = textBoxKoefficientTemperature.Text.Replace('.', ',');
                    textBoxStartCount.Text = textBoxStartCount.Text.Replace('.', ',');

                    arrayOfParametrs = new double[4];

                    double param = double.Parse(textBoxStartTemperature.Text);
                    if (param <= 0)
                    {
                        throw new Exception("Первый весовой коэффициент должен быть больше 0");
                    }

                    arrayOfParametrs[0] = param;

                    param = double.Parse(textBoxKoefficientTemperature.Text);
                    if (param <= 0)
                    {
                        throw new Exception("Второй весовой коэффициент должен быть больше 0");
                    }

                    arrayOfParametrs[1] = param;

                    param = double.Parse(textBoxStopTemperature.Text);
                    if (param <= 0)
                    {
                        throw new Exception("Омега должна быть больше 0");
                    }

                    arrayOfParametrs[2] = param;

                    var intParam = int.Parse(textBoxStartCount.Text);
                    if (intParam <= 0)
                    {
                        throw new Exception("Количество эпох должно быть больше 0");
                    }

                    arrayOfParametrs[3] = intParam;
                }
                else if (comboBoxInit.SelectedItem.ToString().Equals("Дифференциальная эволюция"))
                {
                    textBoxStartTemperature.Text = textBoxStartTemperature.Text.Replace('.', ',');
                    textBoxStopTemperature.Text = textBoxStopTemperature.Text.Replace('.', ',');
                    textBoxKoefficientTemperature.Text = textBoxKoefficientTemperature.Text.Replace('.', ',');
                    textBoxStartCount.Text = textBoxStartCount.Text.Replace('.', ',');

                    arrayOfParametrs = new double[4];

                    int intParam = int.Parse(textBoxStartTemperature.Text);
                    if (intParam <= 1)
                    {
                        throw new Exception("Размер популяции должен быть больше 1");
                    }

                    arrayOfParametrs[0] = intParam;

                    double param = double.Parse(textBoxKoefficientTemperature.Text);
                    if (param <= 0 || param >= 1)
                    {
                        throw new Exception("Сила мутации должна быть от 0 до 1");
                    }

                    arrayOfParametrs[1] = param;

                    param = double.Parse(textBoxStopTemperature.Text);
                    if (param <= 0 || param >= 1)
                    {
                        throw new Exception("Вероятность мутации должна быть от 0 до 1");
                    }

                    arrayOfParametrs[2] = param;

                    param = double.Parse(textBoxStopTemperature.Text);
                    if (param <= 0 || param >= 1)
                    {
                        throw new Exception("Вероятность мутации должна быть от 0 до 1");
                    }

                    arrayOfParametrs[2] = param;

                    intParam = int.Parse(textBoxStartCount.Text);
                    if (intParam <= 1 || intParam >= arrayOfParametrs[0])
                    {
                        throw new Exception("Размер стартовой популяции должен быть больше 1 и меньше максимального количества популяций");
                    }

                    arrayOfParametrs[3] = intParam;
                }
                else if (comboBoxInit.SelectedItem.ToString().Equals("Генетический"))
                {
                    textBoxStartTemperature.Text = textBoxStartTemperature.Text.Replace('.', ',');
                    textBoxStopTemperature.Text = textBoxStopTemperature.Text.Replace('.', ',');
                    textBoxKoefficientTemperature.Text = textBoxKoefficientTemperature.Text.Replace('.', ',');
                    textBoxStartCount.Text = textBoxStartCount.Text.Replace('.', ',');

                    arrayOfParametrs = new double[4];

                    double param = double.Parse(textBoxStartTemperature.Text);
                    if (param < 0 || param > 1)
                    {
                        throw new Exception("Вероятность мутации должна быть от 0 до 1");
                    }

                    arrayOfParametrs[0] = param;

                    param = double.Parse(textBoxStopTemperature.Text);
                    if (param < 0 || param > 1)
                    {
                        throw new Exception("Вероятность инверсии должна быть от 0 до 1");
                    }

                    arrayOfParametrs[1] = param;

                    int intParam = int.Parse(textBoxKoefficientTemperature.Text);
                    if (intParam <= 0)
                    {
                        throw new Exception("Количество эпох должно быть больше 0");
                    }

                    arrayOfParametrs[2] = intParam;

                    intParam = int.Parse(textBoxStartCount.Text);
                    if (intParam <= 1)
                    {
                        throw new Exception("размер начальной популяции должен быть больше 1");
                    }

                    arrayOfParametrs[3] = intParam;
                }

                double coefficient = double.Parse(textBoxCoefficient.Text);
                if(coefficient < 0 || coefficient >= 1)
                {
                    throw new Exception("Коэффициент обучения от 0 до 1");
                }

                double momentum = double.Parse(textBoxMoment.Text);
                if(momentum < 0 || momentum >= 1)
                {
                    throw new Exception("Момент от 0 до 1");
                }

                double error = double.Parse(textBoxError.Text);
                if(error < 0)
                {
                    throw new Exception("Ошибка обучения не модет быть отрицательной");
                }

                int countNeurons = int.Parse(textBoxCountNeurons.Text);
                if(countNeurons < 3)
                {
                    throw new Exception("Слишком маленькое число нейронов");
                }

                this.Hide();
                formMain.InitializeNetwork(Int32.Parse(textBoxCountItterations.Text),
                    coefficient,
                    momentum,
                    error,
                    countNeurons, 
                    comboBoxInit.SelectedItem.ToString(), 
                    arrayOfParametrs);

                DialogResult = DialogResult.OK;
                ButtonCancel_Click(sender, e);
            }
            catch(Exception ex)
            {
                this.Show();
                formMain.Hide();
                MessageBox.Show("Проверьте правильность параметров\n" + ex.Message);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormNetwork_Load(object sender, EventArgs e)
        {
            comboBoxInit.SelectedIndex = 0;
        }

        private void ComboBoxInit_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxInit.SelectedItem.ToString())
            {
                case "Имитация отжига":
                    {
                        SwitchAnnealing(true);
                        break;
                    }
                case "Генетический":
                    {
                        SwitchGenetic();
                        break;
                    }
                case "Дифференциальная эволюция":
                    {
                        SwitchDifferential();
                        break;
                    }
                case "Рой частиц":
                    {
                        SwitchSwarm();
                        break;
                    }
                default:
                    {
                        SwitchAnnealing(false);
                        break;
                    }
            }
        }

        private void SwitchSwarm()
        {
            labelStartTemperature.Enabled = true;
            labelStartTemperature.Visible = true;

            labelStartTemperature.Text = "Первый весовой коэффициент";

            textBoxStartTemperature.Visible = true;
            textBoxStartTemperature.Enabled = true;

            textBoxStartTemperature.Text = "0.2";

            labelKoefficientOfTemperature.Enabled = true;
            labelKoefficientOfTemperature.Visible = true;

            labelKoefficientOfTemperature.Text = "Второй весовой коэффициент";

            textBoxKoefficientTemperature.Enabled = true;
            textBoxKoefficientTemperature.Visible = true;

            textBoxKoefficientTemperature.Text = "0.2";

            labelStopTemperature.Enabled = true;
            labelStopTemperature.Visible = true;

            labelStopTemperature.Text = "Омега";

            textBoxStopTemperature.Enabled = true;
            textBoxStopTemperature.Visible = true;

            textBoxStopTemperature.Text = "0.2";

            labelStartCount.Enabled = true;
            labelStartCount.Visible = true;

            labelStartCount.Text = "Количество эпох";

            textBoxStartCount.Enabled = true;
            textBoxStartCount.Visible = true;

            textBoxStartCount.Text = "10000";

            this.Height = 482;
            buttonAccept.Location = new System.Drawing.Point(buttonAccept.Location.X, 412);
            buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, 412);
        }

        private void SwitchDifferential()
        {
            labelStartTemperature.Enabled = true;
            labelStartTemperature.Visible = true;

            labelStartTemperature.Text = "Размер популяции";

            textBoxStartTemperature.Visible = true;
            textBoxStartTemperature.Enabled = true;

            textBoxStartTemperature.Text = "20";

            labelKoefficientOfTemperature.Enabled = true;
            labelKoefficientOfTemperature.Visible = true;

            labelKoefficientOfTemperature.Text = "Сила мутации";

            textBoxKoefficientTemperature.Enabled = true;
            textBoxKoefficientTemperature.Visible = true;

            textBoxKoefficientTemperature.Text = "0.5";

            labelStopTemperature.Enabled = true;
            labelStopTemperature.Visible = true;

            labelStopTemperature.Text = "Вероятность мутации";

            textBoxStopTemperature.Enabled = true;
            textBoxStopTemperature.Visible = true;

            textBoxStopTemperature.Text = "0.5";

            labelStartCount.Enabled = true;
            labelStartCount.Visible = true;

            labelStopTemperature.Text = "Начальный размер популяции";

            textBoxStartCount.Enabled = true;
            textBoxStartCount.Visible = true;

            textBoxStartCount.Text = "10";

            this.Height = 482;
            buttonAccept.Location = new System.Drawing.Point(buttonAccept.Location.X, 412);
            buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, 412);
        }

        private void SwitchGenetic()
        {
            labelStartTemperature.Enabled = true;
            labelStartTemperature.Visible = true;

            labelStartTemperature.Text = "Вероятность мутации";

            textBoxStartTemperature.Visible = true;
            textBoxStartTemperature.Enabled = true;

            textBoxStartTemperature.Text = "0.3";

            labelStopTemperature.Enabled = true;
            labelStopTemperature.Visible = true;

            labelStopTemperature.Text = "Вероятность инверсии";

            textBoxStopTemperature.Enabled = true;
            textBoxStopTemperature.Visible = true;

            textBoxStopTemperature.Text = "0.3";

            labelKoefficientOfTemperature.Enabled = true;
            labelKoefficientOfTemperature.Visible = true;

            labelKoefficientOfTemperature.Text = "Количество эпох";

            textBoxKoefficientTemperature.Enabled = true;
            textBoxKoefficientTemperature.Visible = true;

            textBoxKoefficientTemperature.Text = "10";

            labelStartCount.Enabled = true;
            labelStartCount.Visible = true;

            labelStartCount.Text = "Начальный размер популяции";

            textBoxStartCount.Enabled = true;
            textBoxStartCount.Visible = true;

            this.Height = 482;
            buttonAccept.Location = new System.Drawing.Point(buttonAccept.Location.X, 412);
            buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, 412);
        }

        private void SwitchAnnealing(bool switcher)
        {
            labelStartTemperature.Enabled = switcher;
            labelStartTemperature.Visible = switcher;

            textBoxStartTemperature.Visible = switcher;
            textBoxStartTemperature.Enabled = switcher;

            labelStopTemperature.Enabled = switcher;
            labelStopTemperature.Visible = switcher;

            textBoxStopTemperature.Enabled = switcher;
            textBoxStopTemperature.Visible = switcher;

            labelKoefficientOfTemperature.Enabled = switcher;
            labelKoefficientOfTemperature.Visible = switcher;

            textBoxKoefficientTemperature.Enabled = switcher;
            textBoxKoefficientTemperature.Visible = switcher;

            labelStartCount.Enabled = false;
            labelStartCount.Visible = false;

            textBoxStartCount.Enabled = false;
            textBoxStartCount.Visible = false;

            if (!switcher)
            {
                this.Height = 325;
                buttonAccept.Location = new System.Drawing.Point(buttonAccept.Location.X, 255);
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, 255);
            }
            else
            {
                this.Height = 452;
                buttonAccept.Location = new System.Drawing.Point(buttonAccept.Location.X, 377);
                buttonCancel.Location = new System.Drawing.Point(buttonCancel.Location.X, 377);

                labelStartTemperature.Text = "Стартовая температура";
                textBoxStartTemperature.Text = "1";

                labelStopTemperature.Text = "Условие остановки";
                textBoxStopTemperature.Text = "0.1";

                labelKoefficientOfTemperature.Text = "Коэффициент уменьшения температуры";
                textBoxKoefficientTemperature.Text = "0.9";
            }
        }
    }
}
