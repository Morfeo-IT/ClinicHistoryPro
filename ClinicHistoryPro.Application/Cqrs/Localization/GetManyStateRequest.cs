using ClinicHistoryPro.Application.DTOs;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Localization
{
    public class GetManyStateRequest: IRequest<RequestResult<List<GenericDTO>>>
    {
        public int country { get; set; }
    }
}
