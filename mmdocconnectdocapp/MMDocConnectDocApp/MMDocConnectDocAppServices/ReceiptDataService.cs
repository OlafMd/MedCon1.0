using BOp.Providers;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.MainData.Complex.Retrieval;
using MMDocConnectDocAppInterfaces;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Receipt.Manipulation;
using MMDocConnectElasticSearchMethods.Receipt.Retrieval;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectDocAppServices
{
    public class ReceiptDataService : BaseVerification, IReceiptDataService
    {
        IFormatProvider culture = new System.Globalization.CultureInfo("de", true);

        #region RETRIEVAL
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sort_parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        /// Get items from elastic to receipt page list 
        public List<Receipt_Model> GetReceiptItems(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Guid> response = new List<Guid>();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            List<Receipt_Model> receipts = new List<Receipt_Model>();
            try
            {
                string doctor_id = cls_Get_DoctorID_for_AccountID.Invoke(connectionString, securityTicket).Result.DoctorID.ToString();
                receipts = Retrieve_Receipts.Get_Receipt_Items(sort_parameter, doctor_id, securityTicket);

                if (receipts.Any())
                    Add_Item_to_Receipts.Import_Receipt_Item_to_ElasticDB(receipts.Select(item => { item.isViewed = true; return item; }).ToList(), securityTicket.TenantID.ToString());
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }
            return receipts;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        /// get id for download pdf report
        public string GetDownloadURL(Receipt_Model item, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Guid> response = new List<Guid>();
            var securityTicket = VerifySessionToken(sessionTicket);
            var data = cls_Get_Account_Information_with_PracticeID.Invoke(connectionString, securityTicket).Result;

            var downloadURL = "";

            try
            {
                var _providerFactory = ProviderFactory.Instance;
                var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                Guid id = Guid.Empty;
                Guid.TryParse(item.documentID, out id);
                downloadURL = documentProvider.GenerateImageThumbnailLink(id, sessionTicket, true, null, true);
            }
            catch (Exception ex)
            {
                Logger.LogDocAppInfo(new LogEntry(ipInfo.address, ipInfo.agent, connectionString, method, securityTicket, ex), data.PracticeName);

                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
                transaction.IsAuthenicated = true;
                transaction.IsException = true;
            }

            return downloadURL;
        }
        #endregion
    }
}
