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
            try
            {
                textBoxError.Text = textBoxError.Text.Replace('.', ',');
                textBoxCoefficient.Text = textBoxCoefficient.Text.Replace('.', ',');
                textBoxMoment.Text = textBoxMoment.Text.Replace('.', ',');
                this.Hide();
                formMain.InitializeNetwork(Int32.Parse(textBoxCountItterations.Text),
                    Double.Parse(textBoxCoefficient.Text),
                    Double.Parse(textBoxMoment.Text),
                    Double.Parse(textBoxError.Text),
                    int.Parse(textBoxCountNeurons.Text));

                DialogResult = DialogResult.OK;
                ButtonCancel_Click(sender, e);
            }
            catch
            {
                this.Show();
                formMain.Hide();
                MessageBox.Show("Проверьте правильность параметров");
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
