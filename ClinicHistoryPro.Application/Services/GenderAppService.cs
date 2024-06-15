using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using ClinicHistoryPro.Infraestructure.Ports;

namespace ClinicHistoryPro.Application.Services
{
    public class GenderAppService : IGenderAppService
    {
        private readonly IUnitOfWork unitOfWork;
        public GenderAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<List<Gender>> GetManyGender()
        {
            try
            {
                return await unitOfWork.Repository<Gender>().GetManyAsync(
                        selector: gender => new Gender
                        {
                            Id = gender.Id,
                            GuidId = gender.GuidId,
                            Description = gender.Description
                        },
                        orderBy: gender => gender.OrderBy(o => o.Id)
                    );
            }
            catch
            {
                throw;
            }
        }
    }
}
