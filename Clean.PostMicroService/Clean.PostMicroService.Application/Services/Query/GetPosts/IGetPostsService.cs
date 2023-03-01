namespace Clean.PostMicroService.Application.Services.Query.GetPosts
{
    public interface IGetPostsService
    {
        Task<GetPostsResultDto> GetPosts(string key, int page, CancellationToken cancellationToken = default);
    }
}
