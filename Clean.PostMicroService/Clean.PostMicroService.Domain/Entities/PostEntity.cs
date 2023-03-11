using Clean.PostMicroService.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clean.PostMicroService.Domain.Entities
{
    [Table("tblPost")]
    public class PostEntity
    {
        [Key , DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }

    }
}
