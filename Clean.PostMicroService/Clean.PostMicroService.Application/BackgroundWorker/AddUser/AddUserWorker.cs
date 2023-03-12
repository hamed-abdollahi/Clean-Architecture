using Clean.Shared.BaseChannel;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Clean.Shared.Events;
using Clean.PostMicroService.Application.Services.Query.GetPost;
using Clean.PostMicroService.Application.Services.Command.AddPost;
using Clean.PostMicroService.Application.Services.Query.GetUser;
using Clean.UserMicroService.Application.Services.Command.AddUser;
using Clean.PostMicroService.Domain.Entities;

namespace Clean.PostMicroService.Application.BackgroundWorker.AddUser
{
    public class AddUserWorker : BackgroundService
    {
        private readonly ChannelQueue<UserAdded> _readModelChannel;
        private readonly IServiceProvider _serviceProvider;

        public AddUserWorker(ChannelQueue<UserAdded> readModelChannel,IServiceProvider serviceProvider)
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
                var writeRepository = scope.ServiceProvider.GetRequiredService<AddUserMongoService>();
                try
                {
                    await foreach (var item in _readModelChannel.ReturnValue(stoppingToken))
                    {
                        var user = await getUserRepository.GetUser(item.UserId, stoppingToken);

                        if (user != null)
                        {
                            await writeRepository.AddAsync(new UserMongo()
                            {
                                UserId= user.UserId,
                                Name = user.Name ,
                                Family= user.Family 

                            }, stoppingToken);
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
