using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Elastic_Methods.Doctor.Manipulation
{
    public static class CleanupCase
    {
        public static void SaveNewCase(DbConnection Connection, DbTransaction Transaction, Guid treatment_doctor_id, SessionSecurityTicket securityTicket, Guid patient_id, Guid diagnose_id, Guid drug_id, Guid case_id, string localization, Guid aftercare_doctor_practice_id, DateTime treatment_date, Guid practice_id)
        {
            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_PA_GPDfPID_1729() { PatientID = patient_id }, securityTicket).Result;
            var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = diagnose_id }, securityTicket).Result;
            var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = drug_id }, securityTicket).Result;

            #region IMPORT TO ELASTIC
            Case_Model case_model_elastic = new Case_Model();

            case_model_elastic.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
            case_model_elastic.drug = drug_details != null ? drug_details.drug_name : "";
            case_model_elastic.id = case_id.ToString();
            case_model_elastic.localization = diagnose_id == Guid.Empty ? "-" : localization;
            case_model_elastic.previous_status_drug_order = "";
            case_model_elastic.status_treatment = "OP1";

            case_model_elastic.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
            case_model_elastic.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
            case_model_elastic.patient_birthdate = patient_details.birthday;

            var is_aftercare_doctor = true;
            string aftercare_name = "";

            var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = aftercare_doctor_practice_id }, securityTicket).Result.SingleOrDefault();

            if (aftercare_doctor_details != null)
            {
                case_model_elastic.aftercare_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;
                case_model_elastic.aftercare_doctors_practice_name = aftercare_doctor_details.practice;

                aftercare_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.first_name + " " + aftercare_doctor_details.last_name;
            }
            else
            {
                is_aftercare_doctor = false;
                var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = aftercare_doctor_practice_id }, securityTicket).Result.FirstOrDefault();
                if (aftercare_practice_details != null)
                {
                    case_model_elastic.aftercare_name = aftercare_practice_details.practice_name;
                    aftercare_name = aftercare_practice_details.practice_name;
                }
                else
                {
                    case_model_elastic.aftercare_name = "-";
                }
            }

            case_model_elastic.is_aftercare_doctor = is_aftercare_doctor;
            case_model_elastic.treatment_date = treatment_date;
            case_model_elastic.treatment_date_day_month = treatment_date.ToString("dd.MM.");
            case_model_elastic.treatment_date_month_year = treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
            case_model_elastic.treatment_doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.first_name + " " + treatment_doctor_details.last_name : "-";
            case_model_elastic.practice_id = practice_id.ToString();
            case_model_elastic.delivery_time_string = case_model_elastic.delivery_time_from.ToString("HH:mm") + " - " + case_model_elastic.delivery_time_to.ToString("HH:mm");

            List<Case_Model> cases = new List<Case_Model>();
            cases.Add(case_model_elastic);

            Add_New_Case.Import_Case_Data_to_ElasticDB(cases, securityTicket.TenantID.ToString());
            #endregion IMPORT TO ELASTIC
        }

        public static void SubmitCase(DbConnection Connection,
            DbTransaction Transaction, SessionSecurityTicket securityTicket,
            bool is_treatment, Guid treatment_doctor_id, Guid patient_id,
            Guid diagnose_id, Guid drug_id, Guid case_id, string localization,
            Guid aftercare_doctor_id, DateTime treatment_date, Guid practice_id, Guid aftercare_practice_id, DateTime status_date)
        {
            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_PA_GPDfPID_1729() { PatientID = patient_id }, securityTicket).Result;
            var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = diagnose_id }, securityTicket).Result;
            var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = drug_id }, securityTicket).Result;
            var treatment_practice_default_settings = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = practice_id }, securityTicket).Result;
            var aftercare_practice_default_settings = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = aftercare_practice_id }, securityTicket).Result;
            var treatment_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = practice_id }, securityTicket).Result.FirstOrDefault();
            var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = aftercare_practice_id }, securityTicket).Result.FirstOrDefault();
            var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = aftercare_doctor_id }, securityTicket).Result.SingleOrDefault();

            #region IMPORT TO ELASTIC
            var submitted_case_id = Guid.Empty;
            if (is_treatment)
            {
                submitted_case_id = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id;
                Add_New_Case.Delete_Case_After_Submitting(securityTicket.TenantID.ToString(), "case", case_id.ToString());
            }
            else
            {
                submitted_case_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id;
                Add_New_Aftercare.Delete_Aftercare_Submitting(securityTicket.TenantID.ToString(), "aftercare", submitted_case_id.ToString());
            }

            #region IMPORT SUBMITTED CASE TO ELASTIC
            Submitted_Case_Model submitted_case_model_elastic = new Submitted_Case_Model();
            submitted_case_model_elastic.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
            submitted_case_model_elastic.id = submitted_case_id.ToString();
            submitted_case_model_elastic.case_id = case_id.ToString();
            submitted_case_model_elastic.localization = localization;
            submitted_case_model_elastic.management_pauschale = is_treatment ? treatment_practice_default_settings.WaiveServiceFee ? "waived" : "deducted" : aftercare_practice_default_settings.WaiveServiceFee ? "waived" : "deducted";
            submitted_case_model_elastic.patient_birthdate = patient_details.birthday;
            submitted_case_model_elastic.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
            submitted_case_model_elastic.patient_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
            submitted_case_model_elastic.status = "FS1";
            submitted_case_model_elastic.status_date = status_date;
            submitted_case_model_elastic.status_date_string = status_date.ToString("dd.MM.yyyy");
            submitted_case_model_elastic.treatment_date = treatment_date;
            submitted_case_model_elastic.treatment_date_day_month = treatment_date.ToString("dd.MM.");
            submitted_case_model_elastic.treatment_date_month_year = treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
            submitted_case_model_elastic.drug = drug_details != null ? drug_details.drug_name : "";
            submitted_case_model_elastic.type = is_treatment ? "op" : "ac";
            submitted_case_model_elastic.treatment_date_string = treatment_date.ToString("dd.MM.yyyy");
            submitted_case_model_elastic.patient_insurance_number = patient_details.insurance_id;

            if (is_treatment)
            {
                submitted_case_model_elastic.doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name : "-";
                submitted_case_model_elastic.practice_name = treatment_doctor_details.practice;
                submitted_case_model_elastic.doctor_lanr = treatment_doctor_details.lanr;
                submitted_case_model_elastic.practice_bsnr = treatment_practice_details.practice_BSNR;
            }
            else
            {
                submitted_case_model_elastic.doctor_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;
                submitted_case_model_elastic.practice_name = aftercare_doctor_details.practice;
                submitted_case_model_elastic.doctor_lanr = aftercare_doctor_details.lanr;
                submitted_case_model_elastic.practice_bsnr = aftercare_practice_details.practice_BSNR;
            }

            submitted_case_model_elastic.hip_name = patient_details != null ? patient_details.health_insurance_provider : "-";

            List<Submitted_Case_Model> cases_to_submit = new List<Submitted_Case_Model>();
            cases_to_submit.Add(submitted_case_model_elastic);

            Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(cases_to_submit, securityTicket.TenantID.ToString());
            #endregion

            if (is_treatment)
            {
                submitted_case_id = cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id;

                #region IMPORT AFTERCARE TO ELASTIC
                Aftercare_Model aftercare = new Aftercare_Model();
                aftercare.aftercare_doctor_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.first_name + " " + aftercare_doctor_details.last_name;
                aftercare.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
                aftercare.id = submitted_case_id.ToString();
                aftercare.localization = localization;
                aftercare.patient_birthdate = patient_details.birthday;
                aftercare.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
                aftercare.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
                aftercare.practice_id = cls_Get_PracticeID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GPIDfDID_1353() { DoctorID = aftercare_doctor_id }, securityTicket).Result.SingleOrDefault().HEC_MedicalPractiseID.ToString();
                aftercare.status = "AC1";
                aftercare.treatment_date = treatment_date;
                aftercare.treatment_date_day_month = treatment_date.ToString("dd.MM.");
                aftercare.treatment_date_month_year = treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                aftercare.treatment_doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.first_name + " " + treatment_doctor_details.last_name : "-";
                aftercare.treatment_doctor_practice_name = treatment_doctor_details.practice;
                aftercare.case_id = case_id.ToString();
                var aftercare_doctor_account_id = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = aftercare_doctor_id }, securityTicket).Result.accountID;
                aftercare.aftercare_doctor_account_id = aftercare_doctor_account_id.ToString();

                List<Aftercare_Model> aftercares = new List<Aftercare_Model>() { aftercare };
                Add_New_Aftercare.Import_Aftercare_Data_to_ElasticDB(aftercares, securityTicket.TenantID.ToString());
                #endregion
            }
            #endregion IMPORT TO ELASTIC
        }

        public static void ChangeCaseStatus(DbConnection Connection,
            DbTransaction Transaction, SessionSecurityTicket securityTicket,
            bool is_treatment, Guid treatment_doctor_id, Guid patient_id,
            Guid diagnose_id, Guid drug_id, Guid case_id, string localization,
            Guid aftercare_doctor_id, DateTime treatment_date, Guid practice_id, Guid aftercare_practice_id, DateTime status_date, int new_status)
        {
            var submitted_case_id = is_treatment ? 
                cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946() { CaseID = case_id }, securityTicket).Result.planned_action_id : 
                cls_Get_Aftercare_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GAPAfCID_0959() { CaseID = case_id }, securityTicket).Result.planned_action_id;


            var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_PA_GPDfPID_1729() { PatientID = patient_id }, securityTicket).Result;
            var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = diagnose_id }, securityTicket).Result;
            var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = drug_id }, securityTicket).Result;
            var treatment_practice_default_settings = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = practice_id }, securityTicket).Result;
            var aftercare_practice_default_settings = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = aftercare_practice_id }, securityTicket).Result;
            var treatment_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = practice_id }, securityTicket).Result.FirstOrDefault();
            var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = aftercare_practice_id }, securityTicket).Result.FirstOrDefault();
            var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = aftercare_doctor_id }, securityTicket).Result.SingleOrDefault();

            Submitted_Case_Model submitted_case_model_elastic = new Submitted_Case_Model();
            submitted_case_model_elastic.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
            submitted_case_model_elastic.id = submitted_case_id.ToString();
            submitted_case_model_elastic.case_id = case_id.ToString();
            submitted_case_model_elastic.localization = localization;
            submitted_case_model_elastic.management_pauschale = is_treatment ? treatment_practice_default_settings.WaiveServiceFee ? "waived" : "deducted" : aftercare_practice_default_settings.WaiveServiceFee ? "waived" : "deducted";
            submitted_case_model_elastic.patient_birthdate = patient_details.birthday;
            submitted_case_model_elastic.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
            submitted_case_model_elastic.patient_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
            submitted_case_model_elastic.status = "FS" + new_status;
            submitted_case_model_elastic.status_date = status_date;
            submitted_case_model_elastic.status_date_string = status_date.ToString("dd.MM.yyyy");
            submitted_case_model_elastic.treatment_date = treatment_date;
            submitted_case_model_elastic.treatment_date_day_month = treatment_date.ToString("dd.MM.");
            submitted_case_model_elastic.treatment_date_month_year = treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
            submitted_case_model_elastic.drug = drug_details != null ? drug_details.drug_name : "";
            submitted_case_model_elastic.type = is_treatment ? "op" : "ac";
            submitted_case_model_elastic.treatment_date_string = treatment_date.ToString("dd.MM.yyyy");
            submitted_case_model_elastic.patient_insurance_number = patient_details.insurance_id;

            if (is_treatment)
            {
                submitted_case_model_elastic.doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name : "-";
                submitted_case_model_elastic.practice_name = treatment_doctor_details.practice;
                submitted_case_model_elastic.doctor_lanr = treatment_doctor_details.lanr;
                submitted_case_model_elastic.practice_bsnr = treatment_practice_details.practice_BSNR;
            }
            else
            {
                submitted_case_model_elastic.doctor_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;
                submitted_case_model_elastic.practice_name = aftercare_doctor_details.practice;
                submitted_case_model_elastic.doctor_lanr = aftercare_doctor_details.lanr;
                submitted_case_model_elastic.practice_bsnr = aftercare_practice_details.practice_BSNR;
            }

            submitted_case_model_elastic.hip_name = patient_details != null ? patient_details.health_insurance_provider : "-";

            List<Submitted_Case_Model> cases_to_submit = new List<Submitted_Case_Model>();
            cases_to_submit.Add(submitted_case_model_elastic);

            Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(cases_to_submit, securityTicket.TenantID.ToString());
        }

    }
}
