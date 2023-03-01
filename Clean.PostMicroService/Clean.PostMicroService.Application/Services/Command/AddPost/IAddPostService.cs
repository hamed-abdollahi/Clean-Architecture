using Clean.PostMicroService.Domain.Entities;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public interface IAddPostService
    {
        Task<AddPostResultDto> AddPost(PostEntity post, CancellationToken cancellationToken = default);
    }
}
