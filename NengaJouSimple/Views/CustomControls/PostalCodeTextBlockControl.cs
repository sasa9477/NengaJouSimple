using NengaJouSimple.Common;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NengaJouSimple.Views.CustomControls
{
    public class PostalCodeTextBlockControl : Control
    {

        public static readonly DependencyProperty MailWardProperty =
            DependencyProperty.Register(
                nameof(MailWardText),
                typeof(string),
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty TownWardProperty =
            DependencyProperty.Register(
                nameof(TownWardText),
                typeof(string),
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty MailWardAndTownWardMarginProperty =
            DependencyProperty.Register(
                nameof(MailWardAndTownWardMargin),
                typeof(Thickness),
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty MailWardEachWardMarginProperty =
            DependencyProperty.Register(
                nameof(MailWardEachWardMargin),
                typeof(Thickness),
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty TownWardEachWardMarginProperty =
            DependencyProperty.Register(
                nameof(TownWardEachWardMargin),
                typeof(Thickness),
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(new Thickness(), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));

        static PostalCodeTextBlockControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PostalCodeTextBlockControl), new FrameworkPropertyMetadata(typeof(PostalCodeTextBlockControl)));
        }

        public string MailWardText
        {
            get { return (string)GetValue(MailWardProperty); }
            set { SetValue(MailWardProperty, value); }
        }

        public string TownWardText
        {
            get { return (string)GetValue(TownWardProperty); }
            set { SetValue(TownWardProperty, value); }
        }

        public Thickness MailWardAndTownWardMargin
        {
            get { return (Thickness)GetValue(MailWardAndTownWardMarginProperty); }
            set { SetValue(MailWardAndTownWardMarginProperty, value); }
        }

        public Thickness MailWardEachWardMargin
        {
            get { return (Thickness)GetValue(MailWardEachWardMarginProperty); }
            set { SetValue(MailWardEachWardMarginProperty, value); }
        }

        public Thickness TownWardEachWardMargin
        {
            get { return (Thickness)GetValue(TownWardEachWardMarginProperty); }
            set { SetValue(TownWardEachWardMarginProperty, value); }
        }
    }
}
