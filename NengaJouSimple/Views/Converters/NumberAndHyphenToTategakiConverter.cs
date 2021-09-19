using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace NengaJouSimple.Views.Converters
{
    public class NumberAndHyphenToTategakiConverter : IValueConverter
    {
        private static readonly Dictionary<char, char> NumberAndHyphenToTategakiDictionary = new Dictionary<char, char>
        {
            { '0', '〇' }, { '1', '一' }, { '2', '二' }, { '3', '三' }, { '4', '四' }, { '5', '五' }, { '6', '六' }, { '7', '七' }, { '8', '八' }, { '9', '九' },
            { '０', '〇' }, { '１', '一' }, { '２', '二' }, { '３', '三' }, { '４', '四' }, { '５', '五' }, { '６', '六' }, { '７', '七' }, { '８', '八' }, { '９', '九' },
            { '-', 'ー' }, { '―', 'ー' }, { '‐', 'ー' }, { '－', 'ー' },
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {
                var charArray = text.Select(c => NumberAndHyphenToTategakiDictionary.TryGetValue(c, out var result) ? result : c);
                return string.Concat(charArray);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string text)
            {

                var charArray = text.Select(c => NumberAndHyphenToTategakiDictionary.ContainsValue(c) ? NumberAndHyphenToTategakiDictionary.First(dic => dic.Value == c).Key : c);
                return string.Concat(charArray);
            }

            return string.Empty;
        }
    }
}
