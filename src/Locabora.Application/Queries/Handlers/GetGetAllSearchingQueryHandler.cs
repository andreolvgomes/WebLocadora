using Locadora.Data.Context;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dapper;

namespace Locabora.Application.Queries.Handlers
{
    public class GetGetAllSearchingQueryHandler : IRequestHandler<GetGetAllSearchingQuery, IEnumerable<Filme>>
    {
        private readonly LocadoraDbContext _locadoraDbContext;

        public GetGetAllSearchingQueryHandler(LocadoraDbContext locadoraDbContext)
        {
            _locadoraDbContext = locadoraDbContext;
        }

        public async Task<IEnumerable<Filme>> Handle(GetGetAllSearchingQuery request, CancellationToken cancellationToken)
        {
            var connection = _locadoraDbContext.Database.GetDbConnection();

            var sql = "select * from dbo.Filmes";

            if (!string.IsNullOrEmpty(request.Searching))
                sql += $" where Nome like '%{request.Searching}%'";

            var result = await connection.QueryAsync<Filme>(sql);
            return result;
        }
    }
}