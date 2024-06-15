using ClinicHistoryPro.Application.Cqrs.Localization;
using ClinicHistoryPro.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizationController : ControllerBase
    {
        private readonly IMediator mediator;
        public LocalizationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetManyCountry")]
        public async Task<RequestResult<List<GenericDTO>>> GetManyCountry([FromQuery] GetManyCountryRequest request)
        {
            return await mediator.Send(request);
        }
        [HttpGet("GetManyState")]
        public async Task<RequestResult<List<GenericDTO>>> GetManyState([FromQuery] GetManyStateRequest request)
        {
            return await mediator.Send(request);
        }
        [HttpGet("GetManyCity")]
        public async Task<RequestResult<List<GenericDTO>>> GetManyCity([FromQuery] GetManyCityRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
