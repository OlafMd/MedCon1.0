using System.Runtime.Serialization;

namespace CL3_ABDA.Utils
{

    public class ArticleSearchCondition
    {
        [DataMember]
        public string ProductNameStartWith { get; set; }
        [DataMember]
        public string ActiveComponentStartWith { get; set; }
        [DataMember]
        public string PZNOrName { get; set; }
        [DataMember]
        public string DosageForm { get; set; }
        [DataMember]
        public string Unit { get; set; }
        [DataMember]
        public string ProducerName { get; set; }
        [DataMember]
        public string ActiveComponent { get; set; }
        [DataMember]
        public bool? IsAvailableForOrdering { get; set; }
        [DataMember]
        public bool? IsDefaultStock { get; set; } 
    }
  
}
