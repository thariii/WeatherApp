using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApplication.DbServices;
using WeatherApplication.Models;

namespace WeatherApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HttpClient client = new HttpClient();
        private readonly IWeatherDbService dbService;

        public HomeController(ILogger<HomeController> logger, IWeatherDbService weatherDbService)
        {
            _logger = logger;
            dbService = weatherDbService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var data = await dbService.GetAllDataAsync();
            return View(data);
        }

        public IActionResult AddWeatherData()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWeatherData(WeatherData data)
        {
            try
            {
                await dbService.InsertDataAsync(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return RedirectToAction("Index");
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
