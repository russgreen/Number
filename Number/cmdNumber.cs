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

namespace Number;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
public class cmdNumber : IExternalCommand
{
    private UIApplication _uiapp;
    private Autodesk.Revit.ApplicationServices.Application _app;
    private UIDocument _uidoc;
    private Selection _sel;
    private Document _doc;
    private Util _util = new Util();

    /// <summary>
    /// Commmand entry point
    /// </summary>
    /// <param name="commandData"></param>
    /// <param name="message"></param>
    /// <param name="elements"></param>
    /// <returns></returns>
    public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
    {
        try
        {
            // Add Your Code Here
            _uiapp = commandData.Application;
            _app = _uiapp.Application;
            _uidoc = _uiapp.ActiveUIDocument;
            _sel = _uidoc.Selection;
            _doc = _uidoc.Document;

            App.revitDocument = _doc; //the revit doc ref used throughout all UI elments

            var frm = new FormNumber(commandData);
            if(frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Number(
                    frm.numberFrom,
                    frm.prefix,
                    frm.suffix,
                    frm.parameterName,
                    frm.categoryName,
                    frm.checkBoxIsolate.Checked,
                    frm.checkBoxColour.Checked,
                    frm.checkBoxDupMark.Checked);

            // Return Success
            return Result.Succeeded;
            }
          
            return Result.Cancelled;
        }
        catch
        {
            return Result.Failed;
        }
    }

    private void Number(int number, string prefix, string suffix, string paramName, string catName, bool isolate = false, bool colorize = true, bool supressDuplicates = true)
    {
        IList<Element> elems = new List<Element>();

        var ogsClear = new OverrideGraphicSettings();
        var ogs = new OverrideGraphicSettings();
        var red = new Color(255, 0, 0);
        ogs.SetProjectionLineColor(red);

        var fillPatternElements = new FilteredElementCollector(_doc).OfClass(typeof(FillPatternElement)).OfType<FillPatternElement>().OrderBy(fp => fp.Name).ToList();
        var fillPatterns = fillPatternElements.Select(fpe => fpe.GetFillPattern());
        string solidName = "<Solid fill>";

        foreach (FillPattern fp in fillPatterns)
        {
            if (fp.IsSolidFill == true)
            {
                // we have the solid fill
                solidName = fp.Name;
                break;
            }
        }

        var solidFill = new FilteredElementCollector(_doc).OfClass(typeof(FillPatternElement)).Where(q => q.Name.Contains(solidName)).First();

#if REVIT2018 //|| REVIT2019
        ogs.SetProjectionFillPatternId(solidFill.Id);
        ogs.SetProjectionFillColor(new Color(0, 255, 0));
#else
        ogs.SetSurfaceForegroundPatternId(solidFill.Id);
        ogs.SetSurfaceForegroundPatternColor(new Color(0, 255, 0));
#endif

            try
            {
                if (isolate == true)
                {
                    // temporarily isolate model category selected
                    IList<ElementId> ids = new List<ElementId>();

                    // IsolateCategoriesTemporary
                    // select all elements in the active view  
                    var allInView = new FilteredElementCollector(_doc, _doc.ActiveView.Id);
                    allInView.WhereElementIsNotElementType();

                    // use LINQ to collect the category names of all elements whilst ensuring that category is not null  
                    var cats = from elem in allInView
                               where elem.Category is object
                               select elem.Category;
                    foreach (Category cat in cats)
                    {
                        if (cat.Name.ToLower().Contains("tags") == true | cat.Name.ToLower().Contains(catName.ToLower()) == true)
                        {
                            ids.Add(cat.Id);
                        }
                    }

                    using (var t = new Transaction(_doc, "Start Temp View"))
                    {
                        t.Start();
                        _doc.ActiveView.IsolateCategoriesTemporary(ids);
                        t.Commit();
                    }

                }

                // Transaction
                using (var t = new Transaction(_doc, "Modify Parameter"))
                {
                    do
                    {
                        t.Start();
                        var elem = _doc.GetElement(_sel.PickObject(ObjectType.Element));
                        if (supressDuplicates == true)
                        {
                            var failOpt = t.GetFailureHandlingOptions();
                            failOpt.SetFailuresPreprocessor(new WarningSwallower());
                            t.SetFailureHandlingOptions(failOpt);
                        }

                        // Get the Parameter
                        Parameter m_p;
                        m_p = Util.FindParameterByName(ref elem, paramName);
                        if (m_p is object)
                        {
                            // Helper
                            var m_param = new ParameterHelper(m_p);

                            // Change the Value
                            try
                            {
                                m_param.Value = prefix + number.ToString() + suffix;
                            }
                            catch
                            {
                                m_param.Value = number.ToString();
                            }

                            number = number + 1;
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
                    if (isolate == true)
                    {
                        _doc.ActiveView.DisableTemporaryViewMode(TemporaryViewMode.TemporaryHideIsolate);
                    }

                    if (colorize == true)
                    {
                        foreach (var e in elems)
                            _doc.ActiveView.SetElementOverrides(e.Id, ogsClear);
                    }

                    t.Commit();
                }
            }

            // Return Result.Cancelled
            catch (Exception ex)
            {
                //return Result.Failed;
            }

    }
}
