/* 
 * Generated on 02/25/16 14:36:51
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using System.Runtime.Serialization;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_HEC;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using CL1_HEC_CAS;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using CL1_HEC_ACT;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Save_Preexamination.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Save_Preexamination
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guid Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SP_1436 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            //Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            #region DATA
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = Parameter.patient_id }, securityTicket).Result;
            if (patient_details == null)
                throw new Exception("Patient details not found for ID: " + Parameter.patient_id);

            var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, HEC_DoctorID = Parameter.treatment_doctor_id, IsDeleted = false }).SingleOrDefault();
            if (doctor == null)
                throw new Exception("Doctor not found for ID: " + Parameter.treatment_doctor_id);


            var doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.FirstOrDefault();

            if (doctor_details == null)
                throw new Exception("Doctor details not found for ID: " + Parameter.treatment_doctor_id);

            var practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = doctor_details.practice_id }, securityTicket).Result.FirstOrDefault();
            if (practice_details == null)
                throw new Exception("Practice details not found for ID: " + doctor_details.practice_id);
            #endregion

            #region EDIT
            var preexaminationCase = ORM_HEC_CAS_Case.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_CAS_CaseID = Parameter.case_id
            }).SingleOrDefault();

            if (preexaminationCase == null)
                throw new Exception("Case not found; id: " + Parameter.case_id);

            preexaminationCase.Patient_BirthDate = patient_details.birthday;
            preexaminationCase.Patient_FirstName = patient_details.patient_first_name;
            preexaminationCase.Patient_Gender = patient_details.gender;
            preexaminationCase.Patient_LastName = patient_details.patient_last_name;
            preexaminationCase.Patient_RefID = Parameter.patient_id;
            preexaminationCase.Modification_Timestamp = DateTime.Now;

            preexaminationCase.Save(Connection, Transaction);

            var plannedAction = cls_Get_Treatment_Planned_Action_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GTPAfCID_0946()
            {
                CaseID = Parameter.case_id
            }, securityTicket).Result;

            if (plannedAction == null)
                throw new Exception("Planned action not found; case id: " + Parameter.case_id);

            var preexaminationPlannedAction = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PlannedAction.Query()
            {
                HEC_ACT_PlannedActionID = plannedAction.planned_action_id,
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false
            }).SingleOrDefault();

            if (preexaminationPlannedAction == null)
                throw new Exception("Preexamination planned action not found; case id: " + Parameter.case_id);

            preexaminationPlannedAction.Patient_RefID = Parameter.patient_id;
            preexaminationPlannedAction.Modification_Timestamp = DateTime.Now;
            preexaminationPlannedAction.PlannedFor_Date = Parameter.treatment_date;
            preexaminationPlannedAction.ToBePerformedBy_BusinessParticipant_RefID = doctor.BusinessParticipant_RefID;

            preexaminationPlannedAction.Save(Connection, Transaction);

            var diagnosisIDs = cls_Get_Planned_Action_DiagnosisIDs_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GPADIDsfPAID_1041() { PlannedActionID = preexaminationPlannedAction.HEC_ACT_PlannedActionID }, securityTicket).Result;
            if (diagnosisIDs == null)
                throw new Exception("Diagnosis ids not found for planned action id: " + preexaminationPlannedAction.HEC_ACT_PlannedActionID);

            var diagnosisLocalization = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization.Query()
            {
                Tenant_RefID = securityTicket.TenantID,
                IsDeleted = false,
                HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = diagnosisIDs.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID
            }).SingleOrDefault();

            if (diagnosisLocalization == null)
                throw new Exception("Diagnosis localization not found for id: " + diagnosisIDs.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID);

            diagnosisLocalization.Modification_Timestamp = DateTime.Now;
            diagnosisLocalization.IM_PotentialDiagnosisLocalization_Code = Parameter.is_left_eye ? "L" : "R";

            diagnosisLocalization.Save(Connection, Transaction);
            #endregion

            #region ELASTIC
            try
            {
                var settlements = new List<Settlement_Model>();
                var treatments = new List<Submitted_Case_Model>();
                var patientDetailsList = new List<PatientDetailViewModel>();

                #region Settlement
                var settlement = Get_Settlement.GetSettlementForID(preexaminationPlannedAction.HEC_ACT_PlannedActionID.ToString(), securityTicket);
                settlement.birthday = patient_details.birthday.ToString("dd.MM.yyyy");
                settlement.bsnr = practice_details.practice_BSNR;
                settlement.doctor = MMDocConnectDocApp.GenericUtils.GetDoctorName(doctor_details);
                settlement.first_name = patient_details.patient_first_name;
                settlement.hip = patient_details.health_insurance_provider;
                settlement.lanr = doctor_details.lanr;
                settlement.last_name = patient_details.patient_last_name;
                settlement.localization = Parameter.is_left_eye ? "L" : "R";
                settlement.patient_full_name = patient_details.patient_first_name + " " + patient_details.patient_last_name;
                settlement.patient_id = Parameter.patient_id.ToString();
                settlement.patient_insurance_number = patient_details.insurance_id;
                settlement.practice_id = doctor_details.practice_id.ToString();
                settlement.surgery_date = Parameter.treatment_date;
                settlement.surgery_date_string = Parameter.treatment_date.ToString("dd.MM.yyyy");
                settlement.treatment_doctor_id = Parameter.treatment_doctor_id.ToString();

                settlements.Add(settlement);
                #endregion

                #region MM Treatment
                var treatment = Get_Submitted_Cases.GetSubmittedCaseforSubmittedCaseID(preexaminationPlannedAction.HEC_ACT_PlannedActionID.ToString(), securityTicket);
                treatment.doctor_id = Parameter.treatment_doctor_id.ToString();
                treatment.doctor_lanr = doctor_details.lanr;
                treatment.doctor_name = MMDocConnectDocApp.GenericUtils.GetDoctorName(doctor_details);
                treatment.hip_name = patient_details.health_insurance_provider;
                treatment.localization = Parameter.is_left_eye ? "L" : "R";
                treatment.patient_birthdate = patient_details.birthday;
                treatment.patient_birthdate_string = patient_details.birthday.ToString("dd.MM.yyyy");
                treatment.patient_id = Parameter.patient_id.ToString();
                treatment.patient_insurance_number = patient_details.insurance_id;
                treatment.patient_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
                treatment.practice_bsnr = practice_details.practice_BSNR;
                treatment.practice_id = practice_details.practiceID.ToString();
                treatment.practice_name = practice_details.practice_name;
                treatment.treatment_date = Parameter.treatment_date;
                treatment.treatment_date_month_year = Parameter.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                treatment.treatment_date_string = Parameter.treatment_date.ToString("dd.MM.yyyy");

                treatments.Add(treatment);
                #endregion

                #region Patient details
                PatientDetailViewModel patientDetal_elastic = Retrieve_Patients.Get_PatientDetaiForID(preexaminationPlannedAction.HEC_ACT_PlannedActionID.ToString(), securityTicket);
                patientDetal_elastic.practice_id = settlement.practice_id;
                patientDetal_elastic.date = settlement.surgery_date;
                patientDetal_elastic.date_string = settlement.surgery_date_string;
                patientDetal_elastic.treatment_doctor_id = settlement.treatment_doctor_id;
                patientDetal_elastic.diagnose_or_medication = settlement.diagnose;
                patientDetal_elastic.doctor = settlement.doctor;
                patientDetal_elastic.localisation = settlement.localization;
                patientDetal_elastic.patient_id = settlement.patient_id;
                patientDetal_elastic.status = settlement.status;

                patientDetailsList.Add(patientDetal_elastic);
                #endregion

                if (settlements.Any())
                    Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());
                if (treatments.Any())
                    Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(treatments, securityTicket.TenantID.ToString());
                if (patientDetailsList.Any())
                    Add_New_Patient.ImportPatientDetailsToElastic(patientDetailsList, securityTicket.TenantID.ToString());
            }
            catch (Exception ex)
            {
                throw new Exception("Retrieval/Import to elastic failed. " + ex.Message);
            }
            #endregion

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guid Invoke(string ConnectionString, P_CAS_SP_1436 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, P_CAS_SP_1436 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SP_1436 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SP_1436 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guid functionReturn = new FR_Guid();
            try
            {

                if (cleanupConnection == true)
                {
                    Connection = CSV2Core_MySQL.Support.DBSQLSupport.CreateConnection(ConnectionString);
                    Connection.Open();
                }
                if (cleanupTransaction == true)
                {
                    Transaction = Connection.BeginTransaction();
                }

                functionReturn = Execute(Connection, Transaction, Parameter, securityTicket);

                #region Cleanup Connection/Transaction
                //Commit the transaction 
                if (cleanupTransaction == true)
                {
                    Transaction.Commit();
                }
                //Close the connection
                if (cleanupConnection == true)
                {
                    Connection.Close();
                }
                #endregion
            }
            catch (Exception ex)
            {
                try
                {
                    if (cleanupTransaction == true && Transaction != null)
                    {
                        Transaction.Rollback();
                    }
                }
                catch { }

                try
                {
                    if (cleanupConnection == true && Connection != null)
                    {
                        Connection.Close();
                    }
                }
                catch { }

                throw new Exception("Exception occured in method cls_Save_Preexamination", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SP_1436 for attribute P_CAS_SP_1436
    [DataContract]
    public class P_CAS_SP_1436
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public DateTime treatment_date { get; set; }
        [DataMember]
        public Boolean is_left_eye { get; set; }
        [DataMember]
        public Guid treatment_doctor_id { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_Preexamination(,P_CAS_SP_1436 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_Preexamination.Invoke(connectionString,P_CAS_SP_1436 Parameter,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

/* Support for Parameter Invocation (Copy&Paste)
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SP_1436();
parameter.case_id = ...;
parameter.patient_id = ...;
parameter.treatment_date = ...;
parameter.is_left_eye = ...;
parameter.treatment_doctor_id = ...;

*/
