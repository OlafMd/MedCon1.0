using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace BOp.Providers.DOC.Response
{

    [DataContract]
    public class DocumentInfo : IDocument
    {
        [DataMember(Name = "id")]
        public Guid ID { get; set; }
        [DataMember(Name = "fileName")]
        public String FileName { get; set; }
        [DataMember(Name = "height")]
        public int Height { get; set; }
        [DataMember(Name = "width")]
        public int Width { get; set; }
        [DataMember(Name = "contentLength")]
        public long ContentLength { get; set; }
        [DataMember(Name = "mimeType")]
        public String MimeType { get; set; }

        [DataMember(Name = "isPublic")]
        public Boolean IsPublic { get; set; }
        [DataMember(Name = "isDocumentProxy")]
        public Boolean IsDocumentProxy { get; set; }
        [DataMember(Name = "shareExpirationDate")]
        public String ShareExpirationDate { get; set; }
    }

    public interface IDocument
    {
        Guid ID { get; set; }
        String FileName { get; set; }
        int Height { get; set; }
        int Width { get; set; }
         long ContentLength { get; set; }
         String MimeType { get; set; }
    }
}


