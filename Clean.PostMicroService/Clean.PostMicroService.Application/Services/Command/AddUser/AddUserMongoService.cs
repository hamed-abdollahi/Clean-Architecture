using Clean.PostMicroService.Domain.Entities;
using Clean.Shared.Main;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.UserMicroService.Application.Services.Command.AddUser
{
    public class AddUserMongoService : MainMongoRepository<UserMongo>
    {
        public AddUserMongoService(IMongoDatabase db) : base(db)
        {
        }

        public Task<UserMongo> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(user => user.UserId == userId, cancellationToken);
        }

    }
}
