using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels
{
    public class AddressCardListWindowViewModel : BindableBase
    {
        private string address;

        private string fullName;

        private string renmei1;

        private string renmei2;

        private string renmei3;

        private string renmei4;

        private string renmei5;

        public string Address
        {
            get { return address; }
            set { SetProperty(ref address, value); }
        }

        public string FullName
        {
            get { return fullName; }
            set { SetProperty(ref fullName, value); }
        }

        public string Renmei1
        {
            get { return renmei1; }
            set { SetProperty(ref renmei1, value); }
        }

        public string Renmei2
        {
            get { return renmei2; }
            set { SetProperty(ref renmei2, value); }
        }

        public string Renmei3
        {
            get { return renmei3; }
            set { SetProperty(ref renmei3, value); }
        }

        public string Renmei4
        {
            get { return renmei4; }
            set { SetProperty(ref renmei4, value); }
        }

        public string Renmei5
        {
            get { return renmei5; }
            set { SetProperty(ref renmei5, value); }
        }
    }
}
