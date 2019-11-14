using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.Message
{
    public interface IMessageServiceProvider
    {
        void SendMessage(Message message);
        void RegisterListener(MessageListener listener);
    }
}
