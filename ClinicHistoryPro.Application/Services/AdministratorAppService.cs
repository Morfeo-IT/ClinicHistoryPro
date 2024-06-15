using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using ClinicHistoryPro.Infraestructure.Ports;

namespace ClinicHistoryPro.Application.Services
{
    public class AdministratorAppService : IAdministratorAppService
    {
        private readonly IUnitOfWork unitOfWork;
        public AdministratorAppService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<List<Administrator>> GetManyAdministrator()
        {
            return await unitOfWork.Repository<Administrator>().GetManyAsync(
                    selector: administrator => new Administrator
                    {
                        Id = administrator.Id,
                        Code = administrator.Code,
                        Name = administrator.Name,
                        ShortName = administrator.ShortName
                    }
                );
        }
    }
}
