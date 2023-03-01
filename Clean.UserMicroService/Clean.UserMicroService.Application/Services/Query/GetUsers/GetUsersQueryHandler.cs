using MediatR;

namespace Clean.UserMicroService.Application.Services.Query.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersResultDto>
    {
        private readonly IGetUsersService _getUsersService;

        public GetUsersQueryHandler(IGetUsersService getUsersService)
        {
            _getUsersService = getUsersService;
        }

        public Task<GetUsersResultDto> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return _getUsersService.GetUsers(request.Key, request.page, cancellationToken);
        }
    }
}
