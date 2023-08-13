using Paperless.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paperless.Core.Services
{
    public interface IExchangeRateService
    {
        Task<BodyResponse> GetCurrency(int year, int month);
    }
}
