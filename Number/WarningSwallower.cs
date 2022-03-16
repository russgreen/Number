using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace Number;

public class WarningSwallower : IFailuresPreprocessor
{
    private List<FailureSeverity> FailureSeverityList
    {
        get
        {
            var list = new List<FailureSeverity>();
            list.Add(FailureSeverity.Warning);
            list.Add(FailureSeverity.Error);
            return list;
        }
    }

    public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
    {
        var msgAccessorList = failuresAccessor.GetFailureMessages();
        foreach (FailureMessageAccessor msgAccessor in msgAccessorList)
        {
            string tranName = failuresAccessor.GetTransactionName();
            string message = msgAccessor.GetDescriptionText().ToString().ToLower();
            if (message.Contains("elements have duplicate") == true | message.Contains("number is already in use") == true)
            {
                failuresAccessor.DeleteWarning(msgAccessor);
            }
        }

        return FailureProcessingResult.Continue;
    }
}
