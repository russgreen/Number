using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Nice3point.Revit.Extensions;

namespace Number;

public class Util
{

    public static Parameter FindParameterByName(ref Element element, string Definition)
    {
        Parameter foundParameter = null;
        // This will find the first parameter that measures length
        foreach (Parameter parameter in element.Parameters)
        {
            if ((parameter.Definition.Name ?? "") == (Definition ?? ""))
            {
                foundParameter = parameter;
                break;
            }
        }

        return foundParameter;
    }

    /// <summary>
    /// Return a string for a real number
    /// formatted to two decimal places.
    /// </summary>
    public static string RealString(double a)
    {
        return a.ToString("0.##");
    }
    
    public static List<Category> GetCategoriesInActiveView()
    {
        // select all elements in the active view
        var allInView = new FilteredElementCollector(
            App.revitDocument,
            App.revitDocument.ActiveView.Id);

        allInView.WhereElementIsNotElementType();

        //get distinct categories of elements in the active view
        var categories = allInView
                            .ToElements()
                            .Select(x => x.Category)
                            .Distinct(new CategoryComparer())
                            .Where(x => x != null)
                            .Where(x => x.Name.ToLower().Contains("<room separation>") == false)
                            .Where(x => x.Name.ToLower().Contains("sheets") == false)
                            .Where(x => x.Name.ToLower().Contains("schedule graphics") == false)
                            .Where(x => x.Name.ToLower().Contains("lines") == false)
                            .Where(x => x.Name.ToLower().Contains("legends") == false)
                            .Where(x => x.Name.ToLower().Contains("title blocks") == false)
                            .Where(x => x.Name.ToLower().Contains("tags") == false)
                            .Where(x => x.Name.ToLower().Contains("dimensions") == false)
                            .Where(x => x.Name.ToLower().Contains("text") == false)
                            .Where(x => x.Name.ToLower().Contains("cameras") == false)
                            .Where(x => x.Name.ToLower().Contains("elevations") == false)
                            .Where(x => x.Name.ToLower().Contains("sections") == false)
                            .Where(x => x.Name.ToLower().Contains("views") == false)
                            .OrderBy(x => x.Name)
                            .ToList();

        return categories.ToList();
    }

    public static List<FamilyInstance> GetFamilyInstancesByCategoryInActiveView(string categoryName)
    {
        // get family instances in the active view
        var allInView = new FilteredElementCollector(App.revitDocument, App.revitDocument.ActiveView.Id);
        var faminstFilter = new ElementClassFilter(typeof(FamilyInstance));
        allInView.WherePasses(faminstFilter);

        // get the family instances in the active view that are of the specified category
        var faminstInView = from instance in allInView
                            where (instance.Category.Name ?? "") == (categoryName ?? "")
                            select instance;
        var familyInstances = faminstInView.Cast<FamilyInstance>().ToList();

        return familyInstances.ToList<FamilyInstance>();
    }

    public static List<string> GetInstanceParametersByCategoryInActiveView(string categoryName)
    {
        var familyInstances = GetFamilyInstancesByCategoryInActiveView(categoryName);

        //var elements = App.revitDocument
        //    .GetElements(App.revitDocument.ActiveView.Id)
        //    .ToElements();

        //var elements1 = App.revitDocument
        //    .GetElements(App.revitDocument.ActiveView.Id)
        //    .ToElements()
        //    .Where(x => x.Category.Name == categoryName);

        //var instances = App.revitDocument
        //    .GetInstances(App.revitDocument.ActiveView.Id);

        // get the instance parameters of the family instances
        var instanceParameters = new List<string>();

        foreach (FamilyInstance instance in familyInstances)
        {
            foreach (Parameter parameter in instance.Parameters)
            {
                //if parameter.IsReadonly is not false
                
                if (parameter.IsReadOnly == false)
                {
                    switch (parameter.Definition.Name.ToLower() ?? "")
                    {
                        case "family":
                            break;

                        case "family and type":
                            break;

                        case "type":
                            break;

                        case "image":
                            break;

                        case "level":
                            break;

                        case "material":
                            break;

                        case "moves with nearby elements":
                            break;

                        case "phase created":
                            break;

                        case "phase demolished":
                            break;

                        default:
                            instanceParameters.Add(parameter.Definition.Name);
                            break;
                    }
                }                    
            }
        }

        return instanceParameters
            .Distinct()
            .OrderBy(parameterName => parameterName)
            .ToList();
    }

   public static List<string> GetCategoryParameters(ElementId catID)
    {
        if (catID == null) return null;

        var parameters = new List<string>();

        using (Transaction tr = new Transaction(App.revitDocument, "make_schedule"))
        {
            tr.Start();
            // Create schedule
            ViewSchedule vs = ViewSchedule.CreateSchedule(App.revitDocument, catID);
            App.revitDocument.Regenerate();

            // Find schedulable fields
            foreach (SchedulableField sField in vs.Definition.GetSchedulableFields())
            {
                if (sField.FieldType != ScheduleFieldType.ElementType) continue;
                parameters.Add(sField.GetName(App.revitDocument));
            }
            tr.RollBack();
        }
        return parameters;
    }

    public static List<ElementId> GetCategoryParameters(Category cat)
    {
        if (cat == null) return null;

        List<ElementId> paramIds = new List<ElementId>();

        using (Transaction tr = new Transaction(App.revitDocument, "make_schedule"))
        {
            tr.Start();
            // Create schedule
            ViewSchedule vs = ViewSchedule.CreateSchedule(App.revitDocument, cat.Id);
            App.revitDocument.Regenerate();

            // Find schedulable fields
            foreach (SchedulableField sField in vs.Definition.GetSchedulableFields())
            {
                if (sField.FieldType != ScheduleFieldType.ElementType) continue;
                paramIds.Add(sField.ParameterId);
            }
            tr.RollBack();
        }
        return paramIds;
    }


}
