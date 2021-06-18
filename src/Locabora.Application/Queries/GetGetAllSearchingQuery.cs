using MediatR;
using System.Collections.Generic;

namespace Locabora.Application.Queries
{
    public class GetGetAllSearchingQuery: IRequest<IEnumerable<Filme>>
    {
        public string Searching { get; set; }

        public GetGetAllSearchingQuery(string searching)
        {
            Searching = searching;
        }
    }
}