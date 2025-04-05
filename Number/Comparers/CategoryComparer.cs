using Autodesk.Revit.DB;
using System.Collections.Generic;

namespace Number.Comparers;
internal class CategoryComparer : IEqualityComparer<Category>
{
    public bool Equals(Category x, Category y)
    {
        if (x == null || y == null) return false;

        return x.Id.Equals(y.Id);
    }

    public int GetHashCode(Category obj)
    {
#if REVIT2025_OR_GREATER
        return (int)obj.Id.Value;
#else
        return obj.Id.IntegerValue;
#endif
    }
}
