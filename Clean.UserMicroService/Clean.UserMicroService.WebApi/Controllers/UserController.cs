using Clean.UserMicroService.Application.Services.Command.AddUser;
using Clean.UserMicroService.Application.Services.Command.UpdateUser;
using Clean.UserMicroService.Application.Services.Query.GetUser;
using Clean.UserMicroService.Application.Services.Query.GetUsers;
using Clean.UserMicroService.Domain.Entities;
using MassTransit;
using MassTransit.Transports;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Clean.UserMicroService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IBus _bus;
        public UserController(IMediator mediator, IBus bus)
        {
            _mediator = mediator;
            _bus = bus;
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromQuery] GetUsersQuery model, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _mediator.Send(model, cancellationToken);
                if (user is null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser([FromQuery] GetUserQuery model, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _mediator.Send(model, cancellationToken);
                if (user is null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

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
                var user = await _mediator.Send(model, cancellationToken);
                var uri = new Uri("rabbitmq://localhost/user");
                var endpoint = await _bus.GetSendEndpoint(uri);
                endpoint.Send(user);
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