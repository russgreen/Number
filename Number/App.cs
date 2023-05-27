using System;
using System.Reflection;
using System.Windows.Media.Imaging;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace Number;

[Transaction(TransactionMode.Manual)]
[Regeneration(RegenerationOption.Manual)]
class App : IExternalApplication
{
    public static UIControlledApplication CachedUiCtrApp;
    public static UIApplication CachedUiApp;
    public static Autodesk.Revit.DB.Document RevitDocument;

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }

    public Result OnStartup(UIControlledApplication application)
    {
        CachedUiCtrApp = application;
        var ribbonPanel = CreateRibbonPanel();

        return Result.Succeeded;
    }

    private RibbonPanel CreateRibbonPanel()
    {
        RibbonPanel panel = CachedUiCtrApp.CreateRibbonPanel(nameof(Number));
        panel.Title = "Number";

        PushButtonData pushButtonDataNumber = new PushButtonData(
            nameof(Number.Commands.CommandNumber), 
            $"Number{Environment.NewLine}Objects", 
            Assembly.GetExecutingAssembly().Location,
            $"{nameof(Number)}.{nameof(Number.Commands)}.{nameof(Number.Commands.CommandNumber)}");
        pushButtonDataNumber.AvailabilityClassName = $"{nameof(Number)}.{nameof(Number.Controllers)}.{nameof(Number.Controllers.CommandAvailabilityActiveModelView)}";

        PushButton pushButtonNumber = (PushButton)panel.AddItem(pushButtonDataNumber);
        pushButtonNumber.ToolTip = "Number items in order by clicking on them in turn. Esc to finish.";
        pushButtonNumber.LargeImage = PngImageSource("Number.Images.Number32.png");

        PushButtonData pushButtonDataNumberText = new PushButtonData(
            nameof(Number.Commands.CommandNumberText), 
            $"Number{Environment.NewLine}Text", 
            Assembly.GetExecutingAssembly().Location,
        $"{nameof(Number)}.{nameof(Number.Commands)}.{nameof(Number.Commands.CommandNumberText)}");
        pushButtonDataNumberText.AvailabilityClassName = $"{nameof(Number)}.{nameof(Number.Controllers)}.{nameof(Number.Controllers.CommandAvailabilityActiveModelView)}";

        PushButton pushButtonNumberText  = (PushButton)panel.AddItem(pushButtonDataNumberText);
        pushButtonNumberText.ToolTip = "Number text strings in order by clicking on them in turn. Esc to finish.";
        pushButtonNumberText.LargeImage = PngImageSource("Number.Images.NumberText32.png");

        ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, @"https://github.com/russgreen/Number");
        pushButtonNumber.SetContextualHelp(contextHelp);
        pushButtonNumberText.SetContextualHelp(contextHelp);     

        return panel;
    }
    
    private System.Windows.Media.ImageSource PngImageSource(string embeddedPath)
    {
        var stream = GetType().Assembly.GetManifestResourceStream(embeddedPath);
        System.Windows.Media.ImageSource imageSource;
        try
        {
            imageSource = BitmapFrame.Create(stream);
        }
        catch
        {
            imageSource = null;
        }

        return imageSource;
    }

}
