using NengaJouSimple.Common;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NengaJouSimple.Views.CustomControls
{
    public class PostalCodeTextBlockControl : Control
    {
        public static readonly DependencyProperty TextProperty =
            TextBlock.TextProperty.AddOwner(
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnTextChanged), new CoerceValueCallback(CoerceTextProperty)));

        public static readonly DependencyProperty SpaceBetweenMailWardAndTownWardProperty =
            DependencyProperty.Register(
                nameof(SpaceBetweenMailWardAndTownWard),
                typeof(double),
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnSpaceBetweenMailWardAndTownWardChanged)));

        public static readonly DependencyProperty EachWardMarginProperty =
            DependencyProperty.Register(
                nameof(EachWardMargin),
                typeof(Thickness),
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        static PostalCodeTextBlockControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PostalCodeTextBlockControl), new FrameworkPropertyMetadata(typeof(PostalCodeTextBlockControl)));
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public double SpaceBetweenMailWardAndTownWard
        {
            get { return (double)GetValue(SpaceBetweenMailWardAndTownWardProperty); }
            set { SetValue(SpaceBetweenMailWardAndTownWardProperty, value); }
        }

        public Thickness EachWardMargin
        {
            get { return (Thickness)GetValue(EachWardMarginProperty); }
            set { SetValue(EachWardMarginProperty, value); }
        }

        private ItemsControl MailWardTextItemsControl
        {
            get { return (ItemsControl)GetTemplateChild(nameof(MailWardTextItemsControl)); }
        }

        private ItemsControl TownWardTextItemsControl
        {
            get { return (ItemsControl)GetTemplateChild(nameof(TownWardTextItemsControl)); }
        }

        private Thickness MailWardAndTownWardThickness
        {
            get { return new Thickness(0, 0, SpaceBetweenMailWardAndTownWard, 0); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (Text.Length == 7)
            {
                MailWardTextItemsControl.ItemsSource = Text[0..3];
                TownWardTextItemsControl.ItemsSource = Text[3..7];

                MailWardTextItemsControl.Margin = MailWardAndTownWardThickness;
            }
        }

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PostalCodeTextBlockControl)d).OnTextChanged();
        }

        private static object CoerceTextProperty(DependencyObject d, object baseValue)
        {
            var value = baseValue as string ?? string.Empty;

            if (value.Length == 8)
            {
                value = HalfWidthAndFullWidthConverter.ConvertToFullWidth(value);

                return value[0..3] + value[4..8];
            }

            return value;
        }

        private static void OnSpaceBetweenMailWardAndTownWardChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PostalCodeTextBlockControl)d).OnSpaceBetweenMailWardAndTownWardChanged();
        }

        private void OnTextChanged()
        {
            if (IsLoaded)
            {
                if (Text.Length == 7)
                {
                    MailWardTextItemsControl.ItemsSource = Text[0..3];
                    TownWardTextItemsControl.ItemsSource = Text[3..7];

                    MailWardTextItemsControl.Margin = MailWardAndTownWardThickness;
                }
                else
                {
                    MailWardTextItemsControl.ItemsSource = string.Empty;
                    TownWardTextItemsControl.ItemsSource = string.Empty;

                    MailWardTextItemsControl.Margin = new Thickness();
                }
            }
        }

        private void OnSpaceBetweenMailWardAndTownWardChanged()
        {
            if (IsLoaded)
            {
                MailWardTextItemsControl.Margin = MailWardAndTownWardThickness;
            }
        }
    }
}
