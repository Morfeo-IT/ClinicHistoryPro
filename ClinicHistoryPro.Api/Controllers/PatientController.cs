using ClinicHistoryPro.Application.Cqrs.Patients;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator mediator;
        public PatientController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateOnePatient")]
        public async Task<RequestResult<bool>> CreateOnePatient([FromBody] CreateOnePatientRequest request)
        {
            return await mediator.Send(request);
        }
    }
}
