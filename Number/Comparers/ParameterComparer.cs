using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace Number.Comparers;
internal class ParameterComparer : IEqualityComparer<Parameter>
{
    public bool Equals(Parameter x, Parameter y)
    {
        if (x == null || y == null) return false;

        return x.Id.Equals(y.Id);
    }

    public int GetHashCode(Parameter obj)
    {
#if REVIT2025_OR_GREATER
        return (int)obj.Id.Value;
#else
        return obj.Id.IntegerValue;
#endif
    }
}
