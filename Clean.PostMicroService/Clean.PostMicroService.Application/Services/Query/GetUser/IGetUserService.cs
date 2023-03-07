namespace Clean.PostMicroService.Application.Services.Query.GetUser
{
    public interface IGetUserService
    {
        Task<GetUserDto> GetUser(int userId, CancellationToken cancellationToken = default);
    }
}
