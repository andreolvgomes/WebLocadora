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
    public class CriarFilmeCommandHandler : IRequestHandler<CriarFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;

        public CriarFilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Handle(CriarFilmeCommand request, CancellationToken cancellationToken)
        {
            var model = new Filme()
            {
                Nome = request.Nome,
                Inativo = request.Inativo,
                Obsercacao = request.Obsercacao
            };

            await _filmeRepository.Create(model);
            return true;
        }
    }
}
