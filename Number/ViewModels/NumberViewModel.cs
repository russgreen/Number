using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Nice3point.Revit.Extensions;
using System.ComponentModel.DataAnnotations;
using Number.SelectionFilters;

namespace Number.ViewModels;

internal partial class NumberViewModel : BaseViewModel
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
    private List<Category> _categories;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required]
    private Category _selectedCategory;

    [ObservableProperty]
    private List<Parameter> _parameters;

    [ObservableProperty]
    private List<string> _parameterNames;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(NumberEnabled))]
    [NotifyDataErrorInfo]
    [Required]
    private Parameter _selectedParameter;

    [ObservableProperty]
    private bool _supressDuplicateMarkValues = false;

    [ObservableProperty]
    private bool _isMarkParameter = false;

    [ObservableProperty]
    private bool _isolateModelCategoryInView = true;

    [ObservableProperty]
    private bool _colourPickedElements = true;

    [ObservableProperty]
    private System.Windows.Visibility _isWindowVisible;

    private Selection _selection;

    private string _formattedNumberString => Number.ToString(NumberFormat);

    public bool NumberEnabled => SelectedParameter != null;

    public string Sample => $"{Prefix}{_formattedNumberString}{Suffix}";

    public NumberViewModel()
    {
        _selection = App.CachedUiApp.ActiveUIDocument.Selection;

        LoadCategories();

        LoadParameters();
    }

    private void LoadCategories()
    {
        Categories = Util.GetCategoriesInActiveView()
                            .Where(x => x.Name.ToLower().Contains("<room separation>") == false)
                            .Where(x => x.Name.ToLower().Contains("sheets") == false)
                            .Where(x => x.Name.ToLower().Contains("schedule graphics") == false)
                            .Where(x => x.Name.ToLower().Contains("lines") == false)
                            .Where(x => x.Name.ToLower().Contains("legends") == false)
                            .Where(x => x.Name.ToLower().Contains("title blocks") == false)
                            .Where(x => x.Name.ToLower().Contains("tags") == false)
                            .Where(x => x.Name.ToLower().Contains("dimensions") == false)
                            .Where(x => x.Name.ToLower().Contains("text") == false)
                            .Where(x => x.Name.ToLower().Contains("cameras") == false)
                            .Where(x => x.Name.ToLower().Contains("elevations") == false)
                            .Where(x => x.Name.ToLower().Contains("sections") == false)
                            .Where(x => x.Name.ToLower().Contains("views") == false)
                            .ToList();

        SelectedCategory = Categories.FirstOrDefault();
    }

    [RelayCommand]
    private void LoadParameters()
    {
        if(SelectedCategory != null)
        {
#if REVIT2022_OR_GREATER
            Parameters = Util.GetInstanceParametersByCategoryInActiveView(SelectedCategory.Id)
                .Where(x => x.Definition.GetDataType() == SpecTypeId.String.Text)
                .Where(x => x.Definition.Name.ToLower() != "family name")
                .Where(x => x.Definition.Name.ToLower() != "family and type")
                .Where(x => x.Definition.Name.ToLower() != "type name")
                .Where(x => x.Definition.Name.ToLower() != "host")
                .Where(x => x.Definition.Name.ToLower() != "image")
                .Where(x => x.Definition.Name.ToLower() != "level")
                .ToList();
            
#else
            Parameters = Util.GetInstanceParametersByCategoryInActiveView(SelectedCategory.Id)
                .Where(x => x.Definition.ParameterType == ParameterType.Text)
                .Where(x => x.Definition.Name.ToLower() != "family name")
                .Where(x => x.Definition.Name.ToLower() != "family and type")
                .Where(x => x.Definition.Name.ToLower() != "type name")
                .Where(x => x.Definition.Name.ToLower() != "host")
                .Where(x => x.Definition.Name.ToLower() != "image")
                .Where(x => x.Definition.Name.ToLower() != "level")
                .ToList();
#endif


            SelectedParameter = Parameters.FirstOrDefault();
            CheckIfParameterIsMark();
        }
    }

    [RelayCommand]
    private void CheckIfParameterIsMark()
    {
        if (SelectedParameter != null)
        {
            IsMarkParameter = false;
            SupressDuplicateMarkValues = false;

            if (SelectedParameter.Definition.Name == "Mark")
            {
                IsMarkParameter = true;
                SupressDuplicateMarkValues = true;
            }
        }
    }

    [RelayCommand]
    private void NumberObjects()
    {
        IsWindowVisible = System.Windows.Visibility.Hidden;

        Numbering();

        this.OnClosingRequest();
        return;
    }

    private void Numbering()
    {
        IList<Element> elems = new List<Element>();
        
        var ogsClear = new OverrideGraphicSettings();
        var ogs = new OverrideGraphicSettings();
        var red = new Color(255, 0, 0);
        ogs.SetProjectionLineColor(red);

        //TODO: Change this to the RevitExtenions methods
        var fillPatternElements = new FilteredElementCollector(App.RevitDocument)
            .OfClass(typeof(FillPatternElement))
            .OfType<FillPatternElement>()
            .OrderBy(fp => fp.Name)
            .ToList();

        var fillPatterns = fillPatternElements.Select(fpe => fpe.GetFillPattern());
        string solidName = "<Solid fill>";

        foreach (FillPattern fillPattern in fillPatterns)
        {
            if (fillPattern.IsSolidFill == true)
            {
                // we have the solid fill
                solidName = fillPattern.Name;
                break;
            }
        }

        var solidFill = new FilteredElementCollector(App.RevitDocument)
            .OfClass(typeof(FillPatternElement))
            .Where(q => q.Name.Contains(solidName))
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
            if (IsolateModelCategoryInView == true)
            {
                // temporarily isolate model category selected
                IList<ElementId> ids = new List<ElementId>();

                foreach (Category cat in Util.GetCategoriesInActiveView())
                {
                    if (cat.Name.ToLower().Contains("tags") == true | cat.Name.ToLower().Contains(SelectedCategory.Name.ToLower()) == true)
                    {
                        ids.Add(cat.Id);
                    }
                }

                using (var t = new Transaction(App.RevitDocument, "Start Temp View"))
                {
                    t.Start();

                    App.RevitDocument.ActiveView.IsolateCategoriesTemporary(ids);

                    t.Commit();
                }
            }

            // Transaction
            using (var t = new Transaction(App.RevitDocument, "Modify Parameter"))
            {
                do
                {
                    t.Start();

                    var selectionFilter = new CategorySelectionFilter(SelectedCategory.Name);

                    var elem = App.RevitDocument.GetElement(_selection.PickObject(ObjectType.Element, selectionFilter));

                    if (SupressDuplicateMarkValues == true)
                    {
                        var failOpt = t.GetFailureHandlingOptions();
                        failOpt.SetFailuresPreprocessor(new WarningSwallower());
                        t.SetFailureHandlingOptions(failOpt);
                    }


                    // Get the Parameter
                    Parameter parameter = elem.FindParameter(SelectedParameter.Definition.Name);

                    parameter.Set($"{Prefix}{_formattedNumberString}{Suffix}");

                    if (ColourPickedElements == true)
                    {
                        App.RevitDocument.ActiveView.SetElementOverrides(elem.Id, ogs);
                        elems.Add(elem);
                    }

                    Number++;

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

                if (IsolateModelCategoryInView == true)
                {
                    App.RevitDocument.ActiveView.DisableTemporaryViewMode(TemporaryViewMode.TemporaryHideIsolate);
                }

                if (ColourPickedElements == true)
                {
                    foreach (var e in elems)
                        App.RevitDocument.ActiveView.SetElementOverrides(e.Id, ogsClear);
                }

                t.Commit();
            }
        }

        // Return Result.Cancelled
        catch 
        {
            //return Result.Failed;
        }
    }

}
