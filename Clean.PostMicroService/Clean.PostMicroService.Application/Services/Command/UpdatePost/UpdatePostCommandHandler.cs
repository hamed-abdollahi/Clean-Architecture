using Clean.PostMicroService.Application.Services.Command.UpdatePost;
using Clean.PostMicroService.Domain.Entities;
using MediatR;

namespace Clean.UserMicroService.Application.Services.Command.UpdateUser
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostResultDto>
    {
        private readonly IUpdatePostService _updatePostService;

        public UpdatePostCommandHandler(IUpdatePostService updatePostService)
        {
            _updatePostService = updatePostService;
        }

        public Task<UpdatePostResultDto> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new PostEntity()
            {
                Id = request.Id,
                Title= request.Title,
                Content= request.Content,
                UserId= request.UserId
            };
            return _updatePostService.UpdatePost(post, cancellationToken);
        }

        
    }
}
