using NengaJouSimple.Services;
using NengaJouSimple.Views;
using Prism.Ioc;
using System.Windows;

namespace NengaJouSimple
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<SenderAddressCardListWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<AddressCardService>();

            containerRegistry.RegisterInstance(AutoMapperConfig.CreateMapper());
        }
    }
}
