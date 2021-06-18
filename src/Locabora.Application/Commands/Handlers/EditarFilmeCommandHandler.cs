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
    public class EditarFilmeCommandHandler : IRequestHandler<EditarFilmeCommand, bool>
    {
        private readonly IFilmeRepository _filmeRepository;

        public EditarFilmeCommandHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<bool> Handle(EditarFilmeCommand request, CancellationToken cancellationToken)
        {
            var model = await _filmeRepository.GetByName(request.Nome);
            if (model != null && model.Id != request.Id)
                throw new Exception($"Filme já existe na base de dados '{model.Nome}'");

            model = new Filme()
            {
                Id = request.Id,
                Nome = request.Nome,
                Inativo = request.Inativo,
                Obsercacao = request.Obsercacao
            };

            await _filmeRepository.Update(model);
            return true;
        }
    }
}
