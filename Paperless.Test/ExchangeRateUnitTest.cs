using Moq;
using Paperless.Core.Services;
using System;

namespace Paperless.Test
{
    [TestClass]
    public class ExchangeRateUnitTest
    {
        private readonly IExchangeRateService _exchangeRateService;
        public ExchangeRateUnitTest()
        {
            _exchangeRateService = Helper.GetRequiredService<IExchangeRateService>() ?? throw new ArgumentNullException(nameof(IExchangeRateService));
        }
        [TestMethod]
        public async Task TestMethod1()
        {
            var result = await _exchangeRateService.GetCurrency(23, 07);
            Assert.IsTrue(result.GRAPH.Any());
        }
    }
}