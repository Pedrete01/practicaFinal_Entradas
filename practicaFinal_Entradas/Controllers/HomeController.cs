using Microsoft.AspNetCore.Mvc;
using practicaFinal_Entradas.ViewModels;
using practicaFinal_Entradas.Services;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace practicaFinal_Entradas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoriaRepositorio _categoriaRepositorio;

        public HomeController(ILogger<HomeController> logger, ICategoriaRepositorio categoriaRepositorio)
        {
            _logger = logger;
            _categoriaRepositorio = categoriaRepositorio;
        }

        public IActionResult Index()
        {
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
        public IActionResult Entradas()
        {
            return View();
        }
    }
}