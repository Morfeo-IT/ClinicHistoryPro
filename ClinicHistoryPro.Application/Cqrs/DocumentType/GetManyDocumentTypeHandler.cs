using AutoMapper;
using MediatR;
using ClinicHistoryPro.Application.DTOs;
using ClinicHistoryPro.Application.Services.Interfaces;

namespace ClinicHistoryPro.Application.Cqrs.DocumentType
{
    public class GetManyDocumentTypeHandler : IRequestHandler<GetManyDocumentTypeRequest, RequestResult<List<GenericDTO>>>
    {
        private readonly IDocumentTypeAppService documentTypeAppService;
        private readonly IMapper mapper; 
        public GetManyDocumentTypeHandler(IDocumentTypeAppService documentTypeAppService, IMapper mapper) =>
            (this.documentTypeAppService, this.mapper) = (documentTypeAppService, mapper);
        public async Task<RequestResult<List<GenericDTO>>> Handle(GetManyDocumentTypeRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var result = await documentTypeAppService.GetManyDocumentType();
                return RequestResult<List<GenericDTO>>.CreateSuccessful(mapper.Map<List<GenericDTO>>(result));
            }
            catch(Exception ex)
            {
                return RequestResult<List<GenericDTO>>.CreateError(new string[] { ex.Message });
            }
        }
    }
}
