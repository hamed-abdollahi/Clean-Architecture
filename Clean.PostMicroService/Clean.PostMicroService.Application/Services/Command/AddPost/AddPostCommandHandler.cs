using Clean.PostMicroService.Domain.Entities;
using Clean.Shared.BaseChannel;
using Clean.Shared.Events;
using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public class AddPostCommandHandler : IRequestHandler<AddPostCommand, AddPostResultDto>
    {
        private readonly IAddPostService _addPostService;
        private readonly ChannelQueue<PostAdded> _channel;
        public AddPostCommandHandler(IAddPostService addPostService, ChannelQueue<PostAdded> channel)
        {
            _addPostService = addPostService;
            _channel = channel;
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
            await _channel.AddToChannelAsync(new PostAdded { PostId = post.Id }, cancellationToken);
            return res;
        }

    }
}
