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
using Number.Comparers;

namespace Number;

public static class Util
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
            App.RevitDocument,
            App.RevitDocument.ActiveView.Id);

        allInView.WhereElementIsNotElementType();

        //get distinct categories of elements in the active view
        var categories = allInView
                            .ToElements()
                            .Select(x => x.Category)
                            .Distinct(new CategoryComparer())
                            .Where(x => x != null)
                            .OrderBy(x => x.Name)
                            .ToList();

        return categories.ToList();
    }

    public static List<Parameter> GetInstanceParametersByCategoryInActiveView(ElementId catID)
    {
        var instances = App.RevitDocument
            .GetInstances(App.RevitDocument.ActiveView.Id, new ElementCategoryFilter(catID));

        // get the instance parameters of the family instances
        var instanceParameters = new List<Parameter>();

        foreach (var instance in instances)
        {
            foreach (Parameter parameter in instance.Parameters)
            {
                instanceParameters.Add(parameter);
            }
        }

        return instanceParameters
            .Distinct(new ParameterComparer())
            .OrderBy(x => x.Definition.Name)
            .ToList();
    }
}
