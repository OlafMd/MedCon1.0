using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Order.Atomic.Retrieval;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Linq;
using MMDocConnectDBMethods.Case.Atomic.Manipulation;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Order.Complex.Manipulation;
using MMDocConnectUtils.ExcelTemplates;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using System.Globalization;
using System.Diagnostics;
using BOp.Exceptions;

namespace MMDocConnectMMAppServices
{

    public class DashboardDataService : BaseVerification, IDashboardDataServices
    {
        #region RETRIEVAL

        public TileInfo GetTilesInfo(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("de-DE");

            var response = new TileInfo();

            try
            {
                var cases = cls_Get_all_Cases_in_FS_statuses.Invoke(connectionString, new P_CAS_GACiFS_1515() { FStatus = new string[] { "1", "2", "11", "4", "3", "5" } }, userSecurityTicket).Result;

                response.settlementTile = GetTileData(cases, new int[] { 1 });
                response.responseTile = GetTileData(cases, new int[] { 2, 11 });
                response.paymentTile = GetTileData(cases, new int[] { 4 });
                response.errorCorrectionsTile = GetTileData(cases, new int[] { 5 });
                response.casesOnHoldTile = GetTileData(cases, new int[] { 3 });

                #region COMPLETE ORDERS REPORT TILE
                var numberOfAllOrders = GetAllOrderForTile(connectionString, sessionTicket, out transaction);
                if (transaction.ReturnStatus)
                    response.completeOrdersReportTile = new TileInfoModel()
                    {
                        numberOfCases = string.Format("{0:n0}", numberOfAllOrders.number_of_tiles, new System.Globalization.CultureInfo("de", true))
                    };
                else
                    throw new Exception(transaction.ReturnMessage + "; retrieve all orders");
                #endregion

                #region DRUG ORDERS TILE
                var numberOfOrders = GetOrderForTile(connectionString, sessionTicket, out transaction);
                if (transaction.ReturnStatus)
                    response.drugOrdersTile = new TileInfoModel()
                    {
                        dateOfOldest = numberOfOrders.date_for_tile,
                        numberOfCases = string.Format("{0:n0}", numberOfOrders.number_of_tiles, new System.Globalization.CultureInfo("de", true))
                    };
                else
                    throw new Exception(transaction.ReturnMessage + "; retrieve MO1 drug orders");
                #endregion

                #region COMPLETE REPORT TILE
                var allCases = getAllCasesReport(connectionString, sessionTicket, out transaction);
                if (transaction.ReturnStatus)
                    response.completeReportTile = new TileInfoModel()
                    {
                        numberOfCases = string.Format("{0:n0}", allCases.numberOdCases, new System.Globalization.CultureInfo("de", true)) + " / " + string.Format("{0:n0}", allCases.numberOfACCases, new System.Globalization.CultureInfo("de", true))
                    };
                else
                    throw new Exception(transaction.ReturnMessage + "; retrieve all cases");
                #endregion

                #region TEMPORARY DOCTORS TILE
                var temporaryDoctors = GetTemporaryAcDoctorsCount(connectionString, sessionTicket, out transaction);
                if (transaction.ReturnStatus)
                    response.temporaryDoctorsTile = new TileInfoModel()
                    {
                        dateOfOldest = temporaryDoctors.dateofOldestACDoctorChange,
                        numberOfCases = string.Format("{0:n0}", temporaryDoctors.numberOfAcDocs, new System.Globalization.CultureInfo("de", true))
                    };
                else
                    throw new Exception(transaction.ReturnMessage + "; retrieve temporary doctors");
                #endregion
            }
            catch (Exception ex)
            {
                if (!(ex is SDKServiceException))
                {
                    Logger.LogInfo(new LogEntry(null, null, connectionString, method, userSecurityTicket, ex));
                }

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return response;
        }

        private TileInfoModel GetTileData(IEnumerable<CAS_GACiFS_1515> cases, IEnumerable<int> fsStatus)
        {
            var filteredCases = cases.Where(c => fsStatus.Any(f => f == c.StatusNumber));

            if (filteredCases.Any())
            {
                var oldest_case = filteredCases.Min(dt => dt.TreatmentDate);

                return new TileInfoModel()
                {
                    ammountOfMoney = string.Format("{0:n}", filteredCases.Sum(cs => cs.NumberForPayment), new System.Globalization.CultureInfo("de", true)) + " €",
                    dateOfOldest = oldest_case == DateTime.MinValue ? "-" : oldest_case.ToString("dd.MM.yyyy"),
                    numberOfCases = string.Format("{0:n0}", filteredCases.GroupBy(gr => new { gr.HeaderID, gr.CodeForType }).Count(), new System.Globalization.CultureInfo("de", true))
                };
            }

            return new TileInfoModel() { ammountOfMoney = string.Format("{0:n}", 0, new System.Globalization.CultureInfo("de", true)) + " €", dateOfOldest = "-", numberOfCases = "0" };
        }

        public Order_Model_for_Tile GetAllOrderForTile(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();

            transaction = new TransactionalInformation();
            Order_Model_for_Tile modelorder = new Order_Model_for_Tile();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var order_data = cls_Get_Number_of_Orders_for_Complete_Report.Invoke(connectionString, userSecurityTicket).Result;
                if (order_data != null)
                {
                    modelorder.number_of_tiles = order_data.number_of_tiles;
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(null, null, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return modelorder;
        }

        public Order_Model_for_Tile GetOrderForTile(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            //var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            Order_Model_for_Tile modelorder = new Order_Model_for_Tile();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var order_data = cls_Get_All_MO1_Orders.Invoke(connectionString, userSecurityTicket).Result;
                if (order_data != null)
                {
                    modelorder.date_for_tile = order_data.date_for_tile == DateTime.MinValue ? "-" : order_data.date_for_tile.ToString("dd.MM.yyyy");
                    modelorder.number_of_tiles = order_data.number_of_tiles;
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(null, null, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return modelorder;
        }

        public Case_Settlement_Model getAllCasesInStatus(string[] statusList, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            //var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            Case_Settlement_Model caseSettlementModel = new Case_Settlement_Model();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                CAS_GACiFS_1515[] casesFs = cls_Get_all_Cases_in_FS_statuses.Invoke(connectionString, new P_CAS_GACiFS_1515() { FStatus = statusList }, userSecurityTicket).Result;
                if (casesFs.Length > 0)
                {
                    caseSettlementModel.numberOdCases = casesFs.GroupBy(gr => new { gr.HeaderID, gr.CodeForType }).Select(grp => grp.ToList()).ToList().Count();
                    caseSettlementModel.CaseVolumeCount = casesFs.Sum(cs => cs.NumberForPayment);
                    caseSettlementModel.oldest_case = casesFs.Min(dt => dt.TreatmentDate);
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(null, null, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return caseSettlementModel;
        }

        public Case_Settlement_Model getAllCasesReport(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            //var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            Case_Settlement_Model caseSettlementModel = new Case_Settlement_Model();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                caseSettlementModel.numberOdCases = cls_Count_Treatment_or_Aftercare.Invoke(connectionString, new P_CAS_CTOA_1545() { typeOfAction = "mm.docconect.doc.app.planned.action.treatment" }, userSecurityTicket).Result.NumberOfActions;
                caseSettlementModel.numberOfACCases = cls_Get_Aftercares_Count.Invoke(connectionString, new P_CAS_GAC_1104()
                {
                    ActionTypeGpmID = EActionType.PlannedAftercare.Value()
                }, userSecurityTicket).Result.AftercareCount;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(null, null, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return caseSettlementModel;
        }

        public List<string> CasesWithNonEligibleStatuses(List<string> negativeCaseNumberIDs, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();
            List<string> casesWithNonEligibleStatuses = new List<string>();
            try
            {
                P_CAS_GCWSNbI_1511 param = new P_CAS_GCWSNbI_1511();
                List<P_CAS_GCWSNbI_1511_BillNumberArray> paramLIst = new List<P_CAS_GCWSNbI_1511_BillNumberArray>();
                foreach (var item in negativeCaseNumberIDs)
                {

                    var bill_position_number = "000000000000";
                    bill_position_number += (double.Parse(item)).ToString();
                    bill_position_number = bill_position_number.Substring(bill_position_number.Length - 12, 12);

                    P_CAS_GCWSNbI_1511_BillNumberArray paramItem = new P_CAS_GCWSNbI_1511_BillNumberArray();
                    paramItem.bullNumber = bill_position_number;
                    paramLIst.Add(paramItem);
                }
                param.BillNumberArray = paramLIst.ToArray();
                var result = cls_Get_Negative_Cases_Which_Should_Not_be_Imported.Invoke(connectionString, param, userSecurityTicket).Result;

                foreach (var item in result)
                {
                    casesWithNonEligibleStatuses.Add(item.bullNumber);
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return casesWithNonEligibleStatuses;
        }

        public TemporaryDoctorDashboardTileModel GetTemporaryAcDoctorsCount(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            //var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            TemporaryDoctorDashboardTileModel response = new TemporaryDoctorDashboardTileModel();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var doctor_count = cls_Get_Temporary_Doctor_Count_and_Oldest_Date.Invoke(connectionString, userSecurityTicket).Result;
                if (doctor_count != null)
                {
                    response.dateofOldestACDoctorChange = doctor_count.dateofOldestACDoctorChange != DateTime.MinValue ? doctor_count.dateofOldestACDoctorChange.ToString("dd.MM.yyyy") : "-";
                    response.numberOfAcDocs = doctor_count.numberOfAcDocs;
                }
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(null, null, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return response;
        }

        public OrdersChangeInfo shipDrugOrders(List<int> OrderForShipping, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            List<OrderForStatusChange> orderChangeL = new List<OrderForStatusChange>();
            transaction = new TransactionalInformation();
            OR_GOwS_1428[] ordersInMo2 = cls_Get_all_Orders_with_Status.Invoke(connectionString, new P_OR_GOwS_1428() { Status = new string[] { "2" } }, userSecurityTicket).Result;
            OrdersChangeInfo orderToReturn = new OrdersChangeInfo();

            try
            {
                foreach (var ordSt in OrderForShipping)
                {
                    var data = ordersInMo2.Where(od => od.OrderNumber == ordSt).SingleOrDefault();
                    if (data != null)
                    {

                        OrderForStatusChange orderChange = new OrderForStatusChange();

                        orderChange.CaseID = data.CaseID;
                        orderChange.OrderID = data.OrderID;
                        orderChange.StatusTo = 3;
                        orderChange.StatusToStr = "MO3";
                        orderChangeL.Add(orderChange);
                    }
                }

                orderToReturn.orderForChange = orderChangeL;
                orderToReturn.NumberChangeXls = OrderForShipping.Count();
                orderToReturn.NumberChange = OrderForShipping.Count() - orderChangeL.Count();
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return orderToReturn;
        }

        public PositioveResponseCaseModel positiveResponse(List<PositiveResponseModel> PositiveResponseL, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            PositioveResponseCaseModel positiveModel = new PositioveResponseCaseModel();
            try
            {
                var billPositionsAwaitingResponseCount = cls_Get_BillPositionNumbers_waiting_Hip_Response.Invoke(connectionString, new P_CAS_GBPNwHipR_1853()
                {
                    // this is done to remove leading zeros
                    BillNumbers = PositiveResponseL.Select(t => Double.Parse(t.InvoiceNumberHIP).ToString()).ToArray()
                }, userSecurityTicket).Result.position_count;

                positiveModel.CasesImported = PositiveResponseL.Count;
                positiveModel.CasesImportedXLs = PositiveResponseL.Count - billPositionsAwaitingResponseCount;
                positiveModel.positiveModelL = PositiveResponseL;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return positiveModel;
        }
        public string createReportAndDownloadItAok(string connectionString, string sessionTicket, out TransactionalInformation transaction )
        {
            return createReportAndDownloadIt(connectionString, sessionTicket, out transaction, true);
        }

        public string createReportAndDownloadItNonAok(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            return createReportAndDownloadIt(connectionString, sessionTicket, out transaction, false);
        }

        public string createReportAndDownloadIt(string connectionString, string sessionTicket, out TransactionalInformation transaction, bool? ShowOnlyAok = null)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);

            transaction = new TransactionalInformation();
            CAS_CGR_1400 ReportCreated = new CAS_CGR_1400();
            try
            {
                ReportCreated = cls_Create_Report_for_All_Cases.Invoke(connectionString, new P_CAS_CGR_1400 { ShowOnlyAok = ShowOnlyAok }, userSecurityTicket).Result;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                if (ex.InnerException != null)
                {
                    transaction.ReturnMessage.Add(ex.InnerException.Message);
                    transaction.ReturnMessage.Add(ex.InnerException.StackTrace);
                }
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return ReportCreated.DownloadURL;
        }
        #endregion

        #region MANIPULATION
        public void changeOrderStatus(List<OrderForStatusChange> orders, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            try
            {
                P_OR_COS_0840 Parameter = new P_OR_COS_0840()
                {
                    ParameterArray = orders.Select(ord =>
                    {
                        P_OR_COS_0840a orderChange = new P_OR_COS_0840a();
                        orderChange.CaseID = ord.CaseID;
                        orderChange.Order_ID = ord.OrderID;
                        orderChange.Status_To = ord.StatusTo;
                        orderChange.Status_To_Str = ord.StatusToStr;

                        return orderChange;
                    }).ToArray()
                };

                cls_Change_Order_Status.Invoke(connectionString, Parameter, userSecurityTicket);
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, orders));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }


        }

        public string changeAllOrderStatus(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            var reportURL = "";
            try
            {
                P_OR_CAOS_1424 parameter = new P_OR_CAOS_1424();
                parameter.Status_From = 1;
                parameter.Status_To = 2;
                parameter.Status_To_Str = "MO2";
                var data = cls_Change_all_Order_Statuses.Invoke(connectionString, parameter, userSecurityTicket).Result;
                reportURL = data.ReportURL;
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, data.Orders.Select(ord =>
                {
                    return new OrderLogObject
                    {
                        OrderNumber = ord.OrderNumber,
                        CurrentOrderStatus = parameter.Status_To
                    };
                })));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return reportURL;
        }

        public void CreateReportAndChangeStatusToFs2(DateTime? dateFrom, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();
            try
            {
                DateTime DateForElastic = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Local);
                P_CAS_CCS_1516 parameter = new P_CAS_CCS_1516();
                parameter.StatusFrom = 1;
                parameter.StatusTo = 2;
                parameter.AreCasesFiltered = false;
                parameter.UpdatedCasesSubmittedBeforeDate = dateFrom;
                var casesForReportChange = cls_Change_Case_Status.Invoke(connectionString, parameter, userSecurityTicket).Result.caseList;
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, casesForReportChange));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }

        public void positiveResponseConfirm(List<PositiveResponseModel> PositiveResponseConfirm, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();

            P_CAS_CCS_1516 parameter = new P_CAS_CCS_1516();
            parameter.StatusFrom = 2;
            parameter.StatusTo = 4;
            parameter.AreCasesFiltered = true;

            try
            {
                parameter.PositionNumbers = PositiveResponseConfirm.Select(t => Convert.ToDouble(t.InvoiceNumberHIP)).ToArray();
                var casesForReportChange = cls_Change_Case_Status.Invoke(connectionString, parameter, userSecurityTicket).Result.caseList;
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, casesForReportChange));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.ReturnMessage.Add(ex.StackTrace);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }

        public void NegativeResponseConfirm(NegativeResponseCaseModel negativeResponse, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();
            try
            {
                var result = cls_Change_Case_Status.Invoke(connectionString, new P_CAS_CCS_1516()
                {
                    EdifactFileName = negativeResponse.ediName,
                    EdifactMessage = negativeResponse.ediMessage,
                    HipIkNumber = negativeResponse.NegativeResponseList.Any() ? negativeResponse.NegativeResponseList.First().hipId : "",
                    PositionNumbers = negativeResponse.NegativeResponseList.Select(t => Double.Parse(t.billPositionNumber)).ToArray(),
                    StatusFrom = 2,
                    StatusTo = 5
                }, userSecurityTicket).Result.caseList;

                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, result));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
        }

        public bool ChangeCasesPayment(Payment_Model payment, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            var userSecurityTicket = VerifySessionToken(sessionTicket);
            transaction = new TransactionalInformation();
            try
            {
                var caseModelL = new List<CaseForReportModel>();
                var parameter = new P_CAS_CCS_1516();
                parameter.StatusFrom = 4;
                if (payment.paymentStatusChange)
                    parameter.StatusTo = 7;
                else
                    parameter.StatusTo = 4;
                parameter.AreCasesFiltered = false;
                parameter.AreCasesPositive = true;

                if (!payment.paymentStatusChange)
                {
                    parameter.AreCasesPaymentAndStatus = true;
                }
                if (!String.IsNullOrEmpty(payment.date))
                {
                    parameter.StatusChangedOnDate = DateTime.ParseExact(payment.date, "dd.MM.yyyy", new CultureInfo("de", true));
                }

                var casesForReportChange = cls_Change_Case_Status.Invoke(connectionString, parameter, userSecurityTicket).Result.caseList;
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, casesForReportChange));
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return payment.paymentStatusChange;
        }

        public string createCompleteOrdersReport(string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);
            var reportURL = "";
            try
            {
                reportURL = cls_Create_Orders_Report.Invoke(connectionString, new P_OR_COR_1437
                {
                    Statuses = new int[] { 1, 2, 3, 4, 6, 7, 10 }
                }, userSecurityTicket).Result;
            }
            catch (Exception ex)
            {
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return reportURL;
        }

        #endregion
    }
}
