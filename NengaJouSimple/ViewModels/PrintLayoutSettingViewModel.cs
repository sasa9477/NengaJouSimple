using NengaJouSimple.Models.Layouts;
using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Entities.Addresses;
using NengaJouSimple.ViewModels.Entities.Layouts;
using NengaJouSimple.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using Prism.Events;
using System.Threading.Tasks;
using NengaJouSimple.Common;
using System.Windows.Media;
using NengaJouSimple.ViewModels.PubSubEvents;

namespace NengaJouSimple.ViewModels
{
    public class PrintLayoutSettingViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        private readonly IEventAggregator eventAggregator;

        private readonly AddressCardLayoutService addressCardLayoutService;

        private readonly AddressCardService addressCardService;

        private readonly PrintService printService;

        private AddressCardLayoutViewModel selectedAddressCardLayout;

        private bool isLetterCanvasTemplateVisible;

        private int currentAddressCardIndex;

        private bool isEnablePreviousViewAddressCard;

        private bool isEnableNextViewAddressCard;

        private bool isPreparedPrinter;

        private int selectedFontFamilyId;

        public PrintLayoutSettingViewModel(
            IRegionManager regionManager,
            IDialogService dialogService,
            IEventAggregator eventAggregator,
            AddressCardLayoutService addressCardLayoutService,
            AddressCardService addressCardService,
            PrintService printService)
        {
            this.regionManager = regionManager;

            this.dialogService = dialogService;

            this.eventAggregator = eventAggregator;

            this.addressCardLayoutService = addressCardLayoutService;

            this.addressCardService = addressCardService;

            this.printService = printService;

            var allAddressCards = addressCardService.LoadAll();

            AddressCards = new ObservableCollection<AddressCardViewModel>(allAddressCards);

            SelectedAddressCardLayout = addressCardLayoutService.Load();

            SelectedAddressCardLayout.AttachAddressCard(allAddressCards.First());

            CurrentAddressCardIndex = 1;

            IsLetterCanvasTemplateVisible = true;

            AvailableFontFamilyNames = AvailableFontFamilyName.AvailableFontFamilyNames;

            var fontFamilyName = AvailableFontFamilyNames.FirstOrDefault(f => f.EnglishName == SelectedAddressCardLayout.FontFamily.Source);

            SelectedFontFamilyId = fontFamilyName?.Id ?? 0;

            GoBackAddressCardViewCommand = new DelegateCommand(GoBackAddressCardView);

            SetDefaultValueCommand = new DelegateCommand<string>(SetDefaultValue);

            SelectFontFamilyNameCommand = new DelegateCommand(SelectFontFamilyName);

            SaveLayoutCommand = new DelegateCommand(SaveLayout);

            PrintCommand = new DelegateCommand<FrameworkElement>(OnPrint);

            PrintSequenceStartCommand = new DelegateCommand(OnPrintSequenceStart);

            PrintSequenceCommand = new DelegateCommand<FrameworkElement>(OnPrintSequence);

            PreviousViewAddressCardCommnad = new DelegateCommand(PreviousViewAddressCard);

            NextViewAddressCardCommand = new DelegateCommand(NextViewAddressCard);

            ShowChangePrintingLocationHelperDialogCommnad = new DelegateCommand(ShowChangePrintingLocationHelperDialog);

            ValidViewAddressCardButtons();

            PreparePrinter();
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

                ValidViewAddressCardButtons();

                ChangeSelectedAddressCard();
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

        public ObservableCollection<AddressCardViewModel> AddressCards { get; }

        public List<AvailableFontFamilyName> AvailableFontFamilyNames { get; }

        public DelegateCommand GoBackAddressCardViewCommand { get; }

        public DelegateCommand<string> SetDefaultValueCommand { get; }

        public DelegateCommand SelectFontFamilyNameCommand { get; }

        public DelegateCommand SaveLayoutCommand { get; }

        public DelegateCommand<FrameworkElement> PrintCommand { get; }

        public DelegateCommand PrintSequenceStartCommand { get; }

        public DelegateCommand<FrameworkElement> PrintSequenceCommand { get; }

        public DelegateCommand PreviousViewAddressCardCommnad { get; }

        public DelegateCommand NextViewAddressCardCommand { get; }

        public DelegateCommand ShowChangePrintingLocationHelperDialogCommnad { get; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            // 他の画面からこの画面に遷移したときの処理

            AddressCards.Clear();

            var allAddressCards = addressCardService.LoadAll();

            foreach (var addressCard in allAddressCards)
            {
                AddressCards.Add(addressCard);
            }

            CurrentAddressCardIndex = 1;

            ChangeSelectedAddressCard();

            ValidViewAddressCardButtons();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            // 画面のインスタンスを使いまわす
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // この画面から他の画面に遷移するときの処理
        }

        private void GoBackAddressCardView()
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, "AddressCardListView");
        }

        private void SaveLayout()
        {
            addressCardLayoutService.Register(SelectedAddressCardLayout);

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

            var isConfirmedPrinting = printService.ConfirmPrinting();

            if (isConfirmedPrinting)
            {
                SelectedAddressCardLayout.IsAlreadyPrinted = false;

                RaisePropertyChanged(nameof(SelectedAddressCardLayout));

                Print(printElement);

                SelectedAddressCardLayout.IsAlreadyPrinted = true;

                RaisePropertyChanged(nameof(SelectedAddressCardLayout));
            }

            IsLetterCanvasTemplateVisible = true;
        }

        private void OnPrintSequenceStart()
        {
            addressCardLayoutService.Register(SelectedAddressCardLayout);

            CurrentAddressCardIndex = 1;

            if (FindNextPrintTarget())
            {
                var isConfirmedPrinting = printService.ConfirmPrinting();

                if (isConfirmedPrinting)
                {
                    eventAggregator.GetEvent<PrintSeqenceEvent>().Publish();
                }

                return;
            }

            dialogService.ShowInformationDialog("印刷が完了していない宛先がありませんでした。");
        }

        private void OnPrintSequence(FrameworkElement printElement)
        {
            Print(printElement);

            if (FindNextPrintTarget())
            {
                eventAggregator.GetEvent<PrintSeqenceEvent>().Publish();

                return;
            }

            SelectedAddressCardLayout.IsAlreadyPrinted = true;

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));

            IsLetterCanvasTemplateVisible = true;
        }

        private bool FindNextPrintTarget()
        {
            var addressCardLength = AddressCards.Count();

            var currentIndex = CurrentAddressCardIndex - 1;

            while (currentIndex < addressCardLength)
            {
                var addressCard = AddressCards[currentIndex];

                if (!addressCard.IsAlreadyPrinted)
                {
                    CurrentAddressCardIndex = currentIndex + 1;

                    return true;
                }

                currentIndex++;
            }

            return false;
        }

        private void Print(FrameworkElement printElement)
        {
            if (printElement is null) throw new ArgumentException("on printing arags element is null.");

            IsLetterCanvasTemplateVisible = false;

            printService.Print(printElement, SelectedAddressCardLayout.PrintMarginLeft, SelectedAddressCardLayout.PrintMarginTop);

            // dialogService.ShowPrintDialog(printElement, SelectedAddressCardLayout.PrintMarginLeft, SelectedAddressCardLayout.PrintMarginTop, false);

            var addressCard = AddressCards[CurrentAddressCardIndex - 1];

            addressCard.IsAlreadyPrinted = true;

            addressCard.PrintedDateTime = DateTime.Now;

            AddressCards[CurrentAddressCardIndex - 1] = addressCard;

            addressCardService.Register(addressCard);
        }

        private void SetDefaultValue(string targetName)
        {
            switch (targetName)
            {
                case "PostalCode.FontSize":
                    SelectedAddressCardLayout.PostalCode.Font.FontSize = AddressCardLayout.PostalCodeFontSizeDefaultValue;
                    break;

                case "PostalCode.SpaceBetweenMailWardAndTownWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenMailWardAndTownWard = AddressCardLayout.PostalCodeSpaceBetweenMainWardAndTownWardDefaultValue;
                    break;

                case "PostalCode.SpaceBetweenMailWardEachWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenMailWardEachWard = AddressCardLayout.PostalCodeSpaceBetweenMailWardEachWardDefaultValue;
                    break;

                case "PostatlCode.SpaceBetweenTownWardEachWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenTownWardEachWard = AddressCardLayout.PostalCodeSpaceBetweenTownWardEachWardDefaultValue;
                    break;

                case "SenderPostalCode.FontSize":
                    SelectedAddressCardLayout.SenderPostalCode.Font.FontSize = AddressCardLayout.SenderPostalCodeFontSizeDefaultValue;
                    break;

                case "SenderPostalCode.SpaceBetweenMailWardAndTownWard":
                    SelectedAddressCardLayout.SenderPostalCode.SpaceBetweenMailWardAndTownWard = AddressCardLayout.SenderPostalCodeSpaceBetweenMainWardAndTownWardDefaultValue;
                    break;

                case "SenderPostalCode.SpaceBetweenMailWardEachWard":
                    SelectedAddressCardLayout.SenderPostalCode.SpaceBetweenMailWardEachWard = AddressCardLayout.SenderPostalCodeSpaceBetweenMailWardEachWardDefaultValue;
                    break;

                case "SenderPostatlCode.SpaceBetweenTownWardEachWard":
                    SelectedAddressCardLayout.SenderPostalCode.SpaceBetweenTownWardEachWard = AddressCardLayout.SenderPostalCodeSpaceBetweenTownWardEachWardDefaultValue;
                    break;

                default:
                    return;
            }

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));
        }

        private void SelectFontFamilyName()
        {
            var selectedFontFamilyName = AvailableFontFamilyNames[SelectedFontFamilyId];

            SelectedAddressCardLayout.FontFamily = new FontFamily(selectedFontFamilyName.EnglishName);

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));
        }

        private void PreviousViewAddressCard()
        {
            CurrentAddressCardIndex -= 1;
        }

        private void NextViewAddressCard()
        {
            CurrentAddressCardIndex += 1;
        }

        private void ValidViewAddressCardButtons()
        {
            if (AddressCards.Count() <= 1)
            {
                IsEnablePreviousViewAddressCard = false;
                IsEnableNextViewAddressCard = false;

                return;
            }

            IsEnablePreviousViewAddressCard = CurrentAddressCardIndex > 1;
            IsEnableNextViewAddressCard = CurrentAddressCardIndex < AddressCards.Count();
        }

        private void ChangeSelectedAddressCard()
        {
            if (CurrentAddressCardIndex < 1 || AddressCards.Count() < CurrentAddressCardIndex) return;

            var selectedAddressCard = AddressCards[CurrentAddressCardIndex - 1];

            SelectedAddressCardLayout.AttachAddressCard(selectedAddressCard);

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));
        }

        private void ShowChangePrintingLocationHelperDialog()
        {
            dialogService.ShowChangePrintingLocationHelperDialog();
        }
    }
}
