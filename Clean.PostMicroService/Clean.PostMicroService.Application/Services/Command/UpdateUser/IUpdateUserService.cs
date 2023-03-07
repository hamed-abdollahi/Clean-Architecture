using Clean.PostMicroService.Domain.Entities;


namespace Clean.PostMicroService.Application.Services.Command.UpdateUser
{
    public interface IUpdateUserService
    {
        Task<UpdateUserResultDto> UpdateUser(UserEntity user, CancellationToken cancellationToken = default);
    }
}
