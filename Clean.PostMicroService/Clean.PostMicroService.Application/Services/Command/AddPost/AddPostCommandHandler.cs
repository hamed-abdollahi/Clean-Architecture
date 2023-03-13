using Clean.PostMicroService.Domain.Entities;

using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, AddPostResultDto>
    {
        private readonly IAddPostService _addPostService;
        public AddPostCommandHandler(IAddPostService addPostService)
        {
            _addPostService = addPostService;
        }

        public async Task<AddPostResultDto> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var post = new PostEntity()
            {
                Title= request.Title,
                Content= request.Content,
                UserId= request.UserId
            };
            var res = await _addPostService.AddPost(post, cancellationToken);
            return res;
        }

    }
}
