/* 
 * Generated on 1/30/2015 3:17:33 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 */
using System;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using CSV2Core.Core;
using CSV2Core_MySQL.Dictionaries.MultiTable;
using CL1_HEC_DIA;
using CL1_HEC;
using CL2_Language.Atomic.Retrieval;
using CL1_HEC_ACT;
using CL5_MyHealthClub_MedProCommunity.Atomic.Retrieval;

namespace CL5_MyHealthClub_Examanations.Atomic.Manipulation
{
	[Serializable]
	public class cls_Save_PatientExaminationDiagnoses
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5PA_SPED_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Bool();
            returnValue.Result = false;

            P_L2LN_GALFTID_1530 langParam = new P_L2LN_GALFTID_1530();
            langParam.Tenant_RefID = securityTicket.TenantID;
            var DBLanguages = cls_Get_All_Languages_ForTenantID.Invoke(Connection, Transaction, langParam, securityTicket).Result;

            var medPro_Credentials = cls_Get_TenantMemershipData.Invoke(Connection, Transaction, securityTicket).Result;
            var examination = ORM_HEC_ACT_PerformedAction.Query.Search(Connection, Transaction, new ORM_HEC_ACT_PerformedAction.Query()
            {
                IsDeleted=false,
                Tenant_RefID = securityTicket.TenantID,
                HEC_ACT_PerformedActionID = Parameter.ExaminationID
            }).Single();
            #region save
     
