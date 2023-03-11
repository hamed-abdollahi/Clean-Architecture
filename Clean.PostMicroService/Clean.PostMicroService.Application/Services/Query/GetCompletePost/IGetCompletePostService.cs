namespace Clean.PostMicroService.Application.Services.Query.GetCompletePost
{
    public interface IGetCompletePostService
    {
        Task<List<GetCompletePostDto>> GetCompletePost(int userId, CancellationToken cancellationToken = default);
    }
}
