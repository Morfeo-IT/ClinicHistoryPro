using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.Services.Interfaces
{
    public interface IMenuItemAppService
    {
        Task<List<MenuItem>> GetMenuHierarchy();
    }
}
