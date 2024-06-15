using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.Services.Interfaces
{
    public interface IAdministratorAppService
    {
        Task<List<Administrator>> GetManyAdministrator();
    }
}
