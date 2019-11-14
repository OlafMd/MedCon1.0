/* 
 * Generated on 3/14/2017 10:55:43 AM
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
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using MMDocConnectDocApp.ExcelTemplates;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectUtils;
using System.IO;
using BOp.Providers;
using System.Web;
using MMDocConnectDBMethods.Archive.Complex.Manipulation;
using CL1_ORD_PRC;
using CL1_CMN_BPT;
using CL1_HEC;
using MMDocConnectDocApp;
using System.IO.Compression;

namespace MMDocConnectDBMethods.Order.Complex.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Create_Orders_Report.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Create_Orders_Report
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_String Execute(DbConnection Connection, DbTransaction Transaction, P_OR_COR_1437 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_String();
            //Put your code here

            var downloadURL = "";
            var DateForElastic = DateTime.Now;
            var orderStatusesForReport = Parameter.Statuses.Select(x => x.ToString()).ToArray();
            var ordersForReportData = new OR_GOfRfS_1038[] { };
            if (Parameter.GroupByPharmacy)
            {
                ordersForReportData = cls_Get_Orders_For_Steribase_Report.Invoke(Connection, Transaction, securityTicket).Result.Where(x => x.StatusCode != 10).Select(x => new OR_GOfRfS_1038
                {
                    Patient_RefID = x.Patient_RefID,
                    StatusCode = x.StatusCode,
                    CaseID = x.CaseID,
                    StatusID = x.StatusID,
                    BusinesParticipantWhoCreatedOrder = x.BusinesParticipantWhoCreatedOrder,
                    OrderID = x.OrderID,
                    OrderNumber = x.OrderNumber,
                    CaseNumber = x.CaseNumber,
                    DrugName = x.DrugName,
                    PZN = x.PZN,
                    DeliveryDate = x.DeliveryDate,
                    DeliveryTimeFrom = x.DeliveryTimeFrom,
                    DeliveryTimeTo = x.DeliveryTimeTo,
                    OnlyLabel = x.OnlyLabel,
                    ChargesFee = x.ChargesFee,
                    SendInvoiceToPractice = x.SendInvoiceToPractice,
                    TreatmentDate = x.TreatmentDate,
                    DoctorID = x.DoctorID,
                    OrderCreationTimestamp = x.OrderCreationTimestamp,
                    CaseCreationDate = x.CaseCreationDate,
                    OrderComment = x.OrderComment,
                    HeaderComment = x.HeaderComment,
                    IsDeleted = x.IsDeleted,
                    PharmacyName = x.PharmacyName,
                    PharmacyID = x.PharmacyID,
                }).ToArray();
            }
            else
            {
                ordersForReportData = cls_Get_Orders_for_Report_for_Statuses.Invoke(Connection, Transaction, new P_OR_GOfRfS_1038
                {
                    OrderStatuses = orderStatusesForReport
                }, securityTicket).Result.ToArray();
            }

            var allOrderStatuses = ordersForReportData.Any() ? cls_Get_Order_Status_History_for_OrderIDs.Invoke(Connection, Transaction, new P_OR_GOSHfOIDs_1528()
            {
                OrderIDs = ordersForReportData.Select(t => t.OrderID).ToArray()
            }, securityTicket).Result.GroupBy(t => t.OrderID).ToDictionary(t => t.Key, t => t.ToList()) : new Dictionary<Guid, List<OR_GOSHfOIDs_1528>>();

            var orderForReportL = new List<OrdersForReportModel>();
            var orderForGlobalReport = new List<OrdersForReportModel>();
            var patientDataCache = new Dictionary<Guid, P_PA_GPDfPID_1124>();
            var doctorDataCache = new Dictionary<Guid, DO_GDDfDID_0823>();
            var practiceDataCache = new Dictionary<Guid, DO_GPDFR_0840>();
            var practiceData = new DO_GPDFR_0840();
            var practiceID = Guid.Empty;
            var documentCreatCount = 0;
            var documentList = new List<Documents>();
            var allDocuments = new List<Documents>();
            var OrderFromDate = ordersForReportData.Any() ? ordersForReportData.Min(ord => ord.OrderCreationTimestamp) : DateTime.MinValue;
            var patientInsurancesCache = cls_Get_Patient_Insurance_Data_on_Tenant.Invoke(Connection, Transaction, securityTicket).Result.GroupBy(t => t.PatientID).ToDictionary(t => t.Key, t => t.ToList());
            var businessParticipants = ORM_CMN_BPT_BusinessParticipant.Query.Search(Connection, Transaction, new ORM_CMN_BPT_BusinessParticipant.Query()
            {
                IsDeleted = false,
                Tenant_RefID = securityTicket.TenantID
            }).GroupBy(t => t.CMN_BPT_BusinessParticipantID).ToDictionary(t => t.Key, t => t.Single());

            var reportName = "";


            var orderGroupedByPharmacy = new Dictionary<Guid, List<OR_GOfRfS_1038>>();

            if (Parameter.GroupByPharmacy)
            {
                orderGroupedByPharmacy = ordersForReportData.GroupBy(x => x.PharmacyID).ToDictionary(x => x.Key, x => x.ToList());
            }
            else
            {
                orderGroupedByPharmacy = new Dictionary<Guid, List<OR_GOfRfS_1038>>() { { Guid.NewGuid(), ordersForReportData.ToList() } };
            }

            foreach (var pharmacy in orderGroupedByPharmacy)
            {
                orderForReportL = new List<OrdersForReportModel>();
                documentList = new List<Documents>();

                #region Prepare data
                foreach (var orderData in pharmacy.Value)
                {
                    // todo: update pre-fetch
                    if (!patientDataCache.ContainsKey(orderData.Patient_RefID))
                    {
                        patientDataCache.Add(orderData.Patient_RefID, cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = orderData.Patient_RefID }, securityTicket).Result);
                    }
                    var patientData = patientDataCache[orderData.Patient_RefID];
                    if (orderData.DoctorID == Guid.Empty)
                    {
                        if (businessParticipants.ContainsKey(orderData.BusinesParticipantWhoCreatedOrder))
                        {
                            var bptWhoCreatedOred = businessParticipants[orderData.BusinesParticipantWhoCreatedOrder];
                            if (bptWhoCreatedOred.IsCompany)
                            {
                                practiceID = cls_Get_PracticeID_for_BusinesParticipant.Invoke(Connection, Transaction, new P_DO_GPIDFBPT_1700() { PracticeBusinessParticipant = orderData.BusinesParticipantWhoCreatedOrder }, securityTicket).Result.FirstOrDefault().PracticeID;
                            }
                            else
                            {
                                var doctorID = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query()
                                {
                                    IsDeleted = false,
                                    Tenant_RefID = securityTicket.TenantID,
                                    BusinessParticipant_RefID = orderData.BusinesParticipantWhoCreatedOrder
                                }).SingleOrDefault().HEC_DoctorID;
                                practiceID = cls_Get_PracticeID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GPIDfDID_1353() { DoctorID = doctorID }, securityTicket).Result.FirstOrDefault().HEC_MedicalPractiseID;
                            }
                        }
                        if (!practiceDataCache.ContainsKey(practiceID))
                        {
                            var practiceD = cls_Get_Practice_Details_for_Report.Invoke(Connection, Transaction, new P_DO_GPDFR_0840() { PracticeID = practiceID }, securityTicket).Result;
                            if (practiceD != null)
                                practiceDataCache.Add(practiceID, practiceD);
                        }
                        practiceData = practiceDataCache[practiceID];
                    }

                    if (!doctorDataCache.ContainsKey(orderData.DoctorID))
                    {
                        doctorDataCache.Add(orderData.DoctorID, cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = orderData.DoctorID }, securityTicket).Result.SingleOrDefault());
                    }

                    var doctorData = doctorDataCache[orderData.DoctorID];

                    var orderForReport = new OrdersForReportModel();

                    switch (patientData.gender)
                    {
                        case 0:
                            orderForReport.PatientSalutation = "Herr";
                            break;
                        case 1:
                            orderForReport.PatientSalutation = "Frau";
                            break;
                        default:
                            orderForReport.PatientSalutation = "-";
                            break;
                    }
                    var orderStatus = "Bestellung";
                    if (orderData.StatusCode == 6 || orderData.StatusCode == 7)
                    {
                        orderStatus = "Stornierung";
                    }
                    else if (orderData.StatusCode == 10)
                    {
                        orderStatus = "Bestellt bei einer nicht kooperierenden Apotheke";
                    }

                    var hipData = patientInsurancesCache[orderData.Patient_RefID].Where(t => t.InsuranceDate.Date <= orderData.CaseCreationDate.Date).FirstOrDefault();
                    orderForReport.HIP = hipData == null ? "-" : hipData.HipName;
                    orderForReport.PatientInsuranceNumber = hipData == null ? "-" : hipData.InsuranceStateCode;
                    orderForReport.PatientStatusNumber = hipData == null ? "-" : hipData.InsuranceIdNumber;
                    orderForReport.PatientFirstName = patientData.patient_first_name;
                    orderForReport.PatientLastName = patientData.patient_last_name;
                    orderForReport.PatientBirthDate = patientData.birthday;
                    orderForReport.CaseNumber = Convert.ToInt32(orderData.CaseNumber);
                    orderForReport.OrderNumber = Convert.ToInt32(orderData.OrderNumber);
                    orderForReport.OrderType = orderStatus;
                    orderForReport.DrugName = orderData.DrugName;
                    orderForReport.Pzn = orderData.PZN;
                    orderForReport.TreatmentDate = orderData.TreatmentDate;
                    orderForReport.DeliveryDate = orderData.DeliveryDate < orderData.TreatmentDate ? orderData.DeliveryDate : orderData.TreatmentDate;
                    orderForReport.DeliveryTimeFrom = orderData.DeliveryTimeFrom.ToString("HH:mm") == "00:00" ? orderData.DeliveryTimeFrom.AddHours(8) : orderData.DeliveryTimeFrom;
                    orderForReport.DeliveryTimeTo = orderData.DeliveryTimeTo.ToString("HH:mm") == "23:59" ? orderData.DeliveryTimeFrom.AddHours(18) : orderData.DeliveryTimeTo;
                    orderForReport.ChargesFee = orderData.ChargesFee ? "Ja" : "Nein";
                    orderForReport.OnlyLabel = orderData.OnlyLabel ? "Ja" : "Nein";
                    orderForReport.PracticeInvoice = orderData.SendInvoiceToPractice ? "Ja" : "Nein";
                    orderForReport.OrderComment = orderData.OrderComment;
                    orderForReport.HeaderComment = orderData.HeaderComment;
                    orderForReport.PharmacyName = orderData.PharmacyID == Guid.Empty ? "-" : orderData.PharmacyName;

                    if (allOrderStatuses.ContainsKey(orderData.OrderID))
                    {
                        var orderStatuses = allOrderStatuses[orderData.OrderID];
                        if (orderStatuses.Any(t => t.StatusCode == 1))
                        {
                            orderForReport.DateOfSubmission = orderStatuses.First(t => t.StatusCode == 1).StatusChangedOn;
                        }
                    }

                    if (orderData.DoctorID != Guid.Empty)
                    {
                        orderForReport.PracticeName = doctorData != null ? doctorData.practice : "-";
                        orderForReport.TreatmentDoctor = doctorData != null ? doctorData.first_name + " " + doctorData.last_name : "-";
                        orderForReport.Street = doctorData != null ? doctorData.address : "-";
                        orderForReport.City = doctorData != null ? doctorData.city : "-";
                        orderForReport.Zip = doctorData != null ? doctorData.ZIP : "-";
                    }
                    else
                    {
                        orderForReport.PracticeName = practiceData != null ? practiceData.Name : "-";
                        orderForReport.TreatmentDoctor = "-";
                        orderForReport.Street = practiceData != null ? practiceData.Street_Name + " " + practiceData.Street_Number : "-";
                        orderForReport.City = practiceData != null ? practiceData.City : "-";
                        orderForReport.Zip = practiceData != null ? practiceData.ZIP : "-";
                    }

                    if (orderData.StatusCode == 6 && !ordersForReportData.Any(r => r.OrderID != orderData.OrderID && orderData.CaseID == orderData.CaseID))
                    {
                        var originalOrder = new OrdersForReportModel();
                        GenericUtils.CloneObject<OrdersForReportModel>(orderForReport, originalOrder);
                        originalOrder.OrderType = "Bestellung";
                        orderForReportL.Add(originalOrder);
                    }

                    orderForReportL.Add(orderForReport);
                }

                orderForGlobalReport.AddRange(orderForReportL);
                #endregion

                #region create report
                if (orderForReportL.Any())
                {
                    var documentExcel = new Documents();
                    if (Parameter.GroupByPharmacy)
                    {
                        reportName = String.Format("{0} {1}", pharmacy.Value.First().PharmacyName, "Bestellungexport f�r Steribase" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm"));
                    }
                    else
                    {
                        reportName = String.Format("{0} {1}", "CompleteOrdersReport", DateTime.Now.ToString("dd.MM.yyyy_HH.mm"));
                    }

                    documentExcel.documentName = reportName;
                    documentExcel.documentOutputLocation = GenerateReportOrders.CreateOrdersXlsReport(orderForReportL, documentExcel.documentName);
                    documentExcel.mimeType = UtilMethods.GetMimeType(documentExcel.documentOutputLocation);
                    documentExcel.receiver = "Steribase";
                    documentList.Add(documentExcel);
                    allDocuments.Add(documentExcel);

                    foreach (var item in documentList)
                    {
                        var ms = new MemoryStream(File.ReadAllBytes(item.documentOutputLocation));
                        var byteArrayFile = ms.ToArray();
                        var _providerFactory = ProviderFactory.Instance;
                        var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                        var uploadedFrom = HttpContext.Current.Request.UserHostAddress;
                        var documentID = documentProvider.UploadDocument(byteArrayFile, item.documentOutputLocation, securityTicket.SessionTicket, uploadedFrom);
                        downloadURL = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);

                        var parameterDoc = new P_ARCH_UD_1326();
                        parameterDoc.DocumentID = documentID;
                        parameterDoc.Mime = item.mimeType;
                        parameterDoc.DocumentName = item.documentName;
                        parameterDoc.DocumentDate = DateForElastic;
                        parameterDoc.Receiver = item.receiver;
                        parameterDoc.ContractID = item.ContractID;
                        if (Parameter.GroupByPharmacy)
                        {
                            parameterDoc.Description = pharmacy.Value.First().PharmacyName + " - Bestellungen von " + OrderFromDate.ToString("dd.MM.yyyy") + " - " + DateForElastic.ToString("dd.MM.yyyy");
                        }
                        else
                        {
                            parameterDoc.Description = reportName;
                        }
                        cls_Upload_Report.Invoke(Connection, Transaction, parameterDoc, securityTicket);
                    }
                    documentCreatCount++;
                }
                #endregion
            }

            #region create all report

            if (documentCreatCount > 1)
            {
                documentList = new List<Documents>();

                if (orderForGlobalReport.Any())
                {
                    var documentExcel = new Documents();
                    reportName = "Bestellungexport f�r Steribase " + DateTime.Now.ToString("dd.MM.yyyy_HH.mm");
                    documentExcel.documentName = reportName;
                    documentExcel.documentOutputLocation = GenerateReportOrders.CreateOrdersXlsReport(orderForGlobalReport, documentExcel.documentName);
                    documentExcel.mimeType = UtilMethods.GetMimeType(documentExcel.documentOutputLocation);
                    documentExcel.receiver = "Steribase";
                    documentList.Add(documentExcel);
                    allDocuments.Add(documentExcel);

                    foreach (var item in documentList)
                    {
                        var ms = new MemoryStream(File.ReadAllBytes(item.documentOutputLocation));
                        var byteArrayFile = ms.ToArray();
                        var _providerFactory = ProviderFactory.Instance;
                        var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                        var uploadedFrom = HttpContext.Current.Request.UserHostAddress;
                        var documentID = documentProvider.UploadDocument(byteArrayFile, item.documentOutputLocation, securityTicket.SessionTicket, uploadedFrom);
                        downloadURL = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);

                        var parameterDoc = new P_ARCH_UD_1326();
                        parameterDoc.DocumentID = documentID;
                        parameterDoc.Mime = item.mimeType;
                        parameterDoc.DocumentName = item.documentName;
                        parameterDoc.DocumentDate = DateForElastic;
                        parameterDoc.Receiver = item.receiver;
                        parameterDoc.ContractID = item.ContractID;
                        parameterDoc.Description = "Bestellungen von " + OrderFromDate.ToString("dd.MM.yyyy") + " - " + DateForElastic.ToString("dd.MM.yyyy");
                        cls_Upload_Report.Invoke(Connection, Transaction, parameterDoc, securityTicket);
                    }
                }
            }


            #region Create Dictionary And Zip
            returnValue.Result = "";
            if (allDocuments.Any())
            {
                var directoryPath = Path.GetTempPath() + reportName;
                var _providerFactory = ProviderFactory.Instance;
                var documentProvider = _providerFactory.CreateDocumentServiceProvider();

                if (documentCreatCount == 1)
                {
                    var doc = allDocuments.First();
                    var fname = directoryPath + "\\" + doc.documentName + ".xlsx";
                    var ms = new MemoryStream(File.ReadAllBytes(doc.documentOutputLocation));

                    byte[] bytes = ms.ToArray();

                    var mime = UtilMethods.GetMimeType(fname);
                    var documentID = documentProvider.UploadDocument(bytes, fname, securityTicket.SessionTicket, HttpContext.Current.Request.UserHostAddress);
                    returnValue.Result = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);
                }
                else
                {

                    if (Directory.Exists(directoryPath))
                        Directory.Delete(directoryPath, true);

                    Directory.CreateDirectory(directoryPath);

                    var fileVersion = 1;
                    foreach (var doc in allDocuments)
                    {
                        var fname = directoryPath + "\\" + doc.documentName + ".xlsx";
                        if (File.Exists(fname))
                            fname = directoryPath + "\\" + doc.documentName + "(" + fileVersion++ + ")" + ".xlsx";
                        else
                            fileVersion = 1;

                        var ms = new MemoryStream(File.ReadAllBytes(doc.documentOutputLocation));
                        File.WriteAllBytes(fname, ms.ToArray());
                    }

                    byte[] bytes = new byte[] { };
                    var zipName = Path.GetTempPath() + "\\" + reportName + ".zip";
                    ZipFile.CreateFromDirectory(directoryPath, zipName);
                    using (FileStream fs = new FileStream(zipName, FileMode.Open))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fs.CopyTo(ms);
                            bytes = ms.ToArray();
                        }
                    }

                    var mime = UtilMethods.GetMimeType(zipName);
                    var documentID = documentProvider.UploadDocument(bytes, zipName, securityTicket.SessionTicket, HttpContext.Current.Request.UserHostAddress);
                    returnValue.Result = documentProvider.GenerateDownloadLink(documentID, securityTicket.SessionTicket, true, true);

                    Directory.Delete(directoryPath, true);
                    File.Delete(zipName);
                }

            }
            #endregion
            #endregion

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_String Invoke(string ConnectionString, P_OR_COR_1437 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection, P_OR_COR_1437 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_String Invoke(DbConnection Connection, DbTransaction Transaction, P_OR_COR_1437 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_String Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_OR_COR_1437 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

                throw new Exception("Exception occured in method cls_Create_Orders_Report", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_OR_COR_1437 for attribute P_OR_COR_1437
    [DataContract]
    public class P_OR_COR_1437
    {
        //Standard type parameters
        [DataMember]
        public int[] Statuses { get; set; }
        [DataMember]
        public Boolean GroupByPharmacy { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_String cls_Create_Orders_Report(,P_OR_COR_1437 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_String invocationResult = cls_Create_Orders_Report.Invoke(connectionString,P_OR_COR_1437 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Complex.Manipulation.P_OR_COR_1437();
parameter.Statuses = ...;
parameter.GroupByPharmacy = ...;

*/
