using Clean.UserMicroService.Application.Interfaces;

namespace Clean.UserMicroService.Application.Services.Query.GetUser
{
    public class GetUserService : IGetUserService
    {
        private readonly IApplicationDbContext _context;
        public GetUserService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<GetUserDto> GetUser(int id, CancellationToken cancellationToken = default)
        {
            var user = _context.Users.Find(id);
            if (user == null)
                return Task.FromResult<GetUserDto>(null);
            return Task.FromResult(new GetUserDto()
            {
                FullName = user.Name + " " + user.Family,
                Id = user.Id,
                Email = user.Email
            });
        }

    }
}
