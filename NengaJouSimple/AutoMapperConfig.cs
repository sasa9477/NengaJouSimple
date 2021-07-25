using AutoMapper;
using NengaJouSimple.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NengaJouSimple
{
    public static class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonName, ViewModels.Entities.PersonName>();

                config.CreateMap<ViewModels.Entities.PersonName, PersonName>();

                config.CreateMap<SenderAddressCard, ViewModels.Entities.SenderAddressCard>()
                    .ForMember(dest => dest.AddressNumber, opt => opt.MapFrom(src => new ViewModels.Entities.AddressNumber(src.AddressNumber)))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new ViewModels.Entities.Address(src.Address1, src.Address2, src.Address3)))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());

                config.CreateMap<ViewModels.Entities.SenderAddressCard, SenderAddressCard>()
                    .ForMember(dest => dest.AddressNumber, opt => opt.MapFrom(src => src.AddressNumber.ToString()))
                    .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address.Address1))
                    .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address.Address2))
                    .ForMember(dest => dest.Address3, opt => opt.MapFrom(src => src.Address.Address3))
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());

                config.CreateMap<AddressCard, ViewModels.Entities.AddressCard>()
                    .ForMember(dest => dest.AddressNumber, opt => opt.MapFrom(src => new ViewModels.Entities.AddressNumber(src.AddressNumber)))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new ViewModels.Entities.Address(src.Address1, src.Address2, src.Address3)))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());

                config.CreateMap<ViewModels.Entities.AddressCard, AddressCard>()
                    .ForMember(dest => dest.AddressNumber, opt => opt.MapFrom(src => src.AddressNumber.ToString()))
                    .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address.Address1))
                    .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address.Address2))
                    .ForMember(dest => dest.Address3, opt => opt.MapFrom(src => src.Address.Address3))
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());
            });

            mapperConfig.AssertConfigurationIsValid();

            return mapperConfig.CreateMapper();
        }
    }
}
