using NengaJouSimple.ViewModels.PubSubEvents;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NengaJouSimple.Views
{
    /// <summary>
    /// SenderAddressCardListWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class SenderAddressCardListView : UserControl
    {
        public SenderAddressCardListView(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            eventAggregator.GetEvent<FocusAddress2Event>().Subscribe(() =>
            {
                SenderAddressCardControl.Address2.Focus();
            });
        }
    }
}
