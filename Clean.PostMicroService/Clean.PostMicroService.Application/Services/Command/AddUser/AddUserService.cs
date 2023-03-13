using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Domain.Entities;
using Clean.PostMicroService.Application.Services.Command.AddUser;
using Clean.Shared.Main;
using Clean.Shared.Events;
using Clean.Shared.BaseChannel;

namespace Clean.PostMicroService.Application.Services.Query.GetUser
{
    public class AddUserService : MainChannelQueue<UserAdded> , IAddUserService 
    {
        private readonly IApplicationDbContext _context;
        public AddUserService(IApplicationDbContext context, ChannelQueue<UserAdded> channel) :base(channel)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<AddUserResultDto> AddUser(UserEntity user, CancellationToken cancellationToken = default)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            SendToQueue(new UserAdded() { UserId = user.UserId });
            return Task.FromResult(new AddUserResultDto() {
                UserId = user.UserId ,
                Name= user.Name,
                Family= user.Family 
            });
        }

    }
}
