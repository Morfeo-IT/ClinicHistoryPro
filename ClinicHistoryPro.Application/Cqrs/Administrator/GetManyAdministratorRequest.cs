using ClinicHistoryPro.Application.DTOs;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Administrator
{
    public class GetManyAdministratorRequest: IRequest<RequestResult<List<GenericDTO>>>
    {
    }
}
