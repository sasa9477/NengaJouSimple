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
using NengaJouSimple.ViewModels.Entities;

namespace NengaJouSimple.Views.Components
{
    /// <summary>
    /// AddressRegisterControl.xaml の相互作用ロジック
    /// </summary>
    public partial class AddressCardControl : UserControl
    {
        public static readonly DependencyProperty AddressCardProperty =
            DependencyProperty.Register("AddressCard", typeof(AddressCard), typeof(AddressCardControl), new PropertyMetadata(new AddressCard()));

        public static readonly DependencyProperty HonorificsProperty =
            DependencyProperty.Register("Honorifics", typeof(IEnumerable<string>), typeof(AddressCardControl), new PropertyMetadata(new List<string>()));

        public static readonly DependencyProperty SearchByAddressNumberCommandProperty =
            DependencyProperty.Register("SearchByAddressNumberCommand", typeof(ICommand), typeof(AddressCardControl), new PropertyMetadata(null));

        public static readonly DependencyProperty RegisterAddressCommandProperty =
            DependencyProperty.Register("RegisterAddressCommand", typeof(ICommand), typeof(AddressCardControl), new PropertyMetadata(null));

        public AddressCard AddressCard
        {
            get { return (AddressCard)GetValue(AddressCardProperty); }
            set { SetValue(AddressCardProperty, value); }
        }

        public IEnumerable<string> Honorifics
        {
            get { return (IEnumerable<string>)GetValue(HonorificsProperty); }
            set { SetValue(HonorificsProperty, value); }
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

        public AddressCardControl()
        {
            InitializeComponent();
        }
    }
}
