using DLExcelUtils;
using Edifact_API.Models;
using MMDocConnectMMApp.Models;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMApp.Filters;
using MMDocConnectMMApp.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectMMAppServices;
using MMDocConnectUtils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MMDocConnectDocAppModels;
using MMDocConnectMMAppModels;
using Microsoft.AspNet.SignalR;
using MediosConnectSignalR;
using System.Threading;
using LogUtils;
using System.Reflection;
using DLCore_TokenVerification;
using System.Globalization;

namespace MMDocConnectMMApp.Controllers
{

    [RoutePrefix("api/dashboard")]
    [AuthenticationFilter]
    public class DashboardController : BaseApiController
    {
        private string connectionString;
        private string sessionToken;
        private string userLoginEmail;
        private object state;
        private Timer dashboardTimer;

        IDashboardDataServices dashboardDataService;
        public DashboardController()
        {
            this.dashboardDataService = new DashboardDataService();
            this.connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["activeconnection"]].ConnectionString;
        }

        [Route("GetTilesInfo")]
        [HttpGet]
        public HttpResponseMessage GetTilesInfo([FromUri]string loginEmail = null)
        {
            TransactionalInformation dashboardTransaction = new TransactionalInformation();

            sessionToken = SessionToken;

            var timeout = 5000;

            try
            {
                timeout = Convert.ToInt32(ConfigurationManager.AppSettings["notificationTimeoutInMiliseconds"]);
            }
            catch (Exception ex)
            {
                // left empty, since timeout is already set, we don't care about the exception.
            }

            if (loginEmail != null)
            {
                userLoginEmail = loginEmail;

                if (!SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Contains(userLoginEmail))
                    SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Add(userLoginEmail);

                dashboardTimer = new Timer(new TimerCallback(update), state, 0, timeout);
            }

            var response = dashboardDataService.GetTilesInfo(connectionString, sessionToken, out dashboardTransaction);

            if (dashboardTransaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        private void update(object state)
        {
            try
            {
                if (SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Contains(userLoginEmail))
                {
                    TransactionalInformation dashboardTransaction = new TransactionalInformation();
                    var response = dashboardDataService.GetTilesInfo(connectionString, sessionToken, out dashboardTransaction);

                    if (dashboardTransaction.ReturnStatus)
                    {
                        if (!SignalRNotifier.Instance.lastSentDashboardData.ContainsKey(sessionToken) || SignalRNotifier.Instance.lastSentDashboardData[sessionToken].AnyTileDataChanged(response))
                        {
                            if (!SignalRNotifier.Instance.lastSentDashboardData.ContainsKey(sessionToken))
                                SignalRNotifier.Instance.lastSentDashboardData.Add(sessionToken, response);
                            else
                                SignalRNotifier.Instance.lastSentDashboardData[sessionToken] = response;

                            GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>().Clients.Group(userLoginEmail).updateDashboard(response);
                        }
                    }
                    else
                    {
                        GlobalHost.ConnectionManager.GetHubContext<NotificationsHub>().Clients.Group(userLoginEmail).error(dashboardTransaction);
                        SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Remove(userLoginEmail);
                        dashboardTimer.Dispose();
                    }
                }
                else
                {
                    SignalRNotifier.Instance.usersThatAreAlreadyReceievingNewDashboardData.Remove(userLoginEmail);
                    dashboardTimer.Dispose();
                }
            }
            catch { }
        }

        [Route("getOrderForTile")]
        [HttpGet]
        public HttpResponseMessage getOrderForTile()
        {

            TransactionalInformation transaction = new TransactionalInformation();
            OrderForTileApiModel orderForTileApiModel = new OrderForTileApiModel();
            Order_Model_for_Tile orderList = dashboardDataService.GetOrderForTile(connectionString, SessionToken, out transaction);
            orderForTileApiModel.orderForTile = orderList;

            if (transaction.ReturnStatus)
                return Request.CreateResponse<OrderForTileApiModel>(HttpStatusCode.OK, orderForTileApiModel);

            return Request.CreateResponse<OrderForTileApiModel>(HttpStatusCode.BadRequest, orderForTileApiModel);
        }

        [Route("getAllCasesInStatus")]
        [HttpGet]
        public HttpResponseMessage getAllCasesInStatus()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CaseSettlementApiModel CaseSettlementApi = new CaseSettlementApiModel();

            Case_Settlement_Model casesForSettlement = dashboardDataService.getAllCasesInStatus(new string[] { "1" }, connectionString, SessionToken, out transaction);

            CaseSettlementApi.CaseSettlement = casesForSettlement;

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, CaseSettlementApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("getAllCasesForPositiveResponse")]
        [HttpGet]
        public HttpResponseMessage getAllCasesForPositiveResponse()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CaseSettlementApiModel CaseSettlementApi = new CaseSettlementApiModel();

            Case_Settlement_Model casesForSettlement = dashboardDataService.getAllCasesInStatus(new string[] { "2", "11" }, connectionString, SessionToken, out transaction);

            CaseSettlementApi.CaseSettlement = casesForSettlement;

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, CaseSettlementApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("GetTemporaryAcDoctorsCount")]
        [HttpGet]
        public HttpResponseMessage GetTemporaryAcDoctorsCount()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            var response = dashboardDataService.GetTemporaryAcDoctorsCount(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, response);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


        [Route("getAllCasesOnHold")]
        [HttpGet]
        public HttpResponseMessage getAllCasesOnHold()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CaseSettlementApiModel CaseSettlementApi = new CaseSettlementApiModel();

            Case_Settlement_Model casesForSettlement = dashboardDataService.getAllCasesInStatus(new string[] { "3" }, connectionString, SessionToken, out transaction);
            CaseSettlementApi.CaseSettlement = casesForSettlement;

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, CaseSettlementApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("getAllCasesError")]
        [HttpGet]
        public HttpResponseMessage getAllCasesError()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CaseSettlementApiModel CaseSettlementApi = new CaseSettlementApiModel();

            Case_Settlement_Model casesForSettlement = dashboardDataService.getAllCasesInStatus(new string[] { "5" }, connectionString, SessionToken, out transaction);
            CaseSettlementApi.CaseSettlement = casesForSettlement;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, CaseSettlementApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("getAllCasesForPayment")]
        [HttpGet]
        public HttpResponseMessage getAllCasesForPayment()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CaseSettlementApiModel CaseSettlementApi = new CaseSettlementApiModel();
            Case_Settlement_Model casesForSettlement = dashboardDataService.getAllCasesInStatus(new string[] { "4" }, connectionString, SessionToken, out transaction);
            CaseSettlementApi.CaseSettlement = casesForSettlement;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, CaseSettlementApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("ordersFromXls")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            List<int> orderNumbers = new List<int>();
            TransactionalInformation transaction = new TransactionalInformation();
            OrdersChangeInfoApiModel orderChangeApi = new OrdersChangeInfoApiModel();
            if (!Request.Content.IsMimeMultipartContent())
                return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);

            var provider = new MultipartMemoryStreamProvider();
            await Request.Content.ReadAsMultipartAsync(provider);
            foreach (var file in provider.Contents)
            {
                var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                var buffer = await file.ReadAsByteArrayAsync();
                MemoryStream ms = new MemoryStream(buffer);
                bool hasHeader = true;
                System.Data.DataTable excelData = ExcelUtils.getDataFromExcelFileNoPath(ms, hasHeader);
                try
                {

                    foreach (System.Data.DataRow item in excelData.Rows)
                    {
                        if (item.ItemArray[0].ToString() != "")
                        {
                            orderNumbers.Add(int.Parse(item.ItemArray[0].ToString()));
                        }
                    }
                }
                catch (Exception)
                {

                    return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                }
            }
            OrdersChangeInfo orders = dashboardDataService.shipDrugOrders(orderNumbers, connectionString, SessionToken, out transaction);
            orderChangeApi.OrdersChangeInfoApi = orders;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, orderChangeApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);

        }

        [Route("NegativeResponse")]
        [HttpPost]
        public HttpResponseMessage NegativeResponse(NegativeResponseCaseModel negativeResponse)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            dashboardDataService.NegativeResponseConfirm(negativeResponse, connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, "ok");
            return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


        [Route("PositiveResponse")]
        [HttpPost]
        public async Task<HttpResponseMessage> PositiveResponse()
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            try
            {
                TransactionalInformation transaction = new TransactionalInformation();
                ResponseCasesApiModel apiModel = new ResponseCasesApiModel();
                if (!Request.Content.IsMimeMultipartContent())
                    return Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
                List<PositiveResponseModel> PositiveResponseL = new List<PositiveResponseModel>();
                var provider = new MultipartMemoryStreamProvider();
                await Request.Content.ReadAsMultipartAsync(provider);
                foreach (var file in provider.Contents)
                {
                    var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                    int i = filename.LastIndexOf('.');
                    string fileExtension = filename.Substring(filename.Length - 4);

                    if (fileExtension == "xlsx".ToLower() || fileExtension == ".xls".ToLower())
                    {
                        apiModel.isPositiveResponce = true;
                        var buffer = await file.ReadAsByteArrayAsync();
                        MemoryStream ms = new MemoryStream(buffer);
                        bool hasHeader = true;


                        System.Data.DataTable excelData = ExcelUtils.getDataFromExcelFileNoPath(ms, hasHeader);
                        try
                        {
                            foreach (System.Data.DataRow item in excelData.Rows)
                            {
                                if (item.ItemArray.Any() && item.ItemArray[0].ToString() != "")
                                {
                                    PositiveResponseModel positiveModel = new PositiveResponseModel();
                                    try
                                    {
                                        string invoiceNo = item.ItemArray[2].ToString();
                                        if (invoiceNo != "")
                                        {
                                            var bill_position_number = "000000000000";
                                            bill_position_number += (double.Parse(item.ItemArray[2].ToString())).ToString();
                                            bill_position_number = bill_position_number.Substring(bill_position_number.Length - 12, 12);
                                            positiveModel.InvoiceNumberHIP = bill_position_number;
                                            PositiveResponseL.Add(positiveModel);
                                        }
                                    }
                                    catch (Exception ex)
                                    {

                                    };
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var userSecurityTicket = new BaseVerification().VerifySessionToken(SessionToken);
                            Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                            transaction.ReturnMessage = new List<string>();
                            transaction.IsException = true;
                            transaction.ReturnMessage.Add(ex.StackTrace);
                            transaction.ReturnMessage.Add(ex.Message);
                            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                        }
                    }
                    else if (fileExtension.ToLower() == ".edi" || fileExtension.ToLower() == ".txt")
                    {
                        try
                        {
                            var buffer = await file.ReadAsByteArrayAsync();
                            MemoryStream ms = new MemoryStream(buffer);
                            EDIMessage ediMsg = new EDIMessage(ms);
                            var result = ediMsg.GetParsedEdifactFile();
                            List<NegativeResponseModel> negativeResponseList = new List<NegativeResponseModel>();

                            foreach (var item in result.transmitionMessages)
                            {
                                NegativeResponseModel response = new NegativeResponseModel();
                                response.billPositionNumber = item.Rgi.Segment5.Value.Split('K').Last();
                                PositiveResponseL.Add(new Models.PositiveResponseModel() { InvoiceNumberHIP = item.Rgi.Segment5.Value.Split('K').Last() });
                                response.message = String.Join("; ", item.Fhl.Select(t => t.Segment4.Value).ToArray());
                                response.hipId = item.Ivk.Segment4.Value;

                                negativeResponseList.Add(response);
                            }

                            var billNumberIDsList = negativeResponseList.Select(j => j.billPositionNumber).ToList();
                            var nonEligibleStatuses = dashboardDataService.CasesWithNonEligibleStatuses(billNumberIDsList, connectionString, SessionToken, out transaction);

                            apiModel.NonEligibleStatuses += nonEligibleStatuses.Count;
                            apiModel.TotalCases += negativeResponseList.Count;
                            apiModel.isPositiveResponce = false;
                            apiModel.NegativeModel.ediMessage = ediMsg.RawMessage;
                            apiModel.NegativeModel.ediName = filename;
                            var dateToHip_string = result.Unb.Segment5.Value;
                            try
                            {
                                apiModel.NegativeModel.dateOfTransmitionToHIP = DateTime.ParseExact(dateToHip_string, "yyyyMMdd", new CultureInfo("de", true));
                            }
                            catch
                            {

                            }

                            if (nonEligibleStatuses.Count > 0)
                            {
                                foreach (var billNumber in nonEligibleStatuses)
                                {
                                    var itemToRemove = negativeResponseList.Where(h => double.Parse(h.billPositionNumber) == double.Parse(billNumber)).SingleOrDefault();
                                    if (itemToRemove != null)
                                        negativeResponseList.Remove(itemToRemove);
                                }
                                apiModel.NegativeModel.NegativeResponseList.AddRange(negativeResponseList);
                            }
                            else
                                apiModel.NegativeModel.NegativeResponseList.AddRange(negativeResponseList);
                        }
                        catch (Exception ex)
                        {
                            var userSecurityTicket = new BaseVerification().VerifySessionToken(SessionToken);
                            Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                            transaction.ReturnMessage = new List<string>();
                            transaction.IsException = true;
                            transaction.ReturnMessage.Add(ex.StackTrace);
                            transaction.ReturnMessage.Add(ex.Message);
                            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
                        }

                    }
                }
                PositioveResponseCaseModel model = dashboardDataService.positiveResponse(PositiveResponseL, connectionString, SessionToken, out transaction);
                apiModel.PositiveModel = model;
                apiModel.TotalCases = model.CasesImported;
                apiModel.NonEligibleStatuses = model.CasesImportedXLs;

                if (transaction.ReturnStatus)
                    return Request.CreateResponse(HttpStatusCode.OK, apiModel);

                return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
            }
            catch (Exception ex)
            {
                var userSecurityTicket = new BaseVerification().VerifySessionToken(SessionToken);
                Logger.LogInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, userSecurityTicket, ex));

                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }

        [Route("changeOrders")]
        [HttpPost]
        public HttpResponseMessage changeOrders(List<OrderForStatusChange> orders)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            dashboardDataService.changeOrderStatus(orders, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, "ok");

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("positiveResponseConfirm")]
        [HttpPost]
        public HttpResponseMessage positiveResponseConfirm(List<PositiveResponseModel> PositiveResponse)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            dashboardDataService.positiveResponseConfirm(PositiveResponse, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, "ok");

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


        [Route("CreateReportAndChangeStatusToFs2")]
        [HttpGet]
        public HttpResponseMessage CreateReportAndChangeStatusToFs2([FromUri] DateTime? dateFrom = default(DateTime?))
        {
            TransactionalInformation transaction = new TransactionalInformation();

            dashboardDataService.CreateReportAndChangeStatusToFs2(dateFrom, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, "ok");

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


        [Route("ChangeAllOrderStatus")]
        [HttpGet]
        public HttpResponseMessage ChangeAllOrderStatus()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var result = dashboardDataService.changeAllOrderStatus(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("ChangeCasesPayment")]
        [HttpPost]
        public HttpResponseMessage ChangeCasesPayment(Payment_Model payment)
        {
            TransactionalInformation transaction = new TransactionalInformation();

            bool onlystatus = dashboardDataService.ChangeCasesPayment(payment, connectionString, SessionToken, out transaction);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, onlystatus);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("getAllCasesForReport")]
        [HttpGet]
        public HttpResponseMessage getAllCasesForReport()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            CaseSettlementApiModel CaseSettlementApi = new CaseSettlementApiModel();
            Case_Settlement_Model casesForSettlement = dashboardDataService.getAllCasesReport(connectionString, SessionToken, out transaction);
            CaseSettlementApi.CaseSettlement = casesForSettlement;
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, CaseSettlementApi);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("createReportAndDownloadItAok")]
        [HttpGet]
        public HttpResponseMessage createReportAndDownloadItAok()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            string downloadURL = dashboardDataService.createReportAndDownloadIt(connectionString, SessionToken, out transaction, true);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, downloadURL);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }

        [Route("createReportAndDownloadItNonAok")]
        [HttpGet]
        public HttpResponseMessage createReportAndDownloadItNonAok()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            string downloadURL = dashboardDataService.createReportAndDownloadIt(connectionString, SessionToken, out transaction, false);
            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, downloadURL);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


        [Route("CreateCompleteOrdersReport")]
        [HttpGet]
        public HttpResponseMessage CreateCompleteOrdersReport()
        {
            TransactionalInformation transaction = new TransactionalInformation();

            var result = dashboardDataService.createCompleteOrdersReport(connectionString, SessionToken, out transaction);

            if (transaction.ReturnStatus)
                return Request.CreateResponse(HttpStatusCode.OK, result);

            return Request.CreateResponse<TransactionalInformation>(HttpStatusCode.BadRequest, transaction);
        }


    }
}