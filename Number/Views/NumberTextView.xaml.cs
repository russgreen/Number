﻿using System;
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

namespace Number.Views
{
    /// <summary>
    /// Interaction logic for NumberTextView.xaml
    /// </summary>
    public partial class NumberTextView : Window
    {
        private readonly ViewModels.NumberTextViewModel _viewModel; public NumberTextView()
        {
            InitializeComponent();

            var _ = new Microsoft.Xaml.Behaviors.DefaultTriggerAttribute(typeof(Trigger), typeof(Microsoft.Xaml.Behaviors.TriggerBase), null);

            _viewModel = (ViewModels.NumberTextViewModel)this.DataContext;
            _viewModel.ClosingRequest += (sender, e) => this.Close();
        }
    }
}
