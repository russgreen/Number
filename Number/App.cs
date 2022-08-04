﻿using System;
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
    public static Autodesk.Revit.DB.Document revitDocument;

    private readonly string _tabName = "RG Tools";

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
        try
        {
            cachedUiCtrApp.CreateRibbonTab(_tabName);
        }
        catch { }

        RibbonPanel panel = cachedUiCtrApp.CreateRibbonPanel(_tabName, Guid.NewGuid().ToString());
        panel.Title = "Number";

        PushButtonData pbDataNumber = new PushButtonData("Number", "Number objects", Assembly.GetExecutingAssembly().Location, "Number.cmdNumber");
        PushButton pbNumber = (PushButton)panel.AddItem(pbDataNumber);
        pbNumber.ToolTip = "Number items in order by clicking on them in turn. Esc to finish.";
        pbNumber.LargeImage = PngImageSource("Number.Images.Number32.png");

        //PushButtonData pbDataNumberGrid = new PushButtonData("NumberGrid", "Number Grid", Assembly.GetExecutingAssembly().Location, "Number.cmdNumberGrid");
        //PushButton pbNumberGrid = (PushButton)panel.AddItem(pbDataNumberGrid);
        //pbNumberGrid.ToolTip = "Number items in in a datagrid.";
        //pbNumberGrid.LargeImage = PngImageSource("Number.Images.Number32.png");

        PushButtonData pbDataNumberText = new PushButtonData("NumberText", "Number text", Assembly.GetExecutingAssembly().Location, "Number.cmdNumberText");
        PushButton pbNumberText  = (PushButton)panel.AddItem(pbDataNumberText);
        pbNumberText.ToolTip = "Number text strings in order by clicking on them in turn. Esc to finish.";
        pbNumberText.LargeImage = PngImageSource("Number.Images.Number32.png");

        //PushButtonData pbDataAutoNumberRooms = new PushButtonData("NumberRooms", "Number rooms", Assembly.GetExecutingAssembly().Location, "Number.cmdAutoNumberRooms");
        //PushButton pbAutoNumberRooms = (PushButton)panel.AddItem(pbDataAutoNumberRooms);
        //pbAutoNumberRooms.ToolTip = "Automatically number rooms";
        //pbAutoNumberRooms.LargeImage = PngImageSource("Number.Images.Number32.png");

        ContextualHelp contextHelp = new ContextualHelp(ContextualHelpType.Url, @"C:\ProgramData\Autodesk\ApplicationPlugins\RG Number.bundle\Contents\Number.htm");
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
