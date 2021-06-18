using Locadora.WebMVC.Models;
using Locadora.WebMVC.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Locadora.WebMVC.Services
{
    public class ResponseResult
    {
        public List<string> Errors { get; set; }

        public ResponseResult()
        {
            Errors = new List<string>();
        }
    }

    public class FilmeService : ServiceBase, IFilmeService
    {
        private readonly HttpClient _httpClient;

        public FilmeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseResult> Create(FilmeViewModel filme)
        {
            var result = ObterConteudo(filme);

            var response = await _httpClient.PostAsync($"https://localhost:5001/filmes", result);

            if (!TratarErrosResponse(response)) 
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return new ResponseResult();
        }

        public async Task<ResponseResult> Edit(FilmeViewModel filme)
        {
            var result = ObterConteudo(filme);

            var response = await _httpClient.PutAsync($"https://localhost:5001/filmes/{filme.Id}", result);

            if (!TratarErrosResponse(response))
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return new ResponseResult();
        }

        public async Task<IEnumerable<FilmeViewModel>> GetAll()
        {
            var response = await _httpClient.GetAsync($"https://localhost:5001/filmes");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<FilmeViewModel>>(response);
        }

        public async Task<IEnumerable<FilmeViewModel>> GetAllSearching(string searching)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5001/Filmes/searching?searching={searching}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<IEnumerable<FilmeViewModel>>(response);
        }

        public async Task<FilmeViewModel> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"https://localhost:5001/filmes/{id}");

            TratarErrosResponse(response);

            return await DeserializarObjetoResponse<FilmeViewModel>(response);
        }

        public async Task<ResponseResult> Remove(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:5001/filmes/{id}");
            if (!TratarErrosResponse(response)) 
                return await DeserializarObjetoResponse<ResponseResult>(response);

            return new ResponseResult();
        }        
    }
}