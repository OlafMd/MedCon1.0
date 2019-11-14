/* 
 * Generated on 02/25/16 15:50:01
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
using System.Runtime.Serialization;
using CL1_HEC_CAS;
using MMDocConnectDBMethods.Case.Complex.Retrieval;
using MMDocConnectDBMethods.Patient.Atomic.Retrieval;
using CL1_USR;
using CL1_CMN;
using CL1_HEC_ACT;
using CL1_HEC_DIA;
using CL1_HEC;
using CL1_HEC_BIL;
using CL1_BIL;
using MMDocConnectElasticSearchMethods.Models;
using MMDocConnectDBMethods.Doctor.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Manipulation;
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using MMDocConnectElasticSearchMethods.Patient.Manipulation;
using MMDocConnectDBMethods.Case.Complex.Manipulation;
using MMDocConnectDBMethods.Case.Atomic.Retrieval;
using MMDocConnectElasticSearchMethods.Settlement.Retrieval;
using MMDocConnectElasticSearchMethods.Case.Retrieval;
using CL1_HEC_CRT;
using CL1_HEC_CTR;
using MMDocConnectDBMethods.MainData.Atomic.Retrieval;
using System.Web;
using System.Web.Configuration;
using System.Threading;
using System.Threading.Tasks;

namespace MMDocConnectDBMethods.Case.Atomic.Manipulation
{
    /// <summary>
    /// 
    /// <example>
    /// string connectionString = ...;
    /// var result = cls_Submit_Preexamination.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
    [DataContract]
    public class cls_Submit_Preexamination
    {
        public static readonly int QueryTimeout = 60;

        #region Method Execution
        protected static FR_CAS_SPE_1805 Execute(DbConnection Connection, DbTransaction Transaction, P_CAS_SPE_1805 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            #region UserCode
            var returnValue = new FR_CAS_SPE_1805();
            returnValue.Result = new CAS_SPE_1805();
            //Put your code here
            var case_id = Parameter.case_id;

            #region DATA
            var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_P_PA_GPDfPID_1124() { PatientID = Parameter.patient_id }, securityTicket).Result;
            if (patient_details == null)
                throw new Exception("Patient details not found for ID: " + Parameter.patient_id);

            var doctor = ORM_HEC_Doctor.Query.Search(Connection, Transaction, new ORM_HEC_Doctor.Query() { Tenant_RefID = securityTicket.TenantID, HEC_DoctorID = Parameter.doctor_id, IsDeleted = false }).SingleOrDefault();
            if (doctor == null)
                throw new Exception("Doctor not found for ID: " + Parameter.doctor_id);


            var doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = Parameter.doctor_id }, securityTicket).Result.FirstOrDefault();

            if (doctor_details == null)
                throw new Exception("Doctor details not found for ID: " + Parameter.doctor_id);

            var practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = doctor_details.practice_id }, securityTicket).Result.FirstOrDefault();
            if (practice_details == null)
                throw new Exception("Practice details not found for ID: " + doctor_details.practice_id);

            var shouldDownloadReportProperty = cls_Get_Practice_PropertyValue_for_PropertyName_and_PracticeID.Invoke(Connection, Transaction, new P_DO_GPPVfPNaPID_0916() { PracticeID = doctor_details.practice_id, PropertyName = "Download Report Upon Submission" }, securityTicket).Result;
            var shouldDownloadReport = shouldDownloadReportProperty == null ? false : shouldDownloadReportProperty.BooleanValue;

            ORM_USR_Account.Query trigger_accQ = new ORM_USR_Account.Query();
            trigger_accQ.Tenant_RefID = securityTicket.TenantID;
            trigger_accQ.USR_AccountID = securityTicket.AccountID;
            trigger_accQ.IsDeleted = false;

            ORM_USR_Account trigger_acc = ORM_USR_Account.Query.Search(Connection, Transaction, trigger_accQ).Single();

            ORM_CMN_Language.Query all_languagesQ = new ORM_CMN_Language.Query();
            all_languagesQ.Tenant_RefID = securityTicket.TenantID;
            all_languagesQ.IsDeleted = false;

            var all_languagesL = ORM_CMN_Language.Query.Search(Connection, Transaction, all_languagesQ).ToArray();
            var intraocular_procedure_id = Guid.Empty;
            #endregion

            if (!Parameter.isResubmit)
            {
                #region NEW CASE
                ORM_HEC_CAS_Case new_case = new ORM_HEC_CAS_Case();
                new_case.HEC_CAS_CaseID = Guid.NewGuid();
                new_case.Creation_Timestamp = DateTime.Now;
                new_case.CreatedBy_BusinessParticipant_RefID = trigger_acc.BusinessParticipant_RefID;
                new_case.Patient_RefID = Parameter.patient_id;
                new_case.Patient_FirstName = patient_details.patient_first_name;
                new_case.Patient_LastName = patient_details.patient_last_name;
                new_case.Patient_Gender = patient_details.gender;
                new_case.Patient_BirthDate = patient_details.birthday;
                new_case.CaseNumber = cls_Get_Next_Case_Number.Invoke(Connection, Transaction, securityTicket).Result.case_number;
                new_case.Modification_Timestamp = DateTime.Now;

                DateTime today = DateTime.Today;
                int age = today.Year - patient_details.birthday.Year;
                if (patient_details.birthday > today.AddYears(-age))
                    age--;

                new_case.Patient_Age = age;
                new_case.Tenant_RefID = securityTicket.TenantID;

                new_case.Save(Connection, Transaction);
                case_id = new_case.HEC_CAS_CaseID;
                #endregion NEW CASE

                #region INITIAL PERFORMED ACTION
                var initial_performed_action_id = cls_Create_Initial_Performed_Action.Invoke(Connection, Transaction, new P_CAS_CIPA_1140()
                {
                    all_languagesL = all_languagesL,
                    case_id = new_case.HEC_CAS_CaseID,
                    created_by_bpt = trigger_acc.BusinessParticipant_RefID,
                    patient_id = Parameter.patient_id,
                    practice_id = doctor_details.practice_id,
                    action_type_gpmid = "mm.docconect.doc.app.performed.action.preexamination"
                }, securityTicket).Result;
                #endregion INITIAL PERFORMED ACTION

                #region LOCALIZATION
                ORM_HEC_DIA_Diagnosis_Localization diagnosis_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                diagnosis_localization.Modification_Timestamp = DateTime.Now;
                diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                diagnosis_localization.LocalizationCode = Parameter.localization;

                diagnosis_localization.Save(Connection, Transaction);

                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate initial_performed_action_diagnose = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                initial_performed_action_diagnose.HEC_ACT_PerformedAction_RefID = initial_performed_action_id;
                initial_performed_action_diagnose.Modification_Timestamp = DateTime.Now;
                initial_performed_action_diagnose.Tenant_RefID = securityTicket.TenantID;

                initial_performed_action_diagnose.Save(Connection, Transaction);

                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization initial_performed_action_diagnose_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                initial_performed_action_diagnose_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = initial_performed_action_diagnose.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                initial_performed_action_diagnose_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                initial_performed_action_diagnose_localization.Modification_Timestamp = DateTime.Now;
                initial_performed_action_diagnose_localization.Tenant_RefID = securityTicket.TenantID;
                initial_performed_action_diagnose_localization.IM_PotentialDiagnosisLocalization_Code = Parameter.localization;

                initial_performed_action_diagnose_localization.Save(Connection, Transaction);
                #endregion

                #region PLANNED ACTION
                var action_gpmid = "mm.docconect.doc.app.planned.action.preexamination";

                var planned_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, new ORM_HEC_ACT_ActionType.Query()
                {
                    GlobalPropertyMatchingID = action_gpmid,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).SingleOrDefault();

                if (planned_action_type == null)
                {
                    planned_action_type = new ORM_HEC_ACT_ActionType();
                    planned_action_type.GlobalPropertyMatchingID = action_gpmid;
                    planned_action_type.Modification_Timestamp = DateTime.Now;
                    planned_action_type.Tenant_RefID = securityTicket.TenantID;

                    planned_action_type.Save(Connection, Transaction);
                }

                // circular reference to same performed action in order to be compatible with treatment planned actions,
                // so that it can be accessed in the same way
                var preexamination_planned_action = new ORM_HEC_ACT_PlannedAction();
                preexamination_planned_action.IfPlannedFollowup_PreviousAction_RefID = initial_performed_action_id;
                preexamination_planned_action.IsPerformed = true;
                preexamination_planned_action.IfPerformed_PerformedAction_RefID = initial_performed_action_id;
                preexamination_planned_action.MedicalPractice_RefID = doctor_details.practice_id;
                preexamination_planned_action.Modification_Timestamp = DateTime.Now;
                preexamination_planned_action.Patient_RefID = Parameter.patient_id;
                preexamination_planned_action.PlannedFor_Date = Parameter.date;
                preexamination_planned_action.ToBePerformedBy_BusinessParticipant_RefID = doctor.BusinessParticipant_RefID;
                preexamination_planned_action.Tenant_RefID = securityTicket.TenantID;

                preexamination_planned_action.Save(Connection, Transaction);

                var action_to_type = new ORM_HEC_ACT_PlannedAction_2_ActionType();
                action_to_type.HEC_ACT_ActionType_RefID = planned_action_type.HEC_ACT_ActionTypeID;
                action_to_type.HEC_ACT_PlannedAction_RefID = preexamination_planned_action.HEC_ACT_PlannedActionID;
                action_to_type.Modification_Timestamp = DateTime.Now;
                action_to_type.Tenant_RefID = securityTicket.TenantID;

                action_to_type.Save(Connection, Transaction);
                #endregion

                #region GPOS
                var patient_consent = ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query.Search(Connection, Transaction, new ORM_HEC_CRT_InsuranceToBrokerContract_ParticipatingPatient.Query()
                {
                    Patient_RefID = Parameter.patient_id,
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Where(t =>
                {
                    var ctrParameter = cls_Get_Contract_Parameter_Value_for_InsuranceToBrokerContractID.Invoke(Connection, Transaction, new P_MD_GCPVfITBCID_1647()
                    {
                        ParameterName = "Duration of participation consent – Month",
                        InsuranceToBrokerContractID = t.InsuranceToBrokerContract_RefID
                    }, securityTicket).Result;

                    var validThrough = ctrParameter == null || ctrParameter.ConsentValidForMonths == double.MaxValue ? DateTime.MaxValue : t.ValidFrom.AddMonths(Convert.ToInt32(ctrParameter.ConsentValidForMonths));
                    return t.ValidFrom <= Parameter.date && validThrough >= Parameter.date;
                }).OrderBy(t => t.ValidFrom).FirstOrDefault();

                if (patient_consent == null)
                    throw new Exception("No patients consents found for selected date: " + Parameter.date.ToString("dd.MM.yyyy") + " and  patient id: " + Parameter.patient_id);


                var gpos_gpmid = "mm.docconnect.gpos.catalog.voruntersuchung";
                var preexamination_gpos_catalog = ORM_HEC_BIL_PotentialCode_Catalog.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_Catalog.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    GlobalPropertyMatchingID = gpos_gpmid
                }).SingleOrDefault();

                if (preexamination_gpos_catalog == null)
                    throw new Exception("Preexamination catalog not found.");

                var gpos_connections_to_drugs = ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_HealthcareProduct.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).GroupBy(t => t.HEC_BIL_PotentialCode_RefID);

                var gpos_connections_to_diagnoses = ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode_2_PotentialDiagnosis.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).GroupBy(t => t.HEC_BIL_PotentialCode_RefID);

                var preexamination_gposes = ORM_HEC_BIL_PotentialCode.Query.Search(Connection, Transaction, new ORM_HEC_BIL_PotentialCode.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    PotentialCode_Catalog_RefID = preexamination_gpos_catalog.HEC_BIL_PotentialCode_CatalogID
                });

                var covered_gposes = ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query.Search(Connection, Transaction, new ORM_HEC_CTR_InsuranceToBrokerContracts_CoveredPotentialBillCode.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false,
                    InsuranceToBrokerContract_RefID = patient_consent.InsuranceToBrokerContract_RefID
                });

                preexamination_gposes = preexamination_gposes.Where(t => covered_gposes.Any(c => c.PotentialBillCode_RefID == t.HEC_BIL_PotentialCodeID)).ToList();

                var bill_header = new ORM_BIL_BillHeader();
                bill_header.Modification_Timestamp = DateTime.Now;
                bill_header.Tenant_RefID = securityTicket.TenantID;

                foreach (var gpos in preexamination_gposes)
                {
                    if (!gpos_connections_to_diagnoses.Any(t => t.Key == gpos.HEC_BIL_PotentialCodeID) && !gpos_connections_to_drugs.Any(t => t.Key == gpos.HEC_BIL_PotentialCodeID))
                    {
                        var price_value = ORM_CMN_Price_Value.Query.Search(Connection, Transaction, new ORM_CMN_Price_Value.Query() { Price_RefID = gpos.Price_RefID, IsDeleted = false, Tenant_RefID = securityTicket.TenantID }).SingleOrDefault();
                        if (price_value == null)
                            throw new Exception("Price value not found for GPOS: " + gpos.BillingCode);

                        ORM_BIL_BillPosition gpos_position = new ORM_BIL_BillPosition();
                        gpos_position.BIL_BilHeader_RefID = bill_header.BIL_BillHeaderID;
                        gpos_position.Modification_Timestamp = DateTime.Now;
                        gpos_position.Tenant_RefID = securityTicket.TenantID;
                        gpos_position.PositionValue_IncludingTax = Convert.ToDecimal(price_value.PriceValue_Amount);
                        gpos_position.PositionNumber = cls_Get_Next_Bill_Position_Number.Invoke(Connection, Transaction, securityTicket).Result.bill_position_number;

                        gpos_position.Save(Connection, Transaction);

                        ORM_BIL_BillPosition_TransmitionStatus fs_status = new ORM_BIL_BillPosition_TransmitionStatus();
                        fs_status.BillPosition_RefID = gpos_position.BIL_BillPositionID;
                        fs_status.IsActive = true;
                        fs_status.Modification_Timestamp = DateTime.Now;
                        fs_status.Tenant_RefID = securityTicket.TenantID;
                        fs_status.TransmitionCode = 1;
                        fs_status.TransmitionStatusKey = "preexamination";
                        fs_status.TransmittedOnDate = DateTime.Now;

                        fs_status.Save(Connection, Transaction);

                        ORM_HEC_BIL_BillPosition hec_gpos_position = new ORM_HEC_BIL_BillPosition();
                        hec_gpos_position.Ext_BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                        hec_gpos_position.Modification_Timestamp = DateTime.Now;
                        hec_gpos_position.Tenant_RefID = securityTicket.TenantID;
                        hec_gpos_position.PositionFor_Patient_RefID = Parameter.patient_id;

                        hec_gpos_position.Save(Connection, Transaction);

                        ORM_HEC_BIL_BillPosition_BillCode hec_gpos_position_code = new ORM_HEC_BIL_BillPosition_BillCode();
                        hec_gpos_position_code.BillPosition_RefID = hec_gpos_position.HEC_BIL_BillPositionID;
                        hec_gpos_position_code.IM_BillingCode = gpos.BillingCode;
                        hec_gpos_position_code.Modification_Timestamp = DateTime.Now;
                        hec_gpos_position_code.PotentialCode_RefID = gpos.HEC_BIL_PotentialCodeID;
                        hec_gpos_position_code.Tenant_RefID = securityTicket.TenantID;

                        hec_gpos_position_code.Save(Connection, Transaction);

                        ORM_HEC_CAS_Case_BillCode hec_gpos_case_code = new ORM_HEC_CAS_Case_BillCode();
                        hec_gpos_case_code.HEC_BIL_BillPosition_BillCode_RefID = hec_gpos_position_code.HEC_BIL_BillPosition_BillCodeID;
                        hec_gpos_case_code.HEC_CAS_Case_RefID = new_case.HEC_CAS_CaseID;
                        hec_gpos_case_code.Modification_Timestamp = DateTime.Now;
                        hec_gpos_case_code.Tenant_RefID = securityTicket.TenantID;

                        hec_gpos_case_code.Save(Connection, Transaction);

                        ORM_BIL_BillPosition_PropertyValue gpos_management_fee_property_value = new ORM_BIL_BillPosition_PropertyValue();
                        gpos_management_fee_property_value.BIL_BillPosition_RefID = gpos_position.BIL_BillPositionID;
                        gpos_management_fee_property_value.BIL_BillPosition_PropertyValueID = Guid.NewGuid();
                        gpos_management_fee_property_value.Creation_Timestamp = DateTime.Now;
                        gpos_management_fee_property_value.Modification_Timestamp = DateTime.Now;
                        gpos_management_fee_property_value.PropertyKey = "mm.doc.connect.management.fee";
                        gpos_management_fee_property_value.PropertyValue = "waived";
                        gpos_management_fee_property_value.Tenant_RefID = securityTicket.TenantID;

                        gpos_management_fee_property_value.Save(Connection, Transaction);

                        bill_header.TotalValue_IncludingTax += Convert.ToDecimal(price_value.PriceValue_Amount);
                    }
                }

                bill_header.Save(Connection, Transaction);
                #endregion
            }

            return returnValue;
            #endregion UserCode
        }
        #endregion

        #region Method Invocation Wrappers
        ///<summary>
        /// Opens the connection/transaction for the given connectionString, and closes them when complete
        ///<summary>
        public static FR_CAS_SPE_1805 Invoke(string ConnectionString, P_CAS_SPE_1805 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(null, null, ConnectionString, Parameter, securityTicket);
        }
        ///<summary>
        /// Ivokes the method with the given Connection, leaving it open if no exceptions occured
        ///<summary>
        public static FR_CAS_SPE_1805 Invoke(DbConnection Connection, P_CAS_SPE_1805 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, null, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
        ///<summary>
        public static FR_CAS_SPE_1805 Invoke(DbConnection Connection, DbTransaction Transaction, P_CAS_SPE_1805 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            return Invoke(Connection, Transaction, null, Parameter, securityTicket);
        }
        ///<summary>
        /// Method Invocation of wrapper classes
        ///<summary>
        protected static FR_CAS_SPE_1805 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString, P_CAS_SPE_1805 Parameter, CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
        {
            bool cleanupConnection = Connection == null;
            bool cleanupTransaction = Transaction == null;

            FR_CAS_SPE_1805 functionReturn = new FR_CAS_SPE_1805();
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

                throw new Exception("Exception occured in method cls_Submit_Preexamination", ex);
            }
            return functionReturn;
        }
        #endregion
    }

    #region Custom Return Type
    [Serializable]
    public class FR_CAS_SPE_1805 : FR_Base
    {
        public CAS_SPE_1805 Result { get; set; }

        public FR_CAS_SPE_1805() : base() { }

        public FR_CAS_SPE_1805(Exception ex) : base(ex) { }

    }
    #endregion

    #region Support Classes
    #region SClass P_CAS_SPE_1805 for attribute P_CAS_SPE_1805
    [DataContract]
    public class P_CAS_SPE_1805
    {
        //Standard type parameters
        [DataMember]
        public Guid patient_id { get; set; }
        [DataMember]
        public Guid case_id { get; set; }
        [DataMember]
        public Guid doctor_id { get; set; }
        [DataMember]
        public String localization { get; set; }
        [DataMember]
        public DateTime date { get; set; }
        [DataMember]
        public Boolean isResubmit { get; set; }

    }
    #endregion
    #region SClass CAS_SPE_1805 for attribute CAS_SPE_1805
    [DataContract]
    public class CAS_SPE_1805
    {
        //Standard type parameters
        [DataMember]
        public String ReportUrl { get; set; }

    }
    #endregion

    #endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_SPE_1805 cls_Submit_Preexamination(,P_CAS_SPE_1805 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_SPE_1805 invocationResult = cls_Submit_Preexamination.Invoke(connectionString,P_CAS_SPE_1805 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Manipulation.P_CAS_SPE_1805();
parameter.patient_id = ...;
parameter.case_id = ...;
parameter.doctor_id = ...;
parameter.localization = ...;
parameter.date = ...;
parameter.isResubmit = ...;

*/
