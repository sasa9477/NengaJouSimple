using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Addresses
{
    public static class Honorific
    {
        public static List<string> Honorifics => new List<string> { "", "様", "さん", "くん", "ちゃん" };

        public static string DefalutHonorific => Honorifics[1];
    }
}
