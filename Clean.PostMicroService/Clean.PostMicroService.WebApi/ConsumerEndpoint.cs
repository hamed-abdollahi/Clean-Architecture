using Clean.PostMicroService.Application.Services.Command.AddUser;
using Clean.PostMicroService.Application.Services.Command.UpdateUser;
using Clean.PostMicroService.Application.Services.Query.GetUser;
using Clean.PostMicroService.Domain.Entities;
using Clean.Shared.BaseChannel;
using Clean.Shared.Consumers;
using Clean.Shared.DTO;
using Clean.Shared.Events;
using MassTransit;
using MassTransit.Mediator;
using System.Threading;

public class ConsumerEndpoint : IConsumer<MainConsumerDTO>
{
    private readonly IAddUserService _addUserService;
    private readonly IUpdateUserService _updateUserService;
    public ConsumerEndpoint(IAddUserService addUserService,IUpdateUserService updateUserService)
    {
        _addUserService = addUserService;
        _updateUserService = updateUserService;
    }
    public async Task Consume(ConsumeContext<MainConsumerDTO> context)
    {
        var message = context.Message;
        try
        {
            switch (message.Operation)
            {
                case Operation.Add:
                    AddUserConsumer addConsumer = (AddUserConsumer)message.Data;
                    var userAddModel = new UserEntity()
                    {
                        UserId = addConsumer.UserId,
                        Name = addConsumer.Name,
                        Family = addConsumer.Family,
                    };
                    await _addUserService.AddUser(userAddModel);
                    break;
                case Operation.Edit:
                    UpdateUserConsumer updateConsumer = (UpdateUserConsumer)message.Data;
                    var userUpdateModel = new UserEntity()
                    {
                        UserId = updateConsumer.UserId,
                        Name = updateConsumer.Name,
                        Family = updateConsumer.Family,
                    };
                    await _updateUserService.UpdateUser(userUpdateModel);
                    break;
                case Operation.Delete:
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {

            throw;
        }

    }
}
