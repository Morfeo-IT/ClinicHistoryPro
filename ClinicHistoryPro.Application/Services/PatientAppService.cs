using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using ClinicHistoryPro.Infraestructure.Ports;

namespace ClinicHistoryPro.Application.Services
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IUnitOfWork unitOfWork;

        public PatientAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateOnePatient(Patient patient)
        {
            try
            {
                var result =  await unitOfWork.Repository<Patient>().CreateOneAsync(patient);
                return result > 0;
            }
            catch
            {
                throw;
            }
        }
    }
}
