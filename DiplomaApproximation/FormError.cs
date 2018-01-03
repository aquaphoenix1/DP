using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DiplomaApproximation
{
    public partial class FormError : Form
    {
        public FormError(double[] errors, int[] massX)
        {
            InitializeComponent();

            chartError.Series["Ошибка"].ChartType = SeriesChartType.Line;

            chartError.Series["Ошибка"].Points.DataBindXY(massX, errors);
        }
    }
}
