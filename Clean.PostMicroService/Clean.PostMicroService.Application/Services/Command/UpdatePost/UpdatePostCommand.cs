using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.UpdatePost
{
    public class UpdatePostCommand : IRequest<UpdatePostResultDto>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
    }

}
