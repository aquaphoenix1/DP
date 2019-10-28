namespace DiplomaApproximation
{
    partial class FormNetwork
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
            this.textBoxError = new System.Windows.Forms.TextBox();
            this.labelError = new System.Windows.Forms.Label();
            this.textBoxMoment = new System.Windows.Forms.TextBox();
            this.labelMoment = new System.Windows.Forms.Label();
            this.labelCoefficient = new System.Windows.Forms.Label();
            this.textBoxCoefficient = new System.Windows.Forms.TextBox();
            this.textBoxCountItterations = new System.Windows.Forms.TextBox();
            this.labelCountItterations = new System.Windows.Forms.Label();
            this.textBoxCountNeurons = new System.Windows.Forms.TextBox();
            this.labelCountNeurons = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.comboBoxInit = new System.Windows.Forms.ComboBox();
            this.labelInit = new System.Windows.Forms.Label();
            this.textBoxStartTemperature = new System.Windows.Forms.TextBox();
            this.labelStartTemperature = new System.Windows.Forms.Label();
            this.textBoxKoefficientTemperature = new System.Windows.Forms.TextBox();
            this.labelKoefficientOfTemperature = new System.Windows.Forms.Label();
            this.textBoxStopTemperature = new System.Windows.Forms.TextBox();
            this.labelStopTemperature = new System.Windows.Forms.Label();
            this.textBoxStartCount = new System.Windows.Forms.TextBox();
            this.labelStartCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(12, 150);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(199, 20);
            this.textBoxError.TabIndex = 3;
            this.textBoxError.Text = "0.001";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(12, 134);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(124, 13);
            this.labelError.TabIndex = 14;
            this.labelError.Text = "Погрешность обучения";
            // 
            // textBoxMoment
            // 
            this.textBoxMoment.Location = new System.Drawing.Point(12, 189);
            this.textBoxMoment.Name = "textBoxMoment";
            this.textBoxMoment.Size = new System.Drawing.Size(199, 20);
            this.textBoxMoment.TabIndex = 4;
            this.textBoxMoment.Text = "0.01";
            // 
            // labelMoment
            // 
            this.labelMoment.AutoSize = true;
            this.labelMoment.Location = new System.Drawing.Point(9, 173);
            this.labelMoment.Name = "labelMoment";
            this.labelMoment.Size = new System.Drawing.Size(47, 13);
            this.labelMoment.TabIndex = 15;
            this.labelMoment.Text = "Момент";
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.AutoSize = true;
            this.labelCoefficient.Location = new System.Drawing.Point(9, 87);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(126, 13);
            this.labelCoefficient.TabIndex = 13;
            this.labelCoefficient.Text = "Коэффициент обучения";
            // 
            // textBoxCoefficient
            // 
            this.textBoxCoefficient.Location = new System.Drawing.Point(12, 107);
            this.textBoxCoefficient.Name = "textBoxCoefficient";
            this.textBoxCoefficient.Size = new System.Drawing.Size(199, 20);
            this.textBoxCoefficient.TabIndex = 2;
            this.textBoxCoefficient.Text = "0.001";
            // 
            // textBoxCountItterations
            // 
            this.textBoxCountItterations.Location = new System.Drawing.Point(12, 64);
            this.textBoxCountItterations.Name = "textBoxCountItterations";
            this.textBoxCountItterations.Size = new System.Drawing.Size(199, 20);
            this.textBoxCountItterations.TabIndex = 1;
            this.textBoxCountItterations.Text = "5000";
            // 
            // labelCountItterations
            // 
            this.labelCountItterations.AutoSize = true;
            this.labelCountItterations.Location = new System.Drawing.Point(9, 48);
            this.labelCountItterations.Name = "labelCountItterations";
            this.labelCountItterations.Size = new System.Drawing.Size(154, 13);
            this.labelCountItterations.TabIndex = 12;
            this.labelCountItterations.Text = "Количество циклов обучения";
            // 
            // textBoxCountNeurons
            // 
            this.textBoxCountNeurons.Location = new System.Drawing.Point(12, 25);
            this.textBoxCountNeurons.Name = "textBoxCountNeurons";
            this.textBoxCountNeurons.Size = new System.Drawing.Size(199, 20);
            this.textBoxCountNeurons.TabIndex = 0;
            this.textBoxCountNeurons.Text = "20";
            // 
            // labelCountNeurons
            // 
            this.labelCountNeurons.AutoSize = true;
            this.labelCountNeurons.Location = new System.Drawing.Point(9, 9);
            this.labelCountNeurons.Name = "labelCountNeurons";
            this.labelCountNeurons.Size = new System.Drawing.Size(195, 13);
            this.labelCountNeurons.TabIndex = 11;
            this.labelCountNeurons.Text = "Количество нейронов скрытого слоя";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(122, 255);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(89, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(12, 255);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(97, 23);
            this.buttonAccept.TabIndex = 9;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // comboBoxInit
            // 
            this.comboBoxInit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxInit.FormattingEnabled = true;
            this.comboBoxInit.Items.AddRange(new object[] {
            "Случайные веса",
            "Имитация отжига",
            "Дифференциальная эволюция",
            "Рой частиц",
            "Генетический"});
            this.comboBoxInit.Location = new System.Drawing.Point(12, 228);
            this.comboBoxInit.Name = "comboBoxInit";
            this.comboBoxInit.Size = new System.Drawing.Size(199, 21);
            this.comboBoxInit.TabIndex = 5;
            this.comboBoxInit.SelectedIndexChanged += new System.EventHandler(this.ComboBoxInit_SelectedIndexChanged);
            // 
            // labelInit
            // 
            this.labelInit.AutoSize = true;
            this.labelInit.Location = new System.Drawing.Point(9, 212);
            this.labelInit.Name = "labelInit";
            this.labelInit.Size = new System.Drawing.Size(125, 13);
            this.labelInit.TabIndex = 16;
            this.labelInit.Text = "Способ инициализации";
            // 
            // textBoxStartTemperature
            // 
            this.textBoxStartTemperature.Enabled = false;
            this.textBoxStartTemperature.Location = new System.Drawing.Point(13, 268);
            this.textBoxStartTemperature.Name = "textBoxStartTemperature";
            this.textBoxStartTemperature.Size = new System.Drawing.Size(199, 20);
            this.textBoxStartTemperature.TabIndex = 6;
            this.textBoxStartTemperature.Text = "1";
            this.textBoxStartTemperature.Visible = false;
            // 
            // labelStartTemperature
            // 
            this.labelStartTemperature.AutoSize = true;
            this.labelStartTemperature.Enabled = false;
            this.labelStartTemperature.Location = new System.Drawing.Point(9, 252);
            this.labelStartTemperature.Name = "labelStartTemperature";
            this.labelStartTemperature.Size = new System.Drawing.Size(128, 13);
            this.labelStartTemperature.TabIndex = 17;
            this.labelStartTemperature.Text = "Стартовая температура";
            this.labelStartTemperature.Visible = false;
            // 
            // textBoxKoefficientTemperature
            // 
            this.textBoxKoefficientTemperature.Enabled = false;
            this.textBoxKoefficientTemperature.Location = new System.Drawing.Point(12, 307);
            this.textBoxKoefficientTemperature.Name = "textBoxKoefficientTemperature";
            this.textBoxKoefficientTemperature.Size = new System.Drawing.Size(199, 20);
            this.textBoxKoefficientTemperature.TabIndex = 7;
            this.textBoxKoefficientTemperature.Text = "0.9";
            this.textBoxKoefficientTemperature.Visible = false;
            // 
            // labelKoefficientOfTemperature
            // 
            this.labelKoefficientOfTemperature.AutoSize = true;
            this.labelKoefficientOfTemperature.Enabled = false;
            this.labelKoefficientOfTemperature.Location = new System.Drawing.Point(9, 291);
            this.labelKoefficientOfTemperature.Name = "labelKoefficientOfTemperature";
            this.labelKoefficientOfTemperature.Size = new System.Drawing.Size(213, 13);
            this.labelKoefficientOfTemperature.TabIndex = 18;
            this.labelKoefficientOfTemperature.Text = "Коэффициент уменьшения температуры";
            this.labelKoefficientOfTemperature.Visible = false;
            // 
            // textBoxStopTemperature
            // 
            this.textBoxStopTemperature.Enabled = false;
            this.textBoxStopTemperature.Location = new System.Drawing.Point(12, 346);
            this.textBoxStopTemperature.Name = "textBoxStopTemperature";
            this.textBoxStopTemperature.Size = new System.Drawing.Size(199, 20);
            this.textBoxStopTemperature.TabIndex = 8;
            this.textBoxStopTemperature.Text = "0.1";
            this.textBoxStopTemperature.Visible = false;
            // 
            // labelStopTemperature
            // 
            this.labelStopTemperature.AutoSize = true;
            this.labelStopTemperature.Enabled = false;
            this.labelStopTemperature.Location = new System.Drawing.Point(12, 330);
            this.labelStopTemperature.Name = "labelStopTemperature";
            this.labelStopTemperature.Size = new System.Drawing.Size(107, 13);
            this.labelStopTemperature.TabIndex = 19;
            this.labelStopTemperature.Text = "Условие остановки";
            this.labelStopTemperature.Visible = false;
            // 
            // textBoxStartCount
            // 
            this.textBoxStartCount.Enabled = false;
            this.textBoxStartCount.Location = new System.Drawing.Point(12, 386);
            this.textBoxStartCount.Name = "textBoxStartCount";
            this.textBoxStartCount.Size = new System.Drawing.Size(199, 20);
            this.textBoxStartCount.TabIndex = 20;
            this.textBoxStartCount.Text = "5";
            this.textBoxStartCount.Visible = false;
            // 
            // labelStartCount
            // 
            this.labelStartCount.AutoSize = true;
            this.labelStartCount.Enabled = false;
            this.labelStartCount.Location = new System.Drawing.Point(12, 370);
            this.labelStartCount.Name = "labelStartCount";
            this.labelStartCount.Size = new System.Drawing.Size(161, 13);
            this.labelStartCount.TabIndex = 21;
            this.labelStartCount.Text = "Начальный размер популяции";
            this.labelStartCount.Visible = false;
            // 
            // FormNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 431);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxStartCount);
            this.Controls.Add(this.labelStartCount);
            this.Controls.Add(this.textBoxStopTemperature);
            this.Controls.Add(this.labelStopTemperature);
            this.Controls.Add(this.textBoxKoefficientTemperature);
            this.Controls.Add(this.labelKoefficientOfTemperature);
            this.Controls.Add(this.textBoxStartTemperature);
            this.Controls.Add(this.labelStartTemperature);
            this.Controls.Add(this.labelInit);
            this.Controls.Add(this.comboBoxInit);
            this.Controls.Add(this.textBoxError);
            this.Controls.Add(this.labelError);
            this.Controls.Add(this.textBoxMoment);
            this.Controls.Add(this.labelMoment);
            this.Controls.Add(this.labelCoefficient);
            this.Controls.Add(this.textBoxCoefficient);
            this.Controls.Add(this.textBoxCountItterations);
            this.Controls.Add(this.labelCountItterations);
            this.Controls.Add(this.textBoxCountNeurons);
            this.Controls.Add(this.labelCountNeurons);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonAccept);
            this.Name = "FormNetwork";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Параметры сети";
            this.Load += new System.EventHandler(this.FormNetwork_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxError;
        private System.Windows.Forms.Label labelError;
        private System.Windows.Forms.TextBox textBoxMoment;
        private System.Windows.Forms.Label labelMoment;
        private System.Windows.Forms.Label labelCoefficient;
        private System.Windows.Forms.TextBox textBoxCoefficient;
        private System.Windows.Forms.TextBox textBoxCountItterations;
        private System.Windows.Forms.Label labelCountItterations;
        private System.Windows.Forms.TextBox textBoxCountNeurons;
        private System.Windows.Forms.Label labelCountNeurons;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.ComboBox comboBoxInit;
        private System.Windows.Forms.Label labelInit;
        private System.Windows.Forms.TextBox textBoxStartTemperature;
        private System.Windows.Forms.Label labelStartTemperature;
        private System.Windows.Forms.TextBox textBoxKoefficientTemperature;
        private System.Windows.Forms.Label labelKoefficientOfTemperature;
        private System.Windows.Forms.TextBox textBoxStopTemperature;
        private System.Windows.Forms.Label labelStopTemperature;
        private System.Windows.Forms.TextBox textBoxStartCount;
        private System.Windows.Forms.Label labelStartCount;
    }
}