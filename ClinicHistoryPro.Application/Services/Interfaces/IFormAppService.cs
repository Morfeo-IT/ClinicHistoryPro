using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.Services.Interfaces
{
    public interface IFormAppService
    {
        Task<List<Form>> GetManyForm();
        Task<Form> GetOneForms(string url);
    }
}
