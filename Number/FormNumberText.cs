using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number;

public partial class FormNumberText : Form
{
    public int numberFrom;
    public string prefix;
    public string suffix;

    public FormNumberText()
    {
        InitializeComponent();
    }

    private void btnNumber_Click(object sender, EventArgs e)
    {
        numberFrom = (int)Math.Round(nudStartFrom.Value);
        prefix = txtPrefix.Text;
        suffix = txtSuffix.Text;

        this.DialogResult = DialogResult.OK;
        this.Close();
    }
}
