using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Number.PickFilters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Number.ViewModels;

internal partial class NumberTextViewModel : BaseViewModel
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Sample))]
    private string _prefix;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Sample))]
    private int _number = 1;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Sample))]
    private string _suffix;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(Sample))]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Provide at least one character. Only zeros (0) are allowed.")]
    [MinLength(1)]
    [RegularExpressionAttribute(@"[0]+")]
    private string _numberFormat = "000";

    [ObservableProperty]
    private bool _colourPickedElements = true;

    [ObservableProperty]
    private System.Windows.Visibility _isWindowVisible;

    private Selection _selection;

    private string _formattedNumberString => Number.ToString(NumberFormat);

    public string Sample => $"{Prefix}{_formattedNumberString}{Suffix}";

    public NumberTextViewModel()
    {
        _selection = App.CachedUiApp.ActiveUIDocument.Selection;
    }

    [RelayCommand]
    private void NumberText()
    {
        IsWindowVisible = System.Windows.Visibility.Hidden;

        Numbering();

        this.OnClosingRequest();
        return;
    }

    private void Numbering()
    {
        var pickFilter = new TextNotePickFilter();
        IList<Element> elems = new List<Element>();

        var ogsClear = new OverrideGraphicSettings();
        var ogs = new OverrideGraphicSettings();
        var red = new Color(255, 0, 0);
        ogs.SetProjectionLineColor(red);

        var fillPatternElements = new FilteredElementCollector(App.RevitDocument)
            .OfClass(typeof(FillPatternElement))
            .OfType<FillPatternElement>()
            .OrderBy(fp => fp.Name)
            .ToList();

        var fillPatterns = fillPatternElements.Select(fpe => fpe.GetFillPattern());
        string SolidName = "<Solid fill>";

        foreach (FillPattern fp in fillPatterns)
        {
            if (fp.IsSolidFill == true)
            {
                // we have the solid fill
                SolidName = fp.Name;
                break;
            }
        }

        var solidFill = new FilteredElementCollector(App.RevitDocument)
            .OfClass(typeof(FillPatternElement))
            .Where(q => q.Name.Contains(SolidName))
            .First();

#if REVIT2018 //|| REVIT2019
        ogs.SetProjectionFillPatternId(solidFill.Id);
        ogs.SetProjectionFillColor(new Color(0, 255, 0));
#else
        ogs.SetSurfaceForegroundPatternId(solidFill.Id);
        ogs.SetSurfaceForegroundPatternColor(new Color(0, 255, 0));
#endif

        try
        {
            using (var t = new Transaction(App.RevitDocument, "Update Text"))
            {
                do
                {
                    t.Start();

                    string newString = $"{Prefix}{_formattedNumberString}{Suffix}";
                    var elem = App.RevitDocument.GetElement(_selection.PickObject(ObjectType.Element, pickFilter, "Select text notes to place number values"));

                    // SET THE TXT VALUE HERE
                    if (elem is object)
                    {
                        TextNote textNote = (TextNote)elem;
                        textNote.Text = newString;

                        Number++;

                        if (ColourPickedElements == true)
                        {
                            App.RevitDocument.ActiveView.SetElementOverrides(elem.Id, ogs);
                            elems.Add(elem);
                        }
                    }

                    t.Commit();
                }
                while (true);
            }
        }
        catch (Autodesk.Revit.Exceptions.OperationCanceledException generatedExceptionName)
        {
            using (var t = new Transaction(App.RevitDocument, "End Temp View"))
            {
                t.Start();
                if (ColourPickedElements == true)
                {
                    foreach (var e in elems)
                    {
                        App.RevitDocument.ActiveView.SetElementOverrides(e.Id, ogsClear);
                    }

                }

                t.Commit();
            }
        }
        catch
        {

        }

    }
}
