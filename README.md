EXCHANGE-RATES API

Request example that returns historical exchange rate info: 
GET http://localhost:63907/api/ExchangeRates?dates=2018-03-01,2018-02-15,2018-03-01&baseCurrency=SEK&targetCurrency=NOK

Dates must be comma-separated and format: yyyy-MM-dd must be used with date less than or equal to the current date.

Currencies that are available for usage are:
USD,JPY,BGN,CZK,DKK,GBP,HUF,PLN,
SEK,CHF,ISK,NOK,HRK,RUB,TRY,AUD,
BRL,CAD,CNY,HKD,IDR,ILS,INR,KRW,
MXN,MYR,NZD,PHP,SGD,THB,ZAR,RON

Just start app in Visual Studio 2019 and use Swagger
