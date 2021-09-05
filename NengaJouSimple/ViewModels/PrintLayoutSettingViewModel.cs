using NengaJouSimple.Extensions;
using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Entities.Layouts;
using NengaJouSimple.ViewModels.Entities.Settings;
using NengaJouSimple.ViewModels.PubSubEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NengaJouSimple.ViewModels
{
    public class PrintLayoutSettingViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        private readonly IEventAggregator eventAggregator;

        private readonly ApplicationSettingService applicationSettingService;

        private readonly AddressCardLayoutService addressCardLayoutService;

        private readonly AddressCardService addressCardService;

        private readonly PrintService printService;

        private ApplicationSettingViewModel applicationSetting;

        private FontFamily currentFontFamily;

        private AddressCardLayoutViewModel selectedAddressCardLayout;

        private bool isLetterCanvasTemplateVisible;

        private int currentAddressCardIndex;

        private bool isEnablePreviousViewAddressCard;

        private bool isEnableNextViewAddressCard;

        private bool isPreparedPrinter;

        private int selectedFontFamilyId;

        private bool isBeginedSeqencePrinting;

        public PrintLayoutSettingViewModel(
            IRegionManager regionManager,
            IDialogService dialogService,
            IEventAggregator eventAggregator,
            ApplicationSettingService applicationSettingService,
            AddressCardLayoutService addressCardLayoutService,
            AddressCardService addressCardService,
            PrintService printService)
        {
            this.regionManager = regionManager;

            this.dialogService = dialogService;

            this.eventAggregator = eventAggregator;

            this.applicationSettingService = applicationSettingService;

            this.addressCardLayoutService = addressCardLayoutService;

            this.addressCardService = addressCardService;

            this.printService = printService;

            ApplicationSetting = applicationSettingService.Load();

            CurrentFontFamily = new FontFamily(ApplicationSetting.FontFamilyName);

            var allAddressCardLayouts = addressCardLayoutService.LoadAll();

            AddressCardLayouts = new ObservableCollection<AddressCardLayoutViewModel>(allAddressCardLayouts);

            SelectedAddressCardLayout = AddressCardLayouts.First();

            CurrentAddressCardIndex = 1;

            IsLetterCanvasTemplateVisible = true;

            AvailableFontFamilyNames = applicationSetting.AvailableFontFamilies;

            SelectedFontFamilyId = AvailableFontFamilyNames.FirstOrDefault(f => f.EnglishName == applicationSetting.FontFamilyName)?.Id ?? 0;

            GoBackAddressCardViewCommand = new DelegateCommand(GoBackAddressCardView);

            PreviousViewAddressCardCommnad = new DelegateCommand(PreviousViewAddressCard);

            NextViewAddressCardCommand = new DelegateCommand(NextViewAddressCard);

            SelectFontFamilyNameCommand = new DelegateCommand(SelectFontFamilyName);

            SaveLayoutCommand = new DelegateCommand(SaveLayout);

            PrintCommand = new DelegateCommand<FrameworkElement>(OnPrint);

            PrintSequenceStartCommand = new DelegateCommand(OnPrintSequenceStart);

            PrintSequenceCommand = new DelegateCommand<FrameworkElement>(OnPrintSequence);

            SetDefaultValueCommand = new DelegateCommand<string>(SetDefaultValue);

            ChangePreviousAndNextButtonEnablityStautus();

            PreparePrinter();
        }

        public ApplicationSettingViewModel ApplicationSetting
        {
            get { return applicationSetting; }
            set { SetProperty(ref applicationSetting, value); }
        }

        public FontFamily CurrentFontFamily
        {
            get { return currentFontFamily; }
            set { SetProperty(ref currentFontFamily, value); }
        }

        public AddressCardLayoutViewModel SelectedAddressCardLayout
        {
            get { return selectedAddressCardLayout; }
            set { SetProperty(ref selectedAddressCardLayout, value); }
        }

        public bool IsLetterCanvasTemplateVisible
        {
            get { return isLetterCanvasTemplateVisible; }
            set { SetProperty(ref isLetterCanvasTemplateVisible, value); }
        }

        public int CurrentAddressCardIndex
        {
            get { return currentAddressCardIndex; }
            set
            {
                SetProperty(ref currentAddressCardIndex, value);

                ChangePreviousAndNextButtonEnablityStautus();

                if (0 < CurrentAddressCardIndex && AddressCardLayouts.Count() <= CurrentAddressCardIndex)
                {
                    SelectedAddressCardLayout = AddressCardLayouts[CurrentAddressCardIndex - 1];
                }
            }
        }

        public bool IsEnablePreviousViewAddressCard
        {
            get { return isEnablePreviousViewAddressCard; }
            set { SetProperty(ref isEnablePreviousViewAddressCard, value); }
        }

        public bool IsEnableNextViewAddressCard
        {
            get { return isEnableNextViewAddressCard; }
            set { SetProperty(ref isEnableNextViewAddressCard, value); }
        }

        public bool IsPreparedPrinter
        {
            get { return isPreparedPrinter; }
            set { SetProperty(ref isPreparedPrinter, value); }
        }

        public int SelectedFontFamilyId
        {
            get { return selectedFontFamilyId; }
            set { SetProperty(ref selectedFontFamilyId, value); }
        }

        public ObservableCollection<AddressCardLayoutViewModel> AddressCardLayouts { get; }

        public List<AvailableFontFamilyNameViewModel> AvailableFontFamilyNames { get; }

        public DelegateCommand GoBackAddressCardViewCommand { get; }

        public DelegateCommand PreviousViewAddressCardCommnad { get; }

        public DelegateCommand NextViewAddressCardCommand { get; }

        public DelegateCommand SelectFontFamilyNameCommand { get; }

        public DelegateCommand SaveLayoutCommand { get; }

        public DelegateCommand<FrameworkElement> PrintCommand { get; }

        public DelegateCommand PrintSequenceStartCommand { get; }

        public DelegateCommand<FrameworkElement> PrintSequenceCommand { get; }

        public DelegateCommand<string> SetDefaultValueCommand { get; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 他の画面からこの画面に遷移したときの処理
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // 画面のインスタンスを使いまわす
            return false;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // この画面から他の画面に遷移するときの処理
        }

        private void GoBackAddressCardView()
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, "AddressCardListView");
        }

        private void PreviousViewAddressCard()
        {
            CurrentAddressCardIndex -= 1;
        }

        private void NextViewAddressCard()
        {
            CurrentAddressCardIndex += 1;
        }

        private void ChangePreviousAndNextButtonEnablityStautus()
        {
            if (AddressCardLayouts.Count() <= 1)
            {
                IsEnablePreviousViewAddressCard = false;
                IsEnableNextViewAddressCard = false;

                return;
            }

            IsEnablePreviousViewAddressCard = CurrentAddressCardIndex > 1;
            IsEnableNextViewAddressCard = CurrentAddressCardIndex < AddressCardLayouts.Count();
        }

        private void SelectFontFamilyName()
        {
            var selectedFontFamilyName = AvailableFontFamilyNames[SelectedFontFamilyId];

            ApplicationSetting.FontFamilyName = selectedFontFamilyName.EnglishName;

            RaisePropertyChanged(nameof(ApplicationSetting));

            CurrentFontFamily = new FontFamily(ApplicationSetting.FontFamilyName);

            RaisePropertyChanged(nameof(CurrentFontFamily));
        }

        private void SaveLayout()
        {
            addressCardLayoutService.Register(SelectedAddressCardLayout);

            applicationSettingService.Update(applicationSetting);

            dialogService.ShowInformationDialog("レイアウトを保存しました。");
        }

        private void PreparePrinter()
        {
            Task.Run(async () =>
            {
                await printService.PreparePrinting();

                isPreparedPrinter = true;
            });
        }

        private void OnPrint(FrameworkElement printElement)
        {
            addressCardLayoutService.Register(SelectedAddressCardLayout);

            var isCofirmedPrinting = printService.ConfirmPrinting();
            
            if (!isCofirmedPrinting)
            {
                return;
            }

            SelectedAddressCardLayout.IsAlreadyPrinted = false;

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));

            IsLetterCanvasTemplateVisible = false;

            printService.Print(printElement, ApplicationSetting.PrintingOffsetX, ApplicationSetting.PrintingOffsetY);

            SelectedAddressCardLayout.IsAlreadyPrinted = true;

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));

            IsLetterCanvasTemplateVisible = true;

            addressCardService.UpdatePrintDateTime(SelectedAddressCardLayout.AddressCard);
        }

        private void OnPrintSequenceStart()
        {
            addressCardLayoutService.Register(SelectedAddressCardLayout);

            var confirmResult = dialogService.ShowConfirmDialog("連続印刷を実行しますか？");

            if (confirmResult != ButtonResult.Yes)
            {
                return;
            }

            CurrentAddressCardIndex = 1;

            if (FindNextPrintTarget())
            {
                var isCofirmedPrinting = printService.ConfirmPrinting();

                if (isCofirmedPrinting)
                {
                    IsLetterCanvasTemplateVisible = false;

                    // Raise event and set address card data on letter canvas.
                    eventAggregator.GetEvent<PrintSeqenceEvent>().Publish();
                }

                return;
            }

            dialogService.ShowInformationDialog("印刷が終了していない宛先がありませんでした。");
        }

        private void OnPrintSequence(FrameworkElement printElement)
        {
            if (!isBeginedSeqencePrinting)
            {
                printService.Print(printElement, ApplicationSetting.PrintingOffsetX, ApplicationSetting.PrintingOffsetY);

                SelectedAddressCardLayout.IsAlreadyPrinted = true;

                addressCardService.UpdatePrintDateTime(SelectedAddressCardLayout.AddressCard);

                isBeginedSeqencePrinting = true;
            }

            if (FindNextPrintTarget())
            {
                eventAggregator.GetEvent<PrintSeqenceEvent>().Publish();
            }
            else
            {
                // End of printing
                RaisePropertyChanged(nameof(SelectedAddressCardLayout));

                IsLetterCanvasTemplateVisible = true;

                isBeginedSeqencePrinting = false;
            }
        }

        private bool FindNextPrintTarget()
        {
            var addressCardLayoutCount = AddressCardLayouts.Count();

            var currentIndex = CurrentAddressCardIndex - 1;

            while (currentIndex < addressCardLayoutCount)
            {
                var addressCardLayout = AddressCardLayouts[currentIndex];

                if (!addressCardLayout.IsAlreadyPrinted)
                {
                    CurrentAddressCardIndex = currentIndex + 1;

                    return true;
                }

                currentIndex++;
            }

            return false;
        }

        private void SetDefaultValue(string targetName)
        {
            switch (targetName)
            {
                case "PostalCode.FontSize":
                    SelectedAddressCardLayout.PostalCode.FontSize = ApplicationSetting.PostalCodeSetting.FontSizeDefaultValue;
                    break;

                case "PostalCode.SpaceBetweenMailWardAndTownWard":
                    ApplicationSetting.PostalCodeSetting.SpaceBetweenMailWardAndTownWard = ApplicationSetting.PostalCodeSetting.SpaceBetweenMailWardAndTownWardDefaultValue;
                    break;

                case "PostalCode.SpaceBetweenMailWardEachWard":
                    ApplicationSetting.PostalCodeSetting.SpaceBetweenMailWardEachWard = ApplicationSetting.PostalCodeSetting.SpaceBetweenMailWardEachWardDefaultValue;
                    break;

                case "PostatlCode.SpaceBetweenTownWardEachWard":
                    ApplicationSetting.PostalCodeSetting.SpaceBetweenTownWardEachWard = ApplicationSetting.PostalCodeSetting.SpaceBetweenTownWardEachWardDefaultValue;
                    break;

                case "SenderPostalCode.FontSize":
                    SelectedAddressCardLayout.SenderPostalCode.FontSize = ApplicationSetting.SenderPostalCodeSetting.FontSizeDefaultValue;
                    break;

                case "SenderPostalCode.SpaceBetweenMailWardAndTownWard":
                    ApplicationSetting.SenderPostalCodeSetting.SpaceBetweenMailWardAndTownWard = ApplicationSetting.SenderPostalCodeSetting.SpaceBetweenMailWardAndTownWardDefaultValue;
                    break;

                case "SenderPostalCode.SpaceBetweenMailWardEachWard":
                    ApplicationSetting.SenderPostalCodeSetting.SpaceBetweenMailWardEachWard = ApplicationSetting.SenderPostalCodeSetting.SpaceBetweenMailWardEachWardDefaultValue;
                    break;

                case "SenderPostatlCode.SpaceBetweenTownWardEachWard":
                    ApplicationSetting.SenderPostalCodeSetting.SpaceBetweenTownWardEachWard = ApplicationSetting.SenderPostalCodeSetting.SpaceBetweenTownWardEachWardDefaultValue;
                    break;

                default:
                    return;
            }

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));
        }
    }
}
