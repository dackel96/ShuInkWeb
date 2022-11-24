using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShuInkWeb.Data.Common.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        IQueryable<TEntity> All();

        IQueryable<TEntity> All(Expression<Func<TEntity, bool>> search);

        IQueryable<TEntity> AllAsNoTracking();

        IQueryable<TEntity> AllReadonly(Expression<Func<TEntity, bool>> search);

        Task<TEntity> GetByIdAsync(object id);

        Task<TEntity> GetByIdsAsync(object[] id);

        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        Task DeleteAsync(object id);

        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

        void DeleteRange(Expression<Func<TEntity, bool>> deleteWhereClause);

        void Detach(TEntity entity);

        Task<int> SaveChangesAsync();
    }
}
