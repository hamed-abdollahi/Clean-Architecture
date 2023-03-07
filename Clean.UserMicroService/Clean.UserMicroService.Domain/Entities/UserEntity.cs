using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Clean.UserMicroService.Domain.Entities
{
    [Table("tblUser")]
    public class UserEntity
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
