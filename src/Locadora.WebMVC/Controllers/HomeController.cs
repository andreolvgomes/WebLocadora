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

        public async Task<IActionResult> Index()
        {
            return View(await _filmeService.GetAll());
        }

        public IActionResult NovoFilme()
        {
            return View();
        }

        public async Task<IActionResult> EditarFilme(Guid id)
        {
            return View(await _filmeService.GetById(id));
        }

        public async Task<IActionResult> CreateNovo(FilmeViewModel filmeViewModel)
        {
            await _filmeService.Create(filmeViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            await _filmeService.Remove(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(FilmeViewModel filmeViewModel)
        {
            await _filmeService.Edit(filmeViewModel);
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
