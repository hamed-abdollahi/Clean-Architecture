namespace Clean.PostMicroService.Application.Services.Query.GetPosts
{
    public class GetPostsResultDto
    {
        public int rowCount { get; set; }
        public List<GetPostsDto> posts { get; set; }
    }
}
