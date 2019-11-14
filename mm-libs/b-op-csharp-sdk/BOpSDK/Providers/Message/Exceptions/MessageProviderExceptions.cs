using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BOp.Providers.Message.Exceptions
{
    [Serializable]
    public class ListenerRegistrationException : System.Exception
    {
        public ListenerRegistrationException() { }
        public ListenerRegistrationException(string message) : base(message) { }
        public ListenerRegistrationException(string message, System.Exception inner) : base(message, inner) { }
        protected ListenerRegistrationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class MessageException : System.Exception
    {
        public MessageException() { }
        public MessageException(string message) : base(message) { }
        public MessageException(string message, System.Exception inner) : base(message, inner) { }
        protected MessageException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

    [Serializable]
    public class ProviderConfigurationException : Exception
    {
        public ProviderConfigurationException() { }
        public ProviderConfigurationException(string message) : base(message) { }
        public ProviderConfigurationException(string message, Exception inner) : base(message, inner) { }
        protected ProviderConfigurationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }

}
