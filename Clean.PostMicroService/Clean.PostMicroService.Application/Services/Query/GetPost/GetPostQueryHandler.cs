using MediatR;

namespace Clean.PostMicroService.Application.Services.Query.GetPost
{
    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, GetPostDto>
    {
        private readonly IGetPostService _getPostService;

        public GetPostQueryHandler(IGetPostService getPostService)
        {
            _getPostService = getPostService;
        }

        public Task<GetPostDto> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return _getPostService.GetPost(request.Id, cancellationToken);
        }

    }
}
