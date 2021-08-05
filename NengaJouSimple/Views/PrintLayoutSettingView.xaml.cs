using NengaJouSimple.ViewModels;
using NengaJouSimple.ViewModels.PubSubEvents;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NengaJouSimple.Views
{
    /// <summary>
    /// PrintLayoutSettingView.xaml の相互作用ロジック
    /// </summary>
    public partial class PrintLayoutSettingView : UserControl
    {
        public PrintLayoutSettingView(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            eventAggregator.GetEvent<PrintSeqenceEvent>().Subscribe(() =>
            {
                var vm = DataContext as PrintLayoutSettingViewModel;

                if (vm != null)
                {
                    vm.PrintSequenceCommand.Execute(LetterCanvasControl);
                }
            });
        }
    }
}
