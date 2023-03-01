using Clean.PostMicroService.Application.Interfaces;
using Clean.PostMicroService.Domain.Entities;
using Clean.Shared;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Clean.PostMicroService.Application.Services.Command.UpdatePost
{
    public class UpdatePostService : IUpdatePostService
    {
        private readonly IApplicationDbContext _context;
        public UpdatePostService(IApplicationDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        public Task<UpdatePostResultDto> UpdatePost(PostEntity post, CancellationToken cancellationToken = default)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
            return Task.FromResult(new UpdatePostResultDto() { 
               Id = post.Id,
               Content= post.Content,
               Title= post.Title,
               UserId = post.UserId
            });
        }

    }
}
