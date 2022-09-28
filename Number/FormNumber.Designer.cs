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
            this.checkBoxDupMark = new System.Windows.Forms.CheckBox();
            this.textBoxParamName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.checkBoxPickCat = new System.Windows.Forms.CheckBox();
            this.checkBoxColour = new System.Windows.Forms.CheckBox();
            this.checkBoxIsolate = new System.Windows.Forms.CheckBox();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.textBoxSuffix = new System.Windows.Forms.TextBox();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.numericUpDownStartFrom = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.buttonNumber = new System.Windows.Forms.Button();
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.lblParamSelect = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartFrom)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBoxDupMark
            // 
            this.checkBoxDupMark.AutoSize = true;
            this.checkBoxDupMark.Location = new System.Drawing.Point(27, 510);
            this.checkBoxDupMark.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.checkBoxDupMark.Name = "checkBoxDupMark";
            this.checkBoxDupMark.Size = new System.Drawing.Size(447, 36);
            this.checkBoxDupMark.TabIndex = 28;
            this.checkBoxDupMark.Text = "Supress Duplicate Mark Values";
            this.checkBoxDupMark.UseVisualStyleBackColor = true;
            // 
            // textBoxParamName
            // 
            this.textBoxParamName.Location = new System.Drawing.Point(27, 434);
            this.textBoxParamName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxParamName.Name = "textBoxParamName";
            this.textBoxParamName.Size = new System.Drawing.Size(553, 38);
            this.textBoxParamName.TabIndex = 26;
            this.textBoxParamName.Text = "Mark";
            this.textBoxParamName.TextChanged += new System.EventHandler(this.textBoxParamName_TextChanged);
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
            // checkBoxPickCat
            // 
            this.checkBoxPickCat.AutoSize = true;
            this.checkBoxPickCat.Checked = true;
            this.checkBoxPickCat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxPickCat.Location = new System.Drawing.Point(35, 227);
            this.checkBoxPickCat.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.checkBoxPickCat.Name = "checkBoxPickCat";
            this.checkBoxPickCat.Size = new System.Drawing.Size(436, 36);
            this.checkBoxPickCat.TabIndex = 27;
            this.checkBoxPickCat.Text = "Pick a category and parameter";
            this.checkBoxPickCat.UseVisualStyleBackColor = true;
            this.checkBoxPickCat.CheckedChanged += new System.EventHandler(this.checkBoxPickCat_CheckedChanged);
            // 
            // checkBoxColour
            // 
            this.checkBoxColour.AutoSize = true;
            this.checkBoxColour.Checked = true;
            this.checkBoxColour.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxColour.Location = new System.Drawing.Point(27, 613);
            this.checkBoxColour.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.checkBoxColour.Name = "checkBoxColour";
            this.checkBoxColour.Size = new System.Drawing.Size(466, 36);
            this.checkBoxColour.TabIndex = 24;
            this.checkBoxColour.Text = "Colour picked elements in a view";
            this.checkBoxColour.UseVisualStyleBackColor = true;
            // 
            // checkBoxIsolate
            // 
            this.checkBoxIsolate.AutoSize = true;
            this.checkBoxIsolate.Checked = true;
            this.checkBoxIsolate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIsolate.Location = new System.Drawing.Point(27, 565);
            this.checkBoxIsolate.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.checkBoxIsolate.Name = "checkBoxIsolate";
            this.checkBoxIsolate.Size = new System.Drawing.Size(442, 36);
            this.checkBoxIsolate.TabIndex = 25;
            this.checkBoxIsolate.Text = "Isolate Model Category in View";
            this.checkBoxIsolate.UseVisualStyleBackColor = true;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(27, 315);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(553, 39);
            this.comboBoxCategories.TabIndex = 18;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategories_SelectedIndexChanged);
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
            // textBoxSuffix
            // 
            this.textBoxSuffix.Location = new System.Drawing.Point(325, 157);
            this.textBoxSuffix.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxSuffix.Name = "textBoxSuffix";
            this.textBoxSuffix.Size = new System.Drawing.Size(260, 38);
            this.textBoxSuffix.TabIndex = 16;
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(325, 31);
            this.textBoxPrefix.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(260, 38);
            this.textBoxPrefix.TabIndex = 13;
            // 
            // numericUpDownStartFrom
            // 
            this.numericUpDownStartFrom.Location = new System.Drawing.Point(325, 93);
            this.numericUpDownStartFrom.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numericUpDownStartFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownStartFrom.Name = "numericUpDownStartFrom";
            this.numericUpDownStartFrom.Size = new System.Drawing.Size(267, 38);
            this.numericUpDownStartFrom.TabIndex = 14;
            this.numericUpDownStartFrom.Value = new decimal(new int[] {
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
            // buttonNumber
            // 
            this.buttonNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonNumber.Location = new System.Drawing.Point(21, 677);
            this.buttonNumber.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonNumber.Name = "buttonNumber";
            this.buttonNumber.Size = new System.Drawing.Size(557, 114);
            this.buttonNumber.TabIndex = 21;
            this.buttonNumber.Text = "Pick families to (re)number";
            this.buttonNumber.UseVisualStyleBackColor = true;
            this.buttonNumber.Click += new System.EventHandler(this.buttonNumber_Click);
            // 
            // comboBoxParameters
            // 
            this.comboBoxParameters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.Location = new System.Drawing.Point(27, 434);
            this.comboBoxParameters.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(553, 39);
            this.comboBoxParameters.TabIndex = 20;
            this.comboBoxParameters.SelectedIndexChanged += new System.EventHandler(this.comboBoxParameters_SelectedIndexChanged);
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
            this.Controls.Add(this.checkBoxDupMark);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.checkBoxPickCat);
            this.Controls.Add(this.checkBoxColour);
            this.Controls.Add(this.checkBoxIsolate);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.textBoxSuffix);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.numericUpDownStartFrom);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.buttonNumber);
            this.Controls.Add(this.comboBoxParameters);
            this.Controls.Add(this.lblParamSelect);
            this.Controls.Add(this.textBoxParamName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNumber";
            this.Text = "Number";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartFrom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.CheckBox checkBoxDupMark;
        private System.Windows.Forms.TextBox textBoxParamName;
        internal System.Windows.Forms.Label Label5;
        private System.Windows.Forms.CheckBox checkBoxPickCat;
        internal System.Windows.Forms.CheckBox checkBoxColour;
        internal System.Windows.Forms.CheckBox checkBoxIsolate;
        private System.Windows.Forms.ComboBox comboBoxCategories;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.TextBox textBoxSuffix;
        internal System.Windows.Forms.TextBox textBoxPrefix;
        internal System.Windows.Forms.NumericUpDown numericUpDownStartFrom;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button buttonNumber;
        private System.Windows.Forms.ComboBox comboBoxParameters;
        internal System.Windows.Forms.Label lblParamSelect;
    }
}