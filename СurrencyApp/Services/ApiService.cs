using CurrencyApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using СurrencyApp.Interfaces;

namespace СurrencyApp.Services
{
    // TODO Move links in config file
    //
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IEnumerable<RateShort>> GetIntervalExchangeRate(DateTime startDate, DateTime endDate)
        {
            if (startDate < endDate || startDate == default || endDate == default)
                return null;
            
            var rateShortsJson = await _httpClient
                .GetStringAsync($"https://api.nbrb.by/exrates/rates/dynamics/440?startDate={startDate.Date}&endDate={endDate.Date}");

            if(string.IsNullOrEmpty(rateShortsJson))
                return null;

            var rateShorts = JsonConvert.DeserializeObject<IEnumerable<RateShort>>(rateShortsJson);

            return rateShorts;
        }

        public async Task<IEnumerable<Rate>> GetOnDayExchangeRate(DateTime onDate)
        {
            if (onDate == default)
                onDate = DateTime.Now;

            var ratesJson = await _httpClient
                .GetStringAsync($"https://api.nbrb.by/exrates/rates?ondate={onDate.Date}&periodicity=0");

            if (string.IsNullOrEmpty(ratesJson))
                return null;

            var rates = JsonConvert.DeserializeObject<IEnumerable<Rate>>(ratesJson);

            return rates;
        }
    }
}
