using Clean.Application.Interfaces;
using Clean.Application.Services.User.Command.UpdateUser;
using Clean.Domain.Entities;
using Clean.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clean.Application.Services.User.Command.AddUser
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly IApplicationDbContext _context;
        public UpdateUserService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<UpdateUserResultDto> UpdateUser(UserEntity user, CancellationToken cancellationToken = default)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(new UpdateUserResultDto() { 
               Id = user.Id,
               Name = user.Name ,
               Family = user.Family ,
               Email = user.Email,
               Password = user.Password
            });
        }

    }
}
