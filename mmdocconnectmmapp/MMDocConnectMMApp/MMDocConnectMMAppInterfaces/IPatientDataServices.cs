using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectMMAppModels;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectMMAppInterfaces
{
    public interface IPatientDataServices
    {
        List<PatientModelFront> GetPatients(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        PatientDetailViewData Get_PatientDetails( Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        List<PatientDetailViewModelExtended> Get_PatientCasesAndParticipationConsents(ElasticParameterObject parameter, Guid id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        bool GetIsPatientHipOnAnOctContract(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
