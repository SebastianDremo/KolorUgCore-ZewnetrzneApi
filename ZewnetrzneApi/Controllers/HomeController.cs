using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZewnetrzneApi.Models;
using ZewnetrzneApi.Models.Interfaces;

namespace ZewnetrzneApi.Controllers
{
    public class HomeController : Controller
    {
        //uzywanie Dependency Injection - bedziemy uzywac jednego ApiClienta na caly kontroler
        private readonly IApiClient _apiClient;

        //w konstruktorze kontrolera wpuszczamy naszego apiClienta aby przypiac go naszego modulu <- jest to robione przez services PATRZ PLIK Startup.cs
        public HomeController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public IActionResult GetWeatherByCity(City city)
        {
            //Tu wykorzystujemy naszego ApiClient 
            var weatherObj = _apiClient.GetCity(city.Name);

            return View(weatherObj.Result);
        }
    }
}
