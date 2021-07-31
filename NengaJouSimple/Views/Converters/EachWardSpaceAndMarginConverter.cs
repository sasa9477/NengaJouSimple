using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace NengaJouSimple.Views.Converters
{
    public class EachWardSpaceAndMarginConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double dValue)
            {
                return new Thickness(dValue, 0, dValue, 0);
            }

            return new Thickness();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Thickness tValue)
            {
                return tValue.Left;
            }

            return 0.0;
        }
    }
}
