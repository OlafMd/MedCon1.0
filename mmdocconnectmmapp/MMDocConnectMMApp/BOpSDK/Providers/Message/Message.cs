using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Configuration;
using BOp.Config;
using BOp.Providers.Message.Exceptions;

namespace BOp.Providers.Message
{
    public class MessageTarget
    {
        public MessageTarget() { }
        public MessageTarget(Guid tenantID)
        {
            TenantID = tenantID;
        }


        public Guid ApplicationID { get; set; }
        public Guid ModuleID { get; set; }
        public Guid TenantID { get; set; }
    }
    public class MessageBuilder
    {
        private const string DEFAULT_TYPE = "enterprise-talk";

        private Message _message;

        private MessageBuilder(MessageTarget source, MessageTarget destination, String subtype, String body)
        {
            var config = new BOpConfiguration();

            _message = new Message();
            _message.Body = body;

            _message.Header.Source.ApplicationID = source.ApplicationID;
            _message.Header.Source.ModuleID = source.ModuleID;
            _message.Header.Source.TenantID = source.TenantID;

            _message.Header.Destination.ApplicationID = destination.ApplicationID;
            _message.Header.Destination.ModuleID = destination.ModuleID;
            _message.Header.Destination.TenantID = destination.TenantID;


            _message.Header.MessageID = Guid.NewGuid();
            _message.Header.Type = DEFAULT_TYPE;
            _message.Header.Subtype = subtype;
            _message.Header.Version = "0";

            //_message.Header.SentOn
        }

        public static MessageBuilder ForMessage(MessageTarget source, MessageTarget destination, String subtype, String body)
        {
            return new MessageBuilder(source, destination, subtype, body);
        }

        public MessageBuilder setDestinationApplicationAndModule(Guid application, Guid module)
        {
            _message.Header.Destination.ApplicationID = application;
            _message.Header.Destination.ModuleID = module;
            return this;
        }

        public MessageBuilder setMessageID(Guid messageID)
        {
            _message.Header.MessageID = messageID;
            return this;
        }

        public MessageBuilder setMessageType(string type)
        {
            _message.Header.Type = type;
            return this;
        }

        public MessageBuilder setMessageSubtype(string subtype)
        {
            _message.Header.Subtype = subtype;
            return this;
        }

        public MessageBuilder setMessageSubtypeVersion(string version)
        {
            _message.Header.Version = version;
            return this;
        }

        public Message build()
        {
            return _message;
        }

    }

    /// <summary>
    /// Full BOp message wrapper, containing a message header (for b-op) and the body
    /// </summary>
    [DataContract]
    public class Message
    {
        public Message()
        {
            Header = new Header();
            Header.Source = new Target();
            Header.Destination = new Target();
        }
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        /// <value>
        /// The header.
        /// </value>
        [DataMember(Name = "header")]
        public Header Header { get; set; }

        /// <summary>
        /// Specifies the escaped variant of the body
        /// </summary>
        /// <value>
        /// The body.
        /// </value>
        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
    /// <summary>
    /// Specifies the header of the message, containing information used in BOp messaging
    /// </summary>
    [DataContract]
    public class Header
    {
        [DataMember(Name = "source")]
        public Target Source { get; set; }
        [DataMember(Name = "destination")]
        public Target Destination { get; set; }
        [DataMember(Name = "id")]
        public Guid MessageID { get; set; }
        [DataMember(Name = "type")]
        public string Type { get; set; }
        [DataMember(Name = "subtype")]
        public string Subtype { get; set; }
        [DataMember(Name = "version")]
        public string Version { get; set; }
        //[DataMember(Name = "sentOn")]
        //public DateTime SentOn { get; set; }
    }

    [DataContract]
    public class Target
    {
        [DataMember(Name = "realm")]
        public Guid? RealmID { get; set; }
        [DataMember(Name = "application")]
        public Guid? ApplicationID { get; set; }
        [DataMember(Name = "module")]
        public Guid? ModuleID { get; set; }
        [DataMember(Name = "tenant")]
        public Guid? TenantID { get; set; }
    }

}
