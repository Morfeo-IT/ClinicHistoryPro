using AutoMapper;
using MediatR;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Application.Services.Interfaces;

namespace ClinicHistoryPro.Application.Cqrs.Form
{
    public class GetOneFormHandler : IRequestHandler<GetOneFormRequest, RequestResult<FormDTO>>
    {
        private readonly IFormAppService formAppService;
        private readonly IMapper mapper;
        public GetOneFormHandler(IFormAppService formAppService, IMapper mapper) =>
            (this.formAppService, this.mapper) = (formAppService, mapper);
        public async Task<RequestResult<FormDTO>> Handle(GetOneFormRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await formAppService.GetOneForms(request.url);
                if (result == null) return RequestResult<FormDTO>.CreateUnsuccessful(new string[] { "No hay formulario" });
                return RequestResult<FormDTO>.CreateSuccessful(mapper.Map<FormDTO>(result));
            }
            catch (Exception ex)
            {
                return RequestResult<FormDTO>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
