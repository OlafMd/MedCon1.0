using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IReceiptDataService
    {
        List<Receipt_Model> GetReceiptItems(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string GetDownloadURL(Receipt_Model item, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
