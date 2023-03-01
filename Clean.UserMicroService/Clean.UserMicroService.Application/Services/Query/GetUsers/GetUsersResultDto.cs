namespace Clean.UserMicroService.Application.Services.Query.GetUsers
{
    public class GetUsersResultDto
    {
        public int rowCount { get; set; }
        public List<GetUsersDto> users { get; set; }
    }
}
