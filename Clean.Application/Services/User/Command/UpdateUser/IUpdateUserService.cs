using Clean.Application.Services.User.Command.AddUser;
using Clean.Domain.Entities;


namespace Clean.Application.Services.User.Command.UpdateUser
{
    public interface IUpdateUserService
    {
        Task<UpdateUserResultDto> UpdateUser(UserEntity user, CancellationToken cancellationToken = default);
    }
}
