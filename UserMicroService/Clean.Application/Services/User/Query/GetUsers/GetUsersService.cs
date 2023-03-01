using Clean.Application.Interfaces;
using Clean.Shared;


namespace Clean.Application.Services.User.Query.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IApplicationDbContext _context;
        public GetUsersService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        public Task<GetUsersResultDto> GetUsers(string key, int page, CancellationToken cancellationToken = default)
        {
            var users = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(key))
            {
                users = users.Where(p => p.Name.Contains(key) || p.Family.Contains(key) || p.Email.Contains(key));
            }
            int rowCount = 0;
            var result = users.GetPage(page, 20, out rowCount);

            if (result is null)
                return Task.FromResult<GetUsersResultDto>(null);
            
            var res = result.Select(p => new GetUsersDto()
            {
                Id = p.Id,
                FullName = p.Name + " " + p.Family,
                Email = p.Email
            }).ToList();

            return Task.FromResult(new GetUsersResultDto()
            {
                rowCount = rowCount,
                users = res
            });

        }

    }
}
