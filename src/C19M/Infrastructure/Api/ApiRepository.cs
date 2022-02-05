using C19M.Models;
using C19M.Models.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Infrastructure.Api
{
    public class ApiRepository : IRapidRepository
    {
        private readonly RestClient _client;
        private readonly ILogger<ApiRepository> _logger;

        public ApiRepository(
            IConfiguration configuration, 
            ILogger<ApiRepository> logger)
        {
            _logger = logger;
            _client = new RestClient(configuration["RapidApi:Url"])
                            .AddDefaultHeader("x-rapidapi-host", configuration["RapidApi:Host"])
                            .AddDefaultHeader("x-rapidapi-key", configuration["RapidApi:Key"]);
            
        }

        public async Task<IEnumerable<Daily>> GetDailyReportAllCountries(DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            RestRequest request = new RestRequest("/report/country/all", Method.Get);
            request.AddQueryParameter("date", formattedDate);
            
            _logger.LogInformation("Requisição enviada para GET:/report/country/all?date={0}", formattedDate);

            return await _client.GetAsync<IEnumerable<Daily>>(request);

        }

        public async Task<Daily> GetDailyReportByCountryCode(string code, DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            RestRequest request = new RestRequest("/report/country/code", Method.Get)
                                        .AddQueryParameter("date", formattedDate)
                                        .AddQueryParameter("code", code);

            _logger.LogInformation("Requisição enviada para GET:/report/country/code?date={0}&code={1}", formattedDate, code);

            return await _client.GetAsync<Daily>(request);
        }

        public async Task<Daily> GetDailyReportByCountryName(string name, DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            RestRequest request = new RestRequest("/report/country/name", Method.Get)
                                        .AddQueryParameter("date", formattedDate)
                                        .AddQueryParameter("name", name);

            _logger.LogInformation("Requisição enviada para GET:/report/country/name?date={0}&code={1}", formattedDate, name);

            return await _client.GetAsync<Daily>(request);
        }

        public async Task<DailyTotal> GetDailyReportTotals(DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            RestRequest request = new RestRequest("/report/totals", Method.Get)
                                        .AddQueryParameter("date", formattedDate);

            _logger.LogInformation("Requisição enviada para GET:/report/totals?date={0}", formattedDate);

            return await _client.GetAsync<DailyTotal>(request);
        }

        public async Task<IEnumerable<Latest>> GetLatestAllCountries()
        {
            _logger.LogInformation("Requisição enviada para GET:/country/all");
            RestRequest request = new RestRequest("/country/all", Method.Get);
            return await _client.GetAsync<IEnumerable<Latest>>(request);
        }

        public async Task<Latest> GetLatestCountryDataByCode(string code)
        {
            _logger.LogInformation("Requisição enviada para GET:/country/code");
            RestRequest request = new RestRequest("/country/code", Method.Get)
                                        .AddQueryParameter("code", code);

            return await _client.GetAsync<Latest>(request);
        }

        public async Task<Latest> GetLatestCountryDataByName(string name)
        {
            _logger.LogInformation("Requisição enviada para GET:/country/name?name={0}", name);
            RestRequest request = new RestRequest("/country/name", Method.Get)
                                        .AddQueryParameter("name", name);

            return await _client.GetAsync<Latest>(request);
        }

        public async Task<LatestTotal> GetLatestTotals()
        {
            _logger.LogInformation("Requisição enviada para GET:/totals");
            RestRequest request = new RestRequest("/totals", Method.Get);
            return await _client.GetAsync<LatestTotal>(request);
        }

        public async Task<IEnumerable<Country>> GetListOfCountries()
        {
            _logger.LogInformation("Requisição enviada para GET:/help/countries");
            RestRequest request = new RestRequest("/help/countries", Method.Get);
            return await _client.GetAsync<IEnumerable<Country>>(request);
        }
    }
}
