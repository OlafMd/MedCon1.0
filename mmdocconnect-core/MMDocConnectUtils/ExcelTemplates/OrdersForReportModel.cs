using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocApp.ExcelTemplates
{
    public class OrdersForReportModel
    {
        public Guid orderID { get; set; }
        public string HIP { get; set; }
        public string PatientInsuranceNumber { get; set; }
        public string PatientStatusNumber { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public DateTime PatientBirthDate { get; set; }
        public int OrderNumber { get; set; }
        public int CaseNumber { get; set; }
        public string OrderType { get; set; }
        public string DrugName { get; set; }
        public string Pzn { get; set; }
        public DateTime TreatmentDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime DeliveryTimeFrom { get; set; }
        public DateTime DeliveryTimeTo { get; set; }

        public string ChargesFee { get; set; }
        public string PracticeInvoice { get; set; }
        public string OnlyLabel { get; set; }
        public string PracticeName { get; set; }
        public string TreatmentDoctor { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string PatientSalutation { get; set; }
        public string OrderComment { get; set; }
        public string HeaderComment { get; set; }
        public string PharmacyName { get; set; }

        public DateTime DateOfSubmission { get; set; }
    }
}
