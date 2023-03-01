using Clean.PostMicroService.Application.Interfaces;
using Clean.Shared;


namespace Clean.PostMicroService.Application.Services.Query.GetPosts
{
    public class GetPostsService : IGetPostsService
    {
        private readonly IApplicationDbContext _context;
        public GetPostsService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public Task<GetPostsResultDto> GetPosts(string key, int page, CancellationToken cancellationToken = default)
        {
            var posts = _context.Posts.AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                posts = posts.Where(p => p.Title.Contains(key) || p.Content.Contains(key));
            }
            int rowCount = 0;
            var result = posts.GetPage(page, 20, out rowCount);

            if (result is null)
                return Task.FromResult<GetPostsResultDto>(null);
            
            var res = result.Select(p => new GetPostsDto()
            {
                Id= p.Id,
                Title = p.Title,
                Content = p.Content,
                UserId = p.UserId
            }).ToList();

            return Task.FromResult(new GetPostsResultDto()
            {
                rowCount = rowCount,
                posts = res
            });

        }

    }
}
