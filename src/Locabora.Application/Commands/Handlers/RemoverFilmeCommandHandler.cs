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
    public class RemoverFilmeCommandHandler : IRequestHandler<RemoverFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;

        public RemoverFilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Handle(RemoverFilmeCommand request, CancellationToken cancellationToken)
        {
            await _filmeRepository.Remove(request.Id);
            return true;
        }
    }
}
