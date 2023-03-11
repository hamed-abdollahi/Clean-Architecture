using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.UpdateUser
{

    public class UpdateUserCommand : IRequest<UpdateUserResultDto>
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
    }

}
