using AutoMapper;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Application.Services.Interfaces;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Localization
{
    public class GetManyCountryHandler : IRequestHandler<GetManyCountryRequest, RequestResult<List<GenericDTO>>>
    {
        private readonly ILocalizationAppService localizationAppService;
        private readonly IMapper mapper;
        public GetManyCountryHandler(ILocalizationAppService localizationAppService, IMapper mapper)
        {
            this.localizationAppService = localizationAppService;
            this.mapper = mapper;
        }
        public async Task<RequestResult<List<GenericDTO>>> Handle(GetManyCountryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await localizationAppService.GetManyCountry();
                return RequestResult<List<GenericDTO>>.CreateSuccessful(mapper.Map<List<GenericDTO>>(result));
            }
            catch(Exception ex)
            {
                return RequestResult<List<GenericDTO>>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
