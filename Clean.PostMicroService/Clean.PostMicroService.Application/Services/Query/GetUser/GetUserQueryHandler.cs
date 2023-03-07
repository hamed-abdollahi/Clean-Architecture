using MediatR;

namespace Clean.PostMicroService.Application.Services.Query.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserDto>
    {
        private readonly IGetUserService _getUserService;

        public GetUserQueryHandler(IGetUserService getUserService)
        {
            _getUserService = getUserService;
        }

        public Task<GetUserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return _getUserService.GetUser(request.Id, cancellationToken);
        }

    }
}
