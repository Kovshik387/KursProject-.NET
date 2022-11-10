using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject.Interface
{
    internal interface IDeliveryService
    {
        public string? To_Message { get; set; }
        public void MessageSend(string path);
    }
}
