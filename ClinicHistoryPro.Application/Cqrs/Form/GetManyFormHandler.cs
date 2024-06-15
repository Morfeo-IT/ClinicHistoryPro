using AutoMapper;
using MediatR;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Application.Services.Interfaces;

namespace ClinicHistoryPro.Application.Cqrs.Form
{
    public class GetManyFormHandler : IRequestHandler<GetManyFormRequest, RequestResult<List<FormDTO>>>
    {
        private readonly IFormAppService formAppService;
        private readonly IMapper mapper;
        public GetManyFormHandler(IFormAppService formAppService, IMapper mapper) => 
            (this.formAppService, this.mapper) = (formAppService, mapper);
        public async Task<RequestResult<List<FormDTO>>> Handle(GetManyFormRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await formAppService.GetManyForm();
                if (!result.Any()) return RequestResult<List<FormDTO>>.CreateUnsuccessful(new string[] { "No hay formulario" });
                return RequestResult<List<FormDTO>>.CreateSuccessful(mapper.Map<List<FormDTO>>(result));
            }
            catch(Exception ex)
            {
                return RequestResult<List<FormDTO>>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
