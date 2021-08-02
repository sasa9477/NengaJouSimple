using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Layouts
{
    public static class AvailableFontFamily
    {
        public static List<(string EnglishName, string JapaneseName)> AvailableFontFamilies = new List<(string, string)>
        {
            ( "Yu Mincho - SemiBold", "游明朝" ),
            ( "Yu Gothic UI", "游ゴシック" ),
            ( "UD Digi Kyokasho NK-R", "UD デジタル 教科書体 NK-R" ),
            ( "BIZ UDGothic", "BIZ UDゴシック" ),
        };
    }
}
