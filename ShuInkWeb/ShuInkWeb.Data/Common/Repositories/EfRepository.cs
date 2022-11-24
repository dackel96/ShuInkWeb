using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Common.Repositories
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public EfRepository(ApplicationDbContext context)
        {
            this.Context = context ?? throw new ArgumentNullException(nameof(context));
            this.DbSet = this.Context.Set<TEntity>();
        }

        protected DbSet<TEntity> DbSet { get; set; }

        protected ApplicationDbContext Context { get; set; }

        public virtual IQueryable<TEntity> All() => this.DbSet;

        public virtual IQueryable<TEntity> AllAsNoTracking()
            => this.DbSet
                   .AsNoTracking();

        public virtual Task AddAsync(TEntity entity)
            => this.DbSet
                   .AddAsync(entity)
                   .AsTask();

        public virtual void Update(TEntity entity)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entity)
            => this.DbSet
                   .Remove(entity);

        public Task<int> SaveChangesAsync()
            => this.Context
                   .SaveChangesAsync();

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context?.Dispose();
            }
        }

        public IQueryable<TEntity> All(Expression<Func<TEntity, bool>> search)
            => this.DbSet
                   .Where(search);

        public IQueryable<TEntity> AllReadonly(Expression<Func<TEntity, bool>> search)
            => this.DbSet
                   .Where(search)
                   .AsNoTracking();

        public async Task<TEntity> GetByIdAsync(object id)
            => (await DbSet.FindAsync(id))!;

        public async Task<TEntity> GetByIdsAsync(object[] id)
            => (await DbSet.FindAsync(id))!;

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
            => await this.DbSet
                         .AddRangeAsync(entities);

        public void UpdateRange(IEnumerable<TEntity> entities)
            => this.DbSet
                   .UpdateRange(entities);

        public async Task DeleteAsync(object id)
        {
            TEntity entity = await GetByIdAsync(id);

            Delete(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            this.DbSet.RemoveRange(entities);
        }

        public void DeleteRange(Expression<Func<TEntity, bool>> deleteWhereClause)
        {
            var entities = All(deleteWhereClause);
            DeleteRange(entities);
        }

        public void Detach(TEntity entity)
        {
            EntityEntry entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }
    }
}
