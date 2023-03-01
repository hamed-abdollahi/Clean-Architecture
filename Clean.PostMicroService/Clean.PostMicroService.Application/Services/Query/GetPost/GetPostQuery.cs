using MediatR;

namespace Clean.PostMicroService.Application.Services.Query.GetPost
{
    public class GetPostQuery : IRequest<GetPostDto>
    {
        public int Id { get; set; }
    }
}
