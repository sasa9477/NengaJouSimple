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
            return Container.Resolve<AddressCardListWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            var dbContext = CreateDbContext();

            dbContext.Database.EnsureCreated();

            ApplicationDbContextSeed.SeedData(dbContext);

            containerRegistry.RegisterInstance(dbContext);

            containerRegistry.RegisterSingleton<AddressCardRepository>();

            containerRegistry.RegisterSingleton<AddressWebService>();

            containerRegistry.RegisterSingleton<AddressCardService>();

            containerRegistry.RegisterInstance(AutoMapperConfig.CreateMapper());

            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();

            containerRegistry.RegisterDialog<ConfirmDialog, ConfirmDialogViewModel>();
        }

        private static ApplicationDbContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(CreateInMemoryDatabase()).Options;

            return new ApplicationDbContext(dbContextOptions);
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var dbConnection = new SqliteConnection("Data Source=:memory:");

            dbConnection.Open();

            return dbConnection;
        }
    }
}
