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
            this.SuspendLayout();
            // 
            // textBoxError
            // 
            this.textBoxError.Location = new System.Drawing.Point(12, 150);
            this.textBoxError.Name = "textBoxError";
            this.textBoxError.Size = new System.Drawing.Size(100, 20);
            this.textBoxError.TabIndex = 31;
            this.textBoxError.Text = "0.0001";
            // 
            // labelError
            // 
            this.labelError.AutoSize = true;
            this.labelError.Location = new System.Drawing.Point(12, 134);
            this.labelError.Name = "labelError";
            this.labelError.Size = new System.Drawing.Size(124, 13);
            this.labelError.TabIndex = 30;
            this.labelError.Text = "Погрешность обучения";
            // 
            // textBoxMoment
            // 
            this.textBoxMoment.Location = new System.Drawing.Point(12, 189);
            this.textBoxMoment.Name = "textBoxMoment";
            this.textBoxMoment.Size = new System.Drawing.Size(100, 20);
            this.textBoxMoment.TabIndex = 28;
            this.textBoxMoment.Text = "0.1";
            // 
            // labelMoment
            // 
            this.labelMoment.AutoSize = true;
            this.labelMoment.Location = new System.Drawing.Point(9, 173);
            this.labelMoment.Name = "labelMoment";
            this.labelMoment.Size = new System.Drawing.Size(47, 13);
            this.labelMoment.TabIndex = 26;
            this.labelMoment.Text = "Момент";
            // 
            // labelCoefficient
            // 
            this.labelCoefficient.AutoSize = true;
            this.labelCoefficient.Location = new System.Drawing.Point(9, 87);
            this.labelCoefficient.Name = "labelCoefficient";
            this.labelCoefficient.Size = new System.Drawing.Size(126, 13);
            this.labelCoefficient.TabIndex = 25;
            this.labelCoefficient.Text = "Коэффициент обучения";
            // 
            // textBoxCoefficient
            // 
            this.textBoxCoefficient.Location = new System.Drawing.Point(12, 107);
            this.textBoxCoefficient.Name = "textBoxCoefficient";
            this.textBoxCoefficient.Size = new System.Drawing.Size(100, 20);
            this.textBoxCoefficient.TabIndex = 24;
            this.textBoxCoefficient.Text = "0.1";
            // 
            // textBoxCountItterations
            // 
            this.textBoxCountItterations.Location = new System.Drawing.Point(12, 64);
            this.textBoxCountItterations.Name = "textBoxCountItterations";
            this.textBoxCountItterations.Size = new System.Drawing.Size(100, 20);
            this.textBoxCountItterations.TabIndex = 23;
            this.textBoxCountItterations.Text = "3000";
            // 
            // labelCountItterations
            // 
            this.labelCountItterations.AutoSize = true;
            this.labelCountItterations.Location = new System.Drawing.Point(9, 48);
            this.labelCountItterations.Name = "labelCountItterations";
            this.labelCountItterations.Size = new System.Drawing.Size(154, 13);
            this.labelCountItterations.TabIndex = 22;
            this.labelCountItterations.Text = "Количество циклов обучения";
            // 
            // textBoxCountNeurons
            // 
            this.textBoxCountNeurons.Enabled = false;
            this.textBoxCountNeurons.Location = new System.Drawing.Point(12, 25);
            this.textBoxCountNeurons.Name = "textBoxCountNeurons";
            this.textBoxCountNeurons.Size = new System.Drawing.Size(100, 20);
            this.textBoxCountNeurons.TabIndex = 20;
            this.textBoxCountNeurons.Text = "20";
            // 
            // labelCountNeurons
            // 
            this.labelCountNeurons.AutoSize = true;
            this.labelCountNeurons.Location = new System.Drawing.Point(9, 9);
            this.labelCountNeurons.Name = "labelCountNeurons";
            this.labelCountNeurons.Size = new System.Drawing.Size(195, 13);
            this.labelCountNeurons.TabIndex = 19;
            this.labelCountNeurons.Text = "Количество нейронов скрытого слоя";
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(115, 215);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(89, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(12, 215);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(97, 23);
            this.buttonAccept.TabIndex = 16;
            this.buttonAccept.Text = "Принять";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // FormNetwork
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 244);
            this.ControlBox = false;
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
    }
}