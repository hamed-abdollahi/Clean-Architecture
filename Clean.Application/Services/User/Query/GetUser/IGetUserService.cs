using Clean.Domain.Entities;
using System.Linq.Expressions;

namespace Clean.Application.Services.User.Query.GetUser
{
    public interface IGetUserService
    {
        Task<GetUserDto> GetUser(int id, CancellationToken cancellationToken = default);
    }
}
