using System.Windows.Forms;

namespace DiplomaApproximation
{
    public partial class CheckForm : Form
    {
        public CheckForm(double value, int count, double lyambda)
        {
            InitializeComponent();

            textBoxValue.Text = value.ToString();
            textBoxKolmogorov.Text = lyambda.ToString();

            double[,] matrix = {
                {10, 2.15586, 2.55821, 3.24697, 3.94030, 4.86518, 6.73720, 9.34182, 12.54886, 15.98718, 18.30704, 20.48318, 23.20925, 25.18818 },
                {11, 2.60322, 3.05348, 3.81575, 4.57481, 5.57778, 7.58414, 10.34100, 13.70069, 17.27501, 19.67514, 21.92005, 24.72497, 26.75685},
                {12, 3.07382, 3.57057, 4.40379, 5.22603, 6.30380, 8.43842, 11.34032, 14.84540, 18.54935, 21.02607, 23.33666, 26.21697, 28.29952 },
                {13, 3.56503, 4.10692, 5.00875, 5.89186, 7.04150, 9.29907, 12.33976, 15.98391, 19.81193, 22.36203, 24.73560, 27.68825, 29.81947 },
                {14, 4.07467, 4.66043, 5.62873, 6.57063, 7.78953, 10.16531, 13.33927, 17.11693, 21.06414, 23.68479, 26.11895, 29.14124, 31.31935 },
                {15, 4.60092, 5.22935, 6.26214, 7.26094, 8.54676, 11.03654, 14.33886, 18.24509, 22.30713, 24.99579, 27.48839, 30.57791, 32.80132 },
                {16, 5.14221, 5.81221, 6.90766, 7.96165, 9.31224, 11.91222, 15.33850, 19.36886, 23.54183, 26.29623, 28.84535, 31.99993, 34.26719 },
                {17, 5.69722, 6.40776, 7.56419, 8.67176, 10.08519, 12.79193, 16.33818, 20.48868, 24.76904, 27.58711, 30.19101, 33.40866, 35.71847 },
                {18, 6.26480, 7.01491, 8.23075, 9.39046, 10.86494, 13.67529, 17.33790, 21.60489, 25.98942, 28.86930, 31.52638, 34.80531, 37.15645 },
                {19, 6.84397, 7.63273, 8.90652, 10.11701, 11.65091, 14.56200, 18.33765, 22.71781, 27.20357, 30.14353, 32.85233, 36.19087, 38.58226 },
                {20, 7.43384, 8.26040, 9.59078, 10.85081, 12.44261, 15.45177, 19.33743, 23.82769, 28.41198, 31.41043, 34.16961, 37.56623, 39.99685 }
            };

            dataGridViewChiSquare.Rows.Add(11);

            for (int i = 0; i < 11; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    dataGridViewChiSquare.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }

            int k;

            for (k = 1; k < 14; k++)
            {
                if (value < matrix[count - 10, k])
                {
                    dataGridViewChiSquare.Rows[count - 10].Cells[k].Style.BackColor = System.Drawing.Color.Red;
                    break;
                }
            }

            labelIsChiSquare.Text = (k < 14) ? "Критерий Пирсона принят с вероятностью " + dataGridViewChiSquare.Columns[k].HeaderText : "Критерий Пирсона отвергнут";

            dataGridViewKolmogorov.Rows.Add(1);
            double[] array = { 0.29, 0.32, 0.33, 0.4, 0.45, 0.49, 0.51, 0.55, 0.76, 0.83, 0.89, 0.97, 1.04, 1.23 };

            for (int i = 0; i < array.Length; i++)
            {
                dataGridViewKolmogorov.Rows[0].Cells[i].Value = array[i];
            }

            for (k = 0; k < array.Length; k++)
            {
                if (lyambda < array[k])
                {
                    dataGridViewKolmogorov.Rows[0].Cells[k].Style.BackColor = System.Drawing.Color.Red;
                    break;
                }
            }

            labelIsKolmogorov.Text = (k < array.Length) ? "Критерий Колмогорова принят с вероятностью " + dataGridViewKolmogorov.Columns[k].HeaderText : "Критерий Колмогорова отвергнут";
        }

        private void CheckForm_Load(object sender, System.EventArgs e)
        {
            dataGridViewChiSquare.Rows[0].Cells[0].Selected = false;
            dataGridViewKolmogorov.Rows[0].Cells[0].Selected = false;
        }
    }
}
