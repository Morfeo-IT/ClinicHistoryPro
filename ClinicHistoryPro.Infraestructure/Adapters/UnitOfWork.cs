using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ClinicHistoryPro.Infraestructure.Persistence.Configurations;
using ClinicHistoryPro.Infraestructure.Ports;

namespace ClinicHistoryPro.Infraestructure.Adapters
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ClinicHistoryContext _context;
        private bool disposed = false;
        private readonly Dictionary<string, object> repositories;
        private readonly IServiceProvider _serviceProvider;

        public UnitOfWork(ClinicHistoryContext context, IServiceProvider serviceProvider) =>
            (_context, repositories, _serviceProvider) = (context, new Dictionary<string, object>(), serviceProvider);

        public IDynamicRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            var type = typeof(TEntity).Name;

            if (!repositories.ContainsKey(type))
            {
                var repositoryInstance = _serviceProvider.GetRequiredService<IDynamicRepository<TEntity>>();
                repositories.Add(type, repositoryInstance);
            }

            return (IDynamicRepository<TEntity>)repositories[type];
        }

        public async Task<int> CommitAsync() => _context.SaveChanges();
        public async Task RollbackAsync() => await _context.DisposeAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        ~UnitOfWork() => Dispose();
    }
}
