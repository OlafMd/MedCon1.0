using System;
using System.Xml.Serialization;
using BOp.Message;
using System.Web;

namespace DLCore_MessageListener.Messages.Standard.DLStandardMessage
{
    [XmlRoot(ElementName = "PAYLOAD")]
    public class DLStandardMessage<T1, T2>
    where T1 : class, new()
    where T2 : class, new()
    {
        public DLStandardMessage()
        {
            MethodPayload = new MethodPayload<T1, T2>();
        }

        #region Properties

        [XmlElement(ElementName = "METHOD")]
        public String MethodName { get; set; }

        [XmlElement(ElementName = "METHODVERSION")]
        public String MethodVersion { get; set; }

        [XmlElement(ElementName = "METHODPAYLOAD")]
        public MethodPayload<T1, T2> MethodPayload { get; set; }

        #endregion
        
        #region Methods

        public void InitializeData(string MethodName, string MethodVersion, string MessageConfiguration_BaseLanguage, 
            String SupplyingTenant_TenantITL, String SupplyingTenant_TenantName,
            String ProcuringTenant_TenantITL, string ProcuringTenant_TenantName, bool ProcuringTenant_IsExternalTenant)
        {
            this.MethodName = MethodName;
            this.MethodVersion = MethodVersion;
            this.MethodPayload.MessageConfiguration.BaseLanguage = MessageConfiguration_BaseLanguage;            
        }

        public MessageContent<T1, T2> GetMessageContent()
        {
            return MethodPayload.MessageContent;
        }

        public string ToPayload()
        {
            var payload = SerializationUtils.SerializeObject(this);
            return HttpContext.Current.Server.HtmlEncode(payload);
        }

        #endregion

        #region Static methods
        
        public static DLStandardMessage<T1, T2> FromPayload(string Payload)
        {
            var decodedPayload = System.Web.HttpUtility.HtmlDecode(Payload);
            return SerializationUtils.ParseFromPayload<DLStandardMessage<T1, T2>>(decodedPayload);
        }

        #endregion
    }

    #region SubClasses

    public class MethodPayload<T1, T2> 
    where T1: class, new() 
    where T2: class, new()
    {
        public MethodPayload()
        {         
            MessageConfiguration = new MessageConfiguration();
            MessageHeader = new MessageHeader();
            MessageContent = new MessageContent<T1, T2>();
        }

        [XmlElement(ElementName = "MessageConfiguration")]
        public MessageConfiguration MessageConfiguration { get; set; }

        [XmlElement(ElementName = "MessageHeader")]
        public MessageHeader MessageHeader { get; set; }

        [XmlElement(ElementName = "MessageContent")]
        public MessageContent<T1, T2> MessageContent { get; set; }      
    }

    public class MessageConfiguration
    {
        [XmlAttribute(AttributeName = "BaseLanguage")]
        public String BaseLanguage { get; set; }

        [XmlAttribute(AttributeName = "BaseCurrency")]
        public String BaseCurrency { get; set; }
    }

    public class MessageHeader
    {

        public MessageHeader()
        {
            Sender = new Tenant();
            Recipient = new Tenant();
        }

        [XmlElement(ElementName = "Sender")]
        public Tenant Sender { get; set; }

        [XmlElement(ElementName = "Recipient")]
        public Tenant Recipient { get; set; }
    }

    public class MessageContent<T1, T2> 
    where T1 : class, new() 
    where T2 : class, new()
    {
        public MessageContent()
        {
            ContentHeader = new T1(); 
            Positions = new T2();
        }

        [XmlElement(ElementName = "ContentHeader")]
        public T1 ContentHeader { get; set; }

        [XmlElement(ElementName = "Positions")]
        public T2 Positions { get; set; }
    }

    public class Tenant
    {
        public Tenant()
        {
            Identity = new Identity();
        }

        [XmlElement(ElementName = "Identity")]
        public Identity Identity { get; set; }
    }

    public class Identity
    {
        [XmlAttribute(AttributeName="TenantITL")]
        public String TenantITL { get; set; }     

        [XmlElement(ElementName = "TenantName")]
        public String TenantName { get; set; }
    }
    
    #endregion
}
