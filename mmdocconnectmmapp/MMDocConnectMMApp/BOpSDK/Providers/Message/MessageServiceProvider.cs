using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using BOp.Services.Rest;
using BOp.Providers.Message.Exceptions;
using System.Net;

namespace BOp.Providers.Message
{
    internal class MessageServiceProvider : BaseProvider, IMessageServiceProvider
    {

        public MessageServiceProvider(IRestClient client)
            : base(client)
        {
        }

        public void SendMessage(Message message)
        {
            var request = new JSONRestRequest("receiver", Method.POST);
            request.AddBody(message);
            var response = Execute(request, HttpStatusCode.OK);
        }

        public void RegisterListener(MessageListener listener)
        {
            var request = new JSONRestRequest("listeners", Method.POST);
            request.AddBody(listener);
            var response = Execute(request, HttpStatusCode.Created);
        }
    }
}
