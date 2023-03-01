namespace Clean.UserMicroService.Application.Services.Query.GetUsers
{
    public interface IGetUsersService
    {
        Task<GetUsersResultDto> GetUsers(string key, int page, CancellationToken cancellationToken = default);
    }
}
