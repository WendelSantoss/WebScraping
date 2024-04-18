using Microsoft.AspNetCore.Mvc;
using webScraping.Data;

namespace webScraping.Controllers
{
    public class BuscaController : Controller
    {
        public IActionResult Index(string busca)
        {
            if (busca == null)
            {
                return BadRequest();
            }

            var pesquisaTratada = busca.ToLower();

            var alimentos = ListaAlimentos.ListandoTodosAlimentos();

            var pesquisaFiltrada = alimentos.Where(c => c.Nome.ToLower().Contains(pesquisaTratada));

            Console.WriteLine("deu bom ");

            return View(pesquisaFiltrada);
        }
    }
}
