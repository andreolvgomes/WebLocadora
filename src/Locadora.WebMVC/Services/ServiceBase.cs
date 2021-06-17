using Locadora.WebMVC.Models;
using Locadora.WebMVC.Services.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Locadora.WebMVC.Services
{
    public class ServiceBase
    {
        protected StringContent ObterConteudo(object dado)
        {
            return new StringContent(
                JsonSerializer.Serialize(dado),
                Encoding.UTF8,
                "application/json");
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new Exception(response.StatusCode.ToString());

                case 400:
                    return false;
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}