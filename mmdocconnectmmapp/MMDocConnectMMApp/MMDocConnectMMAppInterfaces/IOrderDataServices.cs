using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppInterfaces
{
    public interface IOrderDataServices
    {

        List<Order_Model_Extended> GetOrderListData(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Order_Model rejectOrderStatus(Order_Model orderClicked, string connectionString, string sessionTicket, out TransactionalInformation transaction);

    }


}

