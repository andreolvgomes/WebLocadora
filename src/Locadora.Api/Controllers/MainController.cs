using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Locadora.Api.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {
        protected List<string> Erros = new List<string>();

        protected ActionResult CustomResponse(object result = null, string message = "")
        {
            if (!string.IsNullOrEmpty(message))
                Erros.Add(message);

            if (OperacaoValida())
                return Ok(result);

            return BadRequest(new ResponseResult() { Errors = this.Erros });
        }

        protected bool OperacaoValida()
        {
            return !Erros.Any();
        }
    }
}