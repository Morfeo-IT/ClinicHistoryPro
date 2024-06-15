using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.MenuItems
{
    public class GetManyMenuItemRequest: IRequest<RequestResult<List<object>>>
    {
    }
}
