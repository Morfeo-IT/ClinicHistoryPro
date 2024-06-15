using ClinicHistoryPro.Application.Cqrs.MenuItems;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicHistoryPro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        private readonly IMediator mediator;
        public MenuItemController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet("GetManyMenuItem")]
        public async Task<RequestResult<List<object>>> GetManyMenuItem()
        {
            return await mediator.Send(new GetManyMenuItemRequest());
        }
    }
}
