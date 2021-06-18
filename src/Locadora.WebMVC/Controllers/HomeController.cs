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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmeViewModel filmeViewModel)
        {
            await _filmeService.Create(filmeViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _filmeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, FilmeViewModel filmeViewModel)
        {
            await _filmeService.Edit(filmeViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _filmeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, FilmeViewModel filmeViewModel)
        {
            await _filmeService.Remove(id);
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
