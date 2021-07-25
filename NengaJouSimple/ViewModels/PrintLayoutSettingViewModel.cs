using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels
{
    public class PrintLayoutSettingViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public PrintLayoutSettingViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            GoBackAddressCardViewCommand = new DelegateCommand(GoBackAddressCardView);
        }

        public DelegateCommand GoBackAddressCardViewCommand { get; }
        
        private void GoBackAddressCardView()
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, "AddressCardListView");
        }
    }
}
