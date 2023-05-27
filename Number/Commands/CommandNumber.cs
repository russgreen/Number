using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Number.Commands;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class CommandNumber : IExternalCommand
{
    /// <summary>
    /// Commmand entry point
    /// </summary>
    /// <param name="commandData"></param>
    /// <param name="message"></param>
    /// <param name="elements"></param>
    /// <returns></returns>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        App.CachedUiApp = commandData.Application;
        App.RevitDocument = commandData.Application.ActiveUIDocument.Document;

        var newView = new Views.NumberView();
        newView.ShowDialog();

        return Result.Succeeded;
    }
}
