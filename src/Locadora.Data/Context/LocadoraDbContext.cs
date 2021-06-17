using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Data.Context
{
    public class LocadoraDbContext : DbContext
    {
        public LocadoraDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Filme> Filmes { get; set; }
    }
}