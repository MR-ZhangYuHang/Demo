using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfApp1
{
    class SubmitEnableConverter : IMultiValueConverter 
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //return !values.Cast<string>().Any(text => string.IsNullOrEmpty(text));
            if (!values.Cast<string>().Any(text=>string.IsNullOrEmpty(text))&&values[0].ToString()==values[1].ToString()&&values[2].ToString()==values[3].ToString())
            {
                return true;
            }
            return false;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
