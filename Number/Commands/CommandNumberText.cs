using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Number.Commands;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class CommandNumberText : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {

        App.CachedUiApp = commandData.Application;
        App.RevitDocument = commandData.Application.ActiveUIDocument.Document;

        var newView = new Views.NumberTextView();
        newView.ShowDialog();

        return Result.Succeeded;
    }
}
