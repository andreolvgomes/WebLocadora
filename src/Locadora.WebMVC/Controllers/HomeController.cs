using Locadora.WebMVC.Models;
using Locadora.WebMVC.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFilmeService _filmeService;

        public HomeController(IFilmeService filmeService)
        {
            _filmeService = filmeService;
        }

        public IActionResult Index()
        {
            var filme = _filmeService.GetById(new Guid("4eb97a52-16bd-4e35-a080-220adc56dc2f"));
            return View(filme);
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
