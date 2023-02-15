using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;

namespace Number.SelectionFilters;
internal class CategorySelectionFilter : ISelectionFilter
{
    private string _categoryName;

    public CategorySelectionFilter(string categoryName)
    {
        _categoryName = categoryName;
    }

    public bool AllowElement(Element element)
    {
        if (element.Category != null && element.Category.Name == _categoryName)
        {
            return true;
        }
        return false;
    }

    public bool AllowReference(Reference reference, XYZ position)
    {
        return true;
    }
}
