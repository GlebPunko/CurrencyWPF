using CurrencyApp.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace СurrencyApp.Interfaces
{
    public interface IApiService
    {
        Task<IEnumerable<Rate>> GetOnDayExchangeRate(DateTime onDate);
        Task<IEnumerable<RateShort>> GetIntervalExchangeRate(DateTime startDate, DateTime endDate);
    }
}
