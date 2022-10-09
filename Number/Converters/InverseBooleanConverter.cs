﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace Number.Converters;
[ValueConversion(typeof(bool), typeof(bool))]
internal class InverseBooleanConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
     => !(bool?)value ?? true;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
     => !(value as bool?);
}
