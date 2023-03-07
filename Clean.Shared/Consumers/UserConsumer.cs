using Clean.Shared.Main;

namespace Clean.Shared.Consumers
{
    public class AddUserConsumer : MainConsumer
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
    }

    public class UpdateUserConsumer :MainConsumer
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
    }

    public class DeleteUserConsumer :MainConsumer
    {
        public int UserId { get; set; }
    }
}
