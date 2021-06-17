using Locadora.WebMVC.Models;
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
        void Remove(Guid id);
        void Create(FilmeViewModel filme);
    }
}