

namespace DLCore_DBCommons.XMLInDBModels
{
    public class ProductAdditionalInfoXML
    {
        public bool IsPharmacyOnlyDistribution { get; set; }

        public string ToPayload()
        {
            return SerializationUtils.SerializeObject<ProductAdditionalInfoXML>(this);
        }

        public static ProductAdditionalInfoXML FromPayload(string payload)
        {
            return SerializationUtils.ParseFromPayload<ProductAdditionalInfoXML>(payload);
        }
    }
}
