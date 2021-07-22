using NengaJouSimple.ViewModels.Entities;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels.Components
{
    public class AddressRegisterControlViewModel : BindableBase
    {

        private PersonName mainName = new PersonName();

        private PersonName mainNameKana = new PersonName();

        private string addressNumber1 = string.Empty;

        private string addressNumber2 = string.Empty;

        private string address1 = string.Empty;

        private string address2 = string.Empty;

        private string address3 = string.Empty;

        private PersonName renmei1 = new PersonName();

        private PersonName renmei2 = new PersonName();

        private PersonName renmei3 = new PersonName();

        private PersonName renmei4 = new PersonName();

        private PersonName renmei5 = new PersonName();

        public AddressRegisterControlViewModel()
        {
            mainName.FamilyName = "福田";
            mainName.Honorific = Honorific.FirstItem;
        }

        public List<string> Honorifics => Honorific.Items;

        public PersonName MainName
        {
            get { return mainName; }
            set { SetProperty(ref mainName, value); }
        }

        public string AddressNumber1
        {
            get { return addressNumber1; }
            set { SetProperty(ref addressNumber1, value); }
        }

        public string AddressNumber2
        {
            get { return addressNumber2; }
            set { SetProperty(ref addressNumber2, value); }
        }

        public string Address1
        {
            get { return address1; }
            set { SetProperty(ref address1, value); }
        }

        public string Address2
        {
            get { return address2; }
            set { SetProperty(ref address2, value); }
        }

        public string Address3
        {
            get { return address3; }
            set { SetProperty(ref address3, value); }
        }


        public PersonName MainNameKana
        {
            get { return mainNameKana; }
            set { SetProperty(ref mainNameKana, value); }
        }

        public PersonName Renmei1
        {
            get { return renmei1; }
            set { SetProperty(ref renmei1, value); }
        }

        public PersonName Renmei2
        {
            get { return renmei2; }
            set { SetProperty(ref renmei2, value); }
        }

        public PersonName Renmei3
        {
            get { return renmei3; }
            set { SetProperty(ref renmei3, value); }
        }

        public PersonName Renmei4
        {
            get { return renmei4; }
            set { SetProperty(ref renmei4, value); }
        }

        public PersonName Renmei5
        {
            get { return renmei5; }
            set { SetProperty(ref renmei5, value); }
        }

        public DelegateCommand<string> SearchByAddressNumberCommand => new DelegateCommand<string>(SearchByAddressNumber);

        public DelegateCommand RegisterAddressCommand => new DelegateCommand(RegisterAddress);

        private void SearchByAddressNumber(string addressNumber)
        {
            if (addressNumber.Length != 7)
            {
                return;
            }

            // TODO: HttpRequest through AddressSearch service.
            // If it will failed, no action.
            Address1 = $"[{addressNumber}]東京都江東区北砂";
        }

        private void RegisterAddress()
        {
            // TODO: Register address through Address service.

            System.Diagnostics.Debug.WriteLine("Register!");
        }
    }
}
