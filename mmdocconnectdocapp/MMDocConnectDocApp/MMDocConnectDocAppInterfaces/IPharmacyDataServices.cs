using MMDocConnectDBMethods.Pharmacy.Model;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IPharmacyDataServices
    {
        IEnumerable<Pharmacy> GetPharmacies(string connectionString, string sessionTicket, out TransactionalInformation transaction);

        Pharmacy GetPharmacyInfoForName(string name, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
