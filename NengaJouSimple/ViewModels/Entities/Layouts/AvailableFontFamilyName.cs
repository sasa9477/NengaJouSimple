using NengaJouSimple.Models.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NengaJouSimple.ViewModels.Entities.Layouts
{
    public class AvailableFontFamilyName
    {
        public static List<AvailableFontFamilyName> AvailableFontFamilyNames;

        static AvailableFontFamilyName()
        {
            AvailableFontFamilyNames =
                AvailableFontFamily
                .AvailableFontFamilies
                .Select((familyName, index) => new AvailableFontFamilyName(index, familyName.EnglishName, familyName.JapaneseName))
                .ToList();
        }

        public AvailableFontFamilyName()
        {
            EnglishName = string.Empty;
            JapaneseName = string.Empty;
        }

        public AvailableFontFamilyName(int id, string englishName, string japaneseName)
        {
            Id = id;
            EnglishName = englishName;
            JapaneseName = japaneseName;
        }

        public int Id { get; set; }

        public string EnglishName { get; set; }

        public string JapaneseName { get; set; }
    }
}
