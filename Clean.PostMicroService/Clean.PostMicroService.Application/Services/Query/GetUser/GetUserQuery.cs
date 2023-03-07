using MediatR;

namespace Clean.PostMicroService.Application.Services.Query.GetUser
{
    public class GetUserQuery : IRequest<GetUserDto>
    {
        public int Id { get; set; }
    }
}
