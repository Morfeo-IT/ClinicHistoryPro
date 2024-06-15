using ClinicHistoryPro.Domain.Models;

namespace ClinicHistoryPro.Application.Services.Interfaces
{
    public interface IDocumentTypeAppService
    {
        Task<List<DocumentType>> GetManyDocumentType();
    }
}
