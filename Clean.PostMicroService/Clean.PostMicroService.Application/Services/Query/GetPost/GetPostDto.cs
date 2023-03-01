namespace Clean.PostMicroService.Application.Services.Query.GetPost
{
    public class GetPostDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
    }
}
