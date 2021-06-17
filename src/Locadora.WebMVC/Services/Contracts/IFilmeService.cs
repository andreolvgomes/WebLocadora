using Locadora.WebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Locadora.WebMVC.Services.Contracts
{
    public interface IFilmeService
    {
        Task<FilmeViewModel> GetById(Guid id);
        Task<IEnumerable<FilmeViewModel>> GetAll();
        Task<ResponseResult> Remove(Guid id);
        Task<ResponseResult> Create(FilmeViewModel filme);
        Task<ResponseResult> Edit(FilmeViewModel filme);
    }
}