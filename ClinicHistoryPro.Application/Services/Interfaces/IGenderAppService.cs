using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.Services.Interfaces
{
    public interface IGenderAppService
    {
        Task<List<Gender>> GetManyGender();
    }
}
