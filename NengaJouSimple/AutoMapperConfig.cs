using AutoMapper;
using NengaJouSimple.Data.Csv.Entities;
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

                config.CreateMap<PersonNameViewModel, PersonName>();

                config.CreateMap<SenderAddressCard, SenderAddressCardViewModel>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => new PostalCodeViewModel(src.PostalCode)))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new AddressViewModel(src.Address1, src.Address2, src.Address3)))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());

                config.CreateMap<SenderAddressCardViewModel, SenderAddressCard>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode.ToString()))
                    .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address.Address1))
                    .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address.Address2))
                    .ForMember(dest => dest.Address3, opt => opt.MapFrom(src => src.Address.Address3))
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());

                config.CreateMap<AddressCard, AddressCardViewModel>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => new PostalCodeViewModel(src.PostalCode)))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => new AddressViewModel(src.Address1, src.Address2, src.Address3)))
                    .ForMember(dest => dest.IsRegisterdCard, opt => opt.Ignore());

                config.CreateMap<AddressCardViewModel, AddressCard>()
                    .ForMember(dest => dest.PostalCode, opt => opt.MapFrom(src => src.PostalCode.ToString()))
                    .ForMember(dest => dest.Address1, opt => opt.MapFrom(src => src.Address.Address1))
                    .ForMember(dest => dest.Address2, opt => opt.MapFrom(src => src.Address.Address2))
                    .ForMember(dest => dest.Address3, opt => opt.MapFrom(src => src.Address.Address3))
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());


                config.CreateMap<Font, FontViewModel>()
                    .ForMember(dest => dest.FontFamily, opt =>
                    {
                        opt.PreCondition(src => !string.IsNullOrEmpty(src.FontFamilyName));
                        opt.MapFrom(src => new FontFamily(src.FontFamilyName));
                    })
                    .ForMember(dest => dest.FontStyle, opt => opt.MapFrom(src => src.FontStyle.ToFontStyle()))
                    .ForMember(dest => dest.FontWeight, opt => opt.MapFrom(src => src.FontWeight.ToFontWeight()));

                config.CreateMap<Position, PositionViewModel>();

                config.CreateMap<TextLayout, TextLayoutViewModel>()
                    .ForMember(dest => dest.Text, opt => opt.Ignore());

                config.CreateMap<PostalCodeTextLayout, PostalCodeTextLayoutViewModel>()
                    .IncludeBase<TextLayout, TextLayoutViewModel>();

                config.CreateMap<AddressCardLayout, AddressCardLayoutViewModel>();


                config.CreateMap<FontViewModel, Font>()
                    .ForMember(dest => dest.FontFamilyName, opt => opt.MapFrom(src => src.FontFamily.Source))
                    .ForMember(dest => dest.FontStyle, opt => opt.MapFrom(src => src.FontStyle.ToFontStyleKind()))
                    .ForMember(dest => dest.FontWeight, opt => opt.MapFrom(src => src.FontWeight.ToFontWeightKind()));

                config.CreateMap<PositionViewModel, Position>();

                config.CreateMap<TextLayoutViewModel, TextLayout>()
                    .ForMember(dest => dest.TextLayoutKind, opt => opt.Ignore())
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());

                config.CreateMap<PostalCodeTextLayoutViewModel, PostalCodeTextLayout>()
                    .IncludeBase<TextLayoutViewModel, TextLayout>();

                config.CreateMap<AddressCardLayoutViewModel, AddressCardLayout>()
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore());


                config.CreateMap<TextLayout, TextLayoutCsvDTO>()
                    .ForMember(dest => dest.FontFamilyName, opt => opt.MapFrom(src => src.Font.FontFamilyName))
                    .ForMember(dest => dest.FontSize, opt => opt.MapFrom(src => src.Font.FontSize))
                    .ForMember(dest => dest.FontStyle, opt => opt.MapFrom(src => src.Font.FontStyle))
                    .ForMember(dest => dest.FontWeight, opt => opt.MapFrom(src => src.Font.FontWeight))
                    .ForMember(dest => dest.VerticalAlignment, opt => opt.MapFrom(src => src.Font.VerticalAlignment))
                    .ForMember(dest => dest.SpaceBetweenMainWardAndTownWard, opt => opt.Ignore())
                    .ForMember(dest => dest.SpaceBetweenEachWard, opt => opt.Ignore());

                config.CreateMap<PostalCodeTextLayout, TextLayoutCsvDTO>()
                    .IncludeBase<TextLayout, TextLayoutCsvDTO>()
                    .ForMember(dest => dest.SpaceBetweenMainWardAndTownWard, opt => opt.MapFrom(src => src.SpaceBetweenMainWardAndTownWard))
                    .ForMember(dest => dest.SpaceBetweenEachWard, opt => opt.MapFrom(src => src.SpaceBetweenEachWard));

                config.CreateMap<TextLayoutCsvDTO, TextLayout>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Font, opt => opt.MapFrom(src => new Font(src.FontFamilyName, src.FontSize, src.FontStyle, src.FontWeight, src.VerticalAlignment)))
                    .ForMember(dest => dest.RegisterdDateTime, opt => opt.Ignore())
                    .ForMember(dest => dest.UpdatedDateTime, opt => opt.Ignore()); ;

                config.CreateMap<TextLayoutCsvDTO, PostalCodeTextLayout>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Font, opt => opt.MapFrom(src => new Font(src.FontFamilyName, src.FontSize, src.FontStyle, src.FontWeight, src.VerticalAlignment)))
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
