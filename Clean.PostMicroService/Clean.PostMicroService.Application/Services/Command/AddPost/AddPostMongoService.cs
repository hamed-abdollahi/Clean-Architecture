using Automatonymous;
using Clean.PostMicroService.Domain.Entities;
using Clean.Shared.Main;
using Clean.UserMicroService.Application.Services.Command.AddUser;
using MongoDB.Bson;
using MongoDB.Driver;
using SharpCompress.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public class AddPostMongoService : MainMongoRepository<PostMongo>
    {
        private readonly AddUserMongoService _addUserMongoService;
        IMongoDatabase _db;
        public AddPostMongoService(IMongoDatabase db) : base(db)
        {
            _db = db;
        }

        public async Task AddUserPostAsync(PostMongo post,int userId, CancellationToken cancellationToken = default)
        {
            var tableName = typeof(UserMongo).Name;
            var userCollection = _db.GetCollection<UserMongo>(tableName);
            var builder = Builders<UserMongo>.Filter;
            var filter = builder.Eq(x => x.UserId, userId);

            var update = Builders<UserMongo>.Update
                .AddToSet(x=>x.Posts, new PostMongo
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    PostId = post.PostId,
                    Title = post.Title,
                    Content= post.Content,
                });

            var result = await userCollection.UpdateOneAsync(x=>x.UserId == userId, update, cancellationToken: cancellationToken);

            //if (!result.IsAcknowledged)
                //throw new Exception($"Could not update the entity");

        }

        public Task<PostMongo> GetPostByIdAsync(int postId, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(m => m.PostId == postId, cancellationToken);
        }

        public Task<PostMongo> GetPostByNameAsync(string name, CancellationToken cancellationToken = default)
        {
            return base.FirstOrDefaultAsync(m => m.Title == name, cancellationToken);
        }

        public Task DeletePostByIdAsync(int postId, CancellationToken cancellationToken = default)
        {
            return base.DeleteAsync(m => m.PostId == postId, cancellationToken);
        }
    }
}
