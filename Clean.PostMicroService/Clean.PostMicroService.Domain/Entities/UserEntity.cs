namespace Clean.PostMicroService.Domain.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public List<PostEntity> PostEntity { get; set; }
    }
}
