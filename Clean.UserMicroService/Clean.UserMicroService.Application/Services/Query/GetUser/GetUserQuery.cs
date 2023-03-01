using MediatR;

namespace Clean.UserMicroService.Application.Services.Query.GetUser
{
    public class GetUserQuery : IRequest<GetUserDto>
    {
        public int Id { get; set; }
    }
}
