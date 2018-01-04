using DiplomaApproximation.Distributions;
using System;
using System.Windows.Forms;

namespace DiplomaApproximation
{
    public partial class FormParametrs : Form
    {
        private FormMain formMain;

        public FormParametrs(FormMain formMain)
        {
            InitializeComponent();

            this.formMain = formMain;
        }

        private void ComboBoxDistribution_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonOK.Enabled = true;
            buttonOK.Visible = true;
            switch (comboBoxDistribution.SelectedItem.ToString())
            {
                case "Арксинус":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент a";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = false;
                        label2.Enabled = false;
                        textBox2.Enabled = false;
                        textBox2.Visible = false;
                        break;
                    }
                case "Экспоненциальное":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент лямбда";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = false;
                        label2.Enabled = false;
                        textBox2.Enabled = false;
                        textBox2.Visible = false;
                        break;
                    }
                case "Лаплас":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент лямбда";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Коэффициент мю";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
                case "Нормальное":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Математическое ожидание";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Диперсия";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
                case "Релей":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент Сигма";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = false;
                        label2.Enabled = false;
                        textBox2.Enabled = false;
                        textBox2.Visible = false;
                        break;
                    }
                case "Симпсон":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент a";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Коэффициент b";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
                case "Коши":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент mu";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Коэффициент a";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
                case "Равномерный":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент a";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Коэффициент b";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
                case "Вейбулл":
                    {
                        label1.Visible = true;
                        label1.Enabled = true;
                        label1.Text = "Коэффициент a";
                        textBox1.Enabled = true;
                        textBox1.Visible = true;
                        label2.Visible = true;
                        label2.Enabled = true;
                        label2.Text = "Коэффициент b";
                        textBox2.Enabled = true;
                        textBox2.Visible = true;
                        break;
                    }
            }
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Replace('.', ',');
                textBox2.Text = textBox2.Text.Replace('.', ',');

                if (int.Parse(textBoxCount.Text) < 2000)
                {
                    textBoxCount.Text = "2000";
                }

                double[] array = new double[formMain.GetCountNeurons()];
                switch (comboBoxDistribution.SelectedItem.ToString())
                {
                    case "Арксинус":
                        {
                            array = new Arcsinus(Double.Parse(textBox1.Text), Int32.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Arcsinus", true);
                            CloseForm();
                            break;
                        }
                    case "Экспоненциальное":
                        {
                            array = new ExponentialOneway(Double.Parse(textBox1.Text), Int32.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Exponential", true);
                            CloseForm();
                            break;
                        }
                    case "Лаплас":
                        {
                            array = new Laplas(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), Int32.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Laplas", true);
                            CloseForm();
                            break;
                        }
                    case "Нормальное":
                        {
                            array = new Normal(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), Int32.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Normal", true);
                            CloseForm();
                            break;
                        }
                    case "Релей":
                        {
                            array = new Relei(Double.Parse(textBox1.Text), Int32.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Relei", true);
                            CloseForm();
                            break;
                        }
                    case "Симпсон":
                        {
                            array = new Simpson(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), Int32.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Simpson", true);
                            CloseForm();
                            break;
                        }
                    case "Коши":
                        {
                            array = new Koshi(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), int.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Koshi", true);
                            CloseForm();
                            break;
                        }
                    case "Равномерный":
                        {
                            array = new Uniform(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), int.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Uniform", true);
                            CloseForm();
                            break;
                        }
                    case "Вейбулл":
                        {
                            array = new Veibull(Double.Parse(textBox1.Text), Double.Parse(textBox2.Text), int.Parse(textBoxCount.Text)).Generate();

                            formMain.Generate(array, "Veibul", true);
                            CloseForm();
                            break;
                        }
                }
            }
            catch
            {
                MessageBox.Show("Проверьте правильность введенных данных");
            }
        }

        private void CloseForm()
        {
            Close();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CloseForm();
        }
    }
}
