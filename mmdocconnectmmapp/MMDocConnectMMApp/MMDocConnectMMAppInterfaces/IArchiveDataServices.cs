using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppInterfaces
{
    public interface IArchiveDataServices
    {
        List<Archive_Model> GetAllItemsForArchive(ElasticParameterObject sort_parameter,string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string GetDownloadURL(Archive_Model item, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }


}
