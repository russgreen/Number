using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Number.Controllers;
internal class CommandAvailabilityActiveModelView : IExternalCommandAvailability
{
    public bool IsCommandAvailable(UIApplication applicationData, CategorySet selectedCategories)
    {
        if (applicationData.ActiveUIDocument != null &&
            applicationData.ActiveUIDocument.Document.ActiveView != null &&
            applicationData.ActiveUIDocument.Document.ActiveView.ViewType != ViewType.ProjectBrowser &&
            applicationData.ActiveUIDocument.Document.ActiveView.ViewType != ViewType.Schedule)
        {
            return true;
        }

        return false;
    }
}
