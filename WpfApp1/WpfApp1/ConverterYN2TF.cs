using System;
using System.Windows.Data;

namespace WpfApp1
{
    [ValueConversion(typeof(string),typeof(bool?))]
    class ConverterYN2TF : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string str = System.Convert.ToString(value);
            switch (str)
            {
                case"Y":
                    return true;
                case"N":
                    return false;
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? b = System.Convert.ToBoolean(value);
            switch (b)
            {
                case true:
                    return "Y";
                case false:
                    return "N";
                default:
                    return "Null";
            }
        }
    }
}
