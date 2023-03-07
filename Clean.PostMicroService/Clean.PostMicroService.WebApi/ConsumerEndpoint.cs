using Clean.PostMicroService.Application.Services.Command.AddUser;
using Clean.PostMicroService.Application.Services.Command.UpdateUser;
using Clean.PostMicroService.Application.Services.Query.GetUser;
using Clean.PostMicroService.Domain.Entities;
using Clean.Shared.Consumers;
using Clean.Shared.DTO;
using MassTransit;
using MassTransit.Mediator;

public class ConsumerEndpoint : IConsumer<MainConsumerDTO>
{
    private readonly IAddUserService _addUserService;
    private readonly IGetUserService _getUserService;
    private readonly IUpdateUserService _updateUserService;
    public ConsumerEndpoint(IAddUserService addUserService,
          IGetUserService getUserService, IUpdateUserService updateUserService)
    {
        _addUserService = addUserService;
        _getUserService = getUserService;
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
                    var getUser = await _getUserService.GetUser(updateConsumer.UserId);
                    var userUpdateModel = new UserEntity()
                    {
                        Id = getUser.Id,
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
