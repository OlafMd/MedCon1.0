using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace MMDocConnectDBMethods.Order.Complex.Model
{
    public class SubmitOrderPdfReportContent
    {
        [XmlElement("Pharmacy")]
        public string Pharmacy { get; set; }

        [XmlElement("Practice")]
        public string Practice { get; set; }

        [XmlElement("OrderOverview")]
        public string OrderOverview { get; set; }

        [XmlElement("OrderNumber")]
        public string OrderNumber { get; set; }

        [XmlElement("DeliveryDate")]
        public string DeliveryDate { get; set; }

        [XmlElement("DeliveryTime")]
        public string DeliveryTime { get; set; }

        [XmlElement("Medication")]
        public string Medication { get; set; }

        [XmlElement("Amount")]
        public string Amount { get; set; }

        [XmlElement("Signature")]
        public string Signature { get; set; }

        [XmlElement("Patient")]
        public string Patient { get; set; }

        [XmlElement("BirthDate")]
        public string BirthDate { get; set; }

        [XmlElement("HealthInsurance")]
        public string HealthInsurance { get; set; }

        [XmlElement("InsuranceStatus")]
        public string InsuranceStatus { get; set; }

        [XmlElement("FeeWaived")]
        public string FeeWaived { get; set; }

        [XmlElement("TotalQuantity")]
        public string TotalQuantity { get; set; }
     
        [XmlElement("PositionComment")]
        public string PositionComment { get; set; }

        [XmlElement("HeaderComment")]
        public string HeaderComment { get; set; }
        

            

        public SubmitOrderPdfReportContent(string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(SubmitOrderPdfReportContent));
            var reader = new StreamReader(path);
            var labels = (SubmitOrderPdfReportContent)xmlSerializer.Deserialize(reader);

            foreach (var prop in this.GetType().GetProperties())
            {
                prop.SetValue(this, Regex.Unescape(prop.GetValue(labels).ToString()));
            }
        }

        public SubmitOrderPdfReportContent() { }
    }
}
