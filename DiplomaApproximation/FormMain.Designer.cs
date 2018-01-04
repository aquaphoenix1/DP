namespace DiplomaApproximation
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartHystogram = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkParametrsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.learnNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopLearningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testNetworkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBoxErrorWorking = new System.Windows.Forms.TextBox();
            this.textBoxCurrentIteration = new System.Windows.Forms.TextBox();
            this.textBoxCurrentError = new System.Windows.Forms.TextBox();
            this.labelCurrentIteration = new System.Windows.Forms.Label();
            this.labelError = new System.Windows.Forms.Label();
            this.labelErrorWorking = new System.Windows.Forms.Label();
            this.textBoxPirson = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chartHystogram)).BeginInit();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartHystogram
            // 
            chartArea1.Name = "ChartArea1";
            this.chartHystogram.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartHystogram.Legends.Add(legend1);
            this.chartHystogram.Location = new System.Drawing.Point(12, 43);
            this.chartHystogram.Name = "chartHystogram";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Выборка";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Сеть";
            this.chartHystogram.Series.Add(series1);
            this.chartHystogram.Series.Add(series2);
            this.chartHystogram.Size = new System.Drawing.Size(481, 425);
            this.chartHystogram.TabIndex = 0;
            this.chartHystogram.Text = "chart1";
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.networkParametrsToolStripMenuItem,
            this.fileToolStripMenuItem,
            this.generatorToolStripMenuItem,
            this.learnNetworkToolStripMenuItem,
            this.stopLearningToolStripMenuItem,
            this.testNetworkToolStripMenuItem,
            this.workingToolStripMenuItem});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(629, 24);
            this.menuStripMain.TabIndex = 5;
            this.menuStripMain.Text = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Enabled = false;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.fileToolStripMenuItem.Text = "Файл";
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.downloadToolStripMenuItem.Text = "Загрузить выборку";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.DownloadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.saveToolStripMenuItem.Text = "Сохранить выборку";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // generatorToolStripMenuItem
            // 
            this.generatorToolStripMenuItem.Enabled = false;
            this.generatorToolStripMenuItem.Name = "generatorToolStripMenuItem";
            this.generatorToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.generatorToolStripMenuItem.Text = "Генератор";
            this.generatorToolStripMenuItem.Click += new System.EventHandler(this.GeneratorToolStripMenuItem_Click);
            // 
            // networkParametrsToolStripMenuItem
            // 
            this.networkParametrsToolStripMenuItem.Name = "networkParametrsToolStripMenuItem";
            this.networkParametrsToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.networkParametrsToolStripMenuItem.Text = "Параметры сети";
            this.networkParametrsToolStripMenuItem.Click += new System.EventHandler(this.NetworkParametrsToolStripMenuItem_Click);
            // 
            // learnNetworkToolStripMenuItem
            // 
            this.learnNetworkToolStripMenuItem.Enabled = false;
            this.learnNetworkToolStripMenuItem.Name = "learnNetworkToolStripMenuItem";
            this.learnNetworkToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.learnNetworkToolStripMenuItem.Text = "Обучить сеть";
            this.learnNetworkToolStripMenuItem.Click += new System.EventHandler(this.LearnNetworkToolStripMenuItem_Click);
            // 
            // stopLearningToolStripMenuItem
            // 
            this.stopLearningToolStripMenuItem.Enabled = false;
            this.stopLearningToolStripMenuItem.Name = "stopLearningToolStripMenuItem";
            this.stopLearningToolStripMenuItem.Size = new System.Drawing.Size(139, 20);
            this.stopLearningToolStripMenuItem.Text = "Остановить обучение";
            this.stopLearningToolStripMenuItem.Click += new System.EventHandler(this.StopLearningToolStripMenuItem_Click);
            // 
            // testNetworkToolStripMenuItem
            // 
            this.testNetworkToolStripMenuItem.Enabled = false;
            this.testNetworkToolStripMenuItem.Name = "testNetworkToolStripMenuItem";
            this.testNetworkToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.testNetworkToolStripMenuItem.Text = "Тест сети";
            this.testNetworkToolStripMenuItem.Click += new System.EventHandler(this.TestNetworkToolStripMenuItem_Click);
            // 
            // workingToolStripMenuItem
            // 
            this.workingToolStripMenuItem.Enabled = false;
            this.workingToolStripMenuItem.Name = "workingToolStripMenuItem";
            this.workingToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.workingToolStripMenuItem.Text = "Работа сети";
            this.workingToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItemWorking_Click);
            // 
            // textBoxErrorWorking
            // 
            this.textBoxErrorWorking.Location = new System.Drawing.Point(499, 59);
            this.textBoxErrorWorking.Name = "textBoxErrorWorking";
            this.textBoxErrorWorking.ReadOnly = true;
            this.textBoxErrorWorking.Size = new System.Drawing.Size(100, 20);
            this.textBoxErrorWorking.TabIndex = 6;
            // 
            // textBoxCurrentIteration
            // 
            this.textBoxCurrentIteration.Location = new System.Drawing.Point(375, 121);
            this.textBoxCurrentIteration.Name = "textBoxCurrentIteration";
            this.textBoxCurrentIteration.ReadOnly = true;
            this.textBoxCurrentIteration.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentIteration.TabIndex = 7;
            // 
            // textBoxCurrentError
            // 
            this.textBoxCurrentError.Location = new System.Drawing.Point(376, 161);
            this.textBoxCurrentError.Name = "textBoxCurrentError";
            this.textBoxCurrentError.ReadOnly = true;
            this.textBoxCurrentError.Size = new System.Drawing.Size(100, 20);
            this.textBoxCurrentError.TabIndex = 8;
            // 
            // labelCurrentIteration
            // 
            this.labelCurrentIteration.AutoSize = true;
            this.labelCurrentIteration.Location = new System.Drawing.Point(373, 105);
            this.labelCurrentIteration.Name = "labelCurrentIteration";
            this.labelCurrentIteration.Size = new System.Drawing.Size(102, 13);
            this.labelCurrentIteration.TabIndex = 9;
            this.labelCurrentIteration.Text = "Текущая итерация";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(373, 145);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(96, 13);
            this.labelError.TabIndex = 10;
            this.labelError.Text = "Ошибка обучения";
            // 
            // labelErrorWorking
            // 
            this.labelErrorWorking.AutoSize = true;
            this.labelErrorWorking.Location = new System.Drawing.Point(497, 43);
            this.labelErrorWorking.Name = "labelErrorWorking";
            this.labelErrorWorking.Size = new System.Drawing.Size(68, 13);
            this.labelErrorWorking.TabIndex = 11;
            this.labelErrorWorking.Text = "Отклонение";
            // 
            // textBoxPirson
            // 
            this.textBoxPirson.Location = new System.Drawing.Point(499, 121);
            this.textBoxPirson.Name = "textBoxPirson";
            this.textBoxPirson.ReadOnly = true;
            this.textBoxPirson.Size = new System.Drawing.Size(100, 20);
            this.textBoxPirson.TabIndex = 12;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 477);
            this.Controls.Add(this.textBoxPirson);
            this.Controls.Add(this.labelErrorWorking);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.labelCurrentIteration);
            this.Controls.Add(this.textBoxCurrentError);
            this.Controls.Add(this.textBoxCurrentIteration);
            this.Controls.Add(this.textBoxErrorWorking);
            this.Controls.Add(this.menuStripMain);
            this.Controls.Add(this.chartHystogram);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аппроксимация";
            ((System.ComponentModel.ISupportInitialize)(this.chartHystogram)).EndInit();
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartHystogram;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkParametrsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem learnNetworkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopLearningToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testNetworkToolStripMenuItem;
        private System.Windows.Forms.TextBox textBoxErrorWorking;
        private System.Windows.Forms.TextBox textBoxCurrentIteration;
        private System.Windows.Forms.TextBox textBoxCurrentError;
        private System.Windows.Forms.ToolStripMenuItem workingToolStripMenuItem;
        private System.Windows.Forms.Label labelCurrentIteration;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.Label labelErrorWorking;
        private System.Windows.Forms.TextBox textBoxPirson;
    }
}

