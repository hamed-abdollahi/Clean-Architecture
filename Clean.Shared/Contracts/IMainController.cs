using Clean.Shared.Main;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Shared.Contracts
{
    public interface IMainController<T> where T : class
    {
        void Produce(T message, string tag);
    }
}
