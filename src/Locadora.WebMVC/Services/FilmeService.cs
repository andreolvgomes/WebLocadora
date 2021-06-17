using Locadora.WebMVC.Models;
using Locadora.WebMVC.Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Locadora.WebMVC.Services
{
    public class FilmeService : ServiceBase, IFilmeService
    {
        private readonly HttpClient _httpClient;

        public FilmeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void Create(FilmeViewModel filme)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<FilmeViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<FilmeViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5001/filmes/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<FilmeViewModel>(response);
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}