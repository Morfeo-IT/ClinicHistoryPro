using AutoMapper;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Application.Services.Interfaces;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Administrator
{
    public class GetManyAdministratorHandler : IRequestHandler<GetManyAdministratorRequest, RequestResult<List<GenericDTO>>>
    {
        private readonly IAdministratorAppService administratorAppService;
        private readonly IMapper mapper;
        public GetManyAdministratorHandler(IAdministratorAppService administratorAppService, IMapper mapper)
        {
            this.administratorAppService = administratorAppService;
            this.mapper = mapper;
        }

        public async Task<RequestResult<List<GenericDTO>>> Handle(GetManyAdministratorRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await administratorAppService.GetManyAdministrator();
                return RequestResult<List<GenericDTO>>.CreateSuccessful(mapper.Map<List<GenericDTO>>(result));
            }
            catch (Exception ex)
            {
                return RequestResult<List<GenericDTO>>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
