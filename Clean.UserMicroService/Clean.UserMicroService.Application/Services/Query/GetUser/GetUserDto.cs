namespace Clean.UserMicroService.Application.Services.Query.GetUser
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
