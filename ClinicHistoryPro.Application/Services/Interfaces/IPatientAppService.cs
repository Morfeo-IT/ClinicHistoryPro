using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.Services.Interfaces
{
    public interface IPatientAppService
    {
        Task<bool> CreateOnePatient(Patient patient);
    }
}