            foreach (var item in Parameter.newDiagnoses)
            {
                if (medPro_Credentials.Credantial != null)
                {
                    var potentialDiagnosisQuery = new ORM_HEC_DIA_PotentialDiagnosis.Query();
                    potentialDiagnosisQuery.IsDeleted = false;
                    potentialDiagnosisQuery.Tenant_RefID = securityTicket.TenantID;
                    potentialDiagnosisQuery.PotentialDiagnosisITL = item.DiagnoseITL;

                    var potentialDiagnosis = ORM_HEC_DIA_PotentialDiagnosis.Query.Search(Connection, Transaction, potentialDiagnosisQuery).SingleOrDefault();

                    if (potentialDiagnosis == null)
                    {
                        potentialDiagnosis = new ORM_HEC_DIA_PotentialDiagnosis();
                        potentialDiagnosis.HEC_DIA_PotentialDiagnosisID = Guid.NewGuid();
                        potentialDiagnosis.ICD10_Code = item.DiagnoseICD10;

                        Dict name = new Dict("hec_dia_potentialdiagnoses");
                        for (int i = 0; i < DBLanguages.Length; i++)
                        {
                            name.AddEntry(DBLanguages[i].CMN_LanguageID, item.DiagnoseName);
                        }
                        potentialDiagnosis.PotentialDiagnosis_Name = name;
                        potentialDiagnosis.PotentialDiagnosisITL = item.DiagnoseITL;
                        potentialDiagnosis.Tenant_RefID = securityTicket.TenantID;
                        potentialDiagnosis.Creation_Timestamp = DateTime.Now;
                        potentialDiagnosis.Modification_Timestamp = DateTime.Now;
                        potentialDiagnosis.Save(Connection, Transaction);
                    }

                    //check if exists active patient diagnoses (same one)
                    var patientDiagQuery = new ORM_HEC_Patient_Diagnosis.Query();
                    patientDiagQuery.IsDeleted = false;
                    patientDiagQuery.Tenant_RefID = securityTicket.TenantID;
                    patientDiagQuery.R_IsActive = true;
                    patientDiagQuery.R_PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
                    patientDiagQuery.Patient_RefID = Parameter.PatientID;
                    var patientDiagExists = ORM_HEC_Patient_Diagnosis.Query.Search(Connection, Transaction, patientDiagQuery).SingleOrDefault();

                    if (patientDiagExists == null)
                    {
                        ORM_HEC_Patient_Diagnosis patientDiagnoses = new ORM_HEC_Patient_Diagnosis();
                        patientDiagnoses.HEC_Patient_DiagnosisID = Guid.NewGuid();
                        patientDiagnoses.Creation_Timestamp = DateTime.Now;
                        patientDiagnoses.Modification_Timestamp = DateTime.Now;
                        patientDiagnoses.R_IsActive = true;
                        patientDiagnoses.Patient_RefID = Parameter.PatientID;
                        patientDiagnoses.Tenant_RefID = securityTicket.TenantID;
                        patientDiagnoses.R_DiagnosedOnDate = examination.IfPerfomed_DateOfAction;
                        patientDiagnoses.R_ScheduledExpiryDate = patientDiagnoses.R_DiagnosedOnDate.AddDays(item.days_valid);
                        patientDiagnoses.R_PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
                        patientDiagnoses.Save(Connection, Transaction);

                        ORM_HEC_ACT_PerformedAction_DiagnosisUpdate diagnosisUpdate = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                        diagnosisUpdate.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                        diagnosisUpdate.Creation_Timestamp = DateTime.Now;
                        diagnosisUpdate.Modification_Timestamp = DateTime.Now;
                        diagnosisUpdate.Tenant_RefID = securityTicket.TenantID;
                        diagnosisUpdate.ScheduledExpiryDate = DateTime.Now.AddDays(item.days_valid);
                        diagnosisUpdate.PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
                        diagnosisUpdate.HEC_Patient_Diagnosis_RefID = patientDiagnoses.HEC_Patient_DiagnosisID;
                        diagnosisUpdate.HEC_ACT_PerformedAction_RefID = Parameter.ExaminationID;
                        diagnosisUpdate.Save(Connection, Transaction);
                    }


                }
                else 
                {
                    var potentialDiagnosisQuery = new ORM_HEC_DIA_PotentialDiagnosis.Query();
                    potentialDiagnosisQuery.IsDeleted = false;
                    potentialDiagnosisQuery.Tenant_RefID = securityTicket.TenantID;
                    potentialDiagnosisQuery.HEC_DIA_PotentialDiagnosisID = new Guid(item.DiagnoseITL);

                    var potentialDiagnosis = ORM_HEC_DIA_PotentialDiagnosis.Query.Search(Connection, Transaction, potentialDiagnosisQuery).SingleOrDefault();


                    //check if exists active patient diagnoses (same one)
                    var patientDiagQuery = new ORM_HEC_Patient_Diagnosis.Query();
                    patientDiagQuery.IsDeleted = false;
                    patientDiagQuery.Tenant_RefID = securityTicket.TenantID;
                    patientDiagQuery.R_IsActive = true;
                    patientDiagQuery.R_PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;

                    var patientDiagExists = ORM_HEC_Patient_Diagnosis.Query.Search(Connection, Transaction, patientDiagQuery).SingleOrDefault();

                    if (patientDiagExists == null)
                    {
                        ORM_HEC_Patient_Diagnosis patientDiagnoses = new ORM_HEC_Patient_Diagnosis();
                        patientDiagnoses.HEC_Patient_DiagnosisID = Guid.NewGuid();
                        patientDiagnoses.Creation_Timestamp = DateTime.Now;
                        patientDiagnoses.Modification_Timestamp = DateTime.Now;
                        patientDiagnoses.R_IsActive = true;
                        patientDiagnoses.Patient_RefID = Parameter.PatientID;
                        patientDiagnoses.Tenant_RefID = securityTicket.TenantID;
                        patientDiagnoses.R_DiagnosedOnDate = DateTime.Now;
                        patientDiagnoses.R_ScheduledExpiryDate = DateTime.Now.AddDays(item.days_valid);
                        patientDiagnoses.R_PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
                        patientDiagnoses.Save(Connection, Transaction);

                        ORM_HEC_ACT_PerformedAction_DiagnosisUpdate diagnosisUpdate = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate();
                        diagnosisUpdate.HEC_ACT_PerformedAction_DiagnosisUpdateID = Guid.NewGuid();
                        diagnosisUpdate.Creation_Timestamp = DateTime.Now;
                        diagnosisUpdate.Modification_Timestamp = DateTime.Now;
                        diagnosisUpdate.Tenant_RefID = securityTicket.TenantID;
                        diagnosisUpdate.ScheduledExpiryDate = DateTime.Now.AddDays(item.days_valid);
                        diagnosisUpdate.PotentialDiagnosis_RefID = potentialDiagnosis.HEC_DIA_PotentialDiagnosisID;
                        diagnosisUpdate.HEC_Patient_Diagnosis_RefID = patientDiagnoses.HEC_Patient_DiagnosisID;
                        diagnosisUpdate.HEC_ACT_PerformedAction_RefID = Parameter.ExaminationID;
                        diagnosisUpdate.Save(Connection, Transaction);
                    }
                }
            }

