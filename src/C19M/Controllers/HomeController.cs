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

        public HomeController(
            ILogger<HomeController> logger,
            IRapidRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var models = await _repository.GetListOfCountries();
            return View(models);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
