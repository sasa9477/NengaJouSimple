using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using NengaJouSimple.Data;
using NengaJouSimple.Data.Csv;
using NengaJouSimple.Data.Jsons;
using NengaJouSimple.Data.Repositories;
using NengaJouSimple.Data.Web;
using NengaJouSimple.Devices;
using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Components;
using NengaJouSimple.Views;
using NengaJouSimple.Views.Components;
using NLog;
using Prism.Ioc;
using System;
using System.Data.Common;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace NengaJouSimple
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        private readonly ILogger logger;

        public App()
        {
            logger = LogManager.GetCurrentClassLogger();

            DispatcherUnhandledException += App_DispatcherUnhandledException;

            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;

            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        }

        protected override Window CreateShell()
        {
            InitializeData();

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

            containerRegistry.RegisterSingleton<TextLayoutCsvService>();

            // Jsons
            containerRegistry.RegisterSingleton<ApplicationSettingJsonService>();

            // Repositories
            containerRegistry.RegisterSingleton<ApplicationSettingRepository>();

            containerRegistry.RegisterSingleton<AddressCardRepository>();

            containerRegistry.RegisterSingleton<SenderAddressCardRepository>();

            containerRegistry.RegisterSingleton<AddressCardLayoutRepository>();

            // Webs
            containerRegistry.RegisterSingleton<AddressWebService>();

            // Devices
            containerRegistry.RegisterSingleton<Printer>();

            // Services
            containerRegistry.RegisterSingleton<ApplicationSettingService>();

            containerRegistry.RegisterSingleton<AddressCardService>();

            containerRegistry.RegisterSingleton<SenderAddressCardService>();

            containerRegistry.RegisterSingleton<AddressCardLayoutService>();

            containerRegistry.RegisterSingleton<PrintService>();

            // Dialogs
            containerRegistry.RegisterDialog<AlertDialog, AlertDialogViewModel>();

            containerRegistry.RegisterDialog<ConfirmDialog, ConfirmDialogViewModel>();

            containerRegistry.RegisterDialog<ChangePrintingLocationHelperDialog, ChangePrintingLocationHelperDialogViewModel>();

            // Views
            containerRegistry.RegisterForNavigation<AddressCardListView>();

            containerRegistry.RegisterForNavigation<SenderAddressCardListView>();

            containerRegistry.RegisterForNavigation<PrintLayoutSettingView>();

            // Windows
            containerRegistry.RegisterDialogWindow<PrismMetroDialogWindow>();
        }

        private static ApplicationDbContext CreateDbContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .EnableSensitiveDataLogging()
                .Options;

            var dbContext = new ApplicationDbContext(dbContextOptions);

            dbContext.Database.EnsureCreated();

            return dbContext;
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var dbConnection = new SqliteConnection("Data Source=:memory:");

            dbConnection.Open();

            return dbConnection;
        }

        private void InitializeData()
        {
            var applicationSettingService = Container.Resolve<ApplicationSettingService>();

            applicationSettingService.InitializeData();

            var senderAddressCardService = Container.Resolve<SenderAddressCardService>();

            senderAddressCardService.InitializeData();

            var addressCardService = Container.Resolve<AddressCardService>();

            addressCardService.InitializeData();

            var addressCardLayoutService = Container.Resolve<AddressCardLayoutService>();

            addressCardLayoutService.InitializeData();
        }

        /// <summary>
        /// UIスレッドで発生した処理されていない例外を検知します。
        /// </summary>
        private void App_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            logger.Error(e.Exception, "UIスレッドでハンドルされていない例外が発生しました。");

            ExitByUnhandledException();
        }

        /// <summary>
        /// バックグラウンドで発生した処理されていない例外を検知します。
        /// </summary>
        private void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            logger.Error(e.Exception, "バッググランドでハンドルされていない例外が発生しました。");

            ExitByUnhandledException();
        }

        /// <summary>
        /// 処理されていない例外を検知します。
        /// </summary>
        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            logger.Error(e.ExceptionObject as Exception, "ハンドルされていない例外が発生しました。");

            ExitByUnhandledException();
        }

        private void ExitByUnhandledException()
        {
#if DEBUG
#else
            MessageBox.Show("予期せぬエラーが発生しました。\nアプリケーションを終了します。", "致命的なエラー", MessageBoxButton.OK, MessageBoxImage.Stop);
#endif
            try
            {
                logger.Info("Exiting by unhandled exception.");
                logger.Info("{0} is shut dowing.", nameof(LogManager));
                LogManager.Shutdown();
            }
            catch (Exception)
            {
                // 例外は処理できない
            }

            Environment.Exit(1);
        }
    }
}
