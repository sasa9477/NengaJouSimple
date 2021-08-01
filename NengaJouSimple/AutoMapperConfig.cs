using AutoMapper;
using NengaJouSimple.Data.Jsons.Entities;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Layouts;
using NengaJouSimple.ViewModels.Entities.Addresses;
using NengaJouSimple.ViewModels.Entities.Layouts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Media;

namespace NengaJouSimple
{
    public static class AutoMapperConfig
    {
        public static IMapper CreateMapper()
        {
            var mapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<PersonName, PersonNameViewModel>();

                config.CreateMap<Renmei, RenmeiViewModel>()
                    .IncludeBase<PersonName, PersonNameViewModel>();

                config.CreateMap<SenderAddressCard, SenderAddressCardViewModel>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => new PostalCodeViewModel(src.PostalCode)))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());

                config.CreateMap<AddressCard, AddressCardViewModel>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => new PostalCodeViewModel(src.PostalCode)))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());


                config.CreateMap<PersonNameViewModel, PersonName>();

                config.CreateMap<RenmeiViewModel, Renmei>()
                    .IncludeBase<PersonNameViewModel, PersonName>();

                config.CreateMap<SenderAddressCardViewModel, SenderAddressCard>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode.ToString()));

                config.CreateMap<AddressCardViewModel, AddressCard>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode.ToString()));


                config.CreateMap<Font, FontViewModel>()
                    .ForMember(dest => dest.FontStyle, opt => opt.MapFrom(src => src.FontStyle.ToFontStyle()))
                    .ForMember(dest => dest.FontWeight, opt => opt.MapFrom(src => src.FontWeight.ToFontWeight()));

                config.CreateMap<Position, PositionViewModel>();

                config.CreateMap<TextLayout, TextLayoutViewModel>()
                    .ForMember(dest => dest.Text, opt => opt.Ignore());

                config.CreateMap<PostalCodeTextLayout, PostalCodeTextLayoutViewModel>()
                    .ForMember(dest => dest.MailWard, opt => opt.Ignore())
                    .ForMember(dest => dest.TownWard, opt => opt.Ignore());

                config.CreateMap<AddressCardLayout, AddressCardLayoutViewModel>()
                    .ForMember(dest => dest.FontFamily, opt =>
                    {
                        opt.PreCondition(src => !string.IsNullOrEmpty(src.FontFamilyName));
                        opt.MapFrom(src => new FontFamily(src.FontFamilyName));
                    })
                    .ForMember(dest => dest.IsAlreadyPrinted, opt => opt.Ignore());

                config.CreateMap<AddressCardLayout, AddressCardLayoutJsonDTO>();


                config.CreateMap<FontViewModel, Font>()
                    .ForMember(dest => dest.FontStyle, opt => opt.MapFrom(src => src.FontStyle.ToFontStyleKind()))
                    .ForMember(dest => dest.FontWeight, opt => opt.MapFrom(src => src.FontWeight.ToFontWeightKind()));

                config.CreateMap<PositionViewModel, Position>();

                config.CreateMap<TextLayoutViewModel, TextLayout>()
                    .ForMember(dest => dest.TextLayoutKind, opt => opt.Ignore());

                config.CreateMap<PostalCodeTextLayoutViewModel, PostalCodeTextLayout>()
                    .ForMember(dest => dest.TextLayoutKind, opt => opt.Ignore());

                config.CreateMap<AddressCardLayoutViewModel, AddressCardLayout>()
                    .ForMember(dest => dest.FontFamilyName, opt => opt.MapFrom(src => src.FontFamily.Source))
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());

                config.CreateMap<AddressCardLayoutJsonDTO, AddressCardLayout>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());

            });

            try
            {
                mapperConfig.AssertConfigurationIsValid();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

                throw;
            }

            return mapperConfig.CreateMapper();
        }
    }
}
