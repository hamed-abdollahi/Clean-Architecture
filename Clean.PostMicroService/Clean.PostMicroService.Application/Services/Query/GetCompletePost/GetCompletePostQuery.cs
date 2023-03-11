using MediatR;

namespace Clean.PostMicroService.Application.Services.Query.GetCompletePost
{
    public class GetCompletePostQuery : IRequest<List<GetCompletePostDto>>
    {
        public int UserId { get; set; }
    }
}
