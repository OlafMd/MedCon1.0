using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMDocConnectDocAppInterfaces
{
    public interface IValidationService
    {
        List<ConsentValidationResponse> ValidateDoctorsAndPatientsParticipationConsent(Guid case_id, bool is_treatment, bool validate_treatment_doctor, Guid doctor_id, Guid aftercare_doctor_practice_id, Guid patient_id, string treatment_date_string, string case_treatment_date, Guid diagnose_id, Guid drug_id, string connectionString, string sessionTicket, out TransactionalInformation transaction, bool is_resubmission = false);
        Guid[] ValidateDoctorsAndPatientsParticipationConsentMulti(Guid authorizing_doctor_id, bool validate_treatment_doctor, string type, bool should_submit, Guid[] case_ids, Guid[] deselected_ids, bool all_selected, Guid doctor_id, Guid aftercare_doctor_practice_id, FilterObject filter, string date_performed_string, string connectionString, string sessionTicket, out TransactionalInformation transaction);

    }
}
