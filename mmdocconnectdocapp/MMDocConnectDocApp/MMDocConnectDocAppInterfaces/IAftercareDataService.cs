using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IAftercareDataService
    {
        IEnumerable<Aftercare_Model> GetAllAftercares(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        String SubmitAftercare(Guid authorizing_doctor_id, Guid case_id, string date_of_performed_action, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);
        long GetAftercaresCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid GetACIDForCaseID( Guid case_id, string sessionTicket, string connectionString, out TransactionalInformation transaction);
        object MultiEditSubmitAftercare(Guid authorizing_doctor_id, Guid[] case_ids, Guid[] case_ids_to_submit, Guid[] deselected_ids, bool all_selected, string aftercare_performed_date, Guid aftercare_doctor_id, bool should_submit, FilterObject filter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid[] ValidateAftercareDateForMultiEdit(Guid[] case_ids, Guid[] deselected_ids, string aftercare_performed_date, bool all_selected, bool should_submit, FilterObject filter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        ACAutocompleteModel GetACDoctorsAndPracticesForAutocomplete(string search_criteria, string sessionTicket, string connectionString, out TransactionalInformation transaction);
        MultiSubmitObject[] InitiateAftercareMultiSubmit(Guid[] case_ids, Guid[] deselected_ids, bool all_selected, FilterObject filter, string sort_by, bool isAsc, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        MulitiSubmitValidation CheckIfAlreadyExistAftercare(IEnumerable<Guid> case_ids, string aftercare_performed_date, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
