using System.Globalization;
using System;
using System.Net;
using Azure.Core;
using Google.Protobuf;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Paperless.Core.Model;
using Paperless.Core.Services;

namespace Paperless.Main
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly IExchangeRateService _exchangeRateService;

        public Function1(ILoggerFactory loggerFactory, IExchangeRateService exchangeRateService)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _exchangeRateService = exchangeRateService;
        }

        [Function("currency/{date}")]
        public async Task<BodyResponse> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req, string date)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            BodyResponse bodyResponse = null;
            DateTime dateTime = DateTime.UtcNow;
            if(DateTime.TryParseExact(date, "yyMM", provider, DateTimeStyles.None, out dateTime))
            {
               bodyResponse = await _exchangeRateService.GetCurrency(dateTime.Year, dateTime.Month);
            }
            else
            {
                _logger.LogInformation("Can't convert string to date.");
            }


            return bodyResponse;
        }
    }
}
