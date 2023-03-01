using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{

    public class AddPostCommand : IRequest<AddPostResultDto>
    {
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
    }

}
