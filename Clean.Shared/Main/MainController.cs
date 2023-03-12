using Clean.Shared.Contracts;
using Clean.Shared.DTO;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Shared.Main
{
    public abstract class MainController : ControllerBase, IMainController<MainConsumerDTO>
    {
        private readonly IBus _bus;
        public MainController(IBus bus)
        {
            _bus = bus;
        }

        [NonAction]
        public async void Produce(MainConsumerDTO message, string tag)
        {
            var uri = new Uri("amqps://jjyupbwu:53a5hzVQv055D31FnzW7U-L4DxnKwV5V@goose.rmq2.cloudamqp.com/jjyupbwu/" + tag);
            var _endPoint = await _bus.GetSendEndpoint(uri);
            _endPoint.Send(message);
        }

    }
}
