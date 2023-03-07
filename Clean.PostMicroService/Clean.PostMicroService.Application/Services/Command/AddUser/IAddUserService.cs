using Clean.PostMicroService.Domain.Entities;

namespace Clean.PostMicroService.Application.Services.Command.AddUser
{
    public interface IAddUserService
    {
        Task<AddUserResultDto> AddUser(UserEntity user, CancellationToken cancellationToken = default);
    }
}
