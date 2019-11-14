using MMDocConnectDBMethods.Pharmacy.Model;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppInterfaces
{
    public interface IPharmacyDataServices
    {
        void SavePharmacy(Pharmacy pharmacy, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<Pharmacy> GetPharmacies(SortPharmacy sortParameters, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Boolean DeletePharmacy(Guid pharmacyID, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
