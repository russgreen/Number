namespace Number
{
    partial class FormNumber
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
            this.chkDupMark = new System.Windows.Forms.CheckBox();
            this.txtParamName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.chkPickCat = new System.Windows.Forms.CheckBox();
            this.chkColour = new System.Windows.Forms.CheckBox();
            this.chkIsolate = new System.Windows.Forms.CheckBox();
            this.cboCategories = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.nudStartFrom = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnNumber = new System.Windows.Forms.Button();
            this.cboParameters = new System.Windows.Forms.ComboBox();
            this.lblParamSelect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // chkDupMark
            // 
            this.chkDupMark.AutoSize = true;
            this.chkDupMark.Location = new System.Drawing.Point(27, 510);
            this.chkDupMark.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkDupMark.Name = "chkDupMark";
            this.chkDupMark.Size = new System.Drawing.Size(447, 36);
            this.chkDupMark.TabIndex = 28;
            this.chkDupMark.Text = "Supress Duplicate Mark Values";
            this.chkDupMark.UseVisualStyleBackColor = true;
            // 
            // txtParamName
            // 
            this.txtParamName.Location = new System.Drawing.Point(27, 434);
            this.txtParamName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtParamName.Name = "txtParamName";
            this.txtParamName.Size = new System.Drawing.Size(553, 38);
            this.txtParamName.TabIndex = 26;
            this.txtParamName.Text = "Mark";
            this.txtParamName.TextChanged += new System.EventHandler(this.txtParamName_TextChanged);
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(27, 274);
            this.Label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(381, 32);
            this.Label5.TabIndex = 17;
            this.Label5.Text = "Filter parameters by category";
            // 
            // chkPickCat
            // 
            this.chkPickCat.AutoSize = true;
            this.chkPickCat.Checked = true;
            this.chkPickCat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPickCat.Location = new System.Drawing.Point(35, 227);
            this.chkPickCat.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkPickCat.Name = "chkPickCat";
            this.chkPickCat.Size = new System.Drawing.Size(436, 36);
            this.chkPickCat.TabIndex = 27;
            this.chkPickCat.Text = "Pick a category and parameter";
            this.chkPickCat.UseVisualStyleBackColor = true;
            this.chkPickCat.CheckedChanged += new System.EventHandler(this.chkPickCat_CheckedChanged);
            // 
            // chkColour
            // 
            this.chkColour.AutoSize = true;
            this.chkColour.Checked = true;
            this.chkColour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkColour.Location = new System.Drawing.Point(27, 613);
            this.chkColour.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkColour.Name = "chkColour";
            this.chkColour.Size = new System.Drawing.Size(466, 36);
            this.chkColour.TabIndex = 24;
            this.chkColour.Text = "Colour picked elements in a view";
            this.chkColour.UseVisualStyleBackColor = true;
            // 
            // chkIsolate
            // 
            this.chkIsolate.AutoSize = true;
            this.chkIsolate.Checked = true;
            this.chkIsolate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsolate.Location = new System.Drawing.Point(27, 565);
            this.chkIsolate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkIsolate.Name = "chkIsolate";
            this.chkIsolate.Size = new System.Drawing.Size(442, 36);
            this.chkIsolate.TabIndex = 25;
            this.chkIsolate.Text = "Isolate Model Category in View";
            this.chkIsolate.UseVisualStyleBackColor = true;
            // 
            // cboCategories
            // 
            this.cboCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategories.FormattingEnabled = true;
            this.cboCategories.Location = new System.Drawing.Point(27, 315);
            this.cboCategories.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cboCategories.Name = "cboCategories";
            this.cboCategories.Size = new System.Drawing.Size(553, 39);
            this.cboCategories.TabIndex = 18;
            this.cboCategories.SelectedIndexChanged += new System.EventHandler(this.cboCategories_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(32, 165);
            this.Label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(86, 32);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Suffix";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(32, 38);
            this.Label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(87, 32);
            this.Label3.TabIndex = 22;
            this.Label3.Text = "Prefix";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(325, 157);
            this.txtSuffix.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(260, 38);
            this.txtSuffix.TabIndex = 16;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(325, 31);
            this.txtPrefix.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(260, 38);
            this.txtPrefix.TabIndex = 13;
            // 
            // nudStartFrom
            // 
            this.nudStartFrom.Location = new System.Drawing.Point(325, 93);
            this.nudStartFrom.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.nudStartFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudStartFrom.Name = "nudStartFrom";
            this.nudStartFrom.Size = new System.Drawing.Size(267, 38);
            this.nudStartFrom.TabIndex = 14;
            this.nudStartFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(32, 98);
            this.Label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(279, 32);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Start numbering from";
            // 
            // btnNumber
            // 
            this.btnNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNumber.Location = new System.Drawing.Point(21, 677);
            this.btnNumber.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnNumber.Name = "btnNumber";
            this.btnNumber.Size = new System.Drawing.Size(557, 114);
            this.btnNumber.TabIndex = 21;
            this.btnNumber.Text = "Pick families to (re)number";
            this.btnNumber.UseVisualStyleBackColor = true;
            this.btnNumber.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // cboParameters
            // 
            this.cboParameters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboParameters.FormattingEnabled = true;
            this.cboParameters.Location = new System.Drawing.Point(27, 434);
            this.cboParameters.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.cboParameters.Name = "cboParameters";
            this.cboParameters.Size = new System.Drawing.Size(553, 39);
            this.cboParameters.TabIndex = 20;
            this.cboParameters.SelectedIndexChanged += new System.EventHandler(this.cboParameters_SelectedIndexChanged);
            // 
            // lblParamSelect
            // 
            this.lblParamSelect.AutoSize = true;
            this.lblParamSelect.Location = new System.Drawing.Point(27, 396);
            this.lblParamSelect.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblParamSelect.Name = "lblParamSelect";
            this.lblParamSelect.Size = new System.Drawing.Size(282, 32);
            this.lblParamSelect.TabIndex = 19;
            this.lblParamSelect.Text = "Available parameters";
            // 
            // FormNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 820);
            this.Controls.Add(this.chkDupMark);
            this.Controls.Add(this.txtParamName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.chkPickCat);
            this.Controls.Add(this.chkColour);
            this.Controls.Add(this.chkIsolate);
            this.Controls.Add(this.cboCategories);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.nudStartFrom);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnNumber);
            this.Controls.Add(this.cboParameters);
            this.Controls.Add(this.lblParamSelect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNumber";
            this.Text = "Number";
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox chkDupMark;
        private System.Windows.Forms.TextBox txtParamName;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.CheckBox chkPickCat;
        internal System.Windows.Forms.CheckBox chkColour;
        internal System.Windows.Forms.CheckBox chkIsolate;
        private System.Windows.Forms.ComboBox cboCategories;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox txtSuffix;
        internal System.Windows.Forms.TextBox txtPrefix;
        internal System.Windows.Forms.NumericUpDown nudStartFrom;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnNumber;
        private System.Windows.Forms.ComboBox cboParameters;
        internal System.Windows.Forms.Label lblParamSelect;
    }
}