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
                case "Случайные веса":
                    {
                        SwitchAnnealing(false);
                        break;
                    }
                case "Имитация отжига":
                    {
                        SwitchAnnealing(true);
                        break;
                    }
            }
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
            }
        }
    }
}
