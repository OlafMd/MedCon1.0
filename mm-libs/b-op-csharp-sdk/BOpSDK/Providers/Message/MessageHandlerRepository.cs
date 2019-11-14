using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BOp.Config;
using System.Configuration;
using System.Web;
using System.IO;
using System.Web.Routing;
using BOp.Services.Serialization;
using Newtonsoft.Json;

namespace BOp.Providers.Message
{
    public delegate void HandleMessage(Message message);

    public class MessageHandlerRepository : IMessageHandler
    {
        private static MessageHandlerRepository _instance;

        public static MessageHandlerRepository Instance
        {
            get
            {
                if (_instance == null) _instance = new MessageHandlerRepository();
                return _instance;
            }
        }


        private Dictionary<string, HandleMessage> _messageHandlers;

        internal MessageHandlerRepository()
        {
            _messageHandlers = new Dictionary<string, HandleMessage>();
        }



        public void RegisterHandler(HandleMessage callback, params string[] messageTypes)
        {
            if (!IsListenerConfigured()) throw new ArgumentException("Listener is not configured in the message section of BOp SDK");

            foreach (string type in messageTypes)
            {
                _messageHandlers.Add(type, callback);
            }
        }


        public void ProcessMessage(Message message)
        {
            var subtype = message.Header.Subtype;
            if (_messageHandlers.ContainsKey(subtype))
            {
                var handler = _messageHandlers[subtype];
                try
                {
                    handler.Invoke(message);
                }
                catch
                {
                    throw;
                }
            }
        }

       
        private bool IsListenerConfigured()
        {
            return true;
        }
    }




}
