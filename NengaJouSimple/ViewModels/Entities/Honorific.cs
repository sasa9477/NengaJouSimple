using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities
{
    public static class Honorific
    {
        public static List<string> Items => new List<string> { "様", "さん", "くん", "ちゃん" };

        public static string FirstItem => Items.First();
    }
}
