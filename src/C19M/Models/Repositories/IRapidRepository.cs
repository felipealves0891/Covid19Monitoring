using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Models.Repositories
{
    public interface IRapidRepository
    {
        public Task<IEnumerable<Latest>> GetLatestAllCountries();

        public Task<Latest> GetLatestCountryDataByCode(string code);

        public Task<Latest> GetLatestCountryDataByName(string name);

        public Task<Daily> GetDailyReportByCountryName(string name, DateTime date);

        public Task<Daily> GetDailyReportByCountryCode(string code, DateTime date);

        public Task<IEnumerable<Daily>> GetDailyReportAllCountries(DateTime date);

        public Task<LatestTotal> GetLatestTotals();

        public Task<DailyTotal> GetDailyReportTotals(DateTime date);

        public Task<IEnumerable<Country>> GetListOfCountries();

    }
}
