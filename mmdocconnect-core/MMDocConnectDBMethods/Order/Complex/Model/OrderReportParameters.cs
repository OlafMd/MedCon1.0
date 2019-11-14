using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Order.Complex.Model
{
    public class OrderReportParameters
    {
        public OrderParticipantInformation Pharmacy { get; set; }

        public OrderParticipantInformation Practice { get; set; }

        public ReportOrderInformation Orders { get; set; }

        public OrderReportParameters()
        {
            Pharmacy = new OrderParticipantInformation();
            Practice = new OrderParticipantInformation();
            Orders = new ReportOrderInformation();
        }
    }

    public class ReportOrderInformation
    {
        public string OrderNumber { get; set; }

        public DateTime DeliveryDate { get; set; }

        public DateTime DeliveryTimeFrom { get; set; }

        public DateTime DeliveryTimeTo { get; set; }

        public DateTime CreationDate { get; set; }

        public string HeaderComment { get; set; }
        
        public List<ReportOrderItem> OrderedDrugs { get; set; }

        public ReportOrderInformation()
        {
            OrderedDrugs = new List<ReportOrderItem>();
        }
    }

    public class ReportOrderItem
    {
        public string Name { get; set; }

        public string PositionComment { get; set; }

        public ReportOrderPatientInformation Patient { get; set; }

        public ReportOrderItem()
        {
            Patient = new ReportOrderPatientInformation();
        }
    }

    public class ReportOrderPatientInformation
    {
        public Guid PatientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Hip { get; set; }

        public string InsuranceStatus { get; set; }

        public bool FeeWaived { get; set; }
    }


    public class OrderParticipantInformation
    {
        public string Name { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Zip { get; set; }

        public string City { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
