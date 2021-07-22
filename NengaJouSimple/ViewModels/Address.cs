using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.ViewModels
{
    public class Address : BindableBase
    {
        private string zipCode;

        private string address1;

        private string address2;

        private string address3;

        private string address1Kana;

        private string address2Kana;

        private string address3Kana;

        private string name;

        private string renmei1;

        private string renmei2;

        private string renmei3;

        private string renmei4;

        private string renmei5;

        public string ZipCode
        {
            get { return zipCode; }
            set { SetProperty(ref zipCode, value); }
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

        public string Address1Kana
        {
            get { return address1Kana; }
            set { SetProperty(ref address1Kana, value); }
        }

        public string Address2Kana
        {
            get { return address2Kana; }
            set { SetProperty(ref address2Kana, value); }
        }

        public string Address3Kana
        {
            get { return address3Kana; }
            set { SetProperty(ref address3Kana, value); }
        }

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
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
