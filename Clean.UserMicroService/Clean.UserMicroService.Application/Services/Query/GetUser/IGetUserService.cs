namespace Clean.UserMicroService.Application.Services.Query.GetUser
{
    public interface IGetUserService
    {
        Task<GetUserDto> GetUser(int id, CancellationToken cancellationToken = default);
    }
}
