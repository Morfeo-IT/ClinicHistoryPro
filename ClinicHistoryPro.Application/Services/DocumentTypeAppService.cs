using ClinicHistoryPro.Application.Services.Interfaces;
using ClinicHistoryPro.Domain.Models;
using ClinicHistoryPro.Infraestructure.Ports;

namespace ClinicHistoryPro.Application.Services
{
    public class DocumentTypeAppService : IDocumentTypeAppService
    {
        private readonly IUnitOfWork unitOfWork;
        public DocumentTypeAppService(IUnitOfWork unitOfWork) => (this.unitOfWork) = (unitOfWork);
        public async Task<List<DocumentType>> GetManyDocumentType()
        {
            try
            {
                return await unitOfWork.Repository<DocumentType>().GetManyAsync(
                    selector: documentType => new DocumentType
                    {
                        Id = documentType.Id,
                        Name = documentType.Name,
                        Description = documentType.Description
                    },
                    orderBy: documentType => documentType.OrderBy(o => o.Name)
                );
            }
            catch
            {
                throw;
            }
        }
    }
}
