using ER.Data.Context;
using ER.Domain.Interfaces;
using ER.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ER.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly ERDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(ERDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task Insert(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await SaveChanges();
        }

        public async Task Delete(TEntity entity)
        {
            DbSet.Remove(entity);
            await SaveChanges();
        }


        public virtual async Task<List<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> Search(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
