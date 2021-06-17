using Locadora.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Locadora.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmesController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public FilmesController(LocadoraContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> Get()
        {
            return await _context.Filmes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> GetFilme(Guid id)
        {
            var result = await _context.Filmes.FindAsync(id);
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, Filme filme)
        {
            if (id != filme.Id)
                return BadRequest();

            _context.Entry(filme).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Post(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            var result = await _context.Filmes.FindAsync(filme.Id);
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Filme>> Delete(Guid id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
                return NotFound();

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();

            return filme;
        }
    }
}