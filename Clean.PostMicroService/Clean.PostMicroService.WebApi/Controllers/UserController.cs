using Clean.Shared.Main;
using Clean.Shared.DTO;
using Clean.Shared.Consumers;
using Clean.PostMicroService.Application.Services.Command.AddUser;
using Clean.PostMicroService.Application.Services.Command.UpdateUser;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.PostMicroService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase 
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromQuery] AddUserCommand model, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }
                var user = await _mediator.Send(model);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromQuery] UpdateUserCommand model, CancellationToken cancellationToken)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(model);
                }
                var user = await _mediator.Send(model, cancellationToken);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}