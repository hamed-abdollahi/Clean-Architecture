using MediatR;

namespace Clean.Application.Services.User.Command.AddUser
{

    public class AddUserCommand : IRequest<AddUserResultDto>
    {
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
