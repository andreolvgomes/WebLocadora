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
    public class CreateFilmeCommandHandler : IRequestHandler<CreateFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;

        public CreateFilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Handle(CreateFilmeCommand request, CancellationToken cancellationToken)
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
