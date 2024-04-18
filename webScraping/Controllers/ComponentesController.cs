using Microsoft.AspNetCore.Mvc;
using webScraping.Data;
using webScraping.Models;

namespace webScraping.Controllers
{
    public class ComponentesController : Controller
    {
        // GET: ComponentesController
        public ActionResult Index(string Codigo)
        {

            if (Codigo == null)
            {
                return BadRequest();
            }

            ScrapingComponentes scraping = new ScrapingComponentes();
            scraping.ColetorScraperComponentes(Codigo);
            var componentes = ListaComponentes.ListandoTodosComponentes();
            var componentesFiltrados = componentes.Where(c => c.Codigo == Codigo);
      
            return View(componentesFiltrados);
        
        }

     

    

    }
}
