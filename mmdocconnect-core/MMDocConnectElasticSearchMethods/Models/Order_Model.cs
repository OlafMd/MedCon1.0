using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectElasticSearchMethods.Models
{
    public class Order_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public DateTime treatment_date { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string drug_id { get; set; }
        public string diagnose_id { get; set; }
        public string patient_name { get; set; }
        public DateTime patient_birthdate { get; set; }
        public string patient_birthdate_string { get; set; }
        public string diagnose { get; set; }
        public string drug { get; set; }
        public string group_name { get; set; }
        public string localization { get; set; }
        public string treatment_doctor_name { get; set; }
        public string treatment_doctor_practice_name { get; set; }
        public string status_drug_order { get; set; }
        public string practice_id { get; set; }
        public DateTime order_modification_timestamp { get; set; }
        public string order_modification_timestamp_string { get; set; }
        public DateTime delivery_time_from { get; set; }
        public DateTime delivery_time_to { get; set; }
        public string delivery_time_string { get; set; }
        public string delivery_date_month_year { get; set; }
        public string delivery_date_month { get; set; }
        public bool is_orders_drug { get; set; }
        public string hip { get; set; }
        public string patient_insurance_number { get; set; }
        public string lanr { get; set; }
        public string bsnr { get; set; }
        public string isOverdue { get; set; }
        public string doctor_id { get; set; }
        public string patient_id { get; set; }

        public string pharmacy_id { get; set; }
        public string pharmacy_name { get; set; }
    }

    public class Order_Model_Extended : Order_Model
    {
        public string delivery_date_string { get; set; }

        public string position_comment { get; set; }

        public string header_comment { get; set; }

        public bool patient_fee_waived { get; set; }

        public bool label_only { get; set; }

        public bool invoice_to_practice { get; set; }

        public bool is_treatment_submitted { get; set; }

        public string create_date_string { get; set; }

        public string submission_date_string { get; set; }

        public void PopulateBase(Order_Model order) 
        {
            var properties = order.GetType().GetProperties();
            foreach (var prop in properties) 
            {
                prop.SetValue(this, prop.GetValue(order));
            }
        }
    }


    public class Return_Order_Model
    {
        public IEnumerable<Order_Stats> order_stats { get; set; }
        public IEnumerable<Order_Model> orders { get; set; }
        public Return_Order_Model()
        {
            orders = new List<Order_Model>();
            order_stats = new List<Order_Stats>();
        }
    }

    public class Order_Stats
    {
        public string drug_name { get; set; }
        public int order_count { get; set; }
        public double percentage { get; set; }
    }
}