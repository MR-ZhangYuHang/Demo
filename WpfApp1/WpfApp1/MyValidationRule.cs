using System.Windows.Controls;

namespace WpfApp1
{
    class MyValidationRule : ValidationRule   
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            double d = 0.0;
            if (double.TryParse((string)value, out d) && d >= 20 && d <= 60)
            {
                return new ValidationResult(true, "OK");
            }
            else
                return new ValidationResult(false, "error");
        }
    }
}
