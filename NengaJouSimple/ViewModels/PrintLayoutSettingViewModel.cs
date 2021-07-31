using NengaJouSimple.Models.Layouts;
using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Entities.Addresses;
using NengaJouSimple.ViewModels.Entities.Layouts;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;

namespace NengaJouSimple.ViewModels
{
    public class PrintLayoutSettingViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private readonly AddressCardService addressCardService;

        private readonly AddressCardLayoutService addressCardLayoutService;

        private AddressCardLayoutViewModel selectedAddressCardLayout;

        private bool isLetterCanvasVisible;

        private int currentAddressCardIndex;

        private bool isEnablePreviousViewAddressCard;

        private bool isEnableNextViewAddressCard;

        public PrintLayoutSettingViewModel(
            IRegionManager regionManager,
            AddressCardLayoutService addressCardLayoutService,
            AddressCardService addressCardService)
        {
            this.regionManager = regionManager;

            this.addressCardLayoutService = addressCardLayoutService;

            this.addressCardService = addressCardService;

            var allAddressCards = addressCardService.LoadAll();

            AddressCards = new ObservableCollection<AddressCardViewModel>(allAddressCards);

            SelectedAddressCardLayout = addressCardLayoutService.Load();

            SelectedAddressCardLayout.AttachAddressCard(allAddressCards.First());

            GoBackAddressCardViewCommand = new DelegateCommand(GoBackAddressCardView);

            SetDefaultValueCommand = new DelegateCommand<string>(SetDefaultValue);

            PrintButtonClickCommand = new DelegateCommand<FrameworkElement>(OnPrintButtonClick);

            PreviousViewAddressCardCommnad = new DelegateCommand(PreviousViewAddressCard);

            NextViewAddressCardCommand = new DelegateCommand(NextViewAddressCard);

            ValidViewAddressCardButtons();
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

        public ObservableCollection<AddressCardViewModel> AddressCards { get; }

        public DelegateCommand GoBackAddressCardViewCommand { get; }

        public DelegateCommand<string> SetDefaultValueCommand { get; }

        public DelegateCommand<FrameworkElement> PrintButtonClickCommand { get; }

        public DelegateCommand PreviousViewAddressCardCommnad { get; }

        public DelegateCommand NextViewAddressCardCommand { get; }

        private void GoBackAddressCardView()
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, "AddressCardListView");
        }

        private void OnPrintButtonClick(FrameworkElement element)
        {
            if (element == null) return;

            IsLetterCanvasVisible = false;

            //var printer = new Printer();
            //printer.Print(element, -3.78, 0);

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

            IsEnablePreviousViewAddressCard = CurrentAddressCardIndex > 0;
            IsEnableNextViewAddressCard = CurrentAddressCardIndex < AddressCards.Count() - 1;
        }

        private void ChangeSelectedAddressCard()
        {
            if (CurrentAddressCardIndex < 0 || AddressCards.Count() <= CurrentAddressCardIndex) return;

            var selectedAddressCard = AddressCards[CurrentAddressCardIndex];

            SelectedAddressCardLayout.AttachAddressCard(selectedAddressCard);

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));
        }
    }
}
