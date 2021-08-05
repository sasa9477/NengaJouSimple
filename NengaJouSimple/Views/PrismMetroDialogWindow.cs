using MahApps.Metro.Controls;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Views
{
    public partial class PrismMetroDialogWindow : MetroWindow, IDialogWindow
    {
        public PrismMetroDialogWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterOwner;

            // 画面表示字のアニメーションを表示しない
            WindowTransitionsEnabled = false;

            Loaded += PrismMetroDialogWindow_Loaded;
        }

        public IDialogResult Result { get; set; }

        private void PrismMetroDialogWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (DataContext is IDialogAware dialogDataContext)
            {
                Title = dialogDataContext.Title;
            }

            Loaded -= PrismMetroDialogWindow_Loaded;
        }
    }
}
