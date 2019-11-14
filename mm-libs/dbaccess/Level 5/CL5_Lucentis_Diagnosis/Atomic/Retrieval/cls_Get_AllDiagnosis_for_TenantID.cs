/* 
 * Generated on 7/8/2013 2:21:44 PM
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

namespace CL5_Lucentis_Diagnosis.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllDiagnosis_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDiagnosis_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DG_GADfT_1422_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DG_GADfT_1422_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Diagnosis.Atomic.Retrieval.SQL.cls_Get_AllDiagnosis_for_TenantID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<L5DG_GADfT_1422_raw> results = new List<L5DG_GADfT_1422_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DIA_PotentialDiagnosisID","ICD10_Code","PotentialDiagnosis_Name_DictID","HEC_DIA_Diagnosis_StateID","DiagnosisState_Abbreviation","DiagnosisState_Name_DictID","HEC_DIA_Diagnosis_LocalizationID","DiagnosisLocalization_Name_DictID" });
				while(reader.Read())
				{
					L5DG_GADfT_1422_raw resultItem = new L5DG_GADfT_1422_raw();
					//0:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(0);
					//1:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(1);
					//2:Parameter PotentialDiagnosis_Name_DictID of type Dict
					resultItem.PotentialDiagnosis_Name_DictID = reader.GetDictionary(2);
					resultItem.PotentialDiagnosis_Name_DictID.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name_DictID);
					//3:Parameter HEC_DIA_Diagnosis_StateID of type Guid
					resultItem.HEC_DIA_Diagnosis_StateID = reader.GetGuid(3);
					//4:Parameter DiagnosisState_Abbreviation of type String
					resultItem.DiagnosisState_Abbreviation = reader.GetString(4);
					//5:Parameter DiagnosisState_Name of type Dict
					resultItem.DiagnosisState_Name = reader.GetDictionary(5);
					resultItem.DiagnosisState_Name.SourceTable = "hec_dia_diagnosis_states";
					loader.Append(resultItem.DiagnosisState_Name);
					//6:Parameter HEC_DIA_Diagnosis_LocalizationID of type Guid
					resultItem.HEC_DIA_Diagnosis_LocalizationID = reader.GetGuid(6);
					//7:Parameter DiagnosisLocalization_Name of type Dict
					resultItem.DiagnosisLocalization_Name = reader.GetDictionary(7);
					resultItem.DiagnosisLocalization_Name.SourceTable = "hec_dia_diagnosis_localizations";
					loader.Append(resultItem.DiagnosisLocalization_Name);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw ex;
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = L5DG_GADfT_1422_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DG_GADfT_1422_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DG_GADfT_1422_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DG_GADfT_1422_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DG_GADfT_1422_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DG_GADfT_1422_Array functionReturn = new FR_L5DG_GADfT_1422_Array();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);


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

	#region Raw Grouping Class
	[Serializable]
	public class L5DG_GADfT_1422_raw 
	{
		public Guid HEC_DIA_PotentialDiagnosisID; 
		public String ICD10_Code; 
		public Dict PotentialDiagnosis_Name_DictID; 
		public Guid HEC_DIA_Diagnosis_StateID; 
		public String DiagnosisState_Abbreviation; 
		public Dict DiagnosisState_Name; 
		public Guid HEC_DIA_Diagnosis_LocalizationID; 
		public Dict DiagnosisLocalization_Name; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5DG_GADfT_1422[] Convert(List<L5DG_GADfT_1422_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5DG_GADfT_1422 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DIA_PotentialDiagnosisID)).ToArray()
	group el_L5DG_GADfT_1422 by new 
	{ 
		el_L5DG_GADfT_1422.HEC_DIA_PotentialDiagnosisID,

	}
	into gfunct_L5DG_GADfT_1422
	select new L5DG_GADfT_1422
	{     
		HEC_DIA_PotentialDiagnosisID = gfunct_L5DG_GADfT_1422.Key.HEC_DIA_PotentialDiagnosisID ,
		ICD10_Code = gfunct_L5DG_GADfT_1422.FirstOrDefault().ICD10_Code ,
		PotentialDiagnosis_Name_DictID = gfunct_L5DG_GADfT_1422.FirstOrDefault().PotentialDiagnosis_Name_DictID ,

		States = 
		(
			from el_States in gfunct_L5DG_GADfT_1422.Where(element => !EqualsDefaultValue(element.HEC_DIA_Diagnosis_StateID)).ToArray()
			group el_States by new 
			{ 
				el_States.HEC_DIA_Diagnosis_StateID,

			}
			into gfunct_States
			select new L5DG_GADfT_1422a
			{     
				HEC_DIA_Diagnosis_StateID = gfunct_States.Key.HEC_DIA_Diagnosis_StateID ,
				DiagnosisState_Abbreviation = gfunct_States.FirstOrDefault().DiagnosisState_Abbreviation ,
				DiagnosisState_Name = gfunct_States.FirstOrDefault().DiagnosisState_Name ,

			}
		).ToArray(),
		Localizations = 
		(
			from el_Localizations in gfunct_L5DG_GADfT_1422.Where(element => !EqualsDefaultValue(element.HEC_DIA_Diagnosis_LocalizationID)).ToArray()
			group el_Localizations by new 
			{ 
				el_Localizations.HEC_DIA_Diagnosis_LocalizationID,

			}
			into gfunct_Localizations
			select new L5DG_GADfT_1422b
			{     
				HEC_DIA_Diagnosis_LocalizationID = gfunct_Localizations.Key.HEC_DIA_Diagnosis_LocalizationID ,
				DiagnosisLocalization_Name = gfunct_Localizations.FirstOrDefault().DiagnosisLocalization_Name ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5DG_GADfT_1422_Array : FR_Base
	{
		public L5DG_GADfT_1422[] Result	{ get; set; } 
		public FR_L5DG_GADfT_1422_Array() : base() {}

		public FR_L5DG_GADfT_1422_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L5DG_GADfT_1422 for attribute L5DG_GADfT_1422
		[DataContract]
		public class L5DG_GADfT_1422 
		{
			[DataMember]
			public L5DG_GADfT_1422a[] States { get; set; }
			[DataMember]
			public L5DG_GADfT_1422b[] Localizations { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name_DictID { get; set; } 

		}
		#endregion
		#region SClass L5DG_GADfT_1422a for attribute States
		[DataContract]
		public class L5DG_GADfT_1422a 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_Diagnosis_StateID { get; set; } 
			[DataMember]
			public String DiagnosisState_Abbreviation { get; set; } 
			[DataMember]
			public Dict DiagnosisState_Name { get; set; } 

		}
		#endregion
		#region SClass L5DG_GADfT_1422b for attribute Localizations
		[DataContract]
		public class L5DG_GADfT_1422b 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_Diagnosis_LocalizationID { get; set; } 
			[DataMember]
			public Dict DiagnosisLocalization_Name { get; set; } 

		}
		#endregion

	#endregion
}
