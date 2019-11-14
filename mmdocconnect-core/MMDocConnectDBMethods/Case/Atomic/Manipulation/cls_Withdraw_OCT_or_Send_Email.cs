/* 
 * Generated on 10/12/16 15:58:01
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Web.Configuration;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using MMDocConnectUtils;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using CL1_HEC_CAS;
using CL1_HEC_ACT;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Withdraw_OCT_or_Send_Email.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Withdraw_OCT_or_Send_Email
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_WOctoSE_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var should_send_email = false;

            var treatment_year_start_date = cls_Get_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GTY_1125()
            {
                Date = Parameter.treatment_date,
                LocalizationCode = Parameter.localization,
                PatientID = Parameter.patient_id,
            }, securityTicket).Result;

            var treatment_year_length = cls_Get_TreatmentYearLength.Invoke(Connection, Transaction, new P_CAS_GTYL_1317()
            {
                Date = Parameter.treatment_date,
                PatientID = Parameter.patient_id
            }, securityTicket).Result;

            var ops_in_treatment_year = cls_Get_OpDates_for_PatientID_and_LocalizationCode_in_TreatmentYear.Invoke(Connection, Transaction, new P_CAS_GOpDfPIDaLCiTY_1110()
            {
                LocalizationCode = Parameter.localization,
                PatientID = Parameter.patient_id,
                TreatmentYearStartDate = treatment_year_start_date,
                TreatmentYearEndDate = treatment_year_start_date.AddDays(treatment_year_length - 1)
            }, securityTicket).Result;

            var existingBillPosition = cls_Get_Existing_OCT_BillPosition_for_PatientID_and_LocalizationCode.Invoke(Connection, Transaction, new P_CAS_GEBPfPIDaLC_1803()
            {
                LocalizationCode = Parameter.localization,
                PatientID = Parameter.patient_id
            }, securityTicket).Result;

            if (existingBillPosition != null && existingBillPosition.CaseID == Parameter.case_id)
            {
                var op_to_reassign_oct_to = ops_in_treatment_year.FirstOrDefault(t => t.CaseID != Parameter.case_id && ((!t.IsPerformed && !t.IsDeleted) || (t.IsPerformed && t.FsStatus != 8 && t.FsStatus != 11 && t.FsStatus != 17)));
                if (op_to_reassign_oct_to != null)
                {
                    var caseBillCode = new ORM_HEC_CAS_Case_BillCode();
                    caseBillCode.Load(Connection, Transaction, existingBillPosition.CaseBillCodeID);

                    caseBillCode.HEC_CAS_Case_RefID = op_to_reassign_oct_to.CaseID;
                    caseBillCode.Save(Connection, Transaction);
                }
                else
                {
                    var oct = Retrieve_Octs.GetOctsWhereFieldsHaveValues(new List<FieldValueParameter>() { 
                        new FieldValueParameter() { FieldName = "case_id", FieldValue = Parameter.case_id.ToString() } 
                    }, null, securityTicket.TenantID.ToString()).SingleOrDefault();

                    if (oct != null)
                    {
                        var oct_id = Guid.Parse(oct.id);
                        var oct_planned_action = new ORM_HEC_ACT_PlannedAction();
                        oct_planned_action.Load(Connection, Transaction, oct_id);
                        oct_planned_action.IsCancelled = true;

                        oct_planned_action.Save(Connection, Transaction);
                    }
                }

                should_send_email = cls_Get_Active_NonError_OctBillPositionID_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GANEOctBPIDfCID_0925() { CaseID = Parameter.case_id }, securityTicket).Result.Any();
            }

            if (should_send_email)
            {
                var performedOcts = cls_Get_PerformedOctDoctorData_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GPOctDDfCID_0935() { CaseID = Parameter.case_id }, securityTicket).Result;

                if (performedOcts.Any())
                {
                    var mailToL = new List<String>();

                    var accountMails = cls_Get_All_Account_LoginEmails_Who_Receive_Notifications.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                    foreach (var mail in accountMails)
                    {
                        mailToL.Add(mail.LoginEmail);
                    }

                    var mailToFromCompanySettings = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                    mailToL.Add(mailToFromCompanySettings);

                    var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = Parameter.patient_id }, securityTicket).Result;
                    var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.op_doctor_id }, securityTicket).Result.First();
                    var appName = WebConfigurationManager.AppSettings["mmAppUrl"];
                    var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                    var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                    var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/TreatmentCancelledFromSettlementPageOctSubmittedEmailTemplate .html"));

                    var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                    dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
                    var subjectMail = subjects["TreatmentCancelledFromSettlementPageSubject"].ToString();

                    email_template = EmailTemplater.SetTemplateData(email_template, new
                    {
                        patient_first_name = patient_details.patient_first_name,
                        patient_last_name = patient_details.patient_last_name,
                        treatment_date = Parameter.treatment_date.ToString("dd.MM.yyyy"),
                        treatment_doctor_title = treatment_doctor_details.title,
                        treatment_doctor_first_name = treatment_doctor_details.first_name,
                        treatment_doctor_last_name = treatment_doctor_details.last_name,
                        octs = performedOcts,
                        mmapp_treatment_page_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName + "/#/treatment",
                        medios_connect_logo_url = imageUrl
                    }, "{{", "}}");

                    try
                    {
                        string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];

                        var mailsDistinct = mailToL.Distinct().ToList();
                        foreach (var mailTo in mailsDistinct)
                        {
                            EmailNotificationSenderUtil.SendEmail(mailFrom, mailTo, subjectMail, email_template);
                        }

                    }
                    catch (Exception ex)
                    {
                        LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Cancel case from settlement: Email sending failed."), "EmailExceptions");
                    }
                }
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_WOctoSE_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_WOctoSE_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_WOctoSE_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_WOctoSE_0938 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method cls_Withdraw_OCT_or_Send_Email", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_WOctoSE_0938 for attribute P_CAS_WOctoSE_0938
    [DataContract]
    public class P_CAS_WOctoSE_0938
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public Guid op_doctor_id { get; set; }
        [DataMember]
        public String localization { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public Guid diagnose_id { get; set; }
        [DataMember]
        public Guid drug_id { get; set; }
        [DataMember]
        public Guid oct_doctor_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Withdraw_OCT_or_Send_Email(,P_CAS_WOctoSE_0938 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Withdraw_OCT_or_Send_Email.Invoke(connectionString,P_CAS_WOctoSE_0938 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_WOctoSE_0938();
parameter.case_id = ...;
parameter.patient_id = ...;
parameter.op_doctor_id = ...;
parameter.localization = ...;
parameter.treatment_date = ...;
parameter.diagnose_id = ...;
parameter.drug_id = ...;
parameter.oct_doctor_id = ...;

*/
