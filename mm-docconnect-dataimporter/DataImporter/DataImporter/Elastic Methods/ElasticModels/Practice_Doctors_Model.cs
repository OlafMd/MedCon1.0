using DataImporter.Elastic_test.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Models
{
    public class Practice_Doctors_Model : IElasticMapper
    {
        public string id { get; set; }
        public string name { get; set; }
        public string name_untouched { get; set; }
        public string autocomplete_name { get; set; }
        public string aditional_info { get; set; }
        public string salutation { get; set; }
        public string type { get; set; }
        public string bsnr_lanr { get; set; }
        public string address { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string bank { get; set; }
        public string bank_untouched { get; set; }
        public string bank_id { get; set; }
        public bool bank_info_inherited { get; set; }
        public string bic { get; set; }
        public string iban { get; set; }
        public object contract { get; set; }
        public string account_status { get; set; }
        public string tenantid { get; set; }
        public string group_name { get; set; }
        public string order_name { get; set; }
        public string practice_for_doctor_id { get; set; }
        public string practice_name_for_doctor { get; set; }
        public string doctor_count_or_practice_name { get; set; }
        public string role { get; set; }
    }

    public class HIP_Model : IElasticMapper
    {
        public string id { get; set; }
        public string name { get; set; }
        public string ik_number { get; set; }
    }

    public class Diagnose_Model : IElasticMapper
    {
        public string id { get; set; }
        public string name { get; set; }
        public string icd10 { get; set; }
    }
    public class Doctor_Contracts
    {
        public Guid DocID { get; set; }
        public int NumberOfContracts { get; set; }

    }
    public class Patient_Model : IElasticMapper
    {
        public string id { get; set; }
        public string name { get; set; }
        public string name_with_birthdate { get; set; }
        public DateTime birthday { get; set; }
        public string birthday_string { get; set; }
        public string sex { get; set; }
        public string health_insurance_provider { get; set; }
        public string insurance_id { get; set; }
        public string insurance_status { get; set; }
        public string practice_id { get; set; }
        public bool has_participation_consent { get; set; }
        public DateTime participation_consent_from { get; set; }
        public DateTime participation_consent_to { get; set; }
        public string last_first_op_doctor_name { get; set; }
        public string op_doctor_lanr { get; set; }
        public string last_first_ac_doctor_name { get; set; }
        public string ac_doctor_lanr { get; set; }
        public string op_practice_id { get; set; }
        public string practice { get; set; }
        public string practice_bsnr { get; set; }
        public string op_doctor_id { get; set; }
        public string ac_doctor_id { get; set; }
        public string ac_practice_id { get; set; }
        public string ac_practice { get; set; }
        public string ac_practice_bsnr { get; set; }
        public bool has_rejected_oct { get; set; }
        public string originating_patient_id { get; set; }
        public string originating_practice_name { get; set; }
        public string originating_practice_id { get; set; }
        public string external_id { get; set; }
    }


    public class Case_Model : IElasticMapper
    {
        public string id { get; set; }
        public DateTime treatment_date { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string patient_name { get; set; }
        public DateTime patient_birthdate { get; set; }
        public string patient_birthdate_string { get; set; }
        public string diagnose { get; set; }
        public string drug { get; set; }
        public string localization { get; set; }
        public string treatment_doctor_name { get; set; }
        public string aftercare_name { get; set; }
        public string status_drug_order { get; set; }
        public string status_treatment { get; set; }
        public string group_name { get; set; }
        public bool is_aftercare_doctor { get; set; }
        public string aftercare_doctors_practice_name { get; set; }
        public string practice_id { get; set; }
        public DateTime order_modification_timestamp { get; set; }
        public string order_modification_timestamp_string { get; set; }
        public DateTime delivery_time_from { get; set; }
        public DateTime delivery_time_to { get; set; }
        public string delivery_time_string { get; set; }
        public bool is_orders_drug { get; set; }
        public string previous_status_drug_order { get; set; }
        public bool is_submit_button_visible { get; set; }
        public bool is_edit_button_visible { get; set; }
        public string treatment_doctor_lanr { get; set; }
        public string aftercare_doctor_lanr { get; set; }
        public string patient_hip { get; set; }
        public string patient_insurance_number { get; set; }
        public string patient_id { get; set; }
        public string aftercare_practice_bsnr { get; set; }
        public string treatment_doctor_id { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }
        public string aftercare_doctors_practice_id { get; set; }
    }



    public class Order_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public string drug_id { get; set; }
        public string diagnose_id { get; set; }
        public DateTime treatment_date { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string doctor_id { get; set; }
        public string patient_id { get; set; }
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
        public string pharmacy_id { get; set; }
        public string pharmacy_name { get; set; }

        public Order_Model()
        {
            this.doctor_id = "";
            this.diagnose_id = "";
        }
    }

    public class Aftercare_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public DateTime treatment_date { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string patient_name { get; set; }
        public DateTime patient_birthdate { get; set; }
        public string patient_birthdate_string { get; set; }
        public string diagnose { get; set; }
        public string localization { get; set; }
        public string treatment_doctor_name { get; set; }
        public string treatment_doctor_practice_name { get; set; }
        public string treatment_doctors_practice_id { get; set; }
        public string aftercare_doctor_name { get; set; }
        public string status { get; set; }
        public string group_name { get; set; }
        public string practice_id { get; set; }
        public bool is_submit_visible { get; set; }
        public string aftercare_doctor_account_id { get; set; }
        public string patient_id { get; set; }
        public string hip { get; set; }
        public string patient_insurance_number { get; set; }
        public string op_lanr { get; set; }
        public string bsnr { get; set; }
        public string ac_lanr { get; set; }
        public string aftercare_date_string { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string treatment_doctor_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }
        public string hip_ik_number { get; set; }
    }
    public class Settlement_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public string group_name { get; set; }
        public DateTime surgery_date { get; set; }
        public string surgery_date_string { get; set; }
        public string surgery_date_string_month { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string patient_full_name { get; set; }
        public string birthday { get; set; }
        public string case_type { get; set; }
        public string diagnose { get; set; }
        public string drug { get; set; }
        public string localization { get; set; }
        public string doctor { get; set; }
        public string acpractice { get; set; }
        public string status { get; set; }
        public bool is_edit_button_visible { get; set; }
        public bool is_submit_button_visible { get; set; }
        public bool is_cancel_button_visible { get; set; }
        public string practice_id { get; set; }
        public string if_aftercare_treatment_date { get; set; }
        public string previous_status { get; set; }
        public string patient_id { get; set; }
        public string treatment_doctor_id { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }
        public string hip { get; set; }
        public string patient_insurance_number { get; set; }
        public string lanr { get; set; }
        public string bsnr { get; set; }
        public bool is_report_downloaded { get; set; }
        public string ac_status { get; set; }
        public string hip_ik_number { get; set; }
        public DateTime status_date { get; set; }
    }

    public class Practice_Parameter
    {
        public Guid practice_id { get; set; }
        public string bsnr { get; set; }
        public string practice_bank_account_id { get; set; }
        public bool ascending { get; set; }
        public string sortfield { get; set; }
        public string role { get; set; }
        public string search_criteria { get; set; }
        public bool? account_status { get; set; }
        public string type { get; set; }
    }


    public class Submitted_Case_Model : IElasticMapper
    {
        public string id { get; set; }
        public string case_id { get; set; }
        public string drug_id { get; set; }
        public string diagnose_id { get; set; }
        public DateTime treatment_date { get; set; }
        public DateTime if_aftercare_treatment_date { get; set; }
        public string treatment_date_string { get; set; }
        public string treatment_date_day_month { get; set; }
        public string treatment_date_month_year { get; set; }
        public string patient_name { get; set; }
        public DateTime patient_birthdate { get; set; }
        public string patient_birthdate_string { get; set; }
        public string type { get; set; }
        public string diagnose { get; set; }
        public string drug { get; set; }
        public string localization { get; set; }
        public string status { get; set; }
        public string management_pauschale { get; set; }
        public string group_name { get; set; }
        public DateTime status_date { get; set; }
        public string status_date_string { get; set; }
        public string doctor_name { get; set; }
        public string practice_id { get; set; }
        public string practice_name { get; set; }
        public string hip_name { get; set; }
        public string doctor_lanr { get; set; }
        public string practice_bsnr { get; set; }
        public string patient_insurance_number { get; set; }
        public string doctor_id { get; set; }
        public string patient_id { get; set; }
    }
    public class Archive_Model : IElasticMapper
    {
        public string id { get; set; }
        public string documentId { get; set; }
        public DateTime filedate { get; set; }
        public DateTime creationtimestamp { get; set; }
        public string datestring { get; set; }
        public string filetype { get; set; }
        public string recipient { get; set; }
        public string description { get; set; }
        public string group_name { get; set; }
    }
    public class Receipt_Model : IElasticMapper
    {
        public string id { get; set; }
        public string documentID { get; set; }
        public string doctorID { get; set; }
        public DateTime filedate { get; set; }
        public string filedateString { get; set; }
        public string period { get; set; }
        public DateTime periodDate { get; set; }
        public string amount { get; set; }
        public int amountNo { get; set; }
        public string group_name { get; set; }
        public bool isViewed { get; set; }
    }

    public class PatientDetailViewModel : IElasticMapper
    {
        public string id { get; set; }
        public string practice_id { get; set; }
        public string patient_id { get; set; }
        public DateTime date { get; set; }
        public string date_string { get; set; }
        public string detail_type { get; set; }
        public string diagnose_or_medication { get; set; }
        public string localisation { get; set; }
        public string doctor { get; set; }
        public string status { get; set; }
        public string group_name { get; set; }
        public string drug { get; set; }
        public string order_status { get; set; }
        public string order_id { get; set; }
        public string case_id { get; set; }
        public string previous_order_status { get; set; }
        public bool if_settlement_is_report_downloaded { get; set; }

        /**********************************************************/
        public string treatment_doctor_id { get; set; }
        public string aftercare_doctor_practice_id { get; set; }
        public string diagnose_id { get; set; }
        public string drug_id { get; set; }

        public string pharmacy_id { get; set; }
        public string pharmacy_name { get; set; }
        public string hip_ik { get; set; }

        public PatientDetailViewModel()
        {
            this.localisation = "-";
            this.doctor = "-";
        }

    }

    public class Oct_Model : IElasticMapper
    {
        public string id { get; set; }

        public DateTime treatment_date { get; set; }

        public DateTime oct_date { get; set; }

        public DateTime treatment_year_date { get; set; }

        public string patient_name { get; set; }

        public DateTime patient_birthdate { get; set; }

        public string diagnose { get; set; }

        public Guid diagnose_id { get; set; }

        public string localization { get; set; }

        public string treatment_doctor_name { get; set; }

        public Guid treatment_doctor_id { get; set; }

        public string treatment_doctor_practice_name { get; set; }

        public Guid treatment_doctor_practice_id { get; set; }

        public string oct_doctor_name { get; set; }

        public Guid oct_doctor_id { get; set; }

        public int treatment_year_octs { get; set; }

        public string status { get; set; }

        public string group_name { get; set; }

        public Guid case_id { get; set; }

        public Guid practice_id { get; set; }

        public Guid patient_id { get; set; }

        public string treatment_doctor_lanr { get; set; }

        public string oct_doctor_lanr { get; set; }

        public string treatment_doctor_practice_bsnr { get; set; }

        public string patient_insurance_number { get; set; }

        public string patient_hip { get; set; }

        public string hip_ik { get; set; }
    }
}
