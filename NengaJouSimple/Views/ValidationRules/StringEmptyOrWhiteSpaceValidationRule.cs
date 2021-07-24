using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace NengaJouSimple.Views.ValidationRules
{
    public class StringEmptyOrWhiteSpaceValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return !string.IsNullOrWhiteSpace(value as string) ? ValidationResult.ValidResult : new ValidationResult(false, "");
        }
    }
}
