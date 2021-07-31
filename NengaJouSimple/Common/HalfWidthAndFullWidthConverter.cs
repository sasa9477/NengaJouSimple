using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NengaJouSimple.Common
{
    public static class HalfWidthAndFullWidthConverter
    {
        private static readonly Dictionary<char, char> HalfWidthAndFullWidthDictionary = new Dictionary<char, char>
        {
            { '!', '！' }, { '#', '＃' }, { '$', '＄' }, { '%', '％' }, { '&', '＆' }, { '(', '（' }, { ')', '）' }, { '*', '＊' }, { '+', '＋' }, { ',', '，' }, { '-', '－' }, { '.', '．' }, { '/', '／' },
            { '0', '０' }, { '1', '１' }, { '2', '２' }, { '3', '３' }, { '4', '４' }, { '5', '５' }, { '6', '６' }, { '7', '７' }, { '8', '８' }, { '9', '９' }, { ':', '：' }, { ';', '；' }, { '<', '＜' }, { '=', '＝' }, { '>', '＞' }, { '?', '？' },
            { '@', '＠' }, { 'A', 'Ａ' }, { 'B', 'Ｂ' }, { 'C', 'Ｃ' }, { 'D', 'Ｄ' }, { 'E', 'Ｅ' }, { 'F', 'Ｆ' }, { 'G', 'Ｇ' }, { 'H', 'Ｈ' }, { 'I', 'Ｉ' }, { 'J', 'Ｊ' }, { 'K', 'Ｋ' }, { 'L', 'Ｌ' }, { 'M', 'Ｍ' }, { 'N', 'Ｎ' }, { 'O', 'Ｏ' },
            { 'P', 'Ｐ' }, { 'Q', 'Ｑ' }, { 'R', 'Ｒ' }, { 'S', 'Ｓ' }, { 'T', 'Ｔ' }, { 'U', 'Ｕ' }, { 'V', 'Ｖ' }, { 'W', 'Ｗ' }, { 'X', 'Ｘ' }, { 'Y', 'Ｙ' }, { 'Z', 'Ｚ' }, { '[', '［' }, { '\\', '￥' }, { ']', '］' }, { '^', '＾' }, { '_', '＿' },
            { '`', '｀' }, { 'a', 'ａ' }, { 'b', 'ｂ' }, { 'c', 'ｃ' }, { 'd', 'ｄ' }, { 'e', 'ｅ' }, { 'f', 'ｆ' }, { 'g', 'ｇ' }, { 'h', 'ｈ' }, { 'i', 'ｉ' }, { 'j', 'ｊ' }, { 'k', 'ｋ' }, { 'l', 'ｌ' }, { 'm', 'ｍ' }, { 'n', 'ｎ' }, { 'o', 'ｏ' },
            { 'p', 'ｐ' }, { 'q', 'ｑ' }, { 'r', 'ｒ' }, { 's', 'ｓ' }, { 't', 'ｔ' }, { 'u', 'ｕ' }, { 'v', 'ｖ' }, { 'w', 'ｗ' }, { 'x', 'ｘ' }, { 'y', 'ｙ' }, { 'z', 'ｚ' }, { '{', '｛' }, { '|', '｜' }, { '}', '｝' }, { '~', '～' },
        };

        public static string ConvertToFullWidth(string text)
        {
            var charArray = text.Select(c => HalfWidthAndFullWidthDictionary.TryGetValue(c, out var result) ? result : c);
            return string.Concat(charArray);
        }

        public static string ConvertToHalfWidth(string text)
        {
            var charArray = text.Select(c => HalfWidthAndFullWidthDictionary.ContainsValue(c) ? HalfWidthAndFullWidthDictionary.First(dic => dic.Value == c).Key : c);
            return string.Concat(charArray);
        }
    }
}
