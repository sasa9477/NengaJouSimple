using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace NengaJouSimple.Views.ValidationRules
{
    public class PostalCodeValidationRule : ValidationRule
    {
        private static readonly Regex PostalCodeRegex = new Regex(@"^[0-9]{3}(-?)[0-9]{4}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return PostalCodeRegex.IsMatch(value as string) ? ValidationResult.ValidResult : new ValidationResult(false, "必須入力");
        }
    }
}
