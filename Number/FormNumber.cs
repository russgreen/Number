using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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

        //_caller.Number(numberFrom, prefix, suffix, parameterName, categoryName, chkIsolate.Checked, chkColour.Checked, chkDupMark.Checked);
        this.DialogResult = DialogResult.OK;
        this.Close();
    }

    private void LoadCategoriesList()
    {
        try
        {
            //// select all elements in the active view  
            //var allInView = new FilteredElementCollector(_document, _document.ActiveView.Id);
            //allInView.WhereElementIsNotElementType();

            //// use LINQ to collect the category names of all elements whilst ensuring that category is not null  
            //var categoryNames = from elem in allInView
            //                    where elem.Category is object
            //                    select elem.Category.Name;

            //// strip out duplicates and order the list of category names  
            //categoryNames = categoryNames.Distinct().OrderBy(catName => catName);

            //var categoryNames1 = from name in categoryNames
            //                     where name.ToLower().Contains("<room separation>") == false & 
            //                     name.ToLower().Contains("sheets") == false & 
            //                     name.ToLower().Contains("schedule graphics") == false & 
            //                     name.ToLower().Contains("lines") == false & 
            //                     name.ToLower().Contains("title blocks") == false & 
            //                     name.ToLower().Contains("tags") == false & 
            //                     name.ToLower().Contains("dimensions") == false & 
            //                     name.ToLower().Contains("text") == false & 
            //                     name.ToLower().Contains("cameras") == false & 
            //                     name.ToLower().Contains("elevations") == false & 
            //                     name.ToLower().Contains("sections") == false & 
            //                     name.ToLower().Contains("views") == false
            //                     select name;

            //// construct a string list of the collected category names  
            //foreach (var catName in categoryNames1)
            //{
            //    cboCategories.Items.Add(catName);
            //}

            //add list<string> to combobox
            foreach (var catName in Util.GetCategoriesInActiveView())
            {
                cboCategories.Items.Add(catName);
            }

            cboCategories.SelectedIndex = 0;
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

        //var faminstFilter = new ElementClassFilter(typeof(FamilyInstance));
        //var faminstCollector = new FilteredElementCollector(_document, _document.ActiveView.Id);
        //faminstCollector.WherePasses(faminstFilter);
        //var query = from instance in faminstCollector
        //            where (instance.Category.Name ?? "") == (cboCategories.SelectedItem.ToString() ?? "")
        //            select instance;
        //var familyInstances = query.Cast<FamilyInstance>().ToList();
        //var ParamLst = new List<string>();

        //foreach (FamilyInstance FmlyInst in familyInstances)
        //{
        //    foreach (Parameter Param in FmlyInst.Parameters)
        //    {
        //        if (Param.IsReadOnly == false)
        //        {
        //            switch (Param.Definition.Name.ToLower() ?? "")
        //            {
        //                case "family":
        //                    break;

        //                case "family and type":
        //                    break;

        //                case "type":
        //                    break;

        //                case "image":
        //                    break;

        //                case "level":
        //                    break;

        //                case "material":
        //                    break;

        //                case "moves with nearby elements":
        //                    break;

        //                case "phase created":
        //                    break;

        //                case "phase demolished":
        //                    break;

        //                default:
        //                    ParamLst.Add(Param.Definition.Name);
        //                    break;
        //            }

        //        }
        //    }
        //}

        //ParamLst = ParamLst.Distinct().OrderBy(paramName => paramName).ToList();
        //foreach (var paramName in ParamLst)
        //    // catList += vbLf + catName
        //    cboParameters.Items.Add(paramName);


        foreach (var paramName in Util.GetInstanceParametersByCategoryInActiveView(cboCategories.SelectedItem.ToString()))
            cboParameters.Items.Add(paramName);
        
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
