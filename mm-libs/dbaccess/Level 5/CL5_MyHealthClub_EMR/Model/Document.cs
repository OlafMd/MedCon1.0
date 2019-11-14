using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace pocdoc.Models.ERMClasses
{
    public class Document
    {
        [XmlAttribute(AttributeName = "PatientDocumentITL")]
        public String ITL { get; set; }


        [XmlElement(ElementName = "FileType")]
        public String FileType { get; set; }

        [XmlElement(ElementName = "FileExtension")]
        public String FileExtension { get; set; }

        [XmlElement(ElementName = "UploadFileName")]
        public String UploadFileName { get; set; }

        [XmlElement(ElementName = "Comment")]
        public String Comment { get; set; }

        [XmlElement(ElementName = "DateOfDocument")]
        public String DateOfDocument { get; set; }
    }
}