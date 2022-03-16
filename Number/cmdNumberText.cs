using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Number;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class cmdNumberText : IExternalCommand
{
    private UIApplication _uiapp;
    private Autodesk.Revit.ApplicationServices.Application _app;
    private UIDocument _uidoc;
    private Selection _sel;
    private Document _doc;
    private Util _util = new Util();

    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        try
        {
            _uiapp = commandData.Application;
            _app = _uiapp.Application;
            _uidoc = _uiapp.ActiveUIDocument;
            _sel = _uidoc.Selection;
            _doc = _uidoc.Document;

            var frm = new FormNumberText();
            if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                NumberText(
                    frm.numberFrom,
                    frm.prefix,
                    frm.suffix,
                    frm.chkColour.Checked);

                return Result.Succeeded;
            }

            return Result.Cancelled;
        }
        catch
        {
            return Result.Failed;
        }
    }

    private void NumberText(int number, string prefix, string suffix, bool colorize = false)
    {
        var tnFilter = new TextNotePickFilter();
        IList<Element> elems = new List<Element>();

        var ogsClear = new OverrideGraphicSettings();
        var ogs = new OverrideGraphicSettings();
        var red = new Color(255, 0, 0);
        ogs.SetProjectionLineColor(red);

        var fillPatternElements = new FilteredElementCollector(_doc).OfClass(typeof(FillPatternElement)).OfType<FillPatternElement>().OrderBy(fp => fp.Name).ToList();
        var fillPatterns = fillPatternElements.Select(fpe => fpe.GetFillPattern());
        string SolidName = "<Solid fill>";

        foreach (FillPattern fp in fillPatterns)
        {
            if (fp.IsSolidFill == true)
            {
                // we have the solid fill
                SolidName = fp.Name;
                break;
            }
        }

        var solidFill = new FilteredElementCollector(_doc).OfClass(typeof(FillPatternElement)).Where(q => q.Name.Contains(SolidName)).First();

#if REVIT2018 //|| REVIT2019
        ogs.SetProjectionFillPatternId(solidFill.Id);
        ogs.SetProjectionFillColor(new Color(0, 255, 0));
#else
        ogs.SetSurfaceForegroundPatternId(solidFill.Id);
        ogs.SetSurfaceForegroundPatternColor(new Color(0, 255, 0));
#endif
        try
        {
            using (var t = new Transaction(_doc, "Update Text"))
            {
                do
                {
                    t.Start();
                    string newString = prefix + number.ToString() + suffix;
                    var elem = _doc.GetElement(_sel.PickObject(ObjectType.Element, tnFilter, "Select text notes to place number values"));

                    // SET THE TXT VALUE HERE
                    if (elem is object)
                    {
                        TextNote tn = (TextNote)elem;
                        tn.Text = newString;
                        number++;
                        if (colorize == true)
                        {
                            _doc.ActiveView.SetElementOverrides(elem.Id, ogs);
                            elems.Add(elem);
                        }
                    }

                    t.Commit();
                }
                while (true);
            }
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException generatedExceptionName)
        {
            using (var t = new Transaction(_doc, "End Temp View"))
            {
                t.Start();
                if (colorize == true)
                {
                    foreach (var e in elems)
                        _doc.ActiveView.SetElementOverrides(e.Id, ogsClear);
                }

                t.Commit();
            }
        }
        catch
        {

        }

    }
}
