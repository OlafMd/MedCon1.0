using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppModels
{
    public class Case
    {
        public Guid case_id { get; set; }
        public Guid patient_id { get; set; }
        public Guid practice_id { get; set; }
        public string treatment_date { get; set; }
        public Guid drug_id { get; set; }
        public bool is_orders_drug { get; set; }
        public bool is_patient_fee_waived { get; set; }
        public bool is_send_invoice_to_practice { get; set; }
        public bool is_label_only { get; set; }
        public Guid diagnose_id { get; set; }
        public bool is_left_eye { get; set; }
        public bool is_confirmed { get; set; }
        public Guid treatment_doctor_id { get; set; }
        public Guid aftercare_doctor_practice_id { get; set; }
        public string patient_display_name { get; set; }
        public bool is_treatment_form_open { get; set; }
        public string aftercare_display_name { get; set; }
        public string treatment_doctor_display_name { get; set; }
        public bool can_cancel_order { get; set; }
        public string min_delivery_date { get; set; }
        public string aftercare_performed_date { get; set; }
        public Guid planned_action_id { get; set; }
        public string order_comment { get; set; }
        public bool is_resubmit { get; set; }
        public Guid? oct_doctor_id { get; set; }
        public bool is_documentation_only { get; set; }
        public string oct_doctor_display_name { get; set; }
        public bool withdraw_oct { get; set; }
        public string submit_oct_until_date { get; set; }
        public bool is_oct_doctor_visible { get; set; }

        public bool is_quick_order { get; set; }
        public string order_status { get; set; }
        public Guid submited_by_doctor_id { get; set; }

        public bool submit_created_case { get; set; }
    }

    public class CancelCaseParameter
    {
        public bool cancel_treatment { get; set; }
        public bool cancel_drug_order { get; set; }
        public Guid case_id { get; set; }
    }

    public class ConsentValidationResponse
    {
        public string message { get; set; }
        public string name { get; set; }
        public string date { get; set; }
        public string first_oct_date { get; set; }
        public string consent_timespan { get; set; }
        public string max_count { get; set; }
        public double treatment_year_length { get; set; }

        public string op_doctor_name { get; set; }
        public string op_doctor_email { get; set; }
        public string op_doctor_phone { get; set; }
        public string hip_name { get; set; }
        public bool is_warning_message { get; set; }
        public string insurance_number { get; set; }

        public ConsentValidationResponse()
        {
            this.message = "";
        }
    }
    public class CaseParameter
    {
        public Guid case_id { get; set; }
        public Guid authorizing_doctor_id { get; set; }
        public Guid planned_action_id { get; set; }
    }
    public class CancelCaseParameterOnSettlementPage : CaseParameter
    {
        public String reasonForCancelation { get; set; }
        public string caseType { get; set; }

    }
    public class SubmitCaseParameter : CaseParameter
    {
        public string date_of_performed_action { get; set; }
        public DateTime datetime_of_performed_action { get; set; }
        public bool is_treatment { get; set; }
    }

    public class MulitiSubmitValidation
    {
        public int number_of_all_cases { get; set; }
        public int number_of_invalid_cases { get; set; }
        public List<Guid> valid_case_ids { get; set; }
    }

    public class OCTValidation
    {
        public bool can_submit { get; set; }
        public String message { get; set; }
        public bool oct_exist_for_case { get; set; }
    }
}
