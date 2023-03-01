using Clean.UserMicroService.Application.Interfaces;
using Clean.UserMicroService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Clean.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }
    }

    
}
