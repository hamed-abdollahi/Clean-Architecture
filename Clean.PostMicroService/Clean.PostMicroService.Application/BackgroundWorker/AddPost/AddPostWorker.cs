using Clean.Shared.BaseChannel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Clean.Shared.Events;
using Clean.PostMicroService.Application.Services.Query.GetPost;
using Clean.PostMicroService.Application.Services.Command.AddPost;
using Clean.PostMicroService.Application.Services.Query.GetUser;
using Clean.PostMicroService.Domain.Entities;

namespace Clean.PostMicroService.Application.BackgroundWorker.AddPost
{
    public class AddPostWorker : BackgroundService
    {
        private readonly ChannelQueue<PostAdded> _readModelChannel;
        private readonly IServiceProvider _serviceProvider;

        public AddPostWorker(ChannelQueue<PostAdded> readModelChannel,IServiceProvider serviceProvider)
        {
            _readModelChannel = readModelChannel;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var getUserRepository = scope.ServiceProvider.GetRequiredService<GetUserService>();
                var getPostRepository = scope.ServiceProvider.GetRequiredService<GetPostService>();
                var writeRepository = scope.ServiceProvider.GetRequiredService<AddPostMongoService>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var post = await getPostRepository.GetPost(item.PostId, stoppingToken);
                        if (post != null)
                        {
                            //await getUserRepository.
                            await writeRepository.AddUserPostAsync(new PostMongo()
                            {
                                PostId = post.Id,
                                Title= post.Title,
                                Content= post.Content
                            },post.UserId, stoppingToken);
                        }
                    }
                }
                catch (Exception e)
                {
                    //_logger.LogError(e, e.Message);
                }
            }
        }
    }
}
