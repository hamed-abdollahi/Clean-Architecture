using Clean.PostMicroService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Clean.PostMicroService.Application.Services.Query.GetCompletePost
{
    public class GetCompletePostService : IGetCompletePostService
    {
        private readonly IApplicationDbContext _context;
        public GetCompletePostService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Task<List<GetCompletePostDto>> GetCompletePost(int userId, CancellationToken cancellationToken = default)
        {
            var post = _context.Posts.Where(x => x.UserId == userId).ToList();
            if (post == null)
                return Task.FromResult<List<GetCompletePostDto>>(null);

            var postUser = _context.Posts.Join(
                      _context.Users,
                      post => post.UserId,
                      user => user.UserId,
                      (post, user) => new { post, user })
            .Where(x => x.post.UserId == userId)
            .Select(x => new GetCompletePostDto
            {
                Id = x.post.Id,
                Title = x.post.Title,
                Content = x.post.Content,
                Name = x.user.Name,
                Family = x.user.Family
            }).ToList();

            return Task.FromResult(postUser);
        }

    }
}
