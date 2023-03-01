using Clean.UserMicroService.Application.Services.Command.AddUser;
using MediatR;

namespace Clean.UserMicroService.Application.Services.Command.UpdateUser
{

    public class UpdateUserCommand : IRequest<UpdateUserResultDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
