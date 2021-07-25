using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Data.Web;
using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Components;
using NengaJouSimple.Views;
using NengaJouSimple.Views.Components;
using Prism.Ioc;
using System.Data.Common;
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
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(CreateDbContext());

            containerRegistry.RegisterSingleton<AddressCardRepository>();

            containerRegistry.RegisterSingleton<AddressWebService>();

            containerRegistry.RegisterSingleton<AddressCardService>();

            containerRegistry.RegisterInstance(AutoMapperConfig.CreateMapper());

            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();

            containerRegistry.RegisterDialog<ConfirmDialog, ConfirmDialogViewModel>();

            containerRegistry.RegisterForNavigation<AddressCardListView>();

            containerRegistry.RegisterForNavigation<SenderAddressCardListView>();

            containerRegistry.RegisterForNavigation<PrintLayoutSettingView>();
        }

        private static ApplicationDbContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(CreateInMemoryDatabase()).Options;

            var dbContext = new ApplicationDbContext(dbContextOptions);

            dbContext.Database.EnsureCreated();

            ApplicationDbContextSeed.SeedData(dbContext);

            return dbContext;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var dbConnection = new SqliteConnection("Data Source=:memory:");

            dbConnection.Open();

            return dbConnection;
        }
    }
}
