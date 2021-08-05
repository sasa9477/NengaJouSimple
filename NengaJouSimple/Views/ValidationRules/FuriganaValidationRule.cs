using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace NengaJouSimple.Views.ValidationRules
{
    public class FuriganaValidationRule : ValidationRule
    {
        private static readonly Regex FuriganaRegex = new Regex(@"^[\uff65-\uff9f|\u30a1-\u30fc]*$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return FuriganaRegex.IsMatch(value as string) ? ValidationResult.ValidResult : new ValidationResult(false, "カナ入力のみ");
        }
    }
}
