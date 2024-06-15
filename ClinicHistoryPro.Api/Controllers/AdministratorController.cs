using ClinicHistoryPro.Application.Cqrs.Administrator;
using ClinicHistoryPro.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly IMediator mediator;
        public AdministratorController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetManyAdministrator")]
        public async Task<RequestResult<List<GenericDTO>>> GetManyAdministrator()
        {
            return await mediator.Send(new GetManyAdministratorRequest());
        }
    }
}
