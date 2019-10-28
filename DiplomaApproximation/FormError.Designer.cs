namespace DiplomaApproximation
{
    partial class FormError
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartError = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).BeginInit();
            this.SuspendLayout();
            // 
            // chartError
            // 
            chartArea1.Name = "ChartArea1";
            this.chartError.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartError.Legends.Add(legend1);
            this.chartError.Location = new System.Drawing.Point(12, 12);
            this.chartError.Name = "chartError";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Ошибка";
            this.chartError.Series.Add(series1);
            this.chartError.Size = new System.Drawing.Size(448, 341);
            this.chartError.TabIndex = 1;
            this.chartError.Text = "Ошибка";
            // 
            // FormError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 362);
            this.Controls.Add(this.chartError);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ошибка обучения";
            ((System.ComponentModel.ISupportInitialize)(this.chartError)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartError;
    }
}