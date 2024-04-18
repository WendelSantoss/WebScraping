using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webScraping.Data;
using webScraping.Models;

namespace webScraping.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            ScrapingAlimentos scraping = new ScrapingAlimentos();
            scraping.ColetorScraperAlimentos();
            var alimentos = ListaAlimentos.ListandoTodosAlimentos();
            return View(alimentos);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
