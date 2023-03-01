using Clean.PostMicroService.Application.Interfaces;

namespace Clean.PostMicroService.Application.Services.Query.GetPost
{
    public class GetPostService : IGetPostService
    {
        private readonly IApplicationDbContext _context;
        public GetPostService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<GetPostDto> GetPost(int id, CancellationToken cancellationToken = default)
        {
            var post = _context.Posts.Find(id);
            if (post == null)
                return Task.FromResult<GetPostDto>(null);
            return Task.FromResult(new GetPostDto()
            {
                Id= post.Id,
                Title= post.Title,
                Content= post.Content,
                UserId = post.UserId
            });
        }

    }
}
