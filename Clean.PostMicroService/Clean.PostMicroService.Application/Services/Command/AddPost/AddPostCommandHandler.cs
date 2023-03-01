using Clean.PostMicroService.Domain.Entities;
using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, AddPostResultDto>
    {
        private readonly IAddPostService _addPostService;

        public AddPostCommandHandler(IAddPostService addUserService)
        {
            _addPostService = addUserService;
        }

        public Task<AddPostResultDto> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var post = new PostEntity()
            {
                Title= request.Title,
                Content= request.Content,
                UserId= request.UserId
            };
            return _addPostService.AddPost(post, cancellationToken);
        }

    }
}
