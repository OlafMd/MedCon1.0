using BOp.Providers;
using DLCore_TokenVerification;
using LogUtils;
using MMDocConnectDBMethods.Archive.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Archive.Retrieval;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMAppInterfaces;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppServices
{
    public class ArchiveDataService : BaseVerification, IArchiveDataServices
    {
        #region RETRIEVAL
        public List<Archive_Model> GetAllItemsForArchive(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {            
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            transaction = new TransactionalInformation();
            List<Archive_Model> archItems = new List<Archive_Model>();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                archItems = Get_Archive_Items.Get_Archived_items(sort_parameter, userSecurityTicket);
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

            return archItems;
        }

        public string GetDownloadURL(Archive_Model item, string connectionString, string sessionTicket, out TransactionalInformation transaction)
        {            
            var method = MethodInfo.GetCurrentMethod();
            var ipInfo = Util.GetIPInfo(HttpContext.Current.Request);

            String downloadURL = "";
            transaction = new TransactionalInformation();
            var userSecurityTicket = VerifySessionToken(sessionTicket);

            try
            {
                var _providerFactory = ProviderFactory.Instance;
                var documentProvider = _providerFactory.CreateDocumentServiceProvider();
                Guid id = Guid.Empty;
                Guid.TryParse(item.documentId, out id);
                downloadURL = documentProvider.GenerateImageThumbnailLink(id, sessionTicket, true, null, true);
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

            return downloadURL;
        }
        #endregion
    }
}
