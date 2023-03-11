using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.UpdateUser
{
    public class UpdateUserResultDto 
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
    }

}
