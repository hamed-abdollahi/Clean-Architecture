using Clean.UserMicroService.Domain.Entities;

namespace Clean.UserMicroService.Application.Services.Command.AddUser
{
    public interface IAddUserService
    {
        Task<AddUserResultDto> AddUser(UserEntity user, CancellationToken cancellationToken = default);
    }
}
