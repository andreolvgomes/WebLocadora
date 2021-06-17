using Locadora.Data.Context;
using Locadora.Domain.Model;
using Locadora.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly LocadoraDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(LocadoraDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Create(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Remove(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public virtual async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public virtual async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }
    }
}