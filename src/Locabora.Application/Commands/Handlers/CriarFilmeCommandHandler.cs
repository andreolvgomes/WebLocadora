using Locadora.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locabora.Application.Commands.Handlers
{
    public class CriarFilmeCommandHandler : IRequestHandler<CriarFilmeCommand, Guid>
    {
        private readonly IFilmeRepository _filmeRepository;

        public CriarFilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Guid> Handle(CriarFilmeCommand request, CancellationToken cancellationToken)
        {
            var model = await _filmeRepository.GetByName(request.Nome);
            if (model != null)
                throw new Exception($"Filme já existe na base de dados '{model.Nome}'");

            model = new Filme()
            {
                Nome = request.Nome,
                Inativo = request.Inativo,
                Obsercacao = request.Obsercacao
            };

            await _filmeRepository.Create(model);
            return model.Id;
        }
    }
}
