using C19M.Helpers.Pagination;
using C19M.Models;
using C19M.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace C19M.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRapidRepository _repository;
        private readonly IRedisRepository _cache;

        public HomeController(
            ILogger<HomeController> logger,
            IRapidRepository repository,
            IRedisRepository cache
        ) {
            _logger = logger;
            _repository = repository;
            _cache = cache;
        }

        public async Task<IActionResult> Index(
            int? pageNumber = null, 
            int? pageSize = null,
            string sortField = null,
            string sortOrder = null,
            string searchText = null
        ) {
            
            string path = HttpContext.Request.Path + '?' + HttpContext.Request.QueryString;
            IEnumerable<Country> inCache = _cache.Get<IEnumerable<Country>>(path, null);
            PaginatedList<Country> paginatedList;

            if(inCache != null)
            {
                paginatedList = PaginatedList<Country>.Create(inCache, pageNumber ?? 1, pageSize ?? 20);
            }
            else
            {
                sortOrder = sortOrder ?? "asc";
                sortField = sortField ?? "name";

                IEnumerable<Country> countries = await _repository.GetListOfCountries();
                IEnumerable<Country> sortCountries = SortCountries(countries, sortField, sortOrder);
                IEnumerable<Country> fieldCountries = FilterCoutries(countries, searchText);

                paginatedList 
                    = PaginatedList<Country>.Create(fieldCountries, pageNumber ?? 1, pageSize ?? 20);

                _cache.Set<IEnumerable<Country>>(path, fieldCountries);

                ViewData["sortOrder"] = sortOrder == "asc" ? "desc" : "asc";
                ViewData["sortField"] = sortField;
                ViewData["pageSize"] = pageSize;
            }

            return View(paginatedList);
        }

        private IEnumerable<Country> FilterCoutries(
            IEnumerable<Country> countries, 
            string searchText)
        {

            if(!string.IsNullOrEmpty(searchText))
            {
                countries = countries.Where(x => x.Name.ToLower().Contains(searchText.ToLower()));
                ViewData["searchText"] = searchText.ToLower();
            }

            return countries;
        }

        private IEnumerable<Country> SortCountries(
            IEnumerable<Country> countries, 
            string sortField, 
            string sortOrder
        ) {
            
            if(sortField.ToLower() == "name")
            {
                if(sortOrder.ToLower() == "asc")
                    countries = countries.OrderBy(x => x.Name);
                else
                    countries = countries.OrderByDescending(x => x.Name);
            }
            else
            {
                if(sortOrder.ToLower() == "asc")
                    countries = countries.OrderBy(x => x.Alpha2Code);
                else
                    countries = countries.OrderByDescending(x => x.Alpha2Code);
            }

            return countries;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
