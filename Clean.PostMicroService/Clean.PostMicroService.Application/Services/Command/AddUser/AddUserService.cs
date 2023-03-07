using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Domain.Entities;
using Clean.PostMicroService.Application.Services.Command.AddUser;

namespace Clean.PostMicroService.Application.Services.Query.GetUser
{
    public class AddUserService : IAddUserService
    {
        private readonly IApplicationDbContext _context;
        public AddUserService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<AddUserResultDto> AddUser(UserEntity user, CancellationToken cancellationToken = default)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return Task.FromResult(new AddUserResultDto() {
                Id = user.UserId ,
                Name= user.Name,
                Family= user.Family ,
                
            });
        }

    }
}
