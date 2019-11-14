using System;
using System.Xml.Serialization;
using BOp.Message;
using System.Web;

namespace DLCore_MessageListener.Messages.Standard
{
    [XmlRoot(ElementName = "PAYLOAD")]
    public class StandardMessage<T>
    {
        public StandardMessage()
        {
            MethodPayload = new MethodPayload<T>();
        }

        #region Properties

        [XmlElement(ElementName = "METHOD")]
        public String MethodName { get; set; }

        [XmlElement(ElementName = "METHODVERSION")]
        public String MethodVersion { get; set; }

        [XmlElement(ElementName = "METHODPAYLOAD")]
        public MethodPayload<T> MethodPayload { get; set; }

        #endregion
        
        #region Methods

        public void InitializeData(string MethodName, string MethodVersion, string MessageConfiguration_BaseLanguage, 
            String SupplyingTenant_TenantITL, String SupplyingTenant_TenantName,
            String ProcuringTenant_TenantITL, string ProcuringTenant_TenantName, bool ProcuringTenant_IsExternalTenant)
        {
            this.MethodName = MethodName;
            this.MethodVersion = MethodVersion;
            this.MethodPayload.MessageConfiguration.BaseLanguage = MessageConfiguration_BaseLanguage;
            this.MethodPayload.SupplyingTenant.Identity.TenantITL = SupplyingTenant_TenantITL;
            this.MethodPayload.SupplyingTenant.Identity.TenantName = SupplyingTenant_TenantName;
            this.MethodPayload.ProcuringTenant.Identity.TenantITL = ProcuringTenant_TenantITL;
            this.MethodPayload.ProcuringTenant.Identity.IsExternalTenant = ProcuringTenant_IsExternalTenant;
            this.MethodPayload.ProcuringTenant.Identity.TenantName = ProcuringTenant_TenantName;
        }

        public T GetMessageTemplate()
        {
            return MethodPayload.MessageTemplate;
        }

        public string ToPayload()
        {
            var payload = SerializationUtils.SerializeObject(this);

            return HttpContext.Current.Server.HtmlEncode(payload);
        }

        #endregion

        #region Static methods
        
        public static StandardMessage<T> FromPayload(string Payload)
        {
            var decodedPayload = System.Web.HttpUtility.HtmlDecode(Payload);

            //A literal ampersand inside an XML tag is not allowed by the XML standard, and such a document will fail to parse by any XML parser.
            decodedPayload = decodedPayload.Replace("&", "&amp;");
            return SerializationUtils.ParseFromPayload<StandardMessage<T>>(decodedPayload);
        }

        #endregion
    }

    #region SubClasses

    public class MethodPayload<T>
    {
        public MethodPayload()
        {
            SupplyingTenant = new Tenant();
            ProcuringTenant = new Tenant();
            MessageConfiguration = new MessageConfiguration();
        }

        [XmlElement(ElementName = "")]
        public T MessageTemplate { get; set; }

        [XmlElement(ElementName = "MessageConfiguration")]
        public MessageConfiguration MessageConfiguration { get; set; }

        [XmlElement(ElementName = "SupplyingTenant")]
        public Tenant SupplyingTenant { get; set; }
        
        [XmlElement(ElementName = "ProcuringTenant")]
        public Tenant ProcuringTenant { get; set; }
    }

    public class MessageConfiguration
    {
        [XmlAttribute(AttributeName = "BaseLanguage")]
        public String BaseLanguage { get; set; }
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
        
        [XmlAttribute(AttributeName="IsExternalTenant")]
        public Boolean IsExternalTenant { get; set; }

        [XmlElement(ElementName = "TenantName")]
        public String TenantName { get; set; }
    }
    
    #endregion
}
