using Clean.Application.Interfaces;
using Clean.Application.Services.User.Command.AddUser;
using Clean.Domain.Entities;
using Clean.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clean.Application.Services.User.Query.GetUser
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
            return Task.FromResult(new AddUserResultDto() { Id = user.Id });
        }

    }
}
