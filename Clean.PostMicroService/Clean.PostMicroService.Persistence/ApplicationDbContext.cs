using Clean.PostMicroService.Domain.Entities;
using Clean.PostMicroService.Application.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace Clean.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<PostEntity> Posts { get; set; }

    }


}
