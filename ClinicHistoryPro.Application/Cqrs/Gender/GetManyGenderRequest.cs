using ClinicHistoryPro.Application.DTOs;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Gender
{
    public class GetManyGenderRequest: IRequest<RequestResult<List<GenericDTO>>>
    {
    }
}
