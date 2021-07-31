using NengaJouSimple.ViewModels.Entities.Addresses;
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
    public partial class AddressCardControl : UserControl
    {
        public static readonly DependencyProperty AddressCardProperty =
            DependencyProperty.Register("AddressCard", typeof(AddressCardViewModel), typeof(AddressCardControl), new PropertyMetadata(new AddressCardViewModel()));

        public static readonly DependencyProperty HonorificsProperty =
            DependencyProperty.Register("Honorifics", typeof(ICollection<string>), typeof(AddressCardControl), new PropertyMetadata(new List<string>()));

        public static readonly DependencyProperty SelectedSenderAddressCardIdProperty =
            DependencyProperty.Register("SelectedSenderAddressCardId", typeof(int), typeof(AddressCardControl), new PropertyMetadata(0));

        public static readonly DependencyProperty SenderAddressCardsProperty =
            DependencyProperty.Register("SenderAddressCards", typeof(ICollection<SenderAddressCardViewModel>), typeof(AddressCardControl), new PropertyMetadata(new List<SenderAddressCardViewModel>()));

        public static readonly DependencyProperty IsSearchingByWebServiceProperty =
            DependencyProperty.Register("IsSearchingByWebService", typeof(bool), typeof(AddressCardControl), new PropertyMetadata(false));

        public static readonly DependencyProperty SearchByAddressNumberCommandProperty =
            DependencyProperty.Register("SearchByAddressNumberCommand", typeof(ICommand), typeof(AddressCardControl), new PropertyMetadata(null));

        public static readonly DependencyProperty RegisterAddressCommandProperty =
            DependencyProperty.Register("RegisterAddressCommand", typeof(ICommand), typeof(AddressCardControl), new PropertyMetadata(null));

        public static readonly DependencyProperty DeleteAddressCommandProperty =
            DependencyProperty.Register("DeleteAddressCommand", typeof(ICommand), typeof(AddressCardControl), new PropertyMetadata(null));

        public AddressCardViewModel AddressCard
        {
            get { return (AddressCardViewModel)GetValue(AddressCardProperty); }
            set { SetValue(AddressCardProperty, value); }
        }

        public ICollection<string> Honorifics
        {
            get { return (ICollection<string>)GetValue(HonorificsProperty); }
            set { SetValue(HonorificsProperty, value); }
        }

        public int SelectedSenderAddressCardId
        {
            get { return (int)GetValue(SelectedSenderAddressCardIdProperty); }
            set { SetValue(SelectedSenderAddressCardIdProperty, value); }
        }

        public ICollection<SenderAddressCardViewModel> SenderAddressCards
        {
            get { return (ICollection<SenderAddressCardViewModel>)GetValue(SenderAddressCardsProperty); }
            set { SetValue(SenderAddressCardsProperty, value); }
        }

        public bool IsSearchingByWebService
        {
            get { return (bool)GetValue(IsSearchingByWebServiceProperty); }
            set { SetValue(IsSearchingByWebServiceProperty, value); }
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

        public AddressCardControl()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Force validation rules
            MainNameFamilyName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            MainNameGivenName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            PostalCode1.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            PostalCode2.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            Address1.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            Address2.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
