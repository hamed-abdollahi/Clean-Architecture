using Clean.PostMicroService.Domain.Entities;
using MassTransit;
using System;

public class ConsumerClass : IConsumer<UserEntity>
{
    public async Task Consume(ConsumeContext<UserEntity> context)
    {
        var user = context.Message;
    }
}
