namespace Clean.Application.Services.User.Query.GetUsers
{
    public interface IGetUsersService
    {
        Task<GetUsersResultDto> GetUsers(string key, int page, CancellationToken cancellationToken = default);
    }
}
