using Clean.Domain.Entities;
using System.Linq.Expressions;

namespace Clean.Application.Services.User.Command.AddUser
{
    public interface IAddUserService
    {
        Task<AddUserResultDto> AddUser(UserEntity user, CancellationToken cancellationToken = default);
    }
}
