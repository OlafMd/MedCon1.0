/* 
 * Generated on 06/30/15 17:34:13
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
using CL1_CMN;
using CL1_HEC_ACT;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;
using CL1_USR;
using CL1_HEC;
using CL1_HEC_DIA;

namespace DataImporter.DBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Create_Treatment_Planned_Action.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Create_Treatment_Planned_Action
	{
        public static readonly int QueryTimeout = 360;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_CTPA_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_Guid();
            //Put your code here
            var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = Parameter.diagnose_id }, securityTicket).Result;

            ORM_HEC_ACT_PlannedAction treatment_planned_action = new ORM_HEC_ACT_PlannedAction();
            treatment_planned_action.Creation_Timestamp = DateTime.Now;
            treatment_planned_action.HEC_ACT_PlannedActionID = Guid.NewGuid();
            treatment_planned_action.IsPlannedFollowup = true;
            treatment_planned_action.IfPlannedFollowup_PreviousAction_RefID = Parameter.initial_performed_action_id;
            treatment_planned_action.IsPerformed = false;
            treatment_planned_action.MedicalPractice_RefID = Parameter.practice_id;
            treatment_planned_action.Modification_Timestamp = DateTime.Now;
            treatment_planned_action.Patient_RefID = Parameter.patient_id;
            treatment_planned_action.PlannedFor_Date = Parameter.treatment_date;
            treatment_planned_action.Tenant_RefID = securityTicket.TenantID;

            if (Parameter.treatment_doctor_id != Guid.Empty)
            {
                var doctor_account_id = cls_Get_Doctor_AccountID_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDAIDfDID_1549() { DoctorID = Parameter.treatment_doctor_id }, securityTicket).Result.accountID;

                ORM_USR_Account.Query doctor_accountQ = new ORM_USR_Account.Query();
                doctor_accountQ.USR_AccountID = doctor_account_id;
                doctor_accountQ.Tenant_RefID = securityTicket.TenantID;
                doctor_accountQ.IsDeleted = false;

                var doctor_account = ORM_USR_Account.Query.Search(Connection, Transaction, doctor_accountQ).SingleOrDefault();
                if (doctor_account != null)
                {
                    treatment_planned_action.ToBePerformedBy_BusinessParticipant_RefID = doctor_account.BusinessParticipant_RefID;
                }
            }

            treatment_planned_action.Save(Connection, Transaction);

            returnValue.Result = treatment_planned_action.HEC_ACT_PlannedActionID;
            /* Treatment planned actions are not connected to case via this table,
             * so that we can get both aftercare and treatment action
             * data in one sql query as one object.
             * 
             *  
                ORM_HEC_CAS_Case_RelevantPlannedAction treatment_planned_action_to_case = new ORM_HEC_CAS_Case_RelevantPlannedAction();
                treatment_planned_action_to_case.Case_RefID = new_case.HEC_CAS_CaseID;
                treatment_planned_action_to_case.Creation_Timestamp = DateTime.Now;
                treatment_planned_action_to_case.HEC_CAS_Case_RelevantPlannedActionID = Guid.NewGuid();
                treatment_planned_action_to_case.Modification_Timestamp = DateTime.Now;
                treatment_planned_action_to_case.PlannedAction_RefID = treatment_planned_action.HEC_ACT_PlannedActionID;
                treatment_planned_action_to_case.Tenant_RefID = securityTicket.TenantID;

                treatment_planned_action_to_case.Save(Connection, Transaction);
            */
            ORM_HEC_ACT_PlannedAction_PotentialProcedure treatment_planned_action_potential_procedure = new ORM_HEC_ACT_PlannedAction_PotentialProcedure();
            treatment_planned_action_potential_procedure.Creation_Timestamp = DateTime.Now;
            treatment_planned_action_potential_procedure.HEC_ACT_PlannedAction_PotentialProcedureID = Guid.NewGuid();
            treatment_planned_action_potential_procedure.Modification_Timestamp = DateTime.Now;
            treatment_planned_action_potential_procedure.PlannedAction_RefID = treatment_planned_action.HEC_ACT_PlannedActionID;
            treatment_planned_action_potential_procedure.Tenant_RefID = securityTicket.TenantID;
            treatment_planned_action_potential_procedure.PotentialProcedure_RefID = Parameter.intraocular_procedure_id;

            treatment_planned_action_potential_procedure.Save(Connection, Transaction);

            ORM_HEC_ACT_ActionType.Query treatment_planned_action_typeQ = new ORM_HEC_ACT_ActionType.Query();
            treatment_planned_action_typeQ.GlobalPropertyMatchingID = "mm.docconect.doc.app.planned.action.treatment";
            treatment_planned_action_typeQ.Tenant_RefID = securityTicket.TenantID;
            treatment_planned_action_typeQ.IsDeleted = false;

            var treatment_planned_action_type = ORM_HEC_ACT_ActionType.Query.Search(Connection, Transaction, treatment_planned_action_typeQ).SingleOrDefault();
            var treatment_planned_action_type_id = Guid.Empty;
            if (treatment_planned_action_type == null)
            {
                treatment_planned_action_type = new ORM_HEC_ACT_ActionType();

                Dict action_type_name_dict = new Dict(ORM_HEC_ACT_ActionType.TableName);

                foreach (var lang in Parameter.all_languagesL)
                {
                    var content = lang.ISO_639_1.Equals("DE") ? "behandlung" : "treatment";
                    action_type_name_dict.AddEntry(lang.CMN_LanguageID, content);
                }

                treatment_planned_action_type.ActionType_Name = action_type_name_dict;
                treatment_planned_action_type.Creation_Timestamp = DateTime.Now;
                treatment_planned_action_type.GlobalPropertyMatchingID = "mm.docconect.doc.app.planned.action.treatment";
                treatment_planned_action_type.Modification_Timestamp = DateTime.Now;
                treatment_planned_action_type.HEC_ACT_ActionTypeID = Guid.NewGuid();
                treatment_planned_action_type.Tenant_RefID = securityTicket.TenantID;
                treatment_planned_action_type.Save(Connection, Transaction);

                treatment_planned_action_type_id = treatment_planned_action_type.HEC_ACT_ActionTypeID;
            }
            else
            {
                treatment_planned_action_type_id = treatment_planned_action_type.HEC_ACT_ActionTypeID;
            }

            ORM_HEC_ACT_PlannedAction_2_ActionType treatment_planned_action_2_type = new ORM_HEC_ACT_PlannedAction_2_ActionType();
            treatment_planned_action_2_type.Tenant_RefID = securityTicket.TenantID;
            treatment_planned_action_2_type.Creation_Timestamp = DateTime.Now;
            treatment_planned_action_2_type.IsDeleted = false;
            treatment_planned_action_2_type.HEC_ACT_ActionType_RefID = treatment_planned_action_type_id;
            treatment_planned_action_2_type.HEC_ACT_PlannedAction_RefID = treatment_planned_action.HEC_ACT_PlannedActionID;
            treatment_planned_action_2_type.Modification_Timestamp = DateTime.Now;
            treatment_planned_action_2_type.HEC_ACT_PlannedAction_2_ActionTypeID = Guid.NewGuid();

            treatment_planned_action_2_type.Save(Connection, Transaction);

            ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct treatment_planned_action_required_product = new ORM_HEC_ACT_PlannedAction_PotentialProcedure_RequiredProduct();
            treatment_planned_action_required_product.BoundTo_HealthcareProcurementOrderPosition_RefID = Parameter.procurement_order_id;
            treatment_planned_action_required_product.Creation_Timestamp = DateTime.Now;
            treatment_planned_action_required_product.HEC_ACT_PlannedAction_PotentialProcedure_RequiredProductID = Guid.NewGuid();
            treatment_planned_action_required_product.Modification_Timestamp = DateTime.Now;
            treatment_planned_action_required_product.PlannedAction_PotentialProcedure_RefID = treatment_planned_action_potential_procedure.HEC_ACT_PlannedAction_PotentialProcedureID;
            treatment_planned_action_required_product.Tenant_RefID = securityTicket.TenantID;
            treatment_planned_action_required_product.HealthcareProduct_RefID = Parameter.drug_id;

            treatment_planned_action_required_product.Save(Connection, Transaction);

            #region DIAGNOSE
            if (Parameter.diagnose_id != Guid.Empty)
            {
                var patient_diagnosis = new ORM_HEC_Patient_Diagnosis();
                patient_diagnosis.Creation_Timestamp = DateTime.Now;
                patient_diagnosis.HEC_Patient_DiagnosisID = Guid.NewGuid();
                patient_diagnosis.Modification_Timestamp = DateTime.Now;
                patient_diagnosis.Patient_RefID = Parameter.patient_id;
                patient_diagnosis.R_IsConfirmed = Parameter.is_confirmed;
                patient_diagnosis.R_PotentialDiagnosis_RefID = Parameter.diagnose_id;
                patient_diagnosis.Tenant_RefID = securityTicket.TenantID;

                patient_diagnosis.Save(Connection, Transaction);

                ORM_HEC_DIA_Diagnosis_Localization diagnosis_localization = new ORM_HEC_DIA_Diagnosis_Localization();
                diagnosis_localization.Creation_Timestamp = DateTime.Now;
                diagnosis_localization.Diagnosis_RefID = Parameter.diagnose_id;
                diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID = Guid.NewGuid();
                diagnosis_localization.Modification_Timestamp = DateTime.Now;
                diagnosis_localization.Tenant_RefID = securityTicket.TenantID;
                diagnosis_localization.LocalizationCode = Parameter.diagnose_id == Guid.Empty ? "-" : Parameter.is_left_eye ? "L" : "R";

                diagnosis_localization.Save(Connection, Transaction);

                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate initial_performed_action_diagnose = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                initial_performed_action_diagnose.Creation_Timestamp = DateTime.Now;
                initial_performed_action_diagnose.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                initial_performed_action_diagnose.HEC_ACT_PerformedAction_RefID = Parameter.initial_performed_action_id;
                initial_performed_action_diagnose.IsDiagnosisConfirmed = Parameter.is_confirmed;
                initial_performed_action_diagnose.Modification_Timestamp = DateTime.Now;
                initial_performed_action_diagnose.PotentialDiagnosis_RefID = Parameter.diagnose_id;
                initial_performed_action_diagnose.Tenant_RefID = securityTicket.TenantID;
                initial_performed_action_diagnose.HEC_Patient_Diagnosis_RefID = patient_diagnosis.HEC_Patient_DiagnosisID;
                initial_performed_action_diagnose.IM_PotentialDiagnosis_Code = diagnose_details.diagnose_icd_10;
                initial_performed_action_diagnose.IM_PotentialDiagnosis_Name = diagnose_details.diagnose_name;
                initial_performed_action_diagnose.IM_PotentialDiagnosisCatalog_Name = diagnose_details.catalog_display_name;

                initial_performed_action_diagnose.Save(Connection, Transaction);

                ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization initial_performed_action_diagnose_localization = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate_Localization();
                initial_performed_action_diagnose_localization.Creation_Timestamp = DateTime.Now;
                initial_performed_action_diagnose_localization.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = Guid.NewGuid();
                initial_performed_action_diagnose_localization.HEX_EXC_Action_DiagnosisUpdate_RefID = initial_performed_action_diagnose.HEC_ACT_PerformedAction_DiagnosisUpdateID;
                initial_performed_action_diagnose_localization.HEC_DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                initial_performed_action_diagnose_localization.Modification_Timestamp = DateTime.Now;
                initial_performed_action_diagnose_localization.Tenant_RefID = securityTicket.TenantID;
                initial_performed_action_diagnose_localization.IM_PotentialDiagnosisLocalization_Code = Parameter.diagnose_id == Guid.Empty ? "-" : Parameter.is_left_eye ? "L" : "R";

                initial_performed_action_diagnose_localization.Save(Connection, Transaction);

                ORM_HEC_Patient_Diagnosis_Localization patient_diagnosis_localization = new ORM_HEC_Patient_Diagnosis_Localization();
                patient_diagnosis_localization.Creation_Timestamp = DateTime.Now;
                patient_diagnosis_localization.DIA_Diagnosis_Localization_RefID = diagnosis_localization.HEC_DIA_Diagnosis_LocalizationID;
                patient_diagnosis_localization.HEC_Patient_Diagnosis_LocalizationID = Guid.NewGuid();
                patient_diagnosis_localization.Patient_Diagnosis_RefID = patient_diagnosis.HEC_Patient_DiagnosisID;
                patient_diagnosis_localization.Tenant_RefID = securityTicket.TenantID;

                patient_diagnosis_localization.Save(Connection, Transaction);
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
		public static FR_Guid Invoke(string ConnectionString,P_CAS_CTPA_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_CAS_CTPA_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_CTPA_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_CTPA_1225 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				functionReturn = Execute(Connection, Transaction,Parameter,securityTicket);

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
					if (cleanupTransaction == true && Transaction!=null)
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

				throw new Exception("Exception occured in method cls_Create_Treatment_Planned_Action",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_CAS_CTPA_1225 for attribute P_CAS_CTPA_1225
		[DataContract]
		public class P_CAS_CTPA_1225 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid initial_performed_action_id { get; set; } 
			[DataMember]
			public Guid practice_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 
			[DataMember]
			public DateTime treatment_date { get; set; } 
			[DataMember]
			public Guid treatment_doctor_id { get; set; } 
			[DataMember]
			public Guid intraocular_procedure_id { get; set; } 
			[DataMember]
			public ORM_CMN_Language[] all_languagesL { get; set; } 
			[DataMember]
			public Guid procurement_order_id { get; set; } 
			[DataMember]
			public Guid drug_id { get; set; } 
			[DataMember]
			public Guid diagnose_id { get; set; } 
			[DataMember]
			public Boolean is_confirmed { get; set; } 
			[DataMember]
			public Boolean is_left_eye { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Create_Treatment_Planned_Action(,P_CAS_CTPA_1225 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Create_Treatment_Planned_Action.Invoke(connectionString,P_CAS_CTPA_1225 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Manipulation.P_CAS_CTPA_1225();
parameter.case_id = ...;
parameter.initial_performed_action_id = ...;
parameter.practice_id = ...;
parameter.patient_id = ...;
parameter.treatment_date = ...;
parameter.treatment_doctor_id = ...;
parameter.intraocular_procedure_id = ...;
parameter.all_languagesL = ...;
parameter.procurement_order_id = ...;
parameter.drug_id = ...;
parameter.diagnose_id = ...;
parameter.is_confirmed = ...;
parameter.is_left_eye = ...;

*/
