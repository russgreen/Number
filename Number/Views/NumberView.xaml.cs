using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Number.Views;
/// <summary>
/// Interaction logic for NumberView.xaml
/// </summary>
public partial class NumberView : Window
{
    private readonly ViewModels.NumberViewModel _viewModel;
    public NumberView()
    {
        InitializeComponent();

        _viewModel = (ViewModels.NumberViewModel)this.DataContext;
        _viewModel.ClosingRequest += (sender, e) => this.Close();


    }
}
