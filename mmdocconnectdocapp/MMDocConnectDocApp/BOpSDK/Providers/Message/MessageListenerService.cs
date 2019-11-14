using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Routing;
using System.IO;
using Newtonsoft.Json;

namespace BOp.Providers.Message
{
    public interface IMessageHandler
    {
        void ProcessMessage(Message message);
    }

    public class MessageListenerService : IHttpHandler, IRouteHandler
    {
        IMessageHandler _handler;


        public MessageListenerService(IMessageHandler handler)
        {
            _handler = handler;
        }

        public bool IsReusable
        {
            get { return false; }
        }

        public void ProcessRequest(HttpContext context)
        {
            //TODO: Add processing time for statistical purposes
            try
            {
                StreamReader stream = new StreamReader(context.Request.InputStream);
                string data = stream.ReadToEnd();
                ProcessMessage(data);
                context.Response.Write("Processing complete");
                context.Response.StatusCode = 200;
            }
            catch (Exception ex)
            {
                //TODO: Log error
                context.Response.Write(ex.StackTrace);
                context.Response.StatusCode = 500;
            }
        }

        public void ProcessMessage(string data)
        {
            var message = JsonConvert.DeserializeObject<Message>(data);
            _handler.ProcessMessage(message);
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return this;
        }
    }
}
