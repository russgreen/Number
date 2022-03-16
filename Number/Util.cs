using System;
using System.Collections.Generic;
using System.Diagnostics;
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
}
