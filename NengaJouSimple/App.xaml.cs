using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Data.Devices;
using NengaJouSimple.Data.Jsons;
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
            InitializeDataFromFiles();

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

            // Jsons
            containerRegistry.RegisterSingleton<AddressCardLayoutJsonService>();

            // Repositories
            containerRegistry.RegisterSingleton<AddressCardRepository>();

            containerRegistry.RegisterSingleton<SenderAddressCardRepository>();

            containerRegistry.RegisterSingleton<AddressCardLayoutRepository>();

            // Webs
            containerRegistry.RegisterSingleton<AddressWebService>();

            // Devices
            containerRegistry.RegisterSingleton<Printer>();

            // Services
            containerRegistry.RegisterSingleton<AddressCardService>();

            containerRegistry.RegisterSingleton<SenderAddressCardService>();

            containerRegistry.RegisterSingleton<AddressCardLayoutService>();

            containerRegistry.RegisterSingleton<PrintService>();

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

        private void InitializeDataFromFiles()
        {
            var senderAddressCardService = Container.Resolve<SenderAddressCardService>();

            senderAddressCardService.ReadCsvFile();

            var addressCardService = Container.Resolve<AddressCardService>();

            addressCardService.ReadCsvFile();

            var addressCardLayoutService = Container.Resolve<AddressCardLayoutService>();

            addressCardLayoutService.ReadJsonFile();
        }
    }
}
