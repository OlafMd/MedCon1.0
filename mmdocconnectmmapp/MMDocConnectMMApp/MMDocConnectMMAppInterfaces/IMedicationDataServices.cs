using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MMDocConnectMMAppInterfaces
{
    public interface IMedicationDataServices
    {
        void SaveMedication(MedicationModel medication, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<MedicationModel> GetMedications(MedicationSort objSort, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        MedicationModel GetMedicationforMedicationID(Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction, HttpRequest request = null);
    }
}
