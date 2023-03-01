namespace Clean.UserMicroService.Application.Services.Query.GetUsers
{
    public class GetUsersDto
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
    }
}
