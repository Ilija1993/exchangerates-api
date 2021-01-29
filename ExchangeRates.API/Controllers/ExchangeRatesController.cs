using AutoMapper;
using ExchangeRates.API.Dtos;
using ExchangeRates.Core.Models;
using ExchangeRates.Services.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExchangeRates.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRatesService _exchangeRatesService;
        public readonly IMapper _mapper;

        public ExchangeRatesController(IExchangeRatesService exchangeRatesService,IMapper mapper)
        {
            _exchangeRatesService = exchangeRatesService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] ExchangeRatesDto model)
        {
            var mapped = _mapper.Map<ExchangeRatesDto, ExchangeRatesRequest>(model);

            return Ok(await _exchangeRatesService.GetExchangeRatesAsync(mapped));
        }
    }
}
