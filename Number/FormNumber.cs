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

        buttonNumber.Enabled = false;
        LoadCategoriesList();
    }

    private void comboBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
    {
        checkBoxPickCat.Checked = true;
        LoadInstanceParameters();
    }

    private void comboBoxParameters_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            checkBoxDupMark.Text = "Surpress Duplicate Mark Values";
            if(comboBoxParameters.SelectedItem != null)
            {
                if (comboBoxParameters.SelectedItem.ToString().ToLower() == "mark")
                {
                    checkBoxDupMark.Checked = true;
                    checkBoxDupMark.Enabled = true;
                }
                else
                {
                    checkBoxDupMark.Checked = false;
                    checkBoxDupMark.Enabled = false;
                }
            }

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private void checkBoxPickCat_CheckedChanged(object sender, EventArgs e)
    {
        ConfigureControls();
    }

    private void textBoxParamName_TextChanged(object sender, EventArgs e)
    {
        HandleParamValTextChange();
    }

    private void buttonNumber_Click(object sender, EventArgs e)
    {
        if (comboBoxParameters.Visible == true)
        {
            parameterName = comboBoxParameters.SelectedItem.ToString();
        }
        else
        {
            parameterName = textBoxParamName.Text;
        }

        categoryName = ((Category)comboBoxCategories.SelectedItem).Name;
        numberFrom = (int)Math.Round(numericUpDownStartFrom.Value);
        prefix = textBoxPrefix.Text;
        suffix = textBoxSuffix.Text;

        if (checkBoxPickCat.Checked == false)
        {
            parameterName = textBoxParamName.Text;
        }

        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void LoadCategoriesList()
    {
        try
        {
            this.comboBoxCategories.DataSource = Util.GetCategoriesInActiveView(); 
            this.comboBoxCategories.DisplayMember = "Name";
            this.comboBoxCategories.ValueMember = "ID";

            this.comboBoxCategories.SelectedIndex = 0;
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
        buttonNumber.Enabled = false;
        textBoxParamName.Visible = false;
        lblParamSelect.Text = "Available parameters";
        checkBoxPickCat.Enabled = true;

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
            buttonNumber.Enabled = true;
        }
        else
        {
            checkBoxPickCat.Checked = false;
            checkBoxPickCat.Enabled = false;
            ConfigureControls();
        }
    }
    
    private void ConfigureControls()
    {
        if (checkBoxPickCat.Checked == true)
        {
            if (comboBoxParameters.Items.Count > 0)
            {
                comboBoxParameters.Visible = true;
                textBoxParamName.Visible = false;
                lblParamSelect.Text = "Available parameters";
            }
            else
            {
                SetParamValText();
                comboBoxParameters.Visible = false;
                textBoxParamName.Visible = true;
                lblParamSelect.Text = "Type parameter name to use";
                HandleParamValTextChange();
            }
        }
        else
        {
            SetParamValText();
            comboBoxParameters.Visible = false;
            textBoxParamName.Visible = true;
            lblParamSelect.Text = "Type parameter name to use";
            HandleParamValTextChange();
        }
    }

    private void SetParamValText()
    {
        switch (comboBoxCategories.SelectedItem.ToString().ToLower() ?? "")
        {
            case var @case when @case == "viewports":
                textBoxParamName.Text = "Detail Number";
                break;

            case var case1 when case1 == "grids":
                textBoxParamName.Text = "Name";
                checkBoxDupMark.Text = "Surpress Duplicate Name Values";
                break;

            case var case2 when case2 == "rvt links":
                textBoxParamName.Text = "Name";
                checkBoxDupMark.Text = "Surpress Duplicate Name Values";
                break;

            default:
                textBoxParamName.Text = "Mark";
                checkBoxDupMark.Text = "Surpress Duplicate Mark Values";
                break;
        }
    }

    private void HandleParamValTextChange()
    {
        if ((textBoxParamName.Text ?? "") != (string.Empty ?? ""))
        {
            buttonNumber.Enabled = true;
            if (textBoxParamName.Text.ToLower() == "mark" | textBoxParamName.Text.ToLower() == "name")
            {
                checkBoxDupMark.Checked = true;
                checkBoxDupMark.Enabled = true;
            }
            else
            {
                checkBoxDupMark.Checked = false;
                checkBoxDupMark.Enabled = false;
            }
        }
        else
        {
            buttonNumber.Enabled = false;
        }
    }

}
