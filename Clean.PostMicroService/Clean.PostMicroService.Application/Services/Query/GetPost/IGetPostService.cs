namespace Clean.PostMicroService.Application.Services.Query.GetPost
{
    public interface IGetPostService
    {
        Task<GetPostDto> GetPost(int id, CancellationToken cancellationToken = default);
    }
}
