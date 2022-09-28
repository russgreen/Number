﻿using Autodesk.Revit.UI;
using System;
using System.Windows.Forms;

namespace Number;
public partial class FormNumberGrid : Form
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
    }  

    private void LoadCategories()
    {
        try
        {
            foreach (var catName in Util.GetCategoriesInActiveView())
                comboBoxCategories.Items.Add(catName);

            comboBoxCategories.SelectedIndex = 0;
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

        foreach (var paramName in Util.GetInstanceParametersByCategoryInActiveView(comboBoxCategories.SelectedItem.ToString()))
            comboBoxParameters.Items.Add(paramName);

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

    private void ConfigureControls()
    {
        
    }
}