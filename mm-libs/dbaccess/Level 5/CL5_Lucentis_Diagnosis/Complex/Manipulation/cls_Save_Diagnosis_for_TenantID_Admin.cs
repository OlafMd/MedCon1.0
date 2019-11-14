/* 
 * Generated on 8/5/2013 11:28:31 AM
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
using CL1_HEC_DIA;

namespace CL5_Lucentis_Diagnosis.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Diagnosis_for_TenantID_Admin.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Diagnosis_for_TenantID_Admin
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5DG_SDfTIDA_10_32 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var item = new ORM_HEC_DIA_PotentialDiagnosis();

            if (Parameter.HEC_DIA_PotentialDiagnosisID != Guid.Empty)
            {
                var result = item.Load(Connection, Transaction, Parameter.HEC_DIA_PotentialDiagnosisID);
                if (result.Status != FR_Status.Success || item.HEC_DIA_PotentialDiagnosisID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            else
            {
                item.HEC_DIA_PotentialDiagnosisID = Guid.NewGuid();
                returnValue.Result = item.HEC_DIA_PotentialDiagnosisID;
            }


            if (Parameter.IsDeleted == true)
            {
                var query_DiagnosisStates_del = new ORM_HEC_DIA_Diagnosis_State.Query();
                query_DiagnosisStates_del.Diagnose_RefID = Parameter.HEC_DIA_PotentialDiagnosisID;

                var found_DiagnosisStates_del = ORM_HEC_DIA_Diagnosis_State.Query.Search(Connection, Transaction, query_DiagnosisStates_del);

                var query_Localizations_del = new ORM_HEC_DIA_Diagnosis_Localization.Query();
                query_Localizations_del.Diagnosis_RefID = Parameter.HEC_DIA_PotentialDiagnosisID;

                var found_Localizations_del = ORM_HEC_DIA_Diagnosis_Localization.Query.Search(Connection, Transaction, query_Localizations_del);

                foreach (var foundState in found_DiagnosisStates_del)
                {                    
                    foundState.IsDeleted = true;
                    foundState.Save(Connection, Transaction);                       
                }             

                foreach (var foundLocalization in found_Localizations_del)
                {                    
                    foundLocalization.IsDeleted = true;
                    foundLocalization.Save(Connection, Transaction);              
                }

                item.IsDeleted = true;
                return new FR_Guid(item.Save(Connection, Transaction), item.HEC_DIA_PotentialDiagnosisID);
            }

            //Save Diagnoses

            Dict diagnosis_nameDict = new Dict("hec_dia_potentialdiagnoses");
            diagnosis_nameDict = Parameter.PotentialDiagnosis_Name_DictID;

            item.Tenant_RefID = securityTicket.TenantID;
            item.Creation_Timestamp = DateTime.Now;
            item.ICD10_Code = Parameter.ICD10_Code;
            //item.PotentialDiagnosis_Name_DictID = diagnosis_nameDict;
            item.PotentialDiagnosis_Description = Parameter.PotentialDiagnosis_Description;
            item.Save(Connection, Transaction);

            // save States
            foreach (var stateParam in Parameter.DiagnosisStates)
            {

                Dict state_nameDict = new Dict("hec_dia_diagnosis_states");
                state_nameDict = stateParam.DiagnosisState_Name;


                var queryState = new ORM_HEC_DIA_Diagnosis_State.Query();
                queryState.HEC_DIA_Diagnosis_StateID = stateParam.HEC_DIA_Diagnosis_StateID;
                queryState.Diagnose_RefID = stateParam.Diagnose_RefID;

                var stateResult = ORM_HEC_DIA_Diagnosis_State.Query.Search(Connection, Transaction, queryState);

                //new State
                if (stateResult.Count == 0)
                {
                    var state = new ORM_HEC_DIA_Diagnosis_State();
                    state.HEC_DIA_Diagnosis_StateID = stateParam.HEC_DIA_Diagnosis_StateID;
                    Dict abbrev = new Dict();
                    state.DiagnosisState_Abbreviation = stateParam.DiagnosisState_Abbreviation;
                    state.DiagnosisState_Name = state_nameDict;
                    state.Diagnose_RefID = item.HEC_DIA_PotentialDiagnosisID;
                    state.Creation_Timestamp = DateTime.Now;
                    state.Tenant_RefID = securityTicket.TenantID;
                    state.IsDeleted = false;
                    state.Save(Connection,Transaction);
                }
                else//edit State
                {
                    if (stateParam.IsDeleted == true)
                    {
                        stateResult[0].IsDeleted = true;
                        stateResult[0].Save(Connection, Transaction);
                    }
                    else
                    {
                        if (stateResult[0].DiagnosisState_Name != null || Parameter.IsDeleted == true)
                        {
                            foreach (var entry in state_nameDict.Contents)
                            {
                                stateResult[0].DiagnosisState_Name.UpdateEntry(entry.LanguageID, entry.Content);
                            }
                        }
                        stateResult[0].DiagnosisState_Abbreviation = stateParam.DiagnosisState_Abbreviation;
                        stateResult[0].Save(Connection, Transaction);
                    }
                   
                }              
            }

            //Diagnosis Localization
            foreach (var localizationParam in Parameter.DiagnosisLocalizations)
            {
                Dict localization_nameDict = new Dict("hec_dia_diagnosis_localizations");
                localization_nameDict = localizationParam.DiagnosisLocalization_Name;

                var queryLocalization = new ORM_HEC_DIA_Diagnosis_Localization.Query();
                queryLocalization.HEC_DIA_Diagnosis_LocalizationID = localizationParam.HEC_DIA_Diagnosis_LocalizationID;
                queryLocalization.Diagnosis_RefID = localizationParam.Diagnosis_RefID;

                var localizationResult = ORM_HEC_DIA_Diagnosis_Localization.Query.Search(Connection, Transaction, queryLocalization);

                if (localizationResult.Count == 0)
                {
                    var localization = new ORM_HEC_DIA_Diagnosis_Localization();
                    localization.HEC_DIA_Diagnosis_LocalizationID = localizationParam.HEC_DIA_Diagnosis_LocalizationID;
                    localization.DiagnosisLocalization_Name = localization_nameDict;
                    localization.Creation_Timestamp = DateTime.Now;
                    localization.Tenant_RefID = securityTicket.TenantID;
                    localization.Diagnosis_RefID = item.HEC_DIA_PotentialDiagnosisID;
                    localization.IsDeleted = false;
                    localization.Save(Connection, Transaction);
                }
                else
                {
                    if (localizationParam.IsDeleted == true || Parameter.IsDeleted == true)
                    {
                        localizationResult[0].IsDeleted = true;
                        localizationResult[0].Save(Connection, Transaction);
                    }
                    else
                    {
                        if (localizationResult[0].DiagnosisLocalization_Name != null)
                        {
                            foreach (var entry in localization_nameDict.Contents)
                            {
                                localizationResult[0].DiagnosisLocalization_Name.UpdateEntry(entry.LanguageID, entry.Content);
                            }
                        }
                        localizationResult[0].Save(Connection, Transaction);
                    }
                   
                }
            }

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5DG_SDfTIDA_10_32 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5DG_SDfTIDA_10_32 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DG_SDfTIDA_10_32 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DG_SDfTIDA_10_32 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5DG_SDfTIDA_10_32 for attribute P_L5DG_SDfTIDA_10_32
		[DataContract]
		public class P_L5DG_SDfTIDA_10_32 
		{
			[DataMember]
			public L5DG_SDfTIDA_10_32_States[] DiagnosisStates { get; set; }
			[DataMember]
			public L5DG_SDfTIDA_10_32_Localizations[] DiagnosisLocalizations { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Description { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name_DictID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 

		}
		#endregion
		#region SClass L5DG_SDfTIDA_10_32_States for attribute DiagnosisStates
		[DataContract]
		public class L5DG_SDfTIDA_10_32_States 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_Diagnosis_StateID { get; set; } 
			[DataMember]
			public String DiagnosisState_Abbreviation { get; set; } 
			[DataMember]
			public Dict DiagnosisState_Name { get; set; } 
			[DataMember]
			public Dict DiagnosisState_Description { get; set; } 
			[DataMember]
			public Guid Diagnose_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion
		#region SClass L5DG_SDfTIDA_10_32_Localizations for attribute DiagnosisLocalizations
		[DataContract]
		public class L5DG_SDfTIDA_10_32_Localizations 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_Diagnosis_LocalizationID { get; set; } 
			[DataMember]
			public Dict DiagnosisLocalization_Name { get; set; } 
			[DataMember]
			public Dict DiagnosisLocalization_Description { get; set; } 
			[DataMember]
			public Guid Diagnosis_RefID { get; set; } 
			[DataMember]
			public Boolean IsDeleted { get; set; } 

		}
		#endregion

	#endregion
}
