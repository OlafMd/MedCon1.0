/* 
 * Generated on 2/14/2017 11:39:18 AM
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
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using CSV2Core_MySQL.Support;
using MMDocConnectElasticSearchMethods.Models;
using CL1_CMN;
using MMDocConnectDBMethods.Pharmacy.Atomic.Retrieval;
using CL1_USR;
using System.Globalization;
using CL1_CMN_PRO;
using CL1_HEC;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using CL1_ORD_PRC;
using CL1_HEC_PRC;
using CL1_HEC_ACT;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectElasticSearchMethods.Order.Retrieval;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Threading;
using System.Web.Configuration;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using MMDocConnectUtils;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectDBMethods.Pharmacy.Atomic.Manipulation;
using MMDocConnectDBMethods.Order.Complex.Model;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Order.Complex.Util;
using BOp.Providers;

namespace MMDocConnectDBMethods.Order.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Submit_Order_to_MM.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Submit_Order_to_MM
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_String Execute(DbConnection Connection, DbTransaction Transaction, P_OR_SOtMM_1311 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_String();
            //Put your code here

            var data = cls_Get_Account_Information_with_PracticeID.Invoke(Connection, Transaction, securityTicket).Result;

            var isNewPharmacy = Parameter.Order.default_pharmacy == Guid.Empty;

            var current_order_status = isNewPharmacy ? "MO10" : "MO1";
            var current_order_status_code = isNewPharmacy ? 10 : 1;

            var all_languages = ORM_CMN_Language.Query.Search(Connection, Transaction, new ORM_CMN_Language.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            });

            var practice_info = cls_Get_Practice_Details_for_Report.Invoke(Connection, Transaction, new P_DO_GPDFR_0840()
            {
                PracticeID = data.PracticeID
            }, securityTicket).Result;

            var trigger_acc = ORM_USR_Account.Query.Search(Connection, Transaction, new ORM_USR_Account.Query() { USR_AccountID = securityTicket.AccountID }).Single();
            var culture = new CultureInfo("de", true);
            var delivery_date = DateTime.ParseExact(Parameter.Order.delivery_date, "dd.MM.yyyy", culture);
            var delivery_date_from = DateTime.ParseExact(Parameter.Order.delivery_date_from, "HH:mm", culture);
            delivery_date_from = delivery_date.AddHours(delivery_date_from.Hour).AddMinutes(delivery_date_from.Minute);
            var delivery_date_to = DateTime.ParseExact(Parameter.Order.delivery_date_to, "HH:mm", culture);
            delivery_date_to = delivery_date.AddHours(delivery_date_to.Hour).AddMinutes(delivery_date_to.Minute);
            var drug_names = new List<string>();
            var cmn_products = ORM_CMN_PRO_Product.Query.Search(Connection, Transaction, new ORM_CMN_PRO_Product.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
            var hec_products = ORM_HEC_Product.Query.Search(Connection, Transaction, new ORM_HEC_Product.Query() { Tenant_RefID = securityTicket.TenantID, IsDeleted = false });
            var drugs = cls_Get_Drug_Details_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

            #region save and get pharmacy
            if (isNewPharmacy)
            {
                Parameter.Order.default_pharmacy = cls_Save_Pharmacy.Invoke(Connection, Transaction, new P_PH_SP_1124
                {
                    Pharmacy = new Pharmacy.Model.Pharmacy(Guid.Empty, Parameter.Order.pharmacy_name, String.Empty, String.Empty,
                        String.Empty, Parameter.Order.pharmacy_street, Parameter.Order.pharmacy_street_number, Parameter.Order.pharmacy_zip_code,
                        Parameter.Order.pharmacy_town, true, String.Empty)
                }, securityTicket).Result;
            }

            var pharmacy = cls_Get_Pharmacy_for_PharmacyID.Invoke(Connection, Transaction, new P_PH_GPfPID_1535
            {
                PharmacyID = Parameter.Order.default_pharmacy
            }, securityTicket).Result;
            #endregion

            var ordersForReport = new List<ReportOrderItem>();

            foreach (var order_id in Parameter.Order.order_ids)
            {
                #region Status
                var header = ORM_ORD_PRC_ProcurementOrder_Header.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Header.Query()
                {
                    ORD_PRC_ProcurementOrder_HeaderID = order_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                header.ProcurementOrder_Supplier_RefID = pharmacy != null ? pharmacy.CompanyBPID : Guid.Empty;

                var header_comment = new ORM_ORD_PRC_ProcurementOrder_Note();
                header_comment.Comment = Parameter.Order.comment;
                header_comment.Title = "Order comment";
                header_comment.Tenant_RefID = securityTicket.TenantID;
                header_comment.ORD_PRC_ProcurementOrder_Header_RefID = order_id;

                header_comment.Save(Connection, Transaction);

                ORM_ORD_PRC_ProcurementOrder_Position.Query order_positionQ = new ORM_ORD_PRC_ProcurementOrder_Position.Query();
                order_positionQ.Tenant_RefID = securityTicket.TenantID;
                order_positionQ.IsDeleted = false;
                order_positionQ.ProcurementOrder_Header_RefID = order_id;
                var order_position = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, order_positionQ).SingleOrDefault();
                var position_comment = order_position != null ? order_position.Position_Comment ?? String.Empty : String.Empty;

                var drug_order_status = new ORM_ORD_PRC_ProcurementOrder_Status();
                drug_order_status.GlobalPropertyMatchingID = String.Format("mm.doc.connect.drug.order.status.{0}", current_order_status.ToLower());
                drug_order_status.Status_Code = current_order_status_code;
                drug_order_status.Tenant_RefID = securityTicket.TenantID;
                drug_order_status.Status_Name = new Dict(ORM_ORD_PRC_ProcurementOrder_Status.TableName);
                foreach (var lang in all_languages)
                {
                    drug_order_status.Status_Name.AddEntry(lang.CMN_LanguageID, current_order_status);
                }
                drug_order_status.Save(Connection, Transaction);

                var drug_order_status_history = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
                drug_order_status_history.ProcurementOrder_Header_RefID = header.ORD_PRC_ProcurementOrder_HeaderID;
                drug_order_status_history.ProcurementOrder_Status_RefID = drug_order_status.ORD_PRC_ProcurementOrder_StatusID;
                drug_order_status_history.Tenant_RefID = securityTicket.TenantID;
                drug_order_status_history.IsStatus_Created = true;
                drug_order_status_history.TriggeredAt_Date = DateTime.Now;
                drug_order_status_history.TriggeredBy_BusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;
                drug_order_status_history.Save(Connection, Transaction);

                header.Current_ProcurementOrderStatus_RefID = drug_order_status.ORD_PRC_ProcurementOrder_StatusID;
                header.Save(Connection, Transaction);
                #endregion Status

                var ord_drug_order = ORM_ORD_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Position.Query()
                {
                    ProcurementOrder_Header_RefID = order_id,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();


                ord_drug_order.Position_RequestedDateOfDelivery = delivery_date.Date;
                ord_drug_order.RequestedDateOfDelivery_TimeFrame_From = delivery_date_from;
                ord_drug_order.RequestedDateOfDelivery_TimeFrame_To = delivery_date_to;
                ord_drug_order.Save(Connection, Transaction);

                var hec_drug_order = ORM_HEC_PRC_ProcurementOrder_Position.Query.Search(Connection, Transaction, new ORM_HEC_PRC_ProcurementOrder_Position.Query()
                {
                    Ext_ORD_PRC_ProcurementOrder_Position_RefID = ord_drug_order.ORD_PRC_ProcurementOrder_PositionID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single();

                var drug_id = ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct.Query()
                {
                    BoundTo_HealthcareProcurementOrderPosition_RefID = hec_drug_order.HEC_PRC_ProcurementOrder_PositionID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single().HealthcareProduct_RefID;

                var drugName = drugs.First(t => t.DrugID == drug_id).DrugName;
                drug_names.Add(drugName);

                if (Parameter.Order.doctor_id != Guid.Empty)
                {
                    var authorizing_doctor_details = cls_Get_Doctor_BasicInformation_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDBIfDID_1034() { DoctorID = Parameter.Order.doctor_id }, securityTicket).Result;

                    hec_drug_order.Clearing_Doctor_RefID = Parameter.Order.doctor_id;
                    hec_drug_order.ClearingDoctor_DisplayName = GenericUtils.GetDoctorName(authorizing_doctor_details);
                    hec_drug_order.Save(Connection, Transaction);
                }

                var shipping_address = new ORM_CMN_UniversalContactDetail();
                shipping_address.Modification_Timestamp = DateTime.Now;
                shipping_address.Tenant_RefID = securityTicket.TenantID;
                shipping_address.Street_Name = Parameter.Order.street;
                shipping_address.Street_Number = Parameter.Order.number;
                shipping_address.ZIP = Parameter.Order.zip;
                shipping_address.Town = Parameter.Order.city;
                shipping_address.CompanyName_Line1 = Parameter.Order.receiver;
                shipping_address.Save(Connection, Transaction);

                var ord_drug_order_header = new ORM_ORD_PRC_ProcurementOrder_Header();
                ord_drug_order_header.Load(Connection, Transaction, ord_drug_order.ProcurementOrder_Header_RefID);
                ord_drug_order_header.ShippingAddressUCD_RefID = shipping_address.CMN_UniversalContactDetailID;
                ord_drug_order_header.Modification_Timestamp = DateTime.Now;
                ord_drug_order_header.ProcurementOrder_Supplier_RefID = pharmacy != null ? pharmacy.CompanyBPID : Guid.Empty;
                ord_drug_order_header.Save(Connection, Transaction);


                ordersForReport.Add(new ReportOrderItem
                {
                    Name = drugName,
                    PositionComment = position_comment,
                    Patient = new ReportOrderPatientInformation
                    {
                        PatientID = hec_drug_order.OrderedFor_Patient_RefID,
                        FeeWaived = hec_drug_order.IsOrderForPatient_PatientFeeWaived
                    }
                });
            }

            #region Send e-mail if urgent order

            var defaultshippingDateOffset = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916()
            {
                PracticeID = data.PracticeID,
                PropertyName = "Default Shipping Date Offset"
            }, securityTicket).Result.NumericValue;

            var company_settings = cls_Get_Company_Settings.Invoke(Connection, Transaction, securityTicket).Result;
            var ordernum = company_settings.ImmediateOrderInterval;

            if (delivery_date > DateTime.Now.AddDays(-defaultshippingDateOffset).AddMinutes(ordernum))
            {
                try
                {
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("de-DE");
                    var mailToL = new List<String>();

                    var accountMails = cls_Get_All_Account_LoginEmails_Who_Receive_Notifications.Invoke(Connection, Transaction, securityTicket).Result.ToList();
                    foreach (var mail in accountMails)
                    {
                        mailToL.Add(mail.LoginEmail);
                    }
                    var mailToFromCompanySettings = company_settings.Email;
                    mailToL.Add(mailToFromCompanySettings);

                    var appName = WebConfigurationManager.AppSettings["mmAppUrl"];
                    var prefix = HttpContext.Current.Request.Url.AbsoluteUri.Contains("https") ? "https://" : "http://";
                    var imageUrl = HttpContext.Current.Request.Url.AbsoluteUri.Substring(0, HttpContext.Current.Request.Url.AbsoluteUri.IndexOf("api")) + "Content/images/logo.png";
                    var email_template = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/UrgentOrderEmailTemplate.html"));

                    var subjectsJson = File.ReadAllText(HttpContext.Current.Server.MapPath("~/EmailTemplates/EmailSubjects.json"));
                    dynamic subjects = JsonConvert.DeserializeObject(subjectsJson);
                    var subjectMail = subjects["UrgentOrderSubject"].ToString();

                    email_template = EmailTemplater.SetTemplateData(email_template, new
                    {
                        orders = drug_names.Select(t => new
                        {
                            order_date_time_from = delivery_date_from.ToString("dd.MM.yyyy HH:mm"),
                            order_date_time_to = delivery_date_to.ToString("HH:mm"),
                            name = data.AccountInformation.name,
                            drug_name = t
                        }),
                        mmapp_dashboard_url = prefix + HttpContext.Current.Request.Url.Authority + "/" + appName,
                        medios_connect_logo_url = imageUrl
                    }, "{{", "}}");

                    var mailFrom = WebConfigurationManager.AppSettings["mailFrom"];
                    var mailsDistinct = mailToL.Distinct().ToList();
                    foreach (var mailTo in mailsDistinct)
                    {
                        EmailNotificationSenderUtil.SendEmail(mailFrom, mailTo, subjectMail, email_template);
                    }
                }
                catch (Exception ex)
                {
                    LogUtils.Logger.LogDocAppInfo(new LogUtils.LogEntry(System.Reflection.MethodInfo.GetCurrentMethod(), ex, null, "Urgent order: Email sending failed."), "EmailExceptions");
                }
            }

            #endregion SEND MAIL URGENT ORDER

            #region Update case order number
            var case_order_number = cls_Save_Case_Order_Number_for_OrderIDs.Invoke(Connection, Transaction, new P_CAS_SCONfOID_1442
            {
                order_ids = Parameter.Order.order_ids.ToArray(),
                practice_bsnr = practice_info.BSNR
            }, securityTicket).Result;
            #endregion

            #region Create PDF report
            if (isNewPharmacy)
            {
                #region patient information
                var patients_info = cls_Get_Patient_Details_for_PatientIDs.Invoke(Connection, Transaction, new P_PA_GPDfPIDs_1354
                {
                    PatientIDs = ordersForReport.Select(x => x.Patient).Select(x => x.PatientID).Distinct().ToArray()
                }, securityTicket).Result;

                foreach (var order in ordersForReport)
                {
                    var patient_info = patients_info.Single(x => x.PatientID == order.Patient.PatientID);

                    order.Patient.FirstName = patient_info.FirstName;
                    order.Patient.LastName = patient_info.LastName;
                    order.Patient.BirthDate = patient_info.BirthDate;
                    order.Patient.Hip = patient_info.HipName;
                    order.Patient.InsuranceStatus = patient_info.InsuranceStatus;
                }
                #endregion

                #region Repack data for report
                var orderPdfReport = new OrderPdfReportGenerator();
                var reportOrderInfo = new ReportOrderInformation
                        {
                            DeliveryDate = delivery_date,
                            DeliveryTimeFrom = delivery_date_from,
                            DeliveryTimeTo = delivery_date_to,
                            CreationDate = DateTime.Now,
                            OrderNumber = case_order_number,
                            HeaderComment = Parameter.Order.comment ?? String.Empty,
                            OrderedDrugs = ordersForReport,
                        };
                var reportPractice = new OrderParticipantInformation
                        {
                            City = practice_info.City,
                            Email = practice_info.Contact_Email,
                            Name = practice_info.Name,
                            Number = practice_info.Street_Number,
                            Phone = practice_info.Contact_Telephone,
                            Street = practice_info.Street_Name,
                            Zip = practice_info.ZIP
                        };
                var reportPharmacy = new OrderParticipantInformation
                        {
                            Name = pharmacy.PharmacyName,
                            Street = pharmacy.Street_Name,
                            Number = pharmacy.Street_Number,
                            Zip = pharmacy.ZIP,
                            City = pharmacy.Town,
                            Email = pharmacy.Contact_Email,
                            Phone = pharmacy.Contact_Telephone
                        };
                #endregion

                var bytes = orderPdfReport.Generate(
                    new Model.OrderReportParameters
                    {
                        Orders = reportOrderInfo,
                        Pharmacy = reportPharmacy,
                        Practice = reportPractice
                    },
                    HttpContext.Current.Server.MapPath("~/ReportContent/SubmitOrderPdfReportContent.xml")
                );

                var _providerFactory = ProviderFactory.Instance;
                var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                var fileName = String.Format("{0}-{1}-{2}.pdf", "Submited Orders", pharmacy.PharmacyName, DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                var documentID = documentProvider.UploadDocument(bytes, fileName, securityTicket.SessionTicket, HttpContext.Current.Request.UserHostAddress);
                var reportURL = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);

                var parameterDoc = new P_OR_UOPDFR_1049();

                parameterDoc.DocumentID = documentID;
                parameterDoc.Mime = UtilMethods.GetMimeType(fileName);
                parameterDoc.DocumentName = fileName;
                parameterDoc.CaseOrderNumber = case_order_number;
                parameterDoc.OrderIDs = Parameter.Order.order_ids.ToArray();

                cls_Upload_Order_PDF_Report.Invoke(Connection, Transaction, parameterDoc, securityTicket);

                returnValue.Result = reportURL;
            }
            #endregion

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_String Invoke(string ConnectionString, P_OR_SOtMM_1311 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection, P_OR_SOtMM_1311 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection, DbTransaction Transaction, P_OR_SOtMM_1311 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_String Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_OR_SOtMM_1311 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_String functionReturn = new FR_String();
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

                throw new Exception("Exception occured in method cls_Submit_Order_to_MM", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_OR_SOtMM_1311 for attribute P_OR_SOtMM_1311
    [DataContract]
    public class P_OR_SOtMM_1311
    {
        //Standard type parameters
        [DataMember]
        public MMDocConnectDBMethods.Order.Complex.Model.OrderSubmitParameter Order { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_String cls_Submit_Order_to_MM(,P_OR_SOtMM_1311 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_String invocationResult = cls_Submit_Order_to_MM.Invoke(connectionString,P_OR_SOtMM_1311 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Complex.Manipulation.P_OR_SOtMM_1311();
parameter.Order = ...;

*/
