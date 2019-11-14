/* 
 * Generated on 09/01/15 10:21:15
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
using System.Web.Configuration;
using System.Text;
using MMDocConnectUtils;
using CL1_HEC;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Doctor.Manipulation;
using System.Threading;
using System.Globalization;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Web;
using System.Configuration;
using System.IO;

namespace MMDocConnectDBMethods.Doctor.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_AdHoc_Doctor.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_AdHoc_Doctor
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_DO_SAHD_1815 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            #region EMAIL
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");

            string urlMM = System.Configuration.ConfigurationManager.AppSettings["mmdocconnect.dashboard.url"];
            List<String> mailToL = new List<String>();
            var accountMails = cls_Get_All_Account_LoginEmails_Who_Receive_Notifications.Invoke(Connection, Transaction, securityTicket).Result.ToList();
            foreach (var mail in accountMails)
            {
                mailToL.Add(mail.LoginEmail);
            }

            string appName = WebConfigurationManager.AppSettings["mmAppUrl"];
            var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
            var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";

            var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/NewTemporaryDoctorEmailTemplate.html"));
            var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
            dynamic subjects = Newtonsoft.Json.JsonConvert.DeserializeObject(subjectsJson);
            var subjectMail = subjects["NewTemporaryDoctorSubject"].ToString();

            email_template = EmailTemplater.SetTemplateData(email_template, new
            {
                name = Parameter.name,
                street = String.IsNullOrEmpty(Parameter.street) ? "-" : Parameter.street,
                house_number = String.IsNullOrEmpty(Parameter.house_number) ? "-" : Parameter.house_number,
                zip = String.IsNullOrEmpty(Parameter.zip) ? "-" : Parameter.zip,
                city = String.IsNullOrEmpty(Parameter.city) ? "-" : Parameter.city,
                phone = String.IsNullOrEmpty(Parameter.phone) ? "-" : Parameter.phone,
                fax = String.IsNullOrEmpty(Parameter.fax) ? "-" : Parameter.fax,
                email = String.IsNullOrEmpty(Parameter.email) ? "-" : Parameter.email,
                comment = String.IsNullOrEmpty(Parameter.comment) ? "-" : Parameter.comment,
                doc_app_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                medios_connect_logo_url = imageUrl
            }, "{{", "}}");

            try
            {
                // string mailFrom = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result.Email;
                string mailFrom = WebConfigurationManager.AppSettings["mailFrom"];
                var mailsDistinct = mailToL.Distinct().ToList();
                foreach (var mailTo in mailsDistinct)
                {
                    EmailNotificationSenderUtil.SendEmail(mailFrom, mailTo, subjectMail, email_template);
                }
            }
            catch (Exception ex)
            {
                LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Temporary doctor creation: Email sending failed."), "EmailExceptions");
            }
            #endregion

            #region PERSON INFO
            ORM_CMN_PER_PersonInfo temporary_doctor_person_info = new ORM_CMN_PER_PersonInfo();
            temporary_doctor_person_info.LastName = Parameter.name;
            temporary_doctor_person_info.Modification_Timestamp = DateTime.Now;
            temporary_doctor_person_info.Tenant_RefID = securityTicket.TenantID;

            temporary_doctor_person_info.Save(Connection, Transaction);

            ORM_CMN_PER_CommunicationContact_Type temporary_doctor_communication_contact_type_email = new ORM_CMN_PER_CommunicationContact_Type();
            temporary_doctor_communication_contact_type_email.Tenant_RefID = securityTicket.TenantID;
            temporary_doctor_communication_contact_type_email.Type = "Email";

            temporary_doctor_communication_contact_type_email.Save(Connection, Transaction);

            ORM_CMN_PER_CommunicationContact temporary_doctor_communication_contact_email = new ORM_CMN_PER_CommunicationContact();
            temporary_doctor_communication_contact_email.Tenant_RefID = securityTicket.TenantID;
            temporary_doctor_communication_contact_email.Modification_Timestamp = DateTime.Now;
            temporary_doctor_communication_contact_email.PersonInfo_RefID = temporary_doctor_person_info.CMN_PER_PersonInfoID;
            temporary_doctor_communication_contact_email.Content = Parameter.email;
            temporary_doctor_communication_contact_email.Contact_Type = temporary_doctor_communication_contact_type_email.CMN_PER_CommunicationContact_TypeID;

            temporary_doctor_communication_contact_email.Save(Connection, Transaction);

            ORM_CMN_PER_CommunicationContact_Type temporary_doctor_communication_contact_type_phone = new ORM_CMN_PER_CommunicationContact_Type();
            temporary_doctor_communication_contact_type_phone.Tenant_RefID = securityTicket.TenantID;
            temporary_doctor_communication_contact_type_phone.Type = "Phone";

            temporary_doctor_communication_contact_type_phone.Save(Connection, Transaction);

            ORM_CMN_PER_CommunicationContact temporary_doctor_communication_contact_phone = new ORM_CMN_PER_CommunicationContact();
            temporary_doctor_communication_contact_phone.Tenant_RefID = securityTicket.TenantID;
            temporary_doctor_communication_contact_phone.Modification_Timestamp = DateTime.Now;
            temporary_doctor_communication_contact_phone.PersonInfo_RefID = temporary_doctor_person_info.CMN_PER_PersonInfoID;
            temporary_doctor_communication_contact_phone.Content = Parameter.phone;
            temporary_doctor_communication_contact_phone.Contact_Type = temporary_doctor_communication_contact_type_phone.CMN_PER_CommunicationContact_TypeID;

            temporary_doctor_communication_contact_phone.Save(Connection, Transaction);
            #endregion

            #region BPT
            ORM_CMN_BPT_BusinessParticipant temporary_doctor_bpt = new ORM_CMN_BPT_BusinessParticipant();
            temporary_doctor_bpt.IfNaturalPerson_CMN_PER_PersonInfo_RefID = temporary_doctor_person_info.CMN_PER_PersonInfoID;
            temporary_doctor_bpt.IsNaturalPerson = true;
            temporary_doctor_bpt.Modification_Timestamp = DateTime.Now;
            temporary_doctor_bpt.Tenant_RefID = securityTicket.TenantID;

            temporary_doctor_bpt.Save(Connection, Transaction);
            #endregion

            #region DOCTOR
            ORM_HEC_Doctor temporary_doctor = new ORM_HEC_Doctor();
            // account ref. id = guid empty means that this is a temporary doctor with no account
            temporary_doctor.Account_RefID = Guid.Empty;
            temporary_doctor.BusinessParticipant_RefID = temporary_doctor_bpt.CMN_BPT_BusinessParticipantID;
            temporary_doctor.DoctorIDNumber = "";
            temporary_doctor.IsDoctorForFollowupTreatmentsOnly = true;
            temporary_doctor.Tenant_RefID = securityTicket.TenantID;

            temporary_doctor.Save(Connection, Transaction);

            ORM_HEC_Doctor_UniversalProperty temporary_doctor_universal_property = new ORM_HEC_Doctor_UniversalProperty();
            temporary_doctor_universal_property.GlobalPropertyMatchingID = "mm.docconnect.temporary.aftercare.doctor.comment";
            temporary_doctor_universal_property.IsValue_String = true;
            temporary_doctor_universal_property.Modification_Timestamp = DateTime.Now;
            temporary_doctor_universal_property.PropertyName = "Comment";
            temporary_doctor_universal_property.Tenant_RefID = securityTicket.TenantID;

            temporary_doctor_universal_property.Save(Connection, Transaction);

            ORM_HEC_Doctor_UniversalPropertyValue temporary_doctor_universal_property_value = new ORM_HEC_Doctor_UniversalPropertyValue();
            temporary_doctor_universal_property_value.HEC_Doctor_RefID = temporary_doctor.HEC_DoctorID;
            temporary_doctor_universal_property_value.Modification_Timestamp = DateTime.Now;
            temporary_doctor_universal_property_value.Value_String = Parameter.comment;
            temporary_doctor_universal_property_value.UniversalProperty_RefID = temporary_doctor_universal_property.HEC_Doctor_UniversalPropertyID;
            temporary_doctor_universal_property_value.Tenant_RefID = securityTicket.TenantID;

            temporary_doctor_universal_property_value.Save(Connection, Transaction);
            #endregion

            #region IMPORT TO ELASTIC

            Practice_Doctors_Model temporary_doctor_elastic_model = new Practice_Doctors_Model();
            temporary_doctor_elastic_model.autocomplete_name = Parameter.name;
            temporary_doctor_elastic_model.name = Parameter.name;
            temporary_doctor_elastic_model.name_untouched = Parameter.name;
            temporary_doctor_elastic_model.address = Parameter.street + " " + Parameter.house_number;
            temporary_doctor_elastic_model.zip = Parameter.zip;
            temporary_doctor_elastic_model.city = Parameter.city;
            temporary_doctor_elastic_model.email = Parameter.email;
            temporary_doctor_elastic_model.phone = Parameter.phone;
            temporary_doctor_elastic_model.account_status = "temp";
            temporary_doctor_elastic_model.id = temporary_doctor.HEC_DoctorID.ToString();
            temporary_doctor_elastic_model.practice_for_doctor_id = Parameter.practice_id.ToString();
            temporary_doctor_elastic_model.tenantid = securityTicket.TenantID.ToString();
            temporary_doctor_elastic_model.type = "Doctor";

            Add_New_Practice.Import_Practice_Data_to_ElasticDB(new List<Practice_Doctors_Model>() { temporary_doctor_elastic_model }, securityTicket.TenantID.ToString());
            #endregion

            returnValue.Result = temporary_doctor.HEC_DoctorID;
            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_DO_SAHD_1815 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_DO_SAHD_1815 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_DO_SAHD_1815 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_DO_SAHD_1815 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Save_AdHoc_Doctor", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_DO_SAHD_1815 for attribute P_DO_SAHD_1815
    [DataContract]
    public class P_DO_SAHD_1815
    {
        //Standard type parameters
        [DataMember]
        public String name { get; set; }
        [DataMember]
        public String street { get; set; }
        [DataMember]
        public String house_number { get; set; }
        [DataMember]
        public String zip { get; set; }
        [DataMember]
        public String city { get; set; }
        [DataMember]
        public String phone { get; set; }
        [DataMember]
        public String fax { get; set; }
        [DataMember]
        public String email { get; set; }
        [DataMember]
        public String comment { get; set; }
        [DataMember]
        public Guid practice_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_AdHoc_Doctor(,P_DO_SAHD_1815 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_AdHoc_Doctor.Invoke(connectionString,P_DO_SAHD_1815 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Doctor.Atomic.Manipulation.P_DO_SAHD_1815();
parameter.name = ...;
parameter.street = ...;
parameter.house_number = ...;
parameter.zip = ...;
parameter.city = ...;
parameter.phone = ...;
parameter.fax = ...;
parameter.email = ...;
parameter.comment = ...;
parameter.practice_id = ...;

*/
