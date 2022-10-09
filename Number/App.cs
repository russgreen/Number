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

    private readonly string _tabName = "RG Tools";

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }

    public Result OnStartup(UIControlledApplication application)
    {
        CachedUiCtrApp = application;
        var ribbonPanel = CreateRibbonPanel();

        Syncfusion.Licensing.SyncfusionLicenseProvider
            .RegisterLicense("##SyncfusionLicense##");

        return Result.Succeeded;
    }

    private RibbonPanel CreateRibbonPanel()
    {
        try
        {
            CachedUiCtrApp.CreateRibbonTab(_tabName);
        }
        catch { }

        RibbonPanel panel = CachedUiCtrApp.CreateRibbonPanel(_tabName, Guid.NewGuid().ToString());
        panel.Title = "Number";

        PushButtonData pbDataNumber = new PushButtonData("Number", $"Number{Environment.NewLine}Objects", Assembly.GetExecutingAssembly().Location, "Number.cmdNumber");
        PushButton pbNumber = (PushButton)panel.AddItem(pbDataNumber);
        pbNumber.ToolTip = "Number items in order by clicking on them in turn. Esc to finish.";
        pbNumber.LargeImage = PngImageSource("Number.Images.Number32.png");

        PushButtonData pbDataNumberText = new PushButtonData("NumberText", $"Number{Environment.NewLine}Text", Assembly.GetExecutingAssembly().Location, "Number.cmdNumberText");
        PushButton pbNumberText  = (PushButton)panel.AddItem(pbDataNumberText);
        pbNumberText.ToolTip = "Number text strings in order by clicking on them in turn. Esc to finish.";
        pbNumberText.LargeImage = PngImageSource("Number.Images.NumberText32.png");

        ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, @"https://github.com/russgreen/Number");
        pbNumber.SetContextualHelp(contextHelp);
        pbNumberText.SetContextualHelp(contextHelp);     

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
