using MMDocConnectDocAppModels;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectUtils;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace MMDocConnectDocAppInterfaces
{
    public interface IOctService
    {
        /// <summary>
        /// Retrieves all octs.
        /// </summary>
        /// <param name="sort_parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<Oct_Model> GetOcts(ElasticParameterObject sort_parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Submits an oct.
        /// </summary>
        /// <param name="oct_ids"></param>
        /// <param name="oct_date"></param>
        /// <param name="authorizing_doctor_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <param name="dbConnection"></param>
        /// <param name="dbTransaction"></param>
        /// <returns></returns>
        string SubmitOct(IEnumerable<Guid> oct_ids, string oct_date, Guid authorizing_doctor_id, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction, bool documentation_only = false, DbConnection dbConnection = null, DbTransaction dbTransaction = null);

        /// <summary>
        /// Validate single oct submission.
        /// </summary>
        /// <param name="oct_id"></param>
        /// <param name="case_id"></param>
        /// <param name="oct_date"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<ConsentValidationResponse> ValidateOctSubmission(Guid oct_id, Guid case_id, string oct_date, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Checks if the same doctor is used for the next OCT.
        /// </summary>
        /// <param name="oct_doctor_id"></param>
        /// <param name="patient_id"></param>
        /// <param name="is_left_eye"></param>
        /// <param name="treatment_date"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        object CheckIsSameOctDoctor(Guid oct_doctor_id, Guid patient_id, bool is_left_eye, string treatment_date, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Validates multi oct submission.
        /// </summary>
        /// <param name="selected_ids"></param>
        /// <param name="deselected_ids"></param>
        /// <param name="sort_parameter"></param>
        /// <param name="all_selected"></param>
        /// <param name="oct_date"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<Guid> ValidateConsentsMultiSubmit(IEnumerable<Guid> oct_ids, string oct_date, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves doctor assignment count for selected octs.
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IEnumerable<MultiSubmitOctObject> InitiateOctMultiSubmit(ElasticParameterObjectMultiSubmit parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Retrieves number of elements when select all clicked
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        long GetOctCount(ElasticParameterObject parameter, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Updates performing doctor and date when action performed for the provided oct ids.
        /// </summary>
        /// <param name="oct_ids"></param>
        /// <param name="oct_date"></param>
        /// <param name="oct_doctor_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void MultiEditOct(IEnumerable<Guid> oct_ids, string oct_date, Guid oct_doctor_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Verified that the provided date isn't in the future.
        /// </summary>
        /// <param name="oct_date"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        bool ValidateOctDate(string oct_date, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Deletes open oct.
        /// </summary>
        /// <param name="oct_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void RejectOct(Guid oct_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Updates oct data for the provided id.
        /// </summary>
        /// <param name="oct_id"></param>
        /// <param name="oct_date"></param>
        /// <param name="oct_doctor_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        object EditOctForErrorCorrection(Guid oct_id, string oct_date, Guid oct_doctor_id, bool is_left_eye, string connectionString, string sessionTicket, out TransactionalInformation transaction, DbConnection dbConnection = null, DbTransaction dbTransaction = null);

        /// <summary>
        /// Retrieves FS6 comment of the oct in error state.
        /// </summary>
        /// <param name="case_id"></param>
        /// <param name="oct_id"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        string GetFS6CommentForDoctor(Guid case_id, Guid oct_id, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Edits the oct doctor or creates a new oct entry if oct was rejected.
        /// </summary>
        /// <param name="patient_id"></param>
        /// <param name="is_left_eye"></param>
        /// <param name="oct_doctor_id"></param>
        /// <param name="withdraw_oct"></param>
        /// <param name="submit_oct_until_date_string"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        void EditOctDoctor(Guid patient_id, bool is_left_eye, Guid oct_doctor_id, bool withdraw_oct, string submit_oct_until_date_string, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Get oct id for case id
        /// </summary>
        /// <param name="caseID"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        Guid GetOctIDForCaseID(Guid caseID, string connectionString, string sessionTicket, out TransactionalInformation transaction);

        /// <summary>
        /// Check does any oct exist for patient (can be list of patients), date and localization
        /// </summary>
        /// <param name="patient_ids"></param>
        /// <param name="oct_date"></param>
        /// <param name="localization"></param>
        /// <param name="connectionString"></param>
        /// <param name="sessionTicket"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        MulitiSubmitValidation CheckIfAlreadyExistOCT(IEnumerable<Guid> oct_ids, string oct_date, bool is_resubmit, string connectionString, string sessionTicket, out TransactionalInformation transaction);
    }
}
