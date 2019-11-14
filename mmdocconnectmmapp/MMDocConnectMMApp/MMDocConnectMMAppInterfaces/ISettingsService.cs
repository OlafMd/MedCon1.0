using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MMDocConnectMMApp.Models;
using MMDocConnectDocAppModels;
using System.Web;

namespace MMDocConnectMMAppInterfaces
{
    public interface ISettingsService
    {
        Employee_Model[] GetEmployees(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        AppSettings GetCompanySettings(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string AddUser(User user, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<Employee_Model> GetUsers(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        string SaveAppSettings(AppSettings settings, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        User GetUserForAccountID(Guid UserID, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null);
        User GetUserForMyAccount(string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }


}
