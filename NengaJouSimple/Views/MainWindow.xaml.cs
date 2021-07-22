using NengaJouSimple.ViewModels.Components;
using System.Windows;

namespace NengaJouSimple.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AddressRegisterControl.DataContext = new AddressRegisterControlViewModel();
        }
    }
}
