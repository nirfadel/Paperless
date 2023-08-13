using Microsoft.VisualBasic;
using Paperless.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperless.Core.Services
{
    public class ExchangeRateService : BaseHttpService, IExchangeRateService
    {
        /// <summary>
        /// Get currency by year and month
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public async Task<BodyResponse> GetCurrency(int year, int month)
        {
            string result = string.Empty;
            try
            {
                result = await Client.GetStringAsync($"https://currencies.apps.grandtrunk.net/getrange/{year}-{getMonth(month)}-01/{year}-{getMonth(month)}-{DateTime.DaysInMonth(year, month)}/usd/ils");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
           
            return GetCurrencyData(result);
}

        /// <summary>
        /// Get all data after currency converter
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private BodyResponse GetCurrencyData(string result)
        {
            BodyResponse bodyResponse = new BodyResponse();
            try
            {
                using (StringReader reader = new StringReader(result))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        DateTime _date = DateTime.MinValue;
                        decimal _rate = 0;
                        var date = line.Split(" ")[0];
                        if (date != null)
                        {
                            DateTime.TryParse(date, out _date);
                        }
                        var rate = line.Split(" ")[1];

                        if (rate != null)
                        {
                            decimal.TryParse(rate, out _rate);
                        }

                        bodyResponse.GRAPH.Add(_date.Day, _rate);
                    }
                }

                bodyResponse.MinValue = bodyResponse.GRAPH.Values.Min();
                bodyResponse.MaxValue = bodyResponse.GRAPH.Values.Max();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           

            return bodyResponse;
        }

        /// <summary>
        /// Get month with zero if need
        /// </summary>
        /// <param name="month"></param>
        /// <returns></returns>
        string getMonth(int month)
        {
            if (month < 10)
                return '0' + month.ToString();
            return month.ToString();
        }
    }
}
