using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    Double.Parse(textBoxError.Text));

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
