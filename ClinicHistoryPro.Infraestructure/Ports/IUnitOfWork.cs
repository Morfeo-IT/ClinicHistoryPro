namespace ClinicHistoryPro.Infraestructure.Ports
{
    public interface IUnitOfWork: IDisposable
    {
        IDynamicRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}
