using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Number;

public partial class FormNumber : System.Windows.Forms.Form
{
    public string parameterName;
    public string categoryName;
    public int numberFrom;
    public string prefix;
    public string suffix;

    private Document _document;

    public FormNumber()
    {
        InitializeComponent();
    }

    public FormNumber(ExternalCommandData CommandData)
    {
        InitializeComponent();

        _document = CommandData.Application.ActiveUIDocument.Document;

        btnNumber.Enabled = false;
        LoadCategoriesList();
    }

    private void cboCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        chkPickCat.Checked = true;
        LoadInstanceParameters();
    }

    private void cboParameters_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            chkDupMark.Text = "Surpress Duplicate Mark Values";
            if (cboParameters.SelectedItem.ToString().ToLower() == "mark")
            {
                chkDupMark.Checked = true;
                chkDupMark.Enabled = true;
            }
            else
            {
                chkDupMark.Checked = false;
                chkDupMark.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void chkPickCat_CheckedChanged(object sender, EventArgs e)
    {
        ConfigureControls();
    }

    private void txtParamName_TextChanged(object sender, EventArgs e)
    {
        HandleParamValTextChange();
    }

    private void btnNumber_Click(object sender, EventArgs e)
    {
        if (cboParameters.Visible == true)
        {
            parameterName = cboParameters.SelectedItem.ToString();
        }
        else
        {
            parameterName = txtParamName.Text;
        }

        categoryName = cboCategories.SelectedItem.ToString();
        numberFrom = (int)Math.Round(nudStartFrom.Value);
        prefix = txtPrefix.Text;
        suffix = txtSuffix.Text;

        if (chkPickCat.Checked == false)
        {
            parameterName = txtParamName.Text;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void LoadCategoriesList()
    {
        try
        {
            this.cboCategories.DataSource = Util.GetCategoriesInActiveView(); 
            this.cboCategories.DisplayMember = "Name";
            this.cboCategories.ValueMember = "ID";

            this.cboCategories.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            var td = new TaskDialog("INFO");
            td.MainContent = "Number could not find any non-annotation categories in this view";
            td.Show();
            Close();
        }
    }

    private void LoadInstanceParameters()
    {
        btnNumber.Enabled = false;
        txtParamName.Visible = false;
        lblParamSelect.Text = "Available parameters";
        chkPickCat.Enabled = true;

        cboParameters.Visible = true;
        cboParameters.SelectedItem = null;
        cboParameters.SelectedValue = null;
        cboParameters.Items.Clear();

        //GetInstanceParametersByCategoryInActiveView
        //var parameters = Util.GetCategoryParameters((Category)this.cboCategories.SelectedItem);

        //foreach (var paramName in Util.GetCategoryParameters(((Category)cboCategories.SelectedItem).Id))
        foreach (var paramName in Util.GetInstanceParametersByCategoryInActiveView(
            ((Category)cboCategories.SelectedItem).Name))
        {
            cboParameters.Items.Add(paramName);
        }
                
        if (cboParameters.Items.Count > 0)
        {
            cboParameters.SelectedIndex = 0;
            btnNumber.Enabled = true;
        }
        else
        {
            chkPickCat.Checked = false;
            chkPickCat.Enabled = false;
            ConfigureControls();
        }
    }
    
    private void ConfigureControls()
    {
        if (chkPickCat.Checked == true)
        {
            if (cboParameters.Items.Count > 0)
            {
                cboParameters.Visible = true;
                txtParamName.Visible = false;
                lblParamSelect.Text = "Available parameters";
            }
            else
            {
                SetParamValText();
                cboParameters.Visible = false;
                txtParamName.Visible = true;
                lblParamSelect.Text = "Type parameter name to use";
                HandleParamValTextChange();
            }
        }
        else
        {
            SetParamValText();
            cboParameters.Visible = false;
            txtParamName.Visible = true;
            lblParamSelect.Text = "Type parameter name to use";
            HandleParamValTextChange();
        }
    }

    private void SetParamValText()
    {
        switch (cboCategories.SelectedItem.ToString().ToLower() ?? "")
        {
            case var @case when @case == "viewports":
                txtParamName.Text = "Detail Number";
                break;

            case var case1 when case1 == "grids":
                txtParamName.Text = "Name";
                chkDupMark.Text = "Surpress Duplicate Name Values";
                break;

            case var case2 when case2 == "rvt links":
                txtParamName.Text = "Name";
                chkDupMark.Text = "Surpress Duplicate Name Values";
                break;

            default:
                txtParamName.Text = "Mark";
                chkDupMark.Text = "Surpress Duplicate Mark Values";
                break;
        }
    }

    private void HandleParamValTextChange()
    {
        if ((txtParamName.Text ?? "") != (string.Empty ?? ""))
        {
            btnNumber.Enabled = true;
            if (txtParamName.Text.ToLower() == "mark" | txtParamName.Text.ToLower() == "name")
            {
                chkDupMark.Checked = true;
                chkDupMark.Enabled = true;
            }
            else
            {
                chkDupMark.Checked = false;
                chkDupMark.Enabled = false;
            }
        }
        else
        {
            btnNumber.Enabled = false;
        }
    }

}
