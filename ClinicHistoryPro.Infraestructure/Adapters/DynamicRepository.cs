using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using ClinicHistoryPro.Infraestructure.Persistence.Configurations;
using ClinicHistoryPro.Infraestructure.Ports;
using System.Data;
using System.Linq.Expressions;

namespace ClinicHistoryPro.Infraestructure.Adapters
{
    public class DynamicRepository<TEntity> : IDynamicRepository<TEntity> where TEntity : class
    {
        private readonly ClinicHistoryContext context;
        readonly DbSet<TEntity> _dataset;
        public DynamicRepository(ClinicHistoryContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            _dataset = this.context.Set<TEntity>();
        }
        public async Task<int> CreateOneAsync(TEntity entity)
        {
            await _dataset.AddAsync(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<int> CreateManyAsync(List<TEntity> entities)
        {
            try
            {
                await _dataset.AddRangeAsync(entities);
                return await context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<List<TResult>> GetManyAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null!,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null!,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dataset;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.Select(selector).ToListAsync();
        }
        public async Task<TEntity> GetOneAsync(int id) =>
            await _dataset.FindAsync(id) ?? throw new ArgumentNullException(nameof(id));
        public async Task<TResult> GetOneAsync<TResult>(
            Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate = null!,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null!,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null!,
            bool disableTracking = true)
        {
            IQueryable<TEntity> query = _dataset;

            if (disableTracking)
            {
                query = query.AsNoTracking();
            }

            if (include != null)
            {
                query = include(query);
            }

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return await query.Select(selector).FirstOrDefaultAsync();
        }
        public async Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            try
            {
                context.Entry(entity).State = EntityState.Deleted;
                _dataset.Remove(entity);
                return await context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw;
            }
        }
        public async Task<int> DeleteRangeAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
        {
            try
            {
                entities.ForEach(entity => context.Entry(entity).State = EntityState.Deleted);
                _dataset.AttachRange(entities);
                _dataset.RemoveRange(entities);
                return await context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                throw;
            }
        }
    }
}
