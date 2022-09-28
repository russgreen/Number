namespace Number;

partial class FormNumberGrid
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
            this.textBoxParameterName = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.comboBoxCategories = new System.Windows.Forms.ComboBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.textBoxSuffix = new System.Windows.Forms.TextBox();
            this.textBoxPrefix = new System.Windows.Forms.TextBox();
            this.numericUpDownStartFrom = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblParamSelect = new System.Windows.Forms.Label();
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.checkBoxSelectParameter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxParameterName
            // 
            this.textBoxParameterName.Location = new System.Drawing.Point(1627, 31);
            this.textBoxParameterName.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxParameterName.Name = "textBoxParameterName";
            this.textBoxParameterName.Size = new System.Drawing.Size(553, 38);
            this.textBoxParameterName.TabIndex = 36;
            this.textBoxParameterName.Text = "Mark";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(32, 36);
            this.Label5.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(129, 32);
            this.Label5.TabIndex = 31;
            this.Label5.Text = "Category";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(179, 29);
            this.comboBoxCategories.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(553, 39);
            this.comboBoxCategories.TabIndex = 32;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategories_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(1019, 100);
            this.Label4.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(86, 32);
            this.Label4.TabIndex = 35;
            this.Label4.Text = "Suffix";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(32, 100);
            this.Label3.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(87, 32);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "Prefix";
            // 
            // textBoxSuffix
            // 
            this.textBoxSuffix.Location = new System.Drawing.Point(1123, 91);
            this.textBoxSuffix.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxSuffix.Name = "textBoxSuffix";
            this.textBoxSuffix.Size = new System.Drawing.Size(260, 38);
            this.textBoxSuffix.TabIndex = 30;
            // 
            // textBoxPrefix
            // 
            this.textBoxPrefix.Location = new System.Drawing.Point(136, 93);
            this.textBoxPrefix.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.textBoxPrefix.Name = "textBoxPrefix";
            this.textBoxPrefix.Size = new System.Drawing.Size(260, 38);
            this.textBoxPrefix.TabIndex = 27;
            // 
            // numericUpDownStartFrom
            // 
            this.numericUpDownStartFrom.Location = new System.Drawing.Point(712, 93);
            this.numericUpDownStartFrom.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.numericUpDownStartFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.numericUpDownStartFrom.Name = "numericUpDownStartFrom";
            this.numericUpDownStartFrom.Size = new System.Drawing.Size(267, 38);
            this.numericUpDownStartFrom.TabIndex = 28;
            this.numericUpDownStartFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(419, 100);
            this.Label1.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(279, 32);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "Start numbering from";
            // 
            // lblParamSelect
            // 
            this.lblParamSelect.AutoSize = true;
            this.lblParamSelect.Location = new System.Drawing.Point(755, 36);
            this.lblParamSelect.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblParamSelect.Name = "lblParamSelect";
            this.lblParamSelect.Size = new System.Drawing.Size(282, 32);
            this.lblParamSelect.TabIndex = 33;
            this.lblParamSelect.Text = "Available parameters";
            // 
            // comboBoxParameters
            // 
            this.comboBoxParameters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.Location = new System.Drawing.Point(1051, 29);
            this.comboBoxParameters.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.comboBoxParameters.Name = "comboBoxParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(553, 39);
            this.comboBoxParameters.TabIndex = 37;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(2064, 1149);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(200, 55);
            this.buttonApply.TabIndex = 38;
            this.buttonApply.Text = "Apply";
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.Location = new System.Drawing.Point(32, 155);
            this.sfDataGrid1.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.PreviewRowHeight = 70;
            this.sfDataGrid1.Size = new System.Drawing.Size(2229, 977);
            this.sfDataGrid1.TabIndex = 39;
            this.sfDataGrid1.Text = "sfDataGrid1";
            // 
            // checkBoxSelectParameter
            // 
            this.checkBoxSelectParameter.AutoSize = true;
            this.checkBoxSelectParameter.Location = new System.Drawing.Point(1467, 100);
            this.checkBoxSelectParameter.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.checkBoxSelectParameter.Name = "checkBoxSelectParameter";
            this.checkBoxSelectParameter.Size = new System.Drawing.Size(444, 36);
            this.checkBoxSelectParameter.TabIndex = 40;
            this.checkBoxSelectParameter.Text = "Select a parameter from the list";
            this.checkBoxSelectParameter.UseVisualStyleBackColor = true;
            // 
            // FormNumberGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2296, 1233);
            this.Controls.Add(this.checkBoxSelectParameter);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxParameters);
            this.Controls.Add(this.textBoxParameterName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.textBoxSuffix);
            this.Controls.Add(this.textBoxPrefix);
            this.Controls.Add(this.numericUpDownStartFrom);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblParamSelect);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "FormNumberGrid";
            this.Text = "FormNumberGrid";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxParameterName;
    internal System.Windows.Forms.Label Label5;
    private System.Windows.Forms.ComboBox comboBoxCategories;
    internal System.Windows.Forms.Label Label4;
    internal System.Windows.Forms.Label Label3;
    internal System.Windows.Forms.TextBox textBoxSuffix;
    internal System.Windows.Forms.TextBox textBoxPrefix;
    internal System.Windows.Forms.NumericUpDown numericUpDownStartFrom;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Label lblParamSelect;
    private System.Windows.Forms.ComboBox comboBoxParameters;
    private System.Windows.Forms.Button buttonApply;
    private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
    private System.Windows.Forms.CheckBox checkBoxSelectParameter;
}
