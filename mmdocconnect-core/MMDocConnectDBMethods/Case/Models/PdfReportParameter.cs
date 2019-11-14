using MigraDoc.DocumentObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Case.Models
{
    public class PdfReportParameter
    {
        public byte[] DocumentBytes { get; set; }
        public PdfReportDoctor Doctor { get; set; }
        public string FileName { get; set; }
        public double Amount { get; set; }
        public string Period { get; set; }
    }

    public class PdfReportDoctor
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
