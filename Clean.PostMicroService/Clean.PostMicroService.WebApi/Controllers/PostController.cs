using Clean.PostMicroService.Application.Services.Command.AddPost;
using Clean.PostMicroService.Application.Services.Command.UpdatePost;
using Clean.PostMicroService.Application.Services.Query.GetPost;
using Clean.PostMicroService.Application.Services.Query.GetPosts;
using Clean.PostMicroService.Application.Services.Query.GetCompletePost;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Clean.UserMicroService.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPosts")]
        public async Task<IActionResult> GetPosts([FromQuery] GetPostsQuery model, CancellationToken cancellationToken)
        {
            try
            {
                var post = await _mediator.Send(model, cancellationToken);
                if (post is null)
                {
                    return NotFound();
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        [HttpGet("GetPost")]
        public async Task<IActionResult> GetPost([FromQuery] GetPostQuery model, CancellationToken cancellationToken)
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

        [HttpGet("GetCompletePost")]
        public async Task<IActionResult> GetCompletePost([FromQuery] GetCompletePostQuery model, CancellationToken cancellationToken)
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

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] AddPostCommand model, CancellationToken cancellationToken)
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
        [HttpPut("UpdatePost")]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePostCommand model, CancellationToken cancellationToken)
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