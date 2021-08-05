using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NengaJouSimple.Views.CustomControls
{
    public class VerticalGlyphMap
    {
        /*
             有効なフォント
            Yu Gothic UI
            BIZ UDGothic
            Source Han Code JP (Not system font)
            UD Digi Kyokasho NK-R
            Yu Mincho - SemiBold*/

        public static readonly Dictionary<Uri, VerticalGlyphMap> Cache = new Dictionary<Uri, VerticalGlyphMap>();

        private readonly Dictionary<int, ushort> glyphMap;

        private readonly Dictionary<ushort, ushort> verticalMap;

        public VerticalGlyphMap(Uri fontUri)
        {
            using var fileStream = File.OpenRead(fontUri.AbsolutePath);
            var typeface = new WaterTrans.GlyphLoader.Typeface(fileStream);

            glyphMap = new Dictionary<int, ushort>(typeface.CharacterToGlyphMap);

            var vertMap = typeface.GetSingleSubstitutionMap("DFLT", "DFLT", "vert");

            verticalMap = new Dictionary<ushort, ushort>();

            // Resolve a bug at GetSingleSubstitutionMap() in the thrid-party library WaterTrans.GlyphLoader.
            foreach (var key in vertMap.Keys)
            {
                verticalMap.Add(key, vertMap[key]);
            }
        }

        public IEnumerable<ushort> EnumerateGlyphIndices(string text)
        {
            foreach (var c in text)
            {
                if (glyphMap.ContainsKey(c))
                {
                    var glyphIndex = glyphMap[c];

                    yield return verticalMap.ContainsKey(glyphIndex) ? verticalMap[glyphIndex] : glyphIndex;
                }
                else
                {
                    yield return glyphMap.First().Value;
                }
            }
        }

        public IEnumerable<string> EnumerateGlyphIndicesTexts(string text)
        {
            foreach (var c in text)
            {
                ushort glyphIndex;

                if (glyphMap.ContainsKey(c))
                {
                    glyphIndex = glyphMap[c];

                    glyphIndex = verticalMap.ContainsKey(glyphIndex) ? verticalMap[glyphIndex] : glyphIndex;
                }
                else
                {
                    glyphIndex = glyphMap.First().Value;
                }

                yield return $"{glyphIndex}";
            }
        }
    }
}
