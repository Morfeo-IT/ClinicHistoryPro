using AutoMapper;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Application.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicHistoryPro.Application.Cqrs.Localization
{
    public class GetManyCityHandler: IRequestHandler<GetManyCityRequest, RequestResult<List<GenericDTO>>>
    {
        private readonly ILocalizationAppService localizationAppService;
        private readonly IMapper mapper;
        public GetManyCityHandler(ILocalizationAppService localizationAppService, IMapper mapper)
        {
            this.localizationAppService = localizationAppService;
            this.mapper = mapper;
        }
        public async Task<RequestResult<List<GenericDTO>>> Handle(GetManyCityRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await localizationAppService.GetManyCity(request.state);
                return RequestResult<List<GenericDTO>>.CreateSuccessful(mapper.Map<List<GenericDTO>>(result));
            }
            catch (Exception ex)
            {
                return RequestResult<List<GenericDTO>>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
