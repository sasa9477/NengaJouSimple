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

        public AddressCardControl()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Force validation rules
            MainNameFamilyName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            MainNameGivenName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            MailWard.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TownWard.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            Address.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }
    }
}
