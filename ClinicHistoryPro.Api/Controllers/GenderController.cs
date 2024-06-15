using ClinicHistoryPro.Application.Cqrs.Gender;
using ClinicHistoryPro.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IMediator mediator;
        public GenderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet("GetManyGender")]
        public async Task<RequestResult<List<GenericDTO>>> GetManyGender()
        {
            return await mediator.Send(new GetManyGenderRequest());
        }
    }
}
