using AutoMapper;
using NengaJouSimple.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple.Services
{
    public class AddressCardService
    {
        private readonly IMapper mapper;

        public AddressCardService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void Register(ViewModels.Entities.AddressCard addressCard)
        {
            var x = mapper.Map<Models.AddressCard>(addressCard);
            System.Diagnostics.Debug.WriteLine("Register AddressCardService!");
        }

        public void Delete(ViewModels.Entities.AddressCard addressCard)
        {

        }
    }
}
