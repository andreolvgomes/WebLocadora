using AutoMapper;
using Locabora.Application.Commands;
using Locabora.Application.Queries;
using Locadora.Api.ViewModel;
using Locadora.Domain.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;
        private IMediator _mediator;

        public FilmesController(IFilmeRepository filmeRepository,
            IMapper mapper,
            IMediator mediator)
        {
            _filmeRepository = filmeRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FilmeViewModel>>> Get()
        {
            return Ok(_mapper.Map<IEnumerable<FilmeViewModel>>(await _filmeRepository.GetAll()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FilmeViewModel>> GetFilme(Guid id)
        {
            var result = _mapper.Map<FilmeViewModel>(await _mediator.Send(new GetFilmeByIdQuery(id)));
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, FilmeViewModel filme)
        {
            if (id != filme.Id)
                return BadRequest();

            try
            {
                await _mediator.Send(_mapper.Map<EditarFilmeCommand>(filme));
            }
            catch (Exception ex)
            {
                throw;
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<FilmeViewModel>> Post(FilmeViewModel filme)
        {
            await _mediator.Send(_mapper.Map<CriarFilmeCommand>(filme));
            var result = _mapper.Map<FilmeViewModel>(await _mediator.Send(new GetFilmeByIdQuery(filme.Id)));
            return result;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FilmeViewModel>> Delete(Guid id)
        {
            var filme = await _mediator.Send(new GetFilmeByIdQuery(id));
            if (filme == null)
                return NotFound();

            await _mediator.Send(new RemoverFilmeCommand(id));

            return _mapper.Map<FilmeViewModel>(filme);
        }
    }
}