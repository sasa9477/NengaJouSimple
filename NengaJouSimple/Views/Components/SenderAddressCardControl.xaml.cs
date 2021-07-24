using NengaJouSimple.ViewModels.Entities;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NengaJouSimple.Views.Components
{
    /// <summary>
    /// SenderAddressCardControl.xaml の相互作用ロジック
    /// </summary>
    public partial class SenderAddressCardControl : UserControl
    {
        public static readonly DependencyProperty AddressCardProperty =
            DependencyProperty.Register("AddressCard", typeof(AddressCard), typeof(SenderAddressCardControl), new PropertyMetadata(new AddressCard()));

        public static readonly DependencyProperty SearchByAddressNumberCommandProperty =
            DependencyProperty.Register("SearchByAddressNumberCommand", typeof(ICommand), typeof(SenderAddressCardControl), new PropertyMetadata(null));

        public static readonly DependencyProperty RegisterAddressCommandProperty =
            DependencyProperty.Register("RegisterAddressCommand", typeof(ICommand), typeof(SenderAddressCardControl), new PropertyMetadata(null));

        public static readonly DependencyProperty DeleteAddressCommandProperty =
            DependencyProperty.Register("DeleteAddressCommand", typeof(ICommand), typeof(SenderAddressCardControl), new PropertyMetadata(null));

        public AddressCard AddressCard
        {
            get { return (AddressCard)GetValue(AddressCardProperty); }
            set { SetValue(AddressCardProperty, value); }
        }

        public ICommand SearchByAddressNumberCommand
        {
            get { return (ICommand)GetValue(SearchByAddressNumberCommandProperty); }
            set { SetValue(SearchByAddressNumberCommandProperty, value); }
        }

        public ICommand RegisterAddressCommand
        {
            get { return (ICommand)GetValue(RegisterAddressCommandProperty); }
            set { SetValue(RegisterAddressCommandProperty, value); }
        }

        public ICommand DeleteAddressCommand
        {
            get { return (ICommand)GetValue(DeleteAddressCommandProperty); }
            set { SetValue(DeleteAddressCommandProperty, value); }
        }

        public SenderAddressCardControl()
        {
            InitializeComponent();
        }
    }
}
