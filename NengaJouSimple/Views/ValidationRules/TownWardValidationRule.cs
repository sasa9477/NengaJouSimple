using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace NengaJouSimple.Views.ValidationRules
{
    public class TownWardValidationRule : ValidationRule
    {
        private static readonly Regex TownWardRegex = new Regex(@"^[0-9]{4}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return TownWardRegex.IsMatch(value as string) ? ValidationResult.ValidResult : new ValidationResult(false, "");
        }
    }
}
