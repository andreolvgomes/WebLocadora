using Locadora.Data.Context;
using Locadora.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Data.Repositories
{
    public class FilmeRepository : Repository<Filme>, IFilmeRepository
    {
        public FilmeRepository(LocadoraDbContext context) 
            : base(context)
        {
        }

        public async Task<Filme> GetByName(string nome)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Nome == nome);
        }
    }
}