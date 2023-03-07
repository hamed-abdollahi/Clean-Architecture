using Clean.Shared.Consumers;
using Clean.Shared.Contracts;
using Clean.Shared.DTO;
using MassTransit;
using MassTransit.Internals.GraphValidation;
using MassTransit.Mediator;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Reflection;
using System.Threading;

namespace Clean.Shared.Main
{
    
    public abstract class MainController : ControllerBase , IMainController<MainConsumerDTO>
    {
        private readonly IBus _bus;
        public MainController(IBus bus)
        {
            _bus= bus;
        }

        [NonAction]
        public async void Produce(MainConsumerDTO message, string tag)
        {
            var uri = new Uri("rabbitmq://localhost/" + tag);
            var _endPoint = await _bus.GetSendEndpoint(uri);
            _endPoint.Send(message);
        }

    }
}
