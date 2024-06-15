using ClinicHistoryPro.Application.DTOs;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Localization
{
    public class GetManyCountryRequest: IRequest<RequestResult<List<GenericDTO>>>
    {
    }
}
