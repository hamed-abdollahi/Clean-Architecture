using MediatR;

namespace Clean.PostMicroService.Application.Services.Query.GetPosts
{
    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, GetPostsResultDto>
    {
        private readonly IGetPostsService _getUsersService;

        public GetPostsQueryHandler(IGetPostsService getPostsService)
        {
            _getUsersService = getPostsService;
        }

        public Task<GetPostsResultDto> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return _getUsersService.GetPosts(request.Key, request.page, cancellationToken);
        }
    }
}
