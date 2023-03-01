using Clean.Application.Services.User.Command.AddUser;
using Clean.Application.Services.User.Command.UpdateUser;
using Clean.Application.Services.User.Query.GetUser;
using Clean.Application.Services.User.Query.GetUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Clean.WebApi.Controllers
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