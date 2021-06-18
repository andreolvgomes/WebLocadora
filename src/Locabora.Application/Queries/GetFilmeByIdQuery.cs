using MediatR;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locabora.Application.Queries
{
    public class GetFilmeByIdQuery : IRequest<Filme>
    {
        public Guid Id { get; set; }

        public GetFilmeByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}