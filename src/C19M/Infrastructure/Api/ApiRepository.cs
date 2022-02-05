using C19M.Models;
using C19M.Models.Repositories;
using Microsoft.Extensions.Configuration;
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

        public ApiRepository(IConfiguration configuration)
        {
            _client = new RestClient(configuration["RapidApi:Url"])
                            .AddDefaultHeader("x-rapidapi-host", configuration["RapidApi:Host"])
                            .AddDefaultHeader("x-rapidapi-key", configuration["RapidApi:Key"]);

        }

        public async Task<IEnumerable<Daily>> GetDailyReportAllCountries(DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");

            RestRequest request = new RestRequest("/report/country/all", Method.Get);
            request.AddQueryParameter("date", formattedDate);

            return await _client.GetAsync<IEnumerable<Daily>>(request);

        }

        public async Task<Daily> GetDailyReportByCountryCode(string code, DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            RestRequest request = new RestRequest("/report/country/code", Method.Get)
                                        .AddQueryParameter("date", formattedDate)
                                        .AddQueryParameter("code", code);

            return await _client.GetAsync<Daily>(request);
        }

        public async Task<Daily> GetDailyReportByCountryName(string name, DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            RestRequest request = new RestRequest("/report/country/name", Method.Get)
                                        .AddQueryParameter("date", formattedDate)
                                        .AddQueryParameter("name", name);

            return await _client.GetAsync<Daily>(request);
        }

        public async Task<DailyTotal> GetDailyReportTotals(DateTime date)
        {
            string formattedDate = date.ToString("yyyy-MM-dd");
            RestRequest request = new RestRequest("/report/totals", Method.Get)
                                        .AddQueryParameter("date", formattedDate);

            return await _client.GetAsync<DailyTotal>(request);
        }

        public async Task<IEnumerable<Latest>> GetLatestAllCountries()
        {
            RestRequest request = new RestRequest("/country/all", Method.Get);
            return await _client.GetAsync<IEnumerable<Latest>>(request);
        }

        public async Task<Latest> GetLatestCountryDataByCode(string code)
        {
            RestRequest request = new RestRequest("/country/code", Method.Get)
                                        .AddQueryParameter("code", code);

            return await _client.GetAsync<Latest>(request);
        }

        public async Task<Latest> GetLatestCountryDataByName(string name)
        {
            RestRequest request = new RestRequest("/country/name", Method.Get)
                                        .AddQueryParameter("name", name);

            return await _client.GetAsync<Latest>(request);
        }

        public async Task<LatestTotal> GetLatestTotals()
        {
            RestRequest request = new RestRequest("/totals", Method.Get);
            return await _client.GetAsync<LatestTotal>(request);
        }

        public async Task<IEnumerable<Country>> GetListOfCountries()
        {
            RestRequest request = new RestRequest("/help/countries", Method.Get);
            return await _client.GetAsync<IEnumerable<Country>>(request);
        }
    }
}
