using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Data.Web;
using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Components;
using NengaJouSimple.Views;
using NengaJouSimple.Views.Components;
using Prism.Ioc;
using System;
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
            InitializeDataFromCsv();

            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Aspects
            containerRegistry.RegisterInstance(CreateDbContext());

            containerRegistry.RegisterInstance(AutoMapperConfig.CreateMapper());

            // Csvs
            containerRegistry.RegisterSingleton<AddressCardCsvService>();

            containerRegistry.RegisterSingleton<SenderAddressCardCsvService>();

            // Repositories
            containerRegistry.RegisterSingleton<AddressCardRepository>();

            containerRegistry.RegisterSingleton<SenderAddressCardRepository>();

            // Webs
            containerRegistry.RegisterSingleton<AddressWebService>();

            // Services
            containerRegistry.RegisterSingleton<AddressCardService>();

            containerRegistry.RegisterSingleton<SenderAddressCardService>();

            // Dialogs
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();

            containerRegistry.RegisterDialog<ConfirmDialog, ConfirmDialogViewModel>();

            // Views
            containerRegistry.RegisterForNavigation<AddressCardListView>();

            containerRegistry.RegisterForNavigation<SenderAddressCardListView>();

            containerRegistry.RegisterForNavigation<PrintLayoutSettingView>();
        }

        private static ApplicationDbContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlite(CreateInMemoryDatabase()).Options;

            var dbContext = new ApplicationDbContext(dbContextOptions);

            dbContext.Database.EnsureCreated();

            // ApplicationDbContextSeed.SeedData(dbContext);

            return dbContext;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var dbConnection = new SqliteConnection("Data Source=:memory:");

            dbConnection.Open();

            return dbConnection;
        }

        private void InitializeDataFromCsv()
        {
            var senderAddressCardService = Container.Resolve<SenderAddressCardService>();

            senderAddressCardService.ReadCsvFile();

            var addressCardService = Container.Resolve<AddressCardService>();

            addressCardService.ReadCsvFile();
        }
    }
}
