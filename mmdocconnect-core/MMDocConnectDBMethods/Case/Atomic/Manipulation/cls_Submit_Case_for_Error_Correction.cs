/* 
 * Generated on 02/09/16 18:03:41
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
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_BIL;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDocApp;
using MMDocConnectUtils;
using CL1_HEC_CAS;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Submit_Case_for_Error_Correction.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Submit_Case_for_Error_Correction
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_Guids Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SCfEC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_Guids();
            //Put your code here
            var case_to_submit = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = Parameter.case_id }, securityTicket).Result;
            if (case_to_submit != null)
            {
                var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1608() { DiagnoseID = case_to_submit.diagnose_id }, securityTicket).Result;
                var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = case_to_submit.drug_id }, securityTicket).Result;
                var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.op_doctor_id }, securityTicket).Result.SingleOrDefault();
                var oct_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.oct_doctor_id }, securityTicket).Result.SingleOrDefault();
                var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = case_to_submit.patient_id }, securityTicket).Result;
                var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.SingleOrDefault();
                var treatment_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.practice_id }, securityTicket).Result.FirstOrDefault();
                var status_ids = cls_Get_Case_TransmitionStatusIDs_for_CaseID_and_StatusCode.Invoke(Connection, Transaction, new P_CAS_GCTSIDsfCIDaSC_1619() { CaseID = Parameter.case_id, StatusCode = 5 }, securityTicket).Result;

                var transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                transmition_statusQ.IsDeleted = false;
                var result = new List<Guid>();

                var status_key = "aftercare";
                if (Parameter.action_type == "op")
                {
                    status_key = "treatment";
                }
                else if (Parameter.action_type == "oct")
                {
                    status_key = "oct";
                }

                if (status_key == "oct")
                {
                    var relevant_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, new ORM_HEC_CAS_Case_RelevantPlannedAction.Query()
                    {
                        PlannedAction_RefID = Parameter.planned_action_id,
                        Tenant_RefID = securityTicket.TenantID,
                        IsDeleted = false
                    }).Single();

                    if (relevant_action.Case_RefID != Parameter.case_id)
                    {
                        Parameter.case_id = relevant_action.Case_RefID;
                    }

                    var oct_status_ids = cls_Get_Case_TransmitionStatusIDs_for_PatientID_and_StatusCode.Invoke(Connection, Transaction, new P_CAS_GCTSIDsfPIDaSC_1859() { PatientID = case_to_submit.patient_id, StatusCode = 5 }, securityTicket).Result;

                    var all_case_status_ids = cls_Get_Case_TransmitionStatusIDs_for_PatientID.Invoke(Connection, Transaction, new P_CAS_GCTSIDsfPID_1856() { PatientID = case_to_submit.patient_id }, securityTicket).Result.Where(t => t.status_key == "oct").ToArray();
                    var new_status_ids = new List<CAS_GCTSIDsfPIDaSC_1859>();
                    var oct_planned_action_type_id = cls_Get_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GATID_1514() { action_type_gpmid = EActionType.PlannedOct.Value() }, securityTicket).Result;

                    var case_relevant_actions = cls_Get_PlannedActionIDs_for_PatientID_and_ActionTypeID.Invoke(Connection, Transaction, new P_CAS_GPAIDsfPIDaATID_1705()
                    {
                        ActionTypeID = oct_planned_action_type_id,
                        PatientID = case_to_submit.patient_id
                    }, securityTicket).Result.Where(t => t.performed).ToList();

                    var case_bill_positions = cls_Get_BillPositionIDs_for_PatientID_and_GposType.Invoke(Connection, Transaction, new P_CAS_GBPIDsfPIDaGposT_1709()
                    {
                        PatientID = case_to_submit.patient_id,
                        GposType = EGposType.Oct.Value()
                    }, securityTicket).Result.Where(t => t.status_id != Guid.Empty).ToList();

                    for (var i = 0; i < case_relevant_actions.Count; i++)
                    {
                        if (case_relevant_actions[i].action_id == Parameter.planned_action_id)
                        {
                            var status = all_case_status_ids.Single(t => t.bill_position_id == case_bill_positions[i].bill_position_id);
                            var status_to_add = oct_status_ids.Single(t => t.bill_position_id == status.bill_position_id);
                            new_status_ids.Add(status_to_add);
                            break;
                        }
                    }

                    if (!new_status_ids.Any())
                    {
                        throw new ArgumentException(String.Format("No suitable bill position found for action id: {0}; and case id: {1}", Parameter.planned_action_id, Parameter.case_id));
                    }

                    status_ids = new_status_ids.Select(t => new CAS_GCTSIDsfCIDaSC_1619()
                    {
                        bill_position_id = t.bill_position_id,
                        global_property_matching_id = t.global_property_matching_id,
                        status_id = t.status_id,
                        status_key = t.status_key
                    }).ToArray();
                }

                foreach (var status in status_ids)
                {
                    if (status.status_key == status_key)
                    {
                        transmition_statusQ.BIL_BillPosition_TransmitionStatusID = status.status_id;
                        var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                        if (transmition_status != null)
                        {
                            transmition_status.IsActive = false;
                            transmition_status.Save(Connection, Transaction);

                            var new_status = new ORM_BIL_BillPosition_TransmitionStatus();
                            new_status.PrimaryComment = Parameter.comment;
                            new_status.TransmitionCode = 6;
                            new_status.IsActive = true;
                            new_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                            new_status.BillPosition_RefID = status.bill_position_id;
                            new_status.Creation_Timestamp = DateTime.Now;
                            new_status.Modification_Timestamp = DateTime.Now;
                            new_status.Tenant_RefID = securityTicket.TenantID;
                            new_status.TransmitionStatusKey = transmition_status.TransmitionStatusKey;

                            var today = DateTime.Today;
                            var age = today.Year - patient_details.birthday.Year;
                            if (patient_details.birthday > today.AddYears(-age))
                                age--;

                            var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                            {
                                DiagnosisCatalogCode = diagnose_details == null ? "-" : diagnose_details.diagnose_icd_10,
                                DiagnosisCatalogName = diagnose_details == null ? "-" : diagnose_details.catalog_display_name,
                                DiagnosisName = diagnose_details == null ? "-" : diagnose_details.diagnose_name,
                                IFPerformedMedicalPracticeName = treatment_practice_details.practice_name,
                                IFPerformedResponsibleBPFullName = treatment_doctor_details != null ? MMDocConnectDocApp.GenericUtils.GetDoctorName(treatment_doctor_details) : null,
                                Localization = case_to_submit.localization,
                                PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                PatientFirstName = patient_details.patient_first_name,
                                PatientGender = patient_details.gender.ToString(),
                                PatientLastName = patient_details.patient_last_name,
                                PatientAge = age.ToString()
                            }, securityTicket).Result;

                            if (snapshot != null)
                            {
                                new_status.TransmissionDataXML = snapshot.XmlFileString;
                            }

                            new_status.TransmittedOnDate = DateTime.Now;

                            new_status.Save(Connection, Transaction);

                            result.Add(new_status.BIL_BillPosition_TransmitionStatusID);
                        }
                    }
                }

                #region IMPORT SUBMITTED CASE TO ELASTIC
                var submitted_case_model_elastic = Get_Submitted_Cases.GetSubmittedCaseforSubmittedCaseID(Parameter.planned_action_id.ToString(), securityTicket);
                submitted_case_model_elastic.status = "FS6";
                submitted_case_model_elastic.status_date = DateTime.Now;
                submitted_case_model_elastic.status_date_string = DateTime.Now.ToString("dd.MM.yyyy");

                var cases_to_submit = new List<Submitted_Case_Model>();
                cases_to_submit.Add(submitted_case_model_elastic);

                Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(cases_to_submit, securityTicket.TenantID.ToString());
                #endregion

                #region IMPORT SETTLEMENT TO ELASTIC
                var doctor_name = default(string);
                switch (Parameter.action_type)
                {
                    case "op":
                        if (treatment_doctor_details != null)
                        {
                            doctor_name = GenericUtils.GetDoctorName(treatment_doctor_details);
                        }
                        break;
                    case "ac":
                        if (aftercare_doctor_details != null)
                        {
                            doctor_name = GenericUtils.GetDoctorName(aftercare_doctor_details);
                        }
                        break;
                    case "oct":
                        if (oct_doctor_details != null)
                        {
                            doctor_name = GenericUtils.GetDoctorName(oct_doctor_details);
                        }
                        break;
                }

                var settlement = Get_Settlement.GetSettlementForID(Parameter.planned_action_id.ToString(), securityTicket);
                settlement.status = "FS6";
                if (!String.IsNullOrEmpty(doctor_name))
                {
                    settlement.doctor = doctor_name;
                }

                settlement.patient_full_name = patient_details.patient_last_name + ", " + patient_details.patient_first_name;
                settlement.first_name = patient_details.patient_first_name;
                settlement.last_name = patient_details.patient_last_name;

                var settlements = new List<Settlement_Model>() { settlement };
                Add_new_Settlement.Import_Settlement_to_ElasticDB(settlements, securityTicket.TenantID.ToString());

                var patientDetailList = new List<PatientDetailViewModel>();
                var patient_detail = Retrieve_Patients.Get_PatientDetaiForID(settlement.id, securityTicket);
                if (patient_detail != null)
                {
                    patient_detail.doctor = doctor_name;
                    patient_detail.status = settlement.status;
                    patientDetailList.Add(patient_detail);
                    Add_New_Patient.ImportPatientDetailsToElastic(patientDetailList, securityTicket.TenantID.ToString());
                }
                #endregion

                returnValue.Result = result.ToArray();
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_Guids Invoke(string ConnectionString, P_CAS_SCfEC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, P_CAS_SCfEC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SCfEC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_Guids Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SCfEC_1641 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_Guids functionReturn = new FR_Guids();
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

                throw new Exception("Exception occured in method cls_Submit_Case_for_Error_Correction", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Support Classes
    #region SClass P_CAS_SCfEC_1641 for attribute P_CAS_SCfEC_1641
    [DataContract]
    public class P_CAS_SCfEC_1641
    {
        //Standard type parameters
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid planned_action_id { get; set; }
        [DataMember]
        public String comment { get; set; }
        [DataMember]
        public String action_type { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guids cls_Submit_Case_for_Error_Correction(,P_CAS_SCfEC_1641 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guids invocationResult = cls_Submit_Case_for_Error_Correction.Invoke(connectionString,P_CAS_SCfEC_1641 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SCfEC_1641();
parameter.case_id = ...;
parameter.planned_action_id = ...;
parameter.comment = ...;
parameter.action_type = ...;

*/
