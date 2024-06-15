using AutoMapper;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Application.Services.Interfaces;
using MediatR;

namespace ClinicHistoryPro.Application.Cqrs.Gender
{
    public class GetManyGenderHandler : IRequestHandler<GetManyGenderRequest, RequestResult<List<GenericDTO>>>
    {
        private readonly IGenderAppService genderAppService;
        private readonly IMapper mapper;
        public GetManyGenderHandler(IGenderAppService genderAppService, IMapper mapper)
        {
            this.genderAppService = genderAppService;
            this.mapper = mapper;
        }
        public async Task<RequestResult<List<GenericDTO>>> Handle(GetManyGenderRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await genderAppService.GetManyGender();
                return RequestResult<List<GenericDTO>>.CreateSuccessful(mapper.Map<List<GenericDTO>>(result));
            }
            catch(Exception ex)
            {
                return RequestResult<List<GenericDTO>>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
