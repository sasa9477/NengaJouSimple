using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace NengaJouSimple.Views.ValidationRules
{
    public class MailWardValidationRule : ValidationRule
    {
        private static readonly Regex MailWardRegex = new Regex(@"^[0-9]{3}$");

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            return MailWardRegex.IsMatch(value as string) ? ValidationResult.ValidResult : new ValidationResult(false, "必須入力");
        }
    }
}
