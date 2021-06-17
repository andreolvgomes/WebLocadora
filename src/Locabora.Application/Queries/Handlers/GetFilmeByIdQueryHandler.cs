using Locadora.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locabora.Application.Queries.Handlers
{
    public class GetFilmeByIdQueryHandler : IRequestHandler<GetFilmeByIdQuery, Filme>
    {
        private readonly IFilmeRepository _filmeRepository;

        public GetFilmeByIdQueryHandler(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        public async Task<Filme> Handle(GetFilmeByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _filmeRepository.GetById(request.Id);
            return result;
        }
    }
}