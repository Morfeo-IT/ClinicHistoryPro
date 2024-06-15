using MediatR;
using ClinicHistoryPro.Application.DTOs;

namespace ClinicHistoryPro.Application.Cqrs.Form
{
    public class GetOneFormRequest: IRequest<RequestResult<FormDTO>>
    {
        public string url { get; set; }
    }
}
