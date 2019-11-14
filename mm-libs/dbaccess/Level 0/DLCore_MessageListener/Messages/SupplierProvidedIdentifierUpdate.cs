using System;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using BOp.Message;

namespace DLCore_MessageListener.Messages
{
    [DataContract(Name = "SupplierProvidedIdentifierUpdate")]
    public class SupplierProvidedIdentifierUpdate
    {
        public const string MESSAGE_TYPE = "realm.apo-demand.supplier-provided-identifier.update";
        public const string MESSAGE_VERSION = "1.0";
        public const string MESSAGE_DEFAULTLANGUAGE = "DE";

        public SupplierProvidedIdentifierUpdate()
        {
            Identifier = String.Empty;
        }

        #region Properties

        [XmlElement(ElementName = "Identifier")]
        public string Identifier { get; set; }

        #endregion

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<SupplierProvidedIdentifierUpdate>(this);
        }

        public static SupplierProvidedIdentifierUpdate FromPayload(string payload)
        {
            var decodedPayload = System.Web.HttpUtility.UrlDecode(payload);

            return SerializationUtils.ParseFromPayload<SupplierProvidedIdentifierUpdate>(decodedPayload);
        }

    }
}
