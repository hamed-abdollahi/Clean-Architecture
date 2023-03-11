using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.PostMicroService.Domain.Entities
{
    [Table("tblUser")]
    public class UserEntity
    {
        [Key , DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        
    }
}
