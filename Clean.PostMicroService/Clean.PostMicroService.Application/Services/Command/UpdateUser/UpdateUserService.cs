using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Application.Services.Command.UpdateUser;
using Clean.PostMicroService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.PostMicroService.Application.Services.Command.AddUser
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
                Id = user.UserId,
                Name = user.Name,
                Family = user.Family
            });
        }

    }
}
