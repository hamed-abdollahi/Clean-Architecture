using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Domain.Entities;
using Clean.Shared.BaseChannel;
using Clean.Shared.Events;
using Clean.Shared.Main;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public class AddPostService : MainChannelQueue<PostAdded>, IAddPostService
    {
        private readonly IApplicationDbContext _context;
        public AddPostService(IApplicationDbContext context , ChannelQueue<PostAdded> channel):base(channel)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public Task<AddPostResultDto> AddPost(PostEntity post, CancellationToken cancellationToken = default)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            SendToQueue(new PostAdded() { PostId = post.Id });
            return Task.FromResult(new AddPostResultDto() { Id = post.Id });
        }
    }
}
