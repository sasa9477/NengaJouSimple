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

namespace NengaJouSimple.ViewModels
{
    public class PrintLayoutSettingViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        private readonly IDialogService dialogService;

        private readonly AddressCardLayoutService addressCardLayoutService;

        private readonly AddressCardService addressCardService;

        private readonly PrintService printService;

        private AddressCardLayoutViewModel selectedAddressCardLayout;

        private bool isLetterCanvasVisible;

        private int currentAddressCardIndex;

        private bool isEnablePreviousViewAddressCard;

        private bool isEnableNextViewAddressCard;

        private bool isPreparedPrinter;

        public PrintLayoutSettingViewModel(
            IRegionManager regionManager,
            IDialogService dialogService,
            AddressCardLayoutService addressCardLayoutService,
            AddressCardService addressCardService,
            PrintService printService)
        {
            this.regionManager = regionManager;

            this.dialogService = dialogService;

            this.addressCardLayoutService = addressCardLayoutService;

            this.addressCardService = addressCardService;

            this.printService = printService;

            var allAddressCards = addressCardService.LoadAll();

            AddressCards = new ObservableCollection<AddressCardViewModel>(allAddressCards);

            SelectedAddressCardLayout = addressCardLayoutService.Load();

            SelectedAddressCardLayout.AttachAddressCard(allAddressCards.First());

            CurrentAddressCardIndex = 1;

            IsLetterCanvasVisible = true;

            GoBackAddressCardViewCommand = new DelegateCommand(GoBackAddressCardView);

            SetDefaultValueCommand = new DelegateCommand<string>(SetDefaultValue);

            SaveLayoutCommand = new DelegateCommand(SaveLayout);

            PrintCommand = new DelegateCommand<FrameworkElement>(OnPrint);

            PreviousViewAddressCardCommnad = new DelegateCommand(PreviousViewAddressCard);

            NextViewAddressCardCommand = new DelegateCommand(NextViewAddressCard);

            ValidViewAddressCardButtons();

            PreparePrinter();
        }

        public AddressCardLayoutViewModel SelectedAddressCardLayout
        {
            get { return selectedAddressCardLayout; }
            set { SetProperty(ref selectedAddressCardLayout, value); }
        }

        public bool IsLetterCanvasVisible
        {
            get { return isLetterCanvasVisible; }
            set { SetProperty(ref isLetterCanvasVisible, value); }
        }

        public int CurrentAddressCardIndex
        {
            get { return currentAddressCardIndex; }
            set { SetProperty(ref currentAddressCardIndex, value); }
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

        public ObservableCollection<AddressCardViewModel> AddressCards { get; }

        public DelegateCommand GoBackAddressCardViewCommand { get; }

        public DelegateCommand<string> SetDefaultValueCommand { get; }

        public DelegateCommand SaveLayoutCommand { get; }

        public DelegateCommand<FrameworkElement> PrintCommand { get; }

        public DelegateCommand PreviousViewAddressCardCommnad { get; }

        public DelegateCommand NextViewAddressCardCommand { get; }

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
            Task.Run(() =>
            {
                printService.PreparePrinting();

                IsPreparedPrinter = true;
            });
        }

        private void OnPrint(FrameworkElement element)
        {
            if (element == null) return;

            IsLetterCanvasVisible = false;

            addressCardLayoutService.Register(SelectedAddressCardLayout);

            var isPrinted = printService.Print(element, SelectedAddressCardLayout.PrintMarginLeft, SelectedAddressCardLayout.PrintMarginTop);

            if (isPrinted)
            {
                var addressCard = AddressCards[CurrentAddressCardIndex - 1];

                addressCard.IsAlreadyPrinted = true;

                addressCardService.Register(addressCard);

                SelectedAddressCardLayout.IsAlreadyPrinted = true;

                RaisePropertyChanged(nameof(SelectedAddressCardLayout));
            }

            IsLetterCanvasVisible = true;
        }

        private void SetDefaultValue(string targetName)
        {
            switch (targetName)
            {
                case "PostalCode.SpaceBetweenMailWardAndTownWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenMailWardAndTownWard = AddressCardLayout.PostalCodeSpaceBetweenMainWardAndTownWardDefaultValue;
                    break;

                case "PostalCode.SpaceBetweenMailWardEachWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenMailWardEachWard = AddressCardLayout.PostalCodeSpaceBetweenMailWardEachWardDefaultValue;
                    break;

                case "PostatlCode.SpaceBetweenTownWardEachWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenTownWardEachWard = AddressCardLayout.PostalCodeSpaceBetweenTownWardEachWardDefaultValue;
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

        private void PreviousViewAddressCard()
        {
            CurrentAddressCardIndex -= 1;

            ValidViewAddressCardButtons();

            ChangeSelectedAddressCard();
        }

        private void NextViewAddressCard()
        {
            CurrentAddressCardIndex += 1;

            ValidViewAddressCardButtons();

            ChangeSelectedAddressCard();
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
    }
}
