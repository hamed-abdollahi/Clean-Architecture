using Clean.PostMicroService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace Clean.PostMicroService.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<UserEntity> Users { get; set; }
        DbSet<PostEntity> Posts { get; set; }
        DatabaseFacade Database { get; }
        EntityEntry Entry(object entity);
        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
