using Clean.Shared.Contracts;
using Clean.Shared.DTO;
using Clean.Shared.Models;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;


namespace Clean.Shared.Main
{
    public abstract class MainController : ControllerBase, IMainController<MainConsumerDTO>
    {
        private readonly IBus _bus;
        private readonly IConfiguration _configuration;
        public MainController(IBus bus,IConfiguration configuration)
        {
            _bus = bus;
            _configuration = configuration;
        }

        [NonAction]
        public async void Produce(MainConsumerDTO message, string tag)
        {
            var rabbitMqSettings = _configuration.GetSection(nameof(RabbitMqSettings)).Get<RabbitMqSettings>();
            var uri = new Uri(rabbitMqSettings.Uri + tag);
            var _endPoint = await _bus.GetSendEndpoint(uri);
            _endPoint.Send(message);
        }

    }
}
