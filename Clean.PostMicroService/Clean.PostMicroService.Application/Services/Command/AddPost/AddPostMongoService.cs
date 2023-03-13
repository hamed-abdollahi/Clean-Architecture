using Clean.PostMicroService.Domain.Entities;
using Clean.Shared.Main;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Clean.PostMicroService.Application.Services.Command.AddPost
{
    public class AddPostMongoService : MainMongoRepository<PostMongo>
    {
        IMongoDatabase _db;
        public AddPostMongoService(IMongoDatabase db) : base(db)
        {
            _db = db;
        }

        public async Task AddUserPostAsync(PostMongo post,int userId, CancellationToken cancellationToken = default)
        {
            var tableName = typeof(UserMongo).Name;
            var userCollection = _db.GetCollection<UserMongo>(tableName);
            var update = Builders<UserMongo>.Update
                .AddToSet(x=>x.Posts, new PostMongo
                {
                    Id = ObjectId.GenerateNewId().ToString(),
                    PostId = post.PostId,
                    Title = post.Title,
                    Content= post.Content,
                });

            var result = await userCollection.UpdateOneAsync(x=>x.UserId == userId, update, cancellationToken: cancellationToken);

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
