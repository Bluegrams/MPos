
namespace MPos
{
    partial class CustomizeForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFont = new System.Windows.Forms.ComboBox();
            this.numFontSize = new System.Windows.Forms.NumericUpDown();
            this.trackOpacity = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.chkDarkMode = new System.Windows.Forms.CheckBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.butDataFormat = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataFormatColor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDataFormatResolution = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataFormatDpi = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataFormatPoint = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).BeginInit();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Font Size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Font Family";
            // 
            // cmbFont
            // 
            this.cmbFont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFont.FormattingEnabled = true;
            this.cmbFont.Location = new System.Drawing.Point(72, 92);
            this.cmbFont.Name = "cmbFont";
            this.cmbFont.Size = new System.Drawing.Size(132, 21);
            this.cmbFont.TabIndex = 4;
            this.cmbFont.SelectedIndexChanged += new System.EventHandler(this.cmbFont_SelectedIndexChanged);
            // 
            // numFontSize
            // 
            this.numFontSize.Location = new System.Drawing.Point(72, 119);
            this.numFontSize.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numFontSize.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFontSize.Name = "numFontSize";
            this.numFontSize.Size = new System.Drawing.Size(60, 20);
            this.numFontSize.TabIndex = 3;
            this.numFontSize.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFontSize.ValueChanged += new System.EventHandler(this.numFontSize_ValueChanged);
            // 
            // trackOpacity
            // 
            this.trackOpacity.BackColor = System.Drawing.Color.White;
            this.trackOpacity.Location = new System.Drawing.Point(72, 41);
            this.trackOpacity.Maximum = 100;
            this.trackOpacity.Name = "trackOpacity";
            this.trackOpacity.Size = new System.Drawing.Size(132, 45);
            this.trackOpacity.TabIndex = 2;
            this.trackOpacity.TickFrequency = 10;
            this.trackOpacity.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.trackOpacity.Scroll += new System.EventHandler(this.trackOpacity_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Opacity";
            // 
            // chkDarkMode
            // 
            this.chkDarkMode.AutoSize = true;
            this.chkDarkMode.Location = new System.Drawing.Point(9, 18);
            this.chkDarkMode.Name = "chkDarkMode";
            this.chkDarkMode.Size = new System.Drawing.Size(79, 17);
            this.chkDarkMode.TabIndex = 0;
            this.chkDarkMode.Text = "Dark Mode";
            this.chkDarkMode.UseVisualStyleBackColor = true;
            this.chkDarkMode.CheckedChanged += new System.EventHandler(this.chkDarkMode_CheckedChanged);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(234, 216);
            this.tabMain.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.chkDarkMode);
            this.tabPage1.Controls.Add(this.cmbFont);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.numFontSize);
            this.tabPage1.Controls.Add(this.trackOpacity);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(226, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Appearance";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.butDataFormat);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtDataFormatColor);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.txtDataFormatResolution);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.txtDataFormatDpi);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtDataFormatPoint);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(226, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Format";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // butDataFormat
            // 
            this.butDataFormat.Location = new System.Drawing.Point(141, 162);
            this.butDataFormat.Name = "butDataFormat";
            this.butDataFormat.Size = new System.Drawing.Size(75, 22);
            this.butDataFormat.TabIndex = 8;
            this.butDataFormat.Text = "Set";
            this.butDataFormat.UseVisualStyleBackColor = true;
            this.butDataFormat.Click += new System.EventHandler(this.butDataFormat_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 120);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Color Format:";
            // 
            // txtDataFormatColor
            // 
            this.txtDataFormatColor.Location = new System.Drawing.Point(6, 136);
            this.txtDataFormatColor.Name = "txtDataFormatColor";
            this.txtDataFormatColor.Size = new System.Drawing.Size(210, 20);
            this.txtDataFormatColor.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Resolution Format:";
            // 
            // txtDataFormatResolution
            // 
            this.txtDataFormatResolution.Location = new System.Drawing.Point(6, 97);
            this.txtDataFormatResolution.Name = "txtDataFormatResolution";
            this.txtDataFormatResolution.Size = new System.Drawing.Size(210, 20);
            this.txtDataFormatResolution.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "DPI Format:";
            // 
            // txtDataFormatDpi
            // 
            this.txtDataFormatDpi.Location = new System.Drawing.Point(6, 58);
            this.txtDataFormatDpi.Name = "txtDataFormatDpi";
            this.txtDataFormatDpi.Size = new System.Drawing.Size(210, 20);
            this.txtDataFormatDpi.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Coordinates Format:";
            // 
            // txtDataFormatPoint
            // 
            this.txtDataFormatPoint.Location = new System.Drawing.Point(6, 19);
            this.txtDataFormatPoint.Name = "txtDataFormatPoint";
            this.txtDataFormatPoint.Size = new System.Drawing.Size(210, 20);
            this.txtDataFormatPoint.TabIndex = 0;
            // 
            // CustomizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 216);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomizeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Customize MPos";
            this.Load += new System.EventHandler(this.CustomizeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numFontSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackOpacity)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkDarkMode;
        private System.Windows.Forms.ComboBox cmbFont;
        private System.Windows.Forms.NumericUpDown numFontSize;
        private System.Windows.Forms.TrackBar trackOpacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDataFormatColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDataFormatResolution;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDataFormatDpi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDataFormatPoint;
        private System.Windows.Forms.Button butDataFormat;
    }
}