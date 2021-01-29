using ExchangeRates.API.Dtos;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Linq;

namespace ExchangeRates.API.FluentValidators
{
    public class ExchangeRatesFluentValidator : AbstractValidator<ExchangeRatesDto>
    {
        public ExchangeRatesFluentValidator()
        {
            RuleFor(model => model.BaseCurrency).NotEmpty().NotNull();
            RuleFor(model => model.TargetCurrency).NotEmpty().NotNull();

            RuleFor(model => model).Custom((dto, context) =>
            {
                dto.Dates.Split(',').ToList().ForEach(date =>
                {
                    if (!DateTime.TryParse(date, out var parsedDate))
                    {
                        context.AddFailure(new ValidationFailure(nameof(dto.Dates), $"{nameof(dto.Dates)} must be in format: yyyy-MM-dd and Separator , must be used!"));
                        return;
                    }

                    if (parsedDate.Date > DateTime.Now.Date)
                    {
                        context.AddFailure(new ValidationFailure(nameof(dto.Dates), $"{nameof(dto.Dates)} year must be less than current date!"));
                        return;
                    }
                });
            });
        }
    }
}
