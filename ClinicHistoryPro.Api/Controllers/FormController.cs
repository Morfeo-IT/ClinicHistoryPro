using MediatR;
using Microsoft.AspNetCore.Mvc;
using ClinicHistoryPro.Application.Cqrs.Form;
using ClinicHistoryPro.Application.DTOs;

namespace ClinicHistoryPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IMediator mediator;
        public FormController(IMediator mediator) => (this.mediator) = (mediator);

        [HttpGet("GetOneForm")]
        public async Task<RequestResult<FormDTO>> GetOneForm([FromQuery] GetOneFormRequest request)
        {
            return await mediator.Send(request);
        }
        [HttpGet("GetManyForm")]
        public async Task<RequestResult<List<FormDTO>>> GetManyForm()
        {
            return await mediator.Send(new GetManyFormRequest());
        }
    }
}
