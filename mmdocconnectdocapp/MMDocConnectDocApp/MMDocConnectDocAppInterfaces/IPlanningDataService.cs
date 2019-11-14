using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace MMDocConnectDocAppInterfaces
{
    public interface IPlanningDataService
    {
        PracticeDefaultSettings GetPracticeDefaultSettings(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        List<AutocompleteModel> GetPatientsForAutocomplete(string search_criteria, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        ACAutocompleteModel GetACDoctorsAndPracticesForAutocomplete(string connectionString, string search_criteria, string sessionTicket, out TransactionalInformation transaction);
        List<AutocompleteModel> GetAllDrugsForDropdown(string connectionString, string sessionTicket, out TransactionalInformation transaction);
        IEnumerable<AutocompleteModel> GetAllDiagnosesForDropdown(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid CreateCase(Case new_case, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);
        List<Case_Model> GetAllCases(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Case GetCaseDetailsforCaseID(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        TreatmentEligibility VerifyTreatmentEligibility(Guid drug_id, Guid patient_id, string treatment_date, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        String SubmitCase(Guid case_id, Guid authorizing_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Case GetPreviousCaseDataforPatientID(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid CancelCase(Guid case_id, bool cancel_treatment, bool cancel_drug_order, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        long GetCasesCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid GetDiagnosisIDForNameAndPatient(Guid patient_id, string name, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid GetDrugIDForName(string drug_name, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        object MultiEditCase(Guid authorizing_doctor_id, Guid[] case_ids, Guid[] case_ids_to_submit, Guid[] deselected_ids, bool all_selected, Guid treatment_doctor_id, Guid aftercare_doctor_id, bool should_submit, FilterObject filter, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);
        MultiSubmitObject[] InitiateCaseMultiSubmit(Guid[] case_ids, Guid[] deselected_ids, bool all_selected, FilterObject filter, string sort_by, bool isAsc, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        Guid CreateTemporaryAftercareDoctor(string name, string street, string house_number, string zip, string city, string phone, string fax, string email, string comment, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        ContractModel[] GetContractList(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        ACAutocompleteModel GetOctDoctorsForAutocomplete(string connectionString, string search_criteria, Guid patient_id, string date, string sessionTicket, out TransactionalInformation transaction);
        bool GetIsPatientHipOnAnOctContract(Guid patient_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool GetIsPatientFeeWaived(Guid patient_id, string treatment_date, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool WillOrderBeCancelled(Case parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool IsOrderSubmitted(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool CaseHasOctPending(Guid case_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool MissingIvomCaseExists(Guid patient_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool CheckIfAlreadyExistTreatment(Guid case_id, Guid patient_id, string treatment_date, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        void SaveOrderMessageVisability(string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);
        bool CanShowOrderMessage(string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);
        MulitiSubmitValidation CheckIfAlreadyExistAnyTreatment(Guid[] case_ids, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        OCTValidation CheckIfOCTCanBeSubmitted(Guid case_id, Guid doctor_id, Guid patient_id, String treatment_date, Guid diagnosis_id, Guid medication_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction);
        bool CanSaveCaseAfterChangeLocalization(Guid case_id, Guid patient_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
