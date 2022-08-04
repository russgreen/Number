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
            this.txtSuffix = new System.Windows.Forms.TextBox();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.nudStartFrom = new System.Windows.Forms.NumericUpDown();
            this.Label1 = new System.Windows.Forms.Label();
            this.lblParamSelect = new System.Windows.Forms.Label();
            this.comboBoxParameters = new System.Windows.Forms.ComboBox();
            this.buttonApply = new System.Windows.Forms.Button();
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.checkBoxSelectParameter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtParamName
            // 
            this.textBoxParameterName.Location = new System.Drawing.Point(610, 13);
            this.textBoxParameterName.Name = "txtParamName";
            this.textBoxParameterName.Size = new System.Drawing.Size(210, 20);
            this.textBoxParameterName.TabIndex = 36;
            this.textBoxParameterName.Text = "Mark";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(12, 15);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(49, 13);
            this.Label5.TabIndex = 31;
            this.Label5.Text = "Category";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCategories.FormattingEnabled = true;
            this.comboBoxCategories.Location = new System.Drawing.Point(67, 12);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(210, 21);
            this.comboBoxCategories.TabIndex = 32;
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.comboBoxCategories_SelectedIndexChanged);
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(382, 42);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(33, 13);
            this.Label4.TabIndex = 35;
            this.Label4.Text = "Suffix";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(12, 42);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(33, 13);
            this.Label3.TabIndex = 34;
            this.Label3.Text = "Prefix";
            // 
            // txtSuffix
            // 
            this.txtSuffix.Location = new System.Drawing.Point(421, 38);
            this.txtSuffix.Name = "txtSuffix";
            this.txtSuffix.Size = new System.Drawing.Size(100, 20);
            this.txtSuffix.TabIndex = 30;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(51, 39);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(100, 20);
            this.txtPrefix.TabIndex = 27;
            // 
            // nudStartFrom
            // 
            this.nudStartFrom.Location = new System.Drawing.Point(267, 39);
            this.nudStartFrom.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudStartFrom.Name = "nudStartFrom";
            this.nudStartFrom.Size = new System.Drawing.Size(100, 20);
            this.nudStartFrom.TabIndex = 28;
            this.nudStartFrom.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(157, 42);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(104, 13);
            this.Label1.TabIndex = 29;
            this.Label1.Text = "Start numbering from";
            // 
            // lblParamSelect
            // 
            this.lblParamSelect.AutoSize = true;
            this.lblParamSelect.Location = new System.Drawing.Point(283, 15);
            this.lblParamSelect.Name = "lblParamSelect";
            this.lblParamSelect.Size = new System.Drawing.Size(105, 13);
            this.lblParamSelect.TabIndex = 33;
            this.lblParamSelect.Text = "Available parameters";
            // 
            // cboParameters
            // 
            this.comboBoxParameters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParameters.FormattingEnabled = true;
            this.comboBoxParameters.Location = new System.Drawing.Point(394, 12);
            this.comboBoxParameters.Name = "cboParameters";
            this.comboBoxParameters.Size = new System.Drawing.Size(210, 21);
            this.comboBoxParameters.TabIndex = 37;
            // 
            // button1
            // 
            this.buttonApply.Location = new System.Drawing.Point(774, 482);
            this.buttonApply.Name = "button1";
            this.buttonApply.Size = new System.Drawing.Size(75, 23);
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
            this.sfDataGrid1.Location = new System.Drawing.Point(12, 65);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.Size = new System.Drawing.Size(837, 411);
            this.sfDataGrid1.TabIndex = 39;
            this.sfDataGrid1.Text = "sfDataGrid1";
            // 
            // checkBoxSelectParameter
            // 
            this.checkBoxSelectParameter.AutoSize = true;
            this.checkBoxSelectParameter.Location = new System.Drawing.Point(550, 42);
            this.checkBoxSelectParameter.Name = "checkBoxSelectParameter";
            this.checkBoxSelectParameter.Size = new System.Drawing.Size(171, 17);
            this.checkBoxSelectParameter.TabIndex = 40;
            this.checkBoxSelectParameter.Text = "Select a parameter from the list";
            this.checkBoxSelectParameter.UseVisualStyleBackColor = true;
            // 
            // FormNumberGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(861, 517);
            this.Controls.Add(this.checkBoxSelectParameter);
            this.Controls.Add(this.sfDataGrid1);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.comboBoxParameters);
            this.Controls.Add(this.textBoxParameterName);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.txtSuffix);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.nudStartFrom);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.lblParamSelect);
            this.Name = "FormNumberGrid";
            this.Text = "FormNumberGrid";
            ((System.ComponentModel.ISupportInitialize)(this.nudStartFrom)).EndInit();
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
    internal System.Windows.Forms.TextBox txtSuffix;
    internal System.Windows.Forms.TextBox txtPrefix;
    internal System.Windows.Forms.NumericUpDown nudStartFrom;
    internal System.Windows.Forms.Label Label1;
    internal System.Windows.Forms.Label lblParamSelect;
    private System.Windows.Forms.ComboBox comboBoxParameters;
    private System.Windows.Forms.Button buttonApply;
    private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
    private System.Windows.Forms.CheckBox checkBoxSelectParameter;
}
