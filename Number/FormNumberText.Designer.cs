
namespace Number
{
    partial class FormNumberText
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
            this.chkColour = new System.Windows.Forms.CheckBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.nudStartFrom = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnNumber = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // chkColour
            // 
            this.chkColour.AutoSize = true;
            this.chkColour.Checked = true;
            this.chkColour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkColour.Location = new System.Drawing.Point(17, 269);
            this.chkColour.Name = "chkColour";
            this.chkColour.Size = new System.Drawing.Size(181, 17);
            this.chkColour.TabIndex = 24;
            this.chkColour.Text = "Colour picked elements in a view";
            this.chkColour.UseVisualStyleBackColor = true;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(14, 68);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(33, 13);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Suffix";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(14, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(33, 13);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Prefix";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(124, 65);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(100, 20);
            this.txtSuffix.TabIndex = 21;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(124, 12);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(100, 20);
            this.txtPrefix.TabIndex = 18;
            // 
            // nudStartFrom
            // 
            this.nudStartFrom.Location = new System.Drawing.Point(124, 38);
            this.nudStartFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudStartFrom.Name = "nudStartFrom";
            this.nudStartFrom.Size = new System.Drawing.Size(100, 20);
            this.nudStartFrom.TabIndex = 19;
            this.nudStartFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(14, 40);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(104, 13);
            this.Label1.TabIndex = 20;
            this.Label1.Text = "Start numbering from";
            // 
            // btnNumber
            // 
            this.btnNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNumber.Location = new System.Drawing.Point(12, 292);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(209, 48);
            this.btnNumber.TabIndex = 17;
            this.btnNumber.Text = "Pick text to (re)number";
            this.btnNumber.UseVisualStyleBackColor = true;
            this.btnNumber.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // FormNumberText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 352);
            this.Controls.Add(this.chkColour);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.nudStartFrom);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNumberText";
            this.Text = "Number Text";
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkColour;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSuffix;
        internal System.Windows.Forms.TextBox txtPrefix;
        internal System.Windows.Forms.NumericUpDown nudStartFrom;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnNumber;
    }
}