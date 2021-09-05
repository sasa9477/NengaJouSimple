using NengaJouSimple.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace NengaJouSimple.Views.CustomControls
{
    public class PostalCodeTextBlockControl : Control, INotifyPropertyChanged
    {
        public static readonly DependencyProperty TextProperty =
            TextBlock.TextProperty.AddOwner(
                typeof(PostalCodeTextBlockControl),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnTextChanged)));

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

        private string mailWardText;

        private string townWardText;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string MailWardText
        {
            get { return mailWardText; }
            set { SetProperty(ref mailWardText, value); }
        }

        public string TownWardText
        {
            get { return townWardText; }
            set { SetProperty(ref townWardText, value); }
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

        private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PostalCodeTextBlockControl)d).OnTextChanged();
        }

        private void OnTextChanged()
        {
            if (string.IsNullOrEmpty(Text)) return;

            var text = Text.Replace("-", string.Empty);

            if (text.Length > 3)
            {
                MailWardText = text[0..3];
                TownWardText = text[3..];
            }
            else
            {
                MailWardText = text;
            }
        }

        private void SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return;

            storage = value;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
