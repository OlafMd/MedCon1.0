/* 
 * Generated on 07/09/15 16:01:09
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
using MMDocConnectElasticSearchMethods.Case.Manipulation;
using DataImporter.Models;
using DataImporter.DBMethods.Case.Atomic.Retrieval;
using CL1_BIL;
using DataImporter.DBMethods.ExportData.Atomic.Retrieval;
using DataImporter.DBMethods.Patient.Atomic.Retrieval;
using DataImporter.DBMethods.Case.Complex.Manipulation;
using CL1_HEC_CAS;
using CL1_HEC_ACT;
using DataImporter.DBMethods.Doctor.Atomic.Retrieval;

namespace DataImporter.DBMethods.Case.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Change_PerformedAction_Status_for_PlannedActionID
	{
		public static readonly int QueryTimeout = 360;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_CPASfPAID_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Guid();
            //Put your code here

            String[] treatment_gpos = cls_Get_All_GPOS_Billing_Codes_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, new P_CAS_GAGPOSBCfGPMID_1516() { GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.operation" }, securityTicket).Result.Select(gpos => gpos.BillingCode).ToArray();
            String[] aftercare_gpos = cls_Get_All_GPOS_Billing_Codes_for_GlobalPropertyMatchingID.Invoke(Connection, Transaction, new P_CAS_GAGPOSBCfGPMID_1516() { GlobalPropertyMatchingID = "mm.docconnect.gpos.catalog.nachsorge" }, securityTicket).Result.Select(gpos => gpos.BillingCode).ToArray();
            
            var is_treatment = cls_Get_PerformedActionType_GlobalPropertyMatchingID_for_PlannedActionID.Invoke(Connection, Transaction, new P_CAS_GPAGPMIDfPAID_1652() { PlannedActionID = Parameter.planned_action_id }, securityTicket).Result.GlobalPropertyMatchingID.Equals("mm.docconect.doc.app.performed.action.treatment");
            var case_id = Guid.Empty;
            if (is_treatment)
            {
                ORM_HEC_ACT_PlannedAction.Query planned_actionQ = new ORM_HEC_ACT_PlannedAction.Query();
                planned_actionQ.HEC_ACT_PlannedActionID = Parameter.planned_action_id;
                planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                planned_actionQ.IsDeleted = false;
                var planned_action = ORM_HEC_ACT_PlannedAction.Query.Search(Connection, Transaction, planned_actionQ).SingleOrDefault();
                if (planned_action != null)
                {
                    ORM_HEC_CAS_Case_RelevantPerformedAction.Query relevant_performed_actionQ = new ORM_HEC_CAS_Case_RelevantPerformedAction.Query();
                    relevant_performed_actionQ.PerformedAction_RefID = planned_action.IfPlannedFollowup_PreviousAction_RefID;
                    relevant_performed_actionQ.Tenant_RefID = securityTicket.TenantID;
                    relevant_performed_actionQ.IsDeleted = false;

                    var relevant_performed_action = ORM_HEC_CAS_Case_RelevantPerformedAction.Query.Search(Connection, Transaction, relevant_performed_actionQ).SingleOrDefault();
                    if (relevant_performed_action != null)
                    {
                        case_id = relevant_performed_action.Case_RefID;
                    }
                }
            }
            else
            {
                ORM_HEC_CAS_Case_RelevantPlannedAction.Query relevant_planned_actionQ = new ORM_HEC_CAS_Case_RelevantPlannedAction.Query();
                relevant_planned_actionQ.PlannedAction_RefID = Parameter.planned_action_id;
                relevant_planned_actionQ.Tenant_RefID = securityTicket.TenantID;
                relevant_planned_actionQ.IsDeleted = false;
                var relevant_planned_action = ORM_HEC_CAS_Case_RelevantPlannedAction.Query.Search(Connection, Transaction, relevant_planned_actionQ).SingleOrDefault();
                if (relevant_planned_action != null)
                {
                    case_id = relevant_planned_action.Case_RefID;
                }
            }

            var case_to_submit = cls_Get_Case_Details_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GCDfCID_1435() { CaseID = case_id }, securityTicket).Result;
            if (case_to_submit != null)
            {
                var current_status = "FS1";
                var diagnose_details = cls_Get_Diagnose_Details_for_DiagnoseID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1357() { DiagnoseID = case_to_submit.diagnose_id }, securityTicket).Result;
                var drug_details = cls_Get_Drug_Details_for_DrugID.Invoke(Connection, Transaction, new P_CAS_GDDfDID_1614() { DrugID = case_to_submit.drug_id }, securityTicket).Result;
                var treatment_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.op_doctor_id }, securityTicket).Result.SingleOrDefault();
                var patient_details = cls_Get_Patient_Details_for_PatientID.Invoke(Connection, Transaction, new P_PA_GPDfPID_1729() { PatientID = case_to_submit.patient_id }, securityTicket).Result;
                var aftercare_doctor_details = cls_Get_Doctor_Details_for_DoctorID.Invoke(Connection, Transaction, new P_DO_GDDfDID_0823() { DoctorID = case_to_submit.ac_doctor_id }, securityTicket).Result.SingleOrDefault();
                var treatment_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.practice_id }, securityTicket).Result.FirstOrDefault();
                var aftercare_practice_details = cls_Get_Practice_Details_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDfPID_1432() { PracticeID = case_to_submit.aftercare_doctors_practice_id }, securityTicket).Result.FirstOrDefault();
                var practice_defaults = cls_Get_Practice_Default_Settings_for_PracticeID.Invoke(Connection, Transaction, new P_DO_GPDSfPID_0909() { PracticeID = case_to_submit.practice_id }, securityTicket).Result;

                if (is_treatment)
                {
                    #region CHANGE TREATMENT STATUS
                    var bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result;
                    foreach (var bill_position in bill_positions)
                    {
                        var billing_code = cls_Get_BillingCode_for_CaseBillCodeID.Invoke(Connection, Transaction, new P_CAS_GBCfCBCID_1334() { CaseBillCodeID = bill_position.hec_case_bill_code_id }, securityTicket).Result;

                        if (!aftercare_gpos.Contains(billing_code.BillingCode))
                        {
                            ORM_BIL_BillPosition_TransmitionStatus.Query transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                            transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                            transmition_statusQ.TransmitionStatusKey = "treatment";
                            transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                            transmition_statusQ.IsDeleted = false;
                            transmition_statusQ.IsActive = true;

                            var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                            if (transmition_status != null)
                            {
                                if (Parameter.change_status)
                                {
                                    transmition_status.IsActive = false;
                                    transmition_status.Modification_Timestamp = Parameter.status_date;
                                    transmition_status.Save(Connection, Transaction);

                                    ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                    position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                    position_status.BillPosition_RefID = bill_position.bill_position_id;
                                    position_status.Creation_Timestamp = Parameter.status_date;
                                    position_status.IsActive = true;
                                    position_status.PrimaryComment = Parameter.primary_comment;
                                    position_status.SecondaryComment = Parameter.secondary_comment;
                                    position_status.Modification_Timestamp = Parameter.status_date;
                                    position_status.TransmitionCode = Parameter.new_status;
                                    position_status.TransmittedOnDate = Parameter.status_date;
                                    position_status.Tenant_RefID = securityTicket.TenantID;
                                    position_status.TransmitionStatusKey = "treatment";

                                    #region CREATE SNAPSHOT
                                    DateTime today = DateTime.Today;
                                    int age = today.Year - patient_details.birthday.Year;
                                    if (patient_details.birthday > today.AddYears(-age))
                                        age--;

                                    var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                    {
                                        DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                        DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                        DiagnosisName = diagnose_details.diagnose_name,
                                        IFPerformedMedicalPracticeName = treatment_practice_details.practice_name,
                                        IFPerformedResponsibleBPFullName = treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name,
                                        Localization = case_to_submit.localization,
                                        PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                        PatientFirstName = patient_details.patient_first_name,
                                        PatientGender = patient_details.gender.ToString(),
                                        PatientLastName = patient_details.patient_last_name,
                                        PatientAge = age.ToString()
                                    }, securityTicket).Result;

                                    if (snapshot != null)
                                    {
                                        position_status.TransmissionDataXML = snapshot.XmlFileString;
                                    }

                                    #endregion

                                    position_status.Save(Connection, Transaction);

                                }
                                else
                                {
                                    current_status = "FS" + transmition_status.TransmitionCode;
                                }
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    var bill_positions = cls_Get_BillPositionIDs_for_CaseID.Invoke(Connection, Transaction, new P_CAS_GBPIDsfCID_0928() { CaseID = case_id }, securityTicket).Result;

                    foreach (var bill_position in bill_positions)
                    {
                        #region CHANGE AFTERCARE STATUS
                        var billing_code = cls_Get_BillingCode_for_CaseBillCodeID.Invoke(Connection, Transaction, new P_CAS_GBCfCBCID_1334() { CaseBillCodeID = bill_position.hec_case_bill_code_id }, securityTicket).Result;

                        if (aftercare_gpos.Contains(billing_code.BillingCode))
                        {
                            ORM_BIL_BillPosition_TransmitionStatus.Query transmition_statusQ = new ORM_BIL_BillPosition_TransmitionStatus.Query();
                            transmition_statusQ.BillPosition_RefID = bill_position.bill_position_id;
                            transmition_statusQ.TransmitionStatusKey = "aftercare";
                            transmition_statusQ.Tenant_RefID = securityTicket.TenantID;
                            transmition_statusQ.IsDeleted = false;
                            transmition_statusQ.IsActive = true;

                            var transmition_status = ORM_BIL_BillPosition_TransmitionStatus.Query.Search(Connection, Transaction, transmition_statusQ).SingleOrDefault();
                            if (transmition_status != null)
                            {
                                if (Parameter.change_status)
                                {
                                    transmition_status.IsActive = false;
                                    transmition_status.Modification_Timestamp = Parameter.status_date;
                                    transmition_status.Save(Connection, Transaction);

                                    ORM_BIL_BillPosition_TransmitionStatus position_status = new ORM_BIL_BillPosition_TransmitionStatus();
                                    position_status.BIL_BillPosition_TransmitionStatusID = Guid.NewGuid();
                                    position_status.BillPosition_RefID = bill_position.bill_position_id;
                                    position_status.Creation_Timestamp = Parameter.status_date;
                                    position_status.IsActive = true;
                                    position_status.PrimaryComment = Parameter.primary_comment;
                                    position_status.SecondaryComment = Parameter.secondary_comment;
                                    position_status.Modification_Timestamp = Parameter.status_date;
                                    position_status.TransmitionCode = Parameter.new_status;
                                    position_status.TransmittedOnDate = Parameter.status_date;
                                    position_status.Tenant_RefID = securityTicket.TenantID;
                                    position_status.TransmitionStatusKey = "aftercare";

                                    #region CREATE SNAPSHOT
                                    DateTime today = DateTime.Today;
                                    int age = today.Year - patient_details.birthday.Year;
                                    if (patient_details.birthday > today.AddYears(-age))
                                        age--;

                                    var snapshot = cls_Create_XML_for_Immutable_Fields.Invoke(Connection, Transaction, new P_CAS_CXFIF_0830()
                                    {
                                        DiagnosisCatalogCode = diagnose_details.diagnose_icd_10,
                                        DiagnosisCatalogName = diagnose_details.catalog_display_name,
                                        DiagnosisName = diagnose_details.diagnose_name,
                                        IFPerformedMedicalPracticeName = treatment_practice_details.practice_name,
                                        IFPerformedResponsibleBPFullName = treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name,
                                        Localization = case_to_submit.localization,
                                        PatientBirthDate = patient_details.birthday.ToString("dd.MM.yyyy"),
                                        PatientFirstName = patient_details.patient_first_name,
                                        PatientGender = patient_details.gender.ToString(),
                                        PatientLastName = patient_details.patient_last_name,
                                        PatientAge = age.ToString()
                                    }, securityTicket).Result;

                                    if (snapshot != null)
                                    {
                                        position_status.TransmissionDataXML = snapshot.XmlFileString;
                                    }

                                    #endregion

                                    position_status.Save(Connection, Transaction);
                                }
                                else
                                {
                                    current_status = "FS" + transmition_status.TransmitionCode;
                                }
                            }
                        }
                        #endregion
                    }
                }

                Submitted_Case_Model submitted_case_model_elastic = new Submitted_Case_Model();
                submitted_case_model_elastic.diagnose = diagnose_details != null ? diagnose_details.diagnose_name + " (" + diagnose_details.catalog_display_name + ": " + diagnose_details.diagnose_icd_10 + ")" : "";
                submitted_case_model_elastic.id = is_treatment ? case_to_submit.treatment_planned_action_id.ToString() : case_to_submit.aftercare_planned_action_id.ToString();
                submitted_case_model_elastic.case_id = case_id.ToString();
                submitted_case_model_elastic.localization = case_to_submit.localization;
                submitted_case_model_elastic.management_pauschale = practice_defaults.WaiveServiceFee ? "waived" : "deducted";
                submitted_case_model_elastic.patient_birthdate = DateTime.SpecifyKind(case_to_submit.Patient_BirthDate.AddHours(2).AddMinutes(33).AddSeconds(44), DateTimeKind.Local);
                submitted_case_model_elastic.patient_birthdate_string = case_to_submit.Patient_BirthDate.ToString("dd.MM.yyyy");
                submitted_case_model_elastic.patient_name = patient_details != null ? patient_details.patient_last_name + ", " + patient_details.patient_first_name : "";
                submitted_case_model_elastic.status = "FS" + Parameter.new_status;
                submitted_case_model_elastic.status_date = Parameter.status_date;
                submitted_case_model_elastic.status_date_string = Parameter.status_date.ToString("dd.MM.yyyy");
                submitted_case_model_elastic.treatment_date = case_to_submit.treatment_date;
                submitted_case_model_elastic.treatment_date_day_month = case_to_submit.treatment_date.ToString("dd.MM.");
                submitted_case_model_elastic.treatment_date_month_year = case_to_submit.treatment_date.ToString("MMMM yyyy", new System.Globalization.CultureInfo("de", true));
                submitted_case_model_elastic.drug = drug_details != null ? drug_details.drug_name : "";
                submitted_case_model_elastic.type = is_treatment ? "op" : "ac";
                submitted_case_model_elastic.treatment_date_string = case_to_submit.treatment_date.ToString("dd.MM.yyyy");
                submitted_case_model_elastic.patient_insurance_number = patient_details.insurance_id;

                if (is_treatment)
                {
                    submitted_case_model_elastic.doctor_name = treatment_doctor_details != null ? treatment_doctor_details.title + " " + treatment_doctor_details.last_name + " " + treatment_doctor_details.first_name : "-";
                    submitted_case_model_elastic.practice_name = treatment_doctor_details.practice;
                    submitted_case_model_elastic.doctor_lanr = treatment_doctor_details.lanr;
                    submitted_case_model_elastic.practice_bsnr = treatment_practice_details.practice_BSNR;
                }
                else
                {
                    submitted_case_model_elastic.doctor_name = aftercare_doctor_details.title + " " + aftercare_doctor_details.last_name + " " + aftercare_doctor_details.first_name;
                    submitted_case_model_elastic.practice_name = aftercare_doctor_details.practice;
                    submitted_case_model_elastic.doctor_lanr = aftercare_doctor_details.lanr;
                    submitted_case_model_elastic.practice_bsnr = aftercare_practice_details.practice_BSNR;
                }

                submitted_case_model_elastic.hip_name = patient_details != null ? patient_details.health_insurance_provider : "-";

                List<Submitted_Case_Model> cases_to_submit = new List<Submitted_Case_Model>();
                cases_to_submit.Add(submitted_case_model_elastic);

                Add_New_Submitted_Case.Import_Submitted_Case_Data_to_ElasticDB(cases_to_submit, securityTicket.TenantID.ToString());
            }

            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_CAS_CPASfPAID_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_CAS_CPASfPAID_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_CPASfPAID_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_CPASfPAID_1654 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_Change_PerformedAction_Status_for_PlannedActionID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_CAS_CPASfPAID_1654 for attribute P_CAS_CPASfPAID_1654
		[DataContract]
		public class P_CAS_CPASfPAID_1654 
		{
			//Standard type parameters
			[DataMember]
			public Guid planned_action_id { get; set; } 
			[DataMember]
			public Boolean all_selected { get; set; } 
			[DataMember]
			public Boolean change_status { get; set; } 
			[DataMember]
			public int new_status { get; set; } 
			[DataMember]
			public String primary_comment { get; set; } 
			[DataMember]
			public String secondary_comment { get; set; } 
			[DataMember]
			public Boolean? management_fee_waived { get; set; } 
			[DataMember]
			public DateTime status_date { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Change_PerformedAction_Status_for_PlannedActionID(,P_CAS_CPASfPAID_1654 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Change_PerformedAction_Status_for_PlannedActionID.Invoke(connectionString,P_CAS_CPASfPAID_1654 Parameter,securityTicket);
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
var parameter = new DataImporter.DBMethods.Case.Atomic.Manipulation.P_CAS_CPASfPAID_1654();
parameter.planned_action_id = ...;
parameter.all_selected = ...;
parameter.change_status = ...;
parameter.new_status = ...;
parameter.primary_comment = ...;
parameter.secondary_comment = ...;
parameter.management_fee_waived = ...;
parameter.status_date = ...;

*/
