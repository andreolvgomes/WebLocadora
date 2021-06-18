using Locadora.WebMVC.Models;
using Locadora.WebMVC.Services;
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

        public async Task<IActionResult> Index(string searching)
        {
            ViewData["CurrentFilter"] = searching;

            // não precisaria ter essa decição no FrontEnd, mas para fins didáticos e mostrar
            // a busca de dados usando Dapper e Entity
            if (string.IsNullOrEmpty(searching) == false)
                return View(await _filmeService.GetAllSearching(searching));
            return View(await _filmeService.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FilmeViewModel filmeViewModel)
        {
            var response = await _filmeService.Create(filmeViewModel);
            if (ThreAreErrors(response))
                return View("Create", filmeViewModel);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            return View(await _filmeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, FilmeViewModel filmeViewModel)
        {
            var response = await _filmeService.Edit(filmeViewModel);
            if (ThreAreErrors(response))
                return View("Edit", filmeViewModel);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            return View(await _filmeService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id, FilmeViewModel filmeViewModel)
        {
            var response = await _filmeService.Remove(id);

            if (ThreAreErrors(response))
                return View("Delete", await _filmeService.GetById(id));

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

        private bool ThreAreErrors(ResponseResult respose)
        {
            if (respose.Errors.Any())
            {
                TempData["Erros"] = respose.Errors;
                return true;
            }

            return false;
        }
    }
}
