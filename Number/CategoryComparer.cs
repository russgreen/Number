using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number;
internal class CategoryComparer : IEqualityComparer<Category>
{
    #region Implementation of IEqualityComparer<in Category>

    public bool Equals(Category x, Category y)
    {
        if (x == null || y == null) return false;

        return x.Id.Equals(y.Id);
    }

    public int GetHashCode(Category obj)
    {
        return obj.Id.IntegerValue;
    }

    #endregion
}
