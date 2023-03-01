using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Domain.Entities;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public class AddPostService : IAddPostService
    {
        private readonly IApplicationDbContext _context;
        public AddPostService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<AddPostResultDto> AddPost(PostEntity post, CancellationToken cancellationToken = default)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return Task.FromResult(new AddPostResultDto() { Id = post.Id });
        }

    }
}
