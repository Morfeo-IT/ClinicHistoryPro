using MediatR;
using ClinicHistoryPro.Application.DTOs;

namespace ClinicHistoryPro.Application.Cqrs.Form
{
    public class GetManyFormRequest : IRequest<RequestResult<List<FormDTO>>>
    {
    }
}
