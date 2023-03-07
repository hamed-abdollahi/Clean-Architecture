using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.PostMicroService.Domain.Entities
{
    [Table("tblUser")]
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        
    }
}
