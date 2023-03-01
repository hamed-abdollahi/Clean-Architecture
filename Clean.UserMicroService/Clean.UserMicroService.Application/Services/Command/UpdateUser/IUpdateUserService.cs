using Clean.UserMicroService.Domain.Entities;


namespace Clean.UserMicroService.Application.Services.Command.UpdateUser
{
    public interface IUpdateUserService
    {
        Task<UpdateUserResultDto> UpdateUser(UserEntity user, CancellationToken cancellationToken = default);
    }
}
