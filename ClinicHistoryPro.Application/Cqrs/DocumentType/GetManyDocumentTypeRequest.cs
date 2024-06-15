using MediatR;
using ClinicHistoryPro.Application.DTOs;

namespace ClinicHistoryPro.Application.Cqrs.DocumentType
{
    public class GetManyDocumentTypeRequest: IRequest<RequestResult<List<GenericDTO>>>
    {
    }
}
