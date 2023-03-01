using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Clean.PostMicroService.Application.Services.Query.GetPosts
{
    public class GetPostsQuery : IRequest<GetPostsResultDto>
    {
        public string? Key { get; set; }
        public int page { get; set; }

    }
}
