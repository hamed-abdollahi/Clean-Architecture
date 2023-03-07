using Clean.PostMicroService.Application.Interfaces;

namespace Clean.PostMicroService.Application.Services.Query.GetUser
{
    public class GetUserService : IGetUserService
    {
        private readonly IApplicationDbContext _context;
        public GetUserService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<GetUserDto> GetUser(int userId, CancellationToken cancellationToken = default)
        {
            var user = _context.Users.FirstOrDefault(x=>x.UserId == userId);
            if (user == null)
                return Task.FromResult<GetUserDto>(null);
            return Task.FromResult(new GetUserDto()
            {
                Id = user.Id,
                UserId = userId,
                Name = user.Name,
                Family = user.Family
            });
        }

    }
}
