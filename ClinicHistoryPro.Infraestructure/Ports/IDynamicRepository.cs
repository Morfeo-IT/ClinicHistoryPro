using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace ClinicHistoryPro.Infraestructure.Ports
{
    public interface IDynamicRepository<TEntity> where TEntity: class
    {
        Task<int> CreateOneAsync(TEntity entity);
        Task<int> CreateManyAsync(List<TEntity> entities);
        Task<TEntity> GetOneAsync(int id);
        Task<TResult> GetOneAsync<TResult>(
                Expression<Func<TEntity, TResult>> selector,
                Expression<Func<TEntity, bool>> predicate = null!,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
                Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null!,
                bool disableTracking = true);
        Task<List<TResult>> GetManyAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null!,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null!,
            bool disableTracking = true);
        Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<int> DeleteRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    }
}
