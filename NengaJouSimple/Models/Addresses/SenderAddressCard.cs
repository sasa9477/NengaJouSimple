﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Models.Addresses
{
    public class SenderAddressCard : EntityBase
    {
        public SenderAddressCard()
        {
            MainName = new PersonName();
            MainNameKana = new PersonName();
            PostalCode = string.Empty;
            Address = string.Empty;
            Renmei1 = new Renmei();
            Renmei2 = new Renmei();
            Renmei3 = new Renmei();
            Renmei4 = new Renmei();
            Renmei5 = new Renmei();
        }

        public PersonName MainName { get; set; }

        public PersonName MainNameKana { get; set; }

        public string PostalCode { get; set; }

        public string Address { get; set; }

        public Renmei Renmei1 { get; set; }

        public Renmei Renmei2 { get; set; }

        public Renmei Renmei3 { get; set; }

        public Renmei Renmei4 { get; set; }

        public Renmei Renmei5 { get; set; }
    }
}
