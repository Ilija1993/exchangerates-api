using AutoMapper;
using ExchangeRates.API.Mappings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace ExchangeRates.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(typeof(ExchangeRatesMappingProfile));
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Exchange Rates API", Version = "v1" });
            });

            return services;
        }
    }
}
