using Clean.Shared.BaseChannel;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Shared.Main
{
    public class MainChannelQueue<T> where T : class
    {
        private readonly ChannelQueue<T> _channel;
        public MainChannelQueue(ChannelQueue<T> channel)
        {
            _channel = channel;
        }

        [NonAction]
        public async void SendToQueue(T eventClass)
        {
             await _channel.AddToChannelAsync(eventClass, default);
        }
    }
}
