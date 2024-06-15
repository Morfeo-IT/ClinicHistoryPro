using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.Services.Interfaces
{
    public interface ILocalizationAppService
    {
        Task<List<Country>> GetManyCountry();
        Task<List<State>> GetManyState(int country);
        Task<List<City>> GetManyCity(int state);
    }
}
