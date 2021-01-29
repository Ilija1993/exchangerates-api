using AutoMapper;
using ExchangeRates.API.Dtos;
using ExchangeRates.API.Extensions;
using ExchangeRates.Core.Models;

namespace ExchangeRates.API.Mappings
{
    public class ExchangeRatesMappingProfile : Profile
    {

        public ExchangeRatesMappingProfile()
        {
            CreateMap<ExchangeRatesDto, ExchangeRatesRequest>()
           .ForMember(dest => dest.BaseCurrency, opts => opts.MapFrom(src => src.BaseCurrency.ToUpper()))
           .ForMember(dest => dest.TargetCurrency, opts => opts.MapFrom(src => src.TargetCurrency.ToUpper()))
           .ForMember(dest => dest.Dates, opts => opts.MapFrom(src => src.Dates.ConvertToDateTimeList(',')));
        }
    }
}
