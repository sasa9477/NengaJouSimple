using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Addresses
{
    public static class HonorificViewModel
    {
        public static List<string> Items => new List<string> { "", "様", "さん", "くん", "ちゃん" };

        public static string DefalutHonorific => Items[1];
    }
}
