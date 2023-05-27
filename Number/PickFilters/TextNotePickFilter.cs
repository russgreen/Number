using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;


namespace Number.PickFilters;

public class TextNotePickFilter : ISelectionFilter
{
    public bool AllowElement(Element elem)
    {
        TextNote tn = elem as TextNote;
        if (tn is null)
        {
            return false;
        }

        return true;
    }

    public bool AllowReference(Reference reference, XYZ position)
    {
        throw new NotImplementedException();
    }
}
