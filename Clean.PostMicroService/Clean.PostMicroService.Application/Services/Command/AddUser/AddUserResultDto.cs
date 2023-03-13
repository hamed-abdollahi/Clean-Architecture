using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.AddUser
{

    public class AddUserResultDto 
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        
    }

}
