using AutoMapper;
using ClinicHistoryPro.Application.Services.Interfaces;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.MenuItems
{
    public class GetManyMenuItemHandler : IRequestHandler<GetManyMenuItemRequest, RequestResult<List<object>>>
    {
        private readonly IMenuItemAppService menuItemAppService;
        private readonly IMapper mapper;
        public GetManyMenuItemHandler(IMenuItemAppService menuItemAppService, IMapper mapper)
        {
            this.menuItemAppService = menuItemAppService;
            this.mapper = mapper;
        }

        public async Task<RequestResult<List<object>>> Handle(GetManyMenuItemRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await menuItemAppService.GetMenuHierarchy();
                return RequestResult<List<object>>.CreateSuccessful(mapper.Map<List<object>>(result));
            }
            catch(Exception ex)
            {
                return RequestResult<List<object>>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
