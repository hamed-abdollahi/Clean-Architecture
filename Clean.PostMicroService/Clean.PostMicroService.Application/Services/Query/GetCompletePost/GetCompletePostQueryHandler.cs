using MediatR;

namespace Clean.PostMicroService.Application.Services.Query.GetCompletePost
{
    public class GetCompletePostQueryHandler : IRequestHandler<GetCompletePostQuery, List<GetCompletePostDto>>
    {
        private readonly IGetCompletePostService _getCompletePostService;

        public GetCompletePostQueryHandler(IGetCompletePostService getCompletePostService)
        {
            _getCompletePostService = getCompletePostService;
        }

        public Task<List<GetCompletePostDto>> Handle(GetCompletePostQuery request, CancellationToken cancellationToken)
        {
            return _getCompletePostService.GetCompletePost(request.UserId, cancellationToken);
        }
    }
}
