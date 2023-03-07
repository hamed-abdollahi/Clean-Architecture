using MediatR;

namespace Clean.PostMicroService.Application.Services.Command.AddUser
{

    public class AddUserResultDto 
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

}
