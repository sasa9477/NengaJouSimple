using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;

namespace NengaJouSimple.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private string _title = "年賀状アプリケーション";

        public MainWindowViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

            LoadedCommand = new DelegateCommand(Loaded);
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand LoadedCommand { get; }

        private void Loaded()
        {
            regionManager.RequestNavigate(RegionNames.ContentRegion, "AddressCardListView");
        }
    }
}
