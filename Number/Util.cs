using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

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
    
    public static List<string> GetCategoriesInActiveView()
    {
        // select all elements in the active view
        var allInView = new FilteredElementCollector(App.revitDocument, App.revitDocument.ActiveView.Id);
        allInView.WhereElementIsNotElementType();

        // use LINQ to collect the category names of all elements whilst ensuring that category is not null  
        var categoryNames = from elem in allInView
                            where elem.Category is object
                            select elem.Category.Name;

        // strip out duplicates and order the list of category names  
        categoryNames = categoryNames.Distinct().OrderBy(catName => catName);

        var categoryNames1 = from name in categoryNames
                             where name.ToLower().Contains("<room separation>") == false &
                             name.ToLower().Contains("sheets") == false &
                             name.ToLower().Contains("schedule graphics") == false &
                             name.ToLower().Contains("lines") == false &
                             name.ToLower().Contains("title blocks") == false &
                             name.ToLower().Contains("tags") == false &
                             name.ToLower().Contains("dimensions") == false &
                             name.ToLower().Contains("text") == false &
                             name.ToLower().Contains("cameras") == false &
                             name.ToLower().Contains("elevations") == false &
                             name.ToLower().Contains("sections") == false &
                             name.ToLower().Contains("views") == false
                             select name;

        return categoryNames1.ToList<string>();
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

        return instanceParameters.Distinct().OrderBy(parameterName => parameterName).ToList();
    }
}
