using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClinicHistoryPro.Application.Cqrs.DocumentType;
using ClinicHistoryPro.Application.DTOs;

namespace ClinicHistoryPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public DocumentTypeController(IMediator mediator) => 
            (this.mediator) = (mediator);

        [HttpGet("GetManyDocumentType")]
        public async Task<RequestResult<List<GenericDTO>>> GetmanyDocumentType()
        {
            return await mediator.Send(new GetManyDocumentTypeRequest());
        }
    }
}
