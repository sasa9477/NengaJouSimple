using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace NengaJouSimple.Views.ValidationRules
{
    public class AddressNumber2ValidationRule : ValidationRule
    {
        private static readonly Regex addressNumber2Regex = new Regex(@"^[0-9]{4}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return addressNumber2Regex.IsMatch((string)value) ? ValidationResult.ValidResult : new ValidationResult(false, "");
        }
    }
}
