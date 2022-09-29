using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Syncfusion.Data.Extensions;
using Syncfusion.WinForms.DataGrid;
using System;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Number;
public partial class FormNumberGrid : System.Windows.Forms.Form
{
    public FormNumberGrid(ExternalCommandData CommandData)
    {
        InitializeComponent();

        buttonApply.Enabled = false;
        LoadCategories();
    }
    
    private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        checkBoxSelectParameter.Checked = true;
        LoadInstanceParameters();
        LoadFamilyInstances();
    }

    private void LoadCategories()
    {
        try
        {
            this.comboBoxCategories.DataSource = Util.GetCategoriesInActiveView();
            this.comboBoxCategories.DisplayMember = "Name";
            this.comboBoxCategories.ValueMember = "ID";

            this.comboBoxCategories.SelectedIndex = 0;
        }
        catch (Exception)
        {
            var td = new TaskDialog("INFO");
            td.MainContent = "Number could not find any non-annotation categories in this view";
            td.Show();
            Close();
        }
    }

    private void LoadInstanceParameters()
    {
        textBoxParameterName.Visible = false;
        comboBoxParameters.Visible = true;
        comboBoxParameters.SelectedItem = null;
        comboBoxParameters.SelectedValue = null;
        comboBoxParameters.Items.Clear();

        foreach (var paramName in Util.GetInstanceParametersByCategoryInActiveView(
            ((Category)comboBoxCategories.SelectedItem).Id))
        {
            comboBoxParameters.Items.Add(paramName);
        }

        if (comboBoxParameters.Items.Count > 0)
        {
            comboBoxParameters.SelectedIndex = 0;
            //button1.Enabled = true;
        }
        else
        {
            checkBoxSelectParameter.Checked = false;
            checkBoxSelectParameter.Enabled = false;
            ConfigureControls();
        }
    }

    private void LoadFamilyInstances()
    {
        this.sfDataGrid1.Columns.Clear();
        this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Id", HeaderText = "ID", AllowEditing = false });
        this.sfDataGrid1.Columns.Add(new GridTextColumn() { MappingName = "Name", HeaderText = "Name",  AllowEditing = false, MinimumWidth = 400 });

        var instances = Util.GetInstancesByCategoryInActiveView(((Category)comboBoxCategories.SelectedItem).Id);
        //this.sfDataGrid1.DataSource = Util.GetInstancesByCategoryInActiveView(((Category)comboBoxCategories.SelectedItem).Id);
    }

    private void ConfigureControls()
    {
        
    }
}