            #endregion

            #region negated

            foreach (var item in Parameter.deletedDiagnoses)
            {
                var patientDiagnosesQuery = new ORM_HEC_Patient_Diagnosis.Query();
                patientDiagnosesQuery.IsDeleted = false;
                patientDiagnosesQuery.R_IsNegated = false;
                patientDiagnosesQuery.R_IsActive = true;
                patientDiagnosesQuery.Tenant_RefID = securityTicket.TenantID;
                patientDiagnosesQuery.HEC_Patient_DiagnosisID = item.PatientDiagnoseID;

                var patientDiagnoses = ORM_HEC_Patient_Diagnosis.Query.Search(Connection, Transaction, patientDiagnosesQuery).Single();
                patientDiagnoses.R_IsNegated = true;
                patientDiagnoses.R_IsActive = false;
                patientDiagnoses.Save(Connection, Transaction);

                var diagnoseUpdateQuery = new ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query();
                diagnoseUpdateQuery.HEC_Patient_Diagnosis_RefID = item.PatientDiagnoseID;
                diagnoseUpdateQuery.IsDeleted = false;
                diagnoseUpdateQuery.IsDiagnosisNegated = false;
                diagnoseUpdateQuery.Tenant_RefID = securityTicket.TenantID;

                var patientUpdate = ORM_HEC_ACT_PerformedAction_DiagnosisUpdate.Query.Search(Connection, Transaction, diagnoseUpdateQuery).Single();
                patientUpdate.IsDiagnosisNegated = true;
                patientUpdate.Save(Connection, Transaction);
            }

            returnValue.Result = true;
            #endregion
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5PA_SPED_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5PA_SPED_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PA_SPED_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PA_SPED_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PA_SPED_1313 for attribute P_L5PA_SPED_1313
		[Serializable]
		public class P_L5PA_SPED_1313 
		{
			public P_L5PA_SPED_1313_newDiagnoses[] newDiagnoses;  
			public P_L5PA_SPED_1313_deletedDiagnoses[] deletedDiagnoses;  

			//Standard type parameters
			public Guid ExaminationID; 
			public Guid PatientID; 

		}
		#endregion
		#region SClass P_L5PA_SPED_1313_newDiagnoses for attribute newDiagnoses
		[Serializable]
		public class P_L5PA_SPED_1313_newDiagnoses 
		{
			//Standard type parameters
			public String DiagnoseITL; 
			public String DiagnoseName; 
			public String DiagnoseICD10; 
			public int days_valid; 

		}
		#endregion
		#region SClass P_L5PA_SPED_1313_deletedDiagnoses for attribute deletedDiagnoses
		[Serializable]
		public class P_L5PA_SPED_1313_deletedDiagnoses 
		{
			//Standard type parameters
			public Guid PatientDiagnoseID; 

		}
		#endregion

	#endregion
}
