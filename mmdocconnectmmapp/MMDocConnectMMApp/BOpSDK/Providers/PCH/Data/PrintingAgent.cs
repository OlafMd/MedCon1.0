using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.PCH
{
    [DataContract]
    public class PrintingAgent
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "computerName")]
        public string ComputerName { get; set; }
        [DataMember(Name = "ipAddress")]
        public string IpAddress { get; set; }
        [DataMember(Name = "macAddress")]
        public string MacAddress { get; set; }
        [DataMember(Name = "operatingSystemInformation")]
        public string OperatingSystemInformation { get; set; }
        [DataMember(Name = "enabled")]
        public bool Enabled { get; set; }
        [DataMember(Name = "version")]
        public int Version { get; set; }
        [DataMember(Name = "logicalPrinters")]
        public List<LogicalPrinter> LogicalPrinters { get; set; }
    }
    [DataContract]
    public class LogicalPrinter
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "physicalPrinters")]
        public List<PhysicalPrinter> PhysicalPrinters { get; set; }
    }

    [DataContract]
    public class PhysicalPrinter
    {
        [DataMember(Name = "id")]
        public string ID { get; set; }
        [DataMember(Name = "type")]
        public EPrinterType Type { get; set; }
        [DataMember(Name = "vendor")]
        public string vendor { get; set; }
        [DataMember(Name = "model")]
        public string Model { get; set; }
    }
}
