using Clean.UserMicroService.Application.Interfaces;
using Clean.UserMicroService.Application.Services.Command.AddUser;
using Clean.UserMicroService.Domain.Entities;
using Clean.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clean.UserMicroService.Application.Services.Query.GetUser
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
