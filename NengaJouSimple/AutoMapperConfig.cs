using AutoMapper;
using NengaJouSimple.Models.Addresses;
using NengaJouSimple.Models.Layouts;
using NengaJouSimple.Models.Settings;
using NengaJouSimple.ViewModels.Entities.Addresses;
using NengaJouSimple.ViewModels.Entities.Layouts;
using NengaJouSimple.ViewModels.Entities.Settings;
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
                // Addresses
                config.CreateMap<PersonName, PersonNameViewModel>();

                config.CreateMap<Renmei, RenmeiViewModel>()
                    .IncludeBase<PersonName, PersonNameViewModel>();

                config.CreateMap<SenderAddressCard, SenderAddressCardViewModel>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());

                config.CreateMap<AddressCard, AddressCardViewModel>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());

                // Layouts
                config.CreateMap<Position, PositionViewModel>();

                config.CreateMap<TextLayout, TextLayoutViewModel>();

                config.CreateMap<AddressCardLayout, AddressCardLayoutViewModel>()
                    .ForMember(dest => dest.IsAlreadyPrinted, opt => opt.Ignore());

                // Settings
                config.CreateMap<TextLayoutSetting, TextLayoutSettingViewModel>();

                config.CreateMap<PostalCodeTextLayoutSetting, PostalCodeTextLayoutSettingViewModel>()
                    .IncludeBase<TextLayoutSetting, TextLayoutSettingViewModel>();

                config.CreateMap<AvailableFontFamilyName, AvailableFontFamilyNameViewModel>();

                config.CreateMap<ApplicationSetting, ApplicationSettingViewModel>();

                // Addresses
                config.CreateMap<PersonNameViewModel, PersonName>();

                config.CreateMap<RenmeiViewModel, Renmei>()
                    .IncludeBase<PersonNameViewModel, PersonName>();

                config.CreateMap<SenderAddressCardViewModel, SenderAddressCard>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode.Length == 7 ? $"{src.PostalCode.Substring(0, 3)}-{src.PostalCode.Substring(3, 4)}" : src.PostalCode));

                config.CreateMap<AddressCardViewModel, AddressCard>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode.Length == 7 ? $"{src.PostalCode.Substring(0, 3)}-{src.PostalCode.Substring(3, 4)}" : src.PostalCode));

                // Layouts
                config.CreateMap<PositionViewModel, Position>();

                config.CreateMap<TextLayoutViewModel, TextLayout>();

                config.CreateMap<AddressCardLayoutViewModel, AddressCardLayout>();

                // Settings
                config.CreateMap<TextLayoutSettingViewModel, TextLayoutSetting>();

                config.CreateMap<PostalCodeTextLayoutSettingViewModel, PostalCodeTextLayoutSetting>()
                    .IncludeBase<TextLayoutSettingViewModel, TextLayoutSetting>();

                config.CreateMap<AvailableFontFamilyNameViewModel, AvailableFontFamilyName>();

                config.CreateMap<ApplicationSettingViewModel, ApplicationSetting>();
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
