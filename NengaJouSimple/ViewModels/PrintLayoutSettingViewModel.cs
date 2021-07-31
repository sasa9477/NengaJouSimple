using NengaJouSimple.Services;
using NengaJouSimple.ViewModels.Entities.Addresses;
using NengaJouSimple.ViewModels.Entities.Layouts;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace NengaJouSimple.ViewModels
{
    public class PrintLayoutSettingViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private readonly AddressCardService addressCardService;

        private AddressCardLayoutViewModel selectedAddressCardLayout;

        private bool isLetterCanvasVisible;

        private int currentAddressCardIndex;

        public PrintLayoutSettingViewModel(
            IRegionManager regionManager,
            AddressCardService addressCardService)
        {
            this.regionManager = regionManager;

            this.addressCardService = addressCardService;

            var allAddressCards = addressCardService.LoadAll();

            AddressCards = new ObservableCollection<AddressCardViewModel>(allAddressCards);

            GoBackAddressCardViewCommand = new DelegateCommand(GoBackAddressCardView);

            SetDefaultValueCommand = new DelegateCommand<string>(SetDefaultValue);

            PrintButtonClickCommand = new DelegateCommand<FrameworkElement>(OnPrintButtonClick);

            PreviousViewAddressCardCommnad = new DelegateCommand(PreviousViewAddressCard);

            NextViewAddressCardCommand = new DelegateCommand(NextViewAddressCard);
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
                case "PostalCodeSpaceBetweenMainWardAndTownWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenMainWardAndTownWard = 2.2;
                    break;

                case "PostalCodeSpaceBetweenEachWard":
                    SelectedAddressCardLayout.PostalCode.SpaceBetweenEachWard = 4;
                    break;

                case "SenderPostalCodeSpaceBetweenMainWardAndTownWard":
                    SelectedAddressCardLayout.SenderPostalCode.SpaceBetweenMainWardAndTownWard = 4;
                    break;

                case "SenderPostalCodeSpaceBetweenEachWard":
                    SelectedAddressCardLayout.SenderPostalCode.SpaceBetweenEachWard = 1.5;
                    break;

                default:
                    return;
            }

            RaisePropertyChanged(nameof(SelectedAddressCardLayout));
        }

        private void PreviousViewAddressCard()
        {
            CurrentAddressCardIndex -= 1;

            ChangeSelectedAddressCard();
        }

        private void NextViewAddressCard()
        {
            CurrentAddressCardIndex += 1;

            ChangeSelectedAddressCard();
        }
        private void ChangeSelectedAddressCard()
        {
//            SelectedAddressCardLayout = AddressCardLayoutViewModel();
        }
    }
}
