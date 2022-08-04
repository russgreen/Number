using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class cmdNumberGrid : IExternalCommand
{
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        UIApplication uiapp;
        UIDocument uidoc;
        Autodesk.Revit.ApplicationServices.Application app;
        Document doc;
        uiapp = commandData.Application;
        uidoc = uiapp.ActiveUIDocument;
        app = uiapp.Application;
        doc = uidoc.Document;

        App.revitDocument = doc; //the revit doc ref used throughout all UI elments

        try
        {
            // add a showdialog watcheer
            uiapp.DialogBoxShowing += AppDialogShowing;
            
            //show the main dialog
            var frm = new FormNumberGrid(commandData);
            //var proc = Process.GetCurrentProcess();
            //var h = proc.MainWindowHandle;
            //frm.ShowDialog(new WindowHandle(h));
            frm.ShowDialog();
            
            // Return Success
            return Result.Succeeded;
        }
        catch (Exception ex)
        {
            message = ex.Message;
            return Result.Failed;
            throw;
        }
        finally
        {
            uiapp.DialogBoxShowing -= AppDialogShowing;
        }
            
    }

    private void AppDialogShowing(object sender, Autodesk.Revit.UI.Events.DialogBoxShowingEventArgs args)
    {
        // Get the help id of the showing dialog
        string dialogId = args.DialogId;

        Debug.WriteLine("DialogID : " + dialogId.ToString());
        // Format the prompt information string
        args.OverrideResult(1);
    }
}
