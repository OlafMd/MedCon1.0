using BOp.Providers;
using BOp.Providers.TMS;
using BOp.Providers.TMS.Requests;
using CSV2Core.SessionSecurity;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.Elastic_Methods.Doctor.Manipulation;
using DataImporter.Models;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Import_data_to_Elastic_from_relation_DB.Methods
{
   public class Import_data_to_elastic
    {
       public static void Import_Data_From_DB_To_Elastic(DbConnection Connection, DbTransaction Transaction, SessionSecurityTicket securityTicket)
       {

           #region add Practices and Doctors to Elastic
           List<Practice_Doctors_Model> LdoctorPracticeM = new List<Practice_Doctors_Model>();
           var dataPractice = cls_Get_All_Practices_from_DB.Invoke(Connection, Transaction, securityTicket).Result;
           IAccountServiceProvider accountService;
           var _providerFactory = ProviderFactory.Instance;
           accountService = _providerFactory.CreateAccountServiceProvider();

           if (dataPractice != null)
           {

               foreach (var practice in dataPractice)
               {

                   Practice_Doctors_Model doctorPracticeM = new Practice_Doctors_Model();

                   bool statusAcc = accountService.GetAccountStatusHistory(securityTicket.TenantID, practice.AccountID).OrderBy(st => st.CreationTimestamp).Reverse().FirstOrDefault().Status == EAccountStatus.BANNED;
                   doctorPracticeM.account_status = statusAcc ? "inaktiv" : "aktiv";
                   doctorPracticeM.id = practice.PracticeID.ToString();
                   doctorPracticeM.name = practice.Name;
                   doctorPracticeM.name_untouched = practice.Name;
                   doctorPracticeM.salutation = "";
                   doctorPracticeM.type = "Practice";
                   doctorPracticeM.address = practice.Street_Name + " " + practice.Street_Number;
                   doctorPracticeM.zip = practice.ZIP;
                   doctorPracticeM.city = practice.City;
                   if (practice.Contact_Email != null)
                   {
                       doctorPracticeM.email = practice.Contact_Email;
                   }
                   doctorPracticeM.phone = doctorPracticeM.phone;

                   doctorPracticeM.bank_untouched = practice.BankName != null ? practice.BankName : "";
                   doctorPracticeM.bank = practice.BankName != null ? practice.BankName : "";

                   if (practice.IBAN != null)
                   {
                       doctorPracticeM.iban = practice.IBAN;
                   }
                   if (practice.BICCode != null)
                   {
                       doctorPracticeM.bic = practice.BICCode;
                   }
                   doctorPracticeM.bsnr_lanr = practice.BSNR;
                   doctorPracticeM.aditional_info = "";
                   doctorPracticeM.tenantid = securityTicket.TenantID.ToString();
                   doctorPracticeM.role = practice.IsSurgeryPractice ? "op" : "ac";
                   DO_GPCN_1133[] dataContract = cls_Get_Practice_Contract_Numbers.Invoke(Connection, Transaction, new P_DO_GPCN_1133() { PracticeID = practice.PracticeID }, securityTicket).Result;
                   doctorPracticeM.contract = dataContract.Count();
                   LdoctorPracticeM.Add(doctorPracticeM);

               }
           }
           var dataDoc = cls_Get_All_Doctors_from_DB.Invoke(Connection, Transaction, securityTicket).Result;
           if (dataDoc != null)
           {

               foreach (var doctor in dataDoc)
               {
                   Practice_Doctors_Model doctorPracticeM = new Practice_Doctors_Model();
                   bool statusAcc = accountService.GetAccountStatusHistory(securityTicket.TenantID, doctor.AccountID).OrderBy(st => st.CreationTimestamp).Reverse().FirstOrDefault().Status == EAccountStatus.BANNED;
                   doctorPracticeM.account_status = statusAcc ? "inaktiv" : "aktiv";
                   doctorPracticeM.id = doctor.Id.ToString();
                   var title = string.IsNullOrEmpty(doctor.Title) ? "" : doctor.Title.Trim();
                   doctorPracticeM.tenantid = securityTicket.TenantID.ToString();
                   doctorPracticeM.name = title + " " + doctor.LastName + " " + doctor.FirstName;
                   doctorPracticeM.name_untouched = doctor.LastName + " " + doctor.FirstName;
                   doctorPracticeM.bsnr_lanr = doctor.Lanr.ToString();
                   doctorPracticeM.salutation = title;
                   doctorPracticeM.type = "Doctor";
                   doctorPracticeM.bank = string.IsNullOrEmpty(doctor.BankName) ? "" : doctor.BankName;
                   doctorPracticeM.bank_untouched = string.IsNullOrEmpty(doctor.BankName) ? "" : doctor.BankName;
                   doctorPracticeM.phone = doctor.Phone;
                   doctorPracticeM.email = string.IsNullOrEmpty(doctor.Email) ? "" : doctor.Email;

                   doctorPracticeM.iban = string.IsNullOrEmpty(doctor.IBAN) ? "" : doctor.IBAN;

                   doctorPracticeM.bic = string.IsNullOrEmpty(doctor.BICCode) ? "" : doctor.BICCode;
                   var practice = dataPractice.Where(pr => pr.PracticeID == doctor.Practice_ID).SingleOrDefault();
                   doctorPracticeM.practice_for_doctor_id = practice.PracticeID.ToString();
                   doctorPracticeM.practice_name_for_doctor = practice.Name;
                   doctorPracticeM.address = practice.Street_Name + " " + practice.Street_Number;
                   doctorPracticeM.zip = practice.ZIP;
                   doctorPracticeM.city = practice.City;
                   doctorPracticeM.role = practice.IsSurgeryPractice ? "op" : "ac";
   
                   if (doctor.BankAccountID == practice.BankAccountID)
                   {
                       doctorPracticeM.bank_id = practice.BankAccountID.ToString();
                       doctorPracticeM.bank_info_inherited = true;
                       doctorPracticeM.bank_untouched = practice.BankName != null ? practice.BankName : "";
                       doctorPracticeM.bank = practice.BankName != null ? practice.BankName : "";

                       if (practice.IBAN != null)
                       {
                           doctorPracticeM.iban = practice.IBAN;
                       }
                       if (practice.BICCode != null)
                       {
                           doctorPracticeM.bic = practice.BICCode;
                       }
                   }
                   else
                   {
                       doctorPracticeM.bank_id = doctor.BankAccountID.ToString();
                       doctorPracticeM.bank_info_inherited = false;
                       doctorPracticeM.bank_untouched = doctor.BankName != null ? doctor.BankName : "";
                       doctorPracticeM.bank = doctor.BankName != null ? doctor.BankName : "";

                       if (doctor.IBAN != null)
                       {
                           doctorPracticeM.iban = doctor.IBAN;
                       }
                       if (doctor.BICCode != null)
                       {
                           doctorPracticeM.bic = doctor.BICCode;
                       }

                   }

                   var docContracts = cls_Get_Doctor_Contract_Numbers.Invoke(Connection, Transaction, new P_DO_CDCD_1505() { DoctorID = doctor.Id }, securityTicket).Result;
                   doctorPracticeM.contract = docContracts.Count();
                   LdoctorPracticeM.Add(doctorPracticeM);
               }


           }
           //first delete Tenant index 
           try
           {
            Add_Practice_Doctors_to_Elastic.Delete_index_on_Elastic(securityTicket.TenantID.ToString());
             //  Add_Practice_Doctors_to_Elastic.Delete_index_on_Elastic(securityTicket.TenantID.ToString() + "/" + "user");
               Console.Write("Type Doctors_Practices deleted");
           }
           catch
           {

               Console.Write("Type Doctors_Practices do not exsists");
           }

           //import items to Elastic
           if (dataDoc != null | dataPractice != null)
           {
               Add_Practice_Doctors_to_Elastic.Import_Practice_Data_to_ElasticDB(LdoctorPracticeM, securityTicket.TenantID.ToString());
           }
           #endregion


           #region add Patients to Elastic
           var dataPatients = cls_Get_All_Patients_from_DB.Invoke(Connection, Transaction, securityTicket).Result;


         
           if (dataPatients != null)
           {
               try
               {
              //     Add_Practice_Doctors_to_Elastic.Delete_index_on_Elastic(securityTicket.TenantID.ToString() + "/" + "patient");
                   Console.Write("Type Patients deleted");
               }
               catch
               {

                   Console.Write("Type Patients do not exsists");
               }

               foreach (var patient in dataPatients)
               {

                   Patient_Model patientModel = new Patient_Model();
                   var HIPLIst = cls_Get_All_HIPs.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                   string HIP = HIPLIst.Where(i => i.id == patient.HIPID).Single().name;
                   IFormatProvider culture = new System.Globalization.CultureInfo("de", true);
                   patientModel.birthday = DateTime.Parse(patient.BirthDate.ToString("dd.MM.yyyy"), culture, System.Globalization.DateTimeStyles.AssumeLocal);
                   patientModel.birthday_string = patient.BirthDate.ToString("dd.MM.yyyy");
                   patientModel.name = patient.LastName + ", " + patient.FirstName;
                   patientModel.health_insurance_provider = HIP;
                   patientModel.name_with_birthdate = patient.FirstName + " " + patient.LastName + " (" + patient.BirthDate.ToString("dd.MM.yyyy") + ")";
                   patientModel.id = patient.Id.ToString();
                   patientModel.insurance_id = patient.HipNumber;
                   patientModel.insurance_status = patient.InsuranceStatus;
                   patientModel.practice_id = patient.PracticeID.ToString();

                   if (patient.Gender == 0)
                       patientModel.sex = "M";
                   else if (patient.Gender == 1)
                       patientModel.sex = "W";
                   else if (patient.Gender == 2)
                       patientModel.sex = "o.A.";

                   //Add patient participation consent 
                   if (patient.ValidFrom != DateTime.MinValue)
                   {
                       patientModel.participation_consent_from = patient.ValidFrom;
                       patientModel.has_participation_consent = true;
                   }

                   if (patient.ValidThrough != DateTime.MinValue)
                       patientModel.participation_consent_to = patient.ValidThrough;

                   Add_New_Patient.Import_Patients_to_ElasticDB(patientModel, securityTicket.TenantID.ToString());

               }

               Console.Write("Patients imported to elastic");
           }

           #endregion
         
           #region Add Cases to Elastic
           List<Case_Model> cases = new List<Case_Model>();
           List<Order_Model> OrderModelL = new List<Order_Model>();
           var dataCases = cls_Get_All_Cases_from_DB.Invoke(Connection, Transaction, securityTicket).Result;
           if (dataCases != null)
           {
               foreach (var Case in dataCases)
               {

                   if (Case.case_status == null)
                   {

                       var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = Case.diagnose_id }, securityTicket).Result;
                       var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = Case.drug_id }, securityTicket).Result;

                       Case_Model case_model_elastic = new Case_Model();
                       case_model_elastic.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
                       case_model_elastic.drug = drug_details != null ? drug_details.drug_name : "";
                       case_model_elastic.id = Case.case_id.ToString();
                       case_model_elastic.localization = Case.localization;
                       case_model_elastic.status_drug_order = Case.order_id != Guid.Empty ? "MO1" : "";

                       case_model_elastic.status_treatment = Case.diagnose_id != Guid.Empty ? "OP1" : "";
                       case_model_elastic.patient_name = Case.patient_id != Guid.Empty ? Case.Patient_LastName + ", " + Case.Patient_FirstName : "";
                       case_model_elastic.patient_birthdate_string = Case.Patient_BirthDate.ToString("dd.MM.yyyy");
                       case_model_elastic.patient_birthdate = Case.Patient_BirthDate;
                       if (Case.is_aftercare_practice)
                       {
                           case_model_elastic.aftercare_name = Case.aftercare_practice_display_name;
                       }
                       else if (Case.is_aftercare_doctor)
                       {
                           case_model_elastic.aftercare_name = Case.aftercare_doctor_display_name;
                       }
                       else
                       {
                           case_model_elastic.aftercare_name = "-";
                       }
                       var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Case.ac_doctor_id }, securityTicket).Result.SingleOrDefault();

                       if (aftercare_doctor_details != null)
                       {
                           case_model_elastic.aftercare_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;
                           case_model_elastic.aftercare_doctors_practice_name = aftercare_doctor_details.practice;
                       }


                       case_model_elastic.is_aftercare_doctor = Case.is_aftercare_doctor;
                       case_model_elastic.treatment_date_day_month = Case.treatment_date.ToString("dd.MM.");
                       case_model_elastic.treatment_date_month_year = Case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                       var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Case.treatment_doctor_id }, securityTicket).Result.SingleOrDefault();
                       case_model_elastic.treatment_doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name : "-";
                       case_model_elastic.practice_id = Case.practice_id.ToString();

                       case_model_elastic.order_modification_timestamp = Case.order_modification_timestamp;
                       case_model_elastic.order_modification_timestamp_string = Case.order_modification_timestamp.ToString("dd.MM.yyyy");
                       case_model_elastic.delivery_time_from = Case.order_id != Guid.Empty ? Case.alternative_delivery_date_from : Case.treatment_date;
                       case_model_elastic.delivery_time_to = Case.order_id != Guid.Empty ? Case.alternative_delivery_date_to : Case.treatment_date.AddHours(23).AddMinutes(59);
                       case_model_elastic.delivery_time_string = case_model_elastic.delivery_time_from.ToString("HH:mm") + " - " + case_model_elastic.delivery_time_to.ToString("HH:mm");


                       Order_Model orderM = new Order_Model();

                       if (Case.order_id != Guid.Empty)
                       {
                           case_model_elastic.is_orders_drug = true;
                           OR_GOSfCID_0858[] OrderCtatusList = cls_Get_Order_Status_for_CaseID.Invoke(Connection, Transaction, new P_OR_GOSfCID_0858() { CaseID = Case.case_id }, securityTicket).Result;
                           OrderCtatusList = OrderCtatusList.OrderBy(tmp => tmp.StatusCreated).Reverse().ToArray();
                           case_model_elastic.status_drug_order = OrderCtatusList.Count() > 0 ? "MO" + OrderCtatusList.First().StatusCode : "MO1";
                           if (OrderCtatusList.Count() > 1)
                           {
                               case_model_elastic.previous_status_drug_order = "MO" + OrderCtatusList[1].StatusCode;
                           }
                           else
                           {
                               case_model_elastic.previous_status_drug_order = "MO1";
                           }
                           orderM.status_drug_order = OrderCtatusList.Count() > 0 ? "MO" + OrderCtatusList.First().StatusCode : "MO1";
                       }
                       else { case_model_elastic.is_orders_drug = false; }
                       cases.Add(case_model_elastic);

                       if (Case.order_id != Guid.Empty)
                       {

                           orderM.case_id = case_model_elastic.id;
                           orderM.id = Case.OrderHeaderID.ToString();

                           orderM.delivery_time_from = Case.alternative_delivery_date_from != null ? Case.alternative_delivery_date_from : Case.treatment_date;
                           orderM.delivery_time_to = Case.alternative_delivery_date_from != null ? Case.alternative_delivery_date_to : Case.treatment_date.AddHours(23).AddMinutes(59);
                           orderM.delivery_time_string = case_model_elastic.delivery_time_from.ToString("HH:mm") + " - " + case_model_elastic.delivery_time_to.ToString("HH:mm");
                           orderM.practice_id = Case.practice_id.ToString();
                           orderM.order_modification_timestamp = DateTime.Now;
                           orderM.order_modification_timestamp_string = DateTime.Now.ToString("dd.MM.yyyy");
                           orderM.is_orders_drug = true;
                           orderM.treatment_date = Case.treatment_date;
                           orderM.treatment_date_day_month = Case.treatment_date.ToString("dd.MM.");
                           orderM.treatment_date_month_year = Case.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                           orderM.treatment_doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name : "-";
                           orderM.treatment_doctor_practice_name = treatment_doctor_details != null ? treatment_doctor_details.practice : "-";
                           orderM.localization = Case.diagnose_id != Guid.Empty ? Case.localization : "-";
                           orderM.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "-";
                           orderM.drug = drug_details != null ? drug_details.drug_name : "";
                           orderM.patient_name = Case.patient_id != Guid.Empty ? Case.Patient_LastName + ", " + Case.Patient_FirstName : "";
                           orderM.patient_birthdate_string = Case.Patient_BirthDate.ToString("dd.MM.yyyy");
                           orderM.patient_birthdate = Case.Patient_BirthDate;


                           OrderModelL.Add(orderM);

                       }

                   }
               }
               try
               {
                    Add_Practice_Doctors_to_Elastic.Delete_index_on_Elastic(securityTicket.TenantID.ToString() + "/" + "case");

                   Console.Write("Type Case deleted");
               }
               catch
               {

                   Console.Write("Type do not exsists");
               }
               Add_New_Case.Import_Case_Data_to_ElasticDB(cases, securityTicket.TenantID.ToString());
               Add_New_Order.Import_Order_Data_to_ElasticDB(OrderModelL, securityTicket.TenantID.ToString());
               Console.Write("Cases and Orders imported to Elastic");



           }
           #endregion

         
       }
    }
}
