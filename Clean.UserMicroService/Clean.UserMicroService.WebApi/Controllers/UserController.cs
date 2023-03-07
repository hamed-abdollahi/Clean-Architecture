using Clean.Shared.Main;
using Clean.Shared.DTO;
using Clean.Shared.Consumers;
using Clean.UserMicroService.Application.Services.Command.AddUser;
using Clean.UserMicroService.Application.Services.Command.UpdateUser;
using Clean.UserMicroService.Application.Services.Query.GetUser;
using Clean.UserMicroService.Application.Services.Query.GetUsers;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Clean.UserMicroService.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : MainController 
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator, IBus bus):base(bus)
        {
            _mediator = mediator;
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

                var _user = new AddUserConsumer()
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Family = user.Family
                };
                Produce(new MainConsumerDTO() { Operation = Operation.Add , Data = _user },"add-user");
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
                var _user = new UpdateUserConsumer()
                {
                    UserId = user.Id,
                    Name = user.Name,
                    Family = user.Family
                };
                Produce(new MainConsumerDTO() { Operation = Operation.Edit, Data = _user }, "update-user");
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

    }
}