using NengaJouSimple.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NengaJouSimple.Views.CustomControls
{
    public class VerticalTextBlockControl : Control
    {
        public static readonly DependencyProperty TextProperty =
            TextBlock.TextProperty.AddOwner(
                typeof(VerticalTextBlockControl),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    new PropertyChangedCallback(OnTextChanged),
                    new CoerceValueCallback(CoerceTextProperty)));

        private VerticalGlyphMap verticalGlyphMap;

        static VerticalTextBlockControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(VerticalTextBlockControl), new FrameworkPropertyMetadata(typeof(VerticalTextBlockControl)));
            FontFamilyProperty.OverrideMetadata(typeof(VerticalTextBlockControl), new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily, new PropertyChangedCallback(OnFontFamilyChanged), new CoerceValueCallback(CoerceFontFamilyProperty)));
            FontWeightProperty.OverrideMetadata(typeof(VerticalTextBlockControl), new FrameworkPropertyMetadata(SystemFonts.MessageFontWeight, new PropertyChangedCallback(OnFontWeightChanged)));
            FontStyleProperty.OverrideMetadata(typeof(VerticalTextBlockControl), new FrameworkPropertyMetadata(SystemFonts.MessageFontStyle, new PropertyChangedCallback(OnFontStyleChanged)));
        }

        public VerticalTextBlockControl()
        {
            GlyphsFirstLine = new ObservableCollection<string>();

            GlyphsSecondLine = new ObservableCollection<string>();

            var fontUri = CurrentGlyphTypeface!.FontUri;

            verticalGlyphMap = VerticalGlyphMap.Cache.GetOrAdd(fontUri, () => new VerticalGlyphMap(fontUri));
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public Uri FontUri
        {
            get { return CurrentGlyphTypeface?.FontUri; }
        }

        public StyleSimulations StyleSimulation
        {
            get { return (FontStyle != FontStyles.Normal ? StyleSimulations.ItalicSimulation : StyleSimulations.None) | (FontWeight != FontWeights.Normal ? StyleSimulations.BoldSimulation : StyleSimulations.None); }
        }

        public ObservableCollection<string> GlyphsFirstLine
        {
            get;
        }

        public ObservableCollection<string> GlyphsSecondLine
        {
            get;
        }

        private GlyphTypeface CurrentGlyphTypeface
        {
            get
            {
                var typefaces = FontFamily.GetTypefaces();
                var typeface = typefaces.FirstOrDefault(typeface => typeface.Style == FontStyle && typeface.Weight == FontWeight);
                if (typeface != null && typeface.TryGetGlyphTypeface(out var glyphTypeface))
                {
                    return glyphTypeface;
                }

                return null;
            }
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VerticalTextBlockControl)d).OnTextChanged();
        }

        private static object CoerceTextProperty(DependencyObject d, object baseValue)
        {
            var value = baseValue as string;

            return string.IsNullOrEmpty(value) ? " " : value;
        }

        private static void OnFontFamilyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VerticalTextBlockControl)d).OnTypefaceChanged();
        }

        private static object CoerceFontFamilyProperty(DependencyObject d, object baseValue)
        {
            return baseValue is FontFamily value ? value : SystemFonts.MessageFontFamily;
        }

        private static void OnFontWeightChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VerticalTextBlockControl)d).OnTypefaceChanged();
        }

        private static void OnFontStyleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((VerticalTextBlockControl)d).OnTypefaceChanged();
        }

        private void OnTextChanged()
        {
            ResetGlyphsLines();
        }

        private void OnTypefaceChanged()
        {
            if (FontUri != null)
            {
                var tempVerticalGlyphMap = VerticalGlyphMap.Cache.GetOrAdd(FontUri, () => new VerticalGlyphMap(FontUri));

                if (tempVerticalGlyphMap != verticalGlyphMap)
                {
                    verticalGlyphMap = tempVerticalGlyphMap;

                    ResetGlyphsLines();
                }
            }
        }

        private void ResetGlyphsLines()
        {
            if (string.IsNullOrEmpty(Text)) return;

            GlyphsFirstLine.Clear();

            GlyphsSecondLine.Clear();

            var lines = Text.Replace("\r\n", "\n").Split("\n");

            var firstLineGlyphIndices = verticalGlyphMap.EnumerateGlyphIndicesTexts(lines[0]);

            foreach (var glyphIndex in firstLineGlyphIndices)
            {
                GlyphsFirstLine.Add(glyphIndex);
            }

            if (lines.Length > 1)
            {
                var secondLineGlyphIndices = verticalGlyphMap.EnumerateGlyphIndicesTexts(lines[1]);

                foreach (var glyphIndex in secondLineGlyphIndices)
                {
                    GlyphsSecondLine.Add(glyphIndex);
                }
            }
        }
    }
}
