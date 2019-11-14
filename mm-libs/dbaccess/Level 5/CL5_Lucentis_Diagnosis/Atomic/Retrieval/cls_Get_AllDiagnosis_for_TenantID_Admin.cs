/* 
 * Generated on 8/5/2013 8:58:25 AM
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
    /// var result = cls_Get_AllDiagnosis_for_TenantID_Admin.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDiagnosis_for_TenantID_Admin
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_GADfTID_1605_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_GADfTID_1605_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Diagnosis.Atomic.Retrieval.SQL.cls_Get_AllDiagnosis_for_TenantID_Admin.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			List<GADfTID_1605_raw> results = new List<GADfTID_1605_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DIA_PotentialDiagnosisID","ICD10_Code","PotentialDiagnosis_Description_DictID","PotentialDiagnosis_Name_DictID","DiagnosisState_Name_DictID","DiagnosisState_Abbreviation","HEC_DIA_Diagnosis_StateID","DiagnosisLocalization_Name_DictID","HEC_DIA_Diagnosis_LocalizationID" });
				while(reader.Read())
				{
					GADfTID_1605_raw resultItem = new GADfTID_1605_raw();
					//0:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(0);
					//1:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(1);
					//2:Parameter PotentialDiagnosis_Description of type Dict
					resultItem.PotentialDiagnosis_Description = reader.GetDictionary(2);
					resultItem.PotentialDiagnosis_Description.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Description);
					//3:Parameter PotentialDiagnosis_Name of type Dict
					resultItem.PotentialDiagnosis_Name = reader.GetDictionary(3);
					resultItem.PotentialDiagnosis_Name.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name);
					//4:Parameter DiagnosisState_Name of type Dict
					resultItem.DiagnosisState_Name = reader.GetDictionary(4);
					resultItem.DiagnosisState_Name.SourceTable = "hec_dia_diagnosis_states";
					loader.Append(resultItem.DiagnosisState_Name);
					//5:Parameter DiagnosisState_Abbreviation of type String
					resultItem.DiagnosisState_Abbreviation = reader.GetString(5);
					//6:Parameter HEC_DIA_Diagnosis_StateID of type Guid
					resultItem.HEC_DIA_Diagnosis_StateID = reader.GetGuid(6);
					//7:Parameter DiagnosisLocalization_Name of type Dict
					resultItem.DiagnosisLocalization_Name = reader.GetDictionary(7);
					resultItem.DiagnosisLocalization_Name.SourceTable = "hec_dia_diagnosis_localizations";
					loader.Append(resultItem.DiagnosisLocalization_Name);
					//8:Parameter HEC_DIA_Diagnosis_LocalizationID of type Guid
					resultItem.HEC_DIA_Diagnosis_LocalizationID = reader.GetGuid(8);

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

			returnStatus.Result = GADfTID_1605_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_GADfTID_1605_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_GADfTID_1605_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_GADfTID_1605_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_GADfTID_1605_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_GADfTID_1605_Array functionReturn = new FR_GADfTID_1605_Array();
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
	public class GADfTID_1605_raw 
	{
		public Guid HEC_DIA_PotentialDiagnosisID; 
		public String ICD10_Code; 
		public Dict PotentialDiagnosis_Description; 
		public Dict PotentialDiagnosis_Name; 
		public Dict DiagnosisState_Name; 
		public String DiagnosisState_Abbreviation; 
		public Guid HEC_DIA_Diagnosis_StateID; 
		public Dict DiagnosisLocalization_Name; 
		public Guid HEC_DIA_Diagnosis_LocalizationID; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static GADfTID_1605[] Convert(List<GADfTID_1605_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_GADfTID_1605 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DIA_PotentialDiagnosisID)).ToArray()
	group el_GADfTID_1605 by new 
	{ 
		el_GADfTID_1605.HEC_DIA_PotentialDiagnosisID,

	}
	into gfunct_GADfTID_1605
	select new GADfTID_1605
	{     
		HEC_DIA_PotentialDiagnosisID = gfunct_GADfTID_1605.Key.HEC_DIA_PotentialDiagnosisID ,
		ICD10_Code = gfunct_GADfTID_1605.FirstOrDefault().ICD10_Code ,
		PotentialDiagnosis_Description = gfunct_GADfTID_1605.FirstOrDefault().PotentialDiagnosis_Description ,
		PotentialDiagnosis_Name = gfunct_GADfTID_1605.FirstOrDefault().PotentialDiagnosis_Name ,

		States = 
		(
			from el_States in gfunct_GADfTID_1605.Where(element => !EqualsDefaultValue(element.HEC_DIA_Diagnosis_StateID)).ToArray()
			group el_States by new 
			{ 
				el_States.HEC_DIA_Diagnosis_StateID,

			}
			into gfunct_States
			select new GADfTID_1605_States
			{     
				DiagnosisState_Name = gfunct_States.FirstOrDefault().DiagnosisState_Name ,
				DiagnosisState_Abbreviation = gfunct_States.FirstOrDefault().DiagnosisState_Abbreviation ,
				HEC_DIA_Diagnosis_StateID = gfunct_States.Key.HEC_DIA_Diagnosis_StateID ,

			}
		).ToArray(),
		Localization = 
		(
			from el_Localization in gfunct_GADfTID_1605.Where(element => !EqualsDefaultValue(element.HEC_DIA_Diagnosis_LocalizationID)).ToArray()
			group el_Localization by new 
			{ 
				el_Localization.HEC_DIA_Diagnosis_LocalizationID,

			}
			into gfunct_Localization
			select new GADfTID_1605_Localization
			{     
				DiagnosisLocalization_Name = gfunct_Localization.FirstOrDefault().DiagnosisLocalization_Name ,
				HEC_DIA_Diagnosis_LocalizationID = gfunct_Localization.Key.HEC_DIA_Diagnosis_LocalizationID ,

			}
		).ToArray(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_GADfTID_1605_Array : FR_Base
	{
		public GADfTID_1605[] Result	{ get; set; } 
		public FR_GADfTID_1605_Array() : base() {}

		public FR_GADfTID_1605_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass GADfTID_1605 for attribute GADfTID_1605
		[DataContract]
		public class GADfTID_1605 
		{
			[DataMember]
			public GADfTID_1605_States[] States { get; set; }
			[DataMember]
			public GADfTID_1605_Localization[] Localization { get; set; }

			//Standard type parameters
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Description { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name { get; set; } 

		}
		#endregion
		#region SClass GADfTID_1605_States for attribute States
		[DataContract]
		public class GADfTID_1605_States 
		{
			//Standard type parameters
			[DataMember]
			public Dict DiagnosisState_Name { get; set; } 
			[DataMember]
			public String DiagnosisState_Abbreviation { get; set; } 
			[DataMember]
			public Guid HEC_DIA_Diagnosis_StateID { get; set; } 

		}
		#endregion
		#region SClass GADfTID_1605_Localization for attribute Localization
		[DataContract]
		public class GADfTID_1605_Localization 
		{
			//Standard type parameters
			[DataMember]
			public Dict DiagnosisLocalization_Name { get; set; } 
			[DataMember]
			public Guid HEC_DIA_Diagnosis_LocalizationID { get; set; } 

		}
		#endregion

	#endregion
}
