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
    public static UIControlledApplication cachedUiCtrApp;

    public Result OnShutdown(UIControlledApplication application)
    {
        return Result.Succeeded;
    }

    public Result OnStartup(UIControlledApplication application)
    {
        cachedUiCtrApp = application;
        var ribbonPanel = CreateRibbonPanel();

        return Result.Succeeded;
    }

    private RibbonPanel CreateRibbonPanel()
    {
        RibbonPanel panel;

        // Check if "Archisoft Tools already exists and use if its there
        try
        {
            panel = cachedUiCtrApp.CreateRibbonPanel("Archisoft Tools", Guid.NewGuid().ToString());
            panel.Name = "ARBG_Number_ExtApp";
            panel.Title = "Number";
        }
        catch
        {
            var archisoftPanel = false;
            var pluginPath = @"C:\ProgramData\Autodesk\ApplicationPlugins";
            if (System.IO.Directory.Exists(pluginPath) == true)
            {
                foreach (var folder in System.IO.Directory.GetDirectories(pluginPath))
                {
                    if (folder.ToLower().Contains("archisoft") == true & folder.ToLower().Contains("archisoft number") == false)
                    {
                        archisoftPanel = true;
                        break;
                    }
                }
            }

            if (archisoftPanel == true)
            {
                cachedUiCtrApp.CreateRibbonTab("Archisoft Tools");
                panel = cachedUiCtrApp.CreateRibbonPanel("Archisoft Tools", Guid.NewGuid().ToString());
                panel.Name = "ARBG_Number_ExtApp";
                panel.Title = "Number";
            }
            else
            {
                panel = cachedUiCtrApp.CreateRibbonPanel("Number");
            }
        }

        PushButtonData pbDataNumber = new PushButtonData("Number", "Number objects", Assembly.GetExecutingAssembly().Location, "Number.cmdNumber");
        PushButton pbNumber = (PushButton)panel.AddItem(pbDataNumber);
        pbNumber.ToolTip = "Number items in order by clicking on them in turn. Esc to finish.";
        pbNumber.LargeImage = PngImageSource("Number.Images.Number32.png");

        PushButtonData pbDataNumberText = new PushButtonData("NumberText", "Number text", Assembly.GetExecutingAssembly().Location, "Number.cmdNumberText");
        PushButton pbNumberText  = (PushButton)panel.AddItem(pbDataNumberText);
        pbNumberText.ToolTip = "Number text strings in order by clicking on them in turn. Esc to finish.";
        pbNumberText.LargeImage = PngImageSource("Number.Images.Number32.png");

        //PushButtonData pbDataAutoNumberRooms = new PushButtonData("NumberRooms", "Number rooms", Assembly.GetExecutingAssembly().Location, "Number.cmdAutoNumberRooms");
        //PushButton pbAutoNumberRooms = (PushButton)panel.AddItem(pbDataAutoNumberRooms);
        //pbAutoNumberRooms.ToolTip = "Automatically number rooms";
        //pbAutoNumberRooms.LargeImage = PngImageSource("Number.Images.Number32.png");

        ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, @"C:\ProgramData\Autodesk\ApplicationPlugins\Archisoft Number.bundle\Contents\Number.htm");
        pbNumber.SetContextualHelp(contextHelp);
        pbNumberText.SetContextualHelp(contextHelp);
        //pbAutoNumberRooms.SetContextualHelp(contextHelp);

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
