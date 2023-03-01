namespace Clean.PostMicroService.Application.Services.Query.GetPosts
{
    public class GetPostsDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
    }
}
