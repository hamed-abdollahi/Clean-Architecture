using Clean.PostMicroService.Domain.Entities;


namespace Clean.PostMicroService.Application.Services.Command.UpdatePost
{
    public interface IUpdatePostService
    {
        Task<UpdatePostResultDto> UpdatePost(PostEntity user, CancellationToken cancellationToken = default);
    }
}
