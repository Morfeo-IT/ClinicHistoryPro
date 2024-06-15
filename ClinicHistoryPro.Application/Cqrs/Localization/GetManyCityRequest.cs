using ClinicHistoryPro.Application.DTOs;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Localization
{
    public class GetManyCityRequest: IRequest<RequestResult<List<GenericDTO>>>
    {
        public int state { get; set; }
    }
}
