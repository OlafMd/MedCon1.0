/* 
 * Generated on 8/5/2013 10:44:00 AM
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
    /// var result = cls_Get_Diagnosis_for_DiagnosisID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Diagnosis_for_DiagnosisID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5GDfDID_1038_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5GDfDID_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5GDfDID_1038_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Diagnosis.Atomic.Retrieval.SQL.cls_Get_Diagnosis_for_DiagnosisID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"DiagnosisID", Parameter.DiagnosisID);


			List<L5GDfDID_1038_raw> results = new List<L5GDfDID_1038_raw>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_DIA_PotentialDiagnosisID","ICD10_Code","PotentialDiagnosis_Description_DictID","PotentialDiagnosis_Name_DictID","DiagnosisState_Name_DictID","DiagnosisState_Abbreviation","HEC_DIA_Diagnosis_StateID","DiagnosisLocalization_Name_DictID","HEC_DIA_Diagnosis_LocalizationID" });
				while(reader.Read())
				{
					L5GDfDID_1038_raw resultItem = new L5GDfDID_1038_raw();
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

			returnStatus.Result = L5GDfDID_1038_raw.Convert(results).ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5GDfDID_1038_Array Invoke(string ConnectionString,P_L5GDfDID_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5GDfDID_1038_Array Invoke(DbConnection Connection,P_L5GDfDID_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5GDfDID_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5GDfDID_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5GDfDID_1038_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5GDfDID_1038 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5GDfDID_1038_Array functionReturn = new FR_L5GDfDID_1038_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5GDfDID_1038_raw 
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

		public static L5GDfDID_1038[] Convert(List<L5GDfDID_1038_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5GDfDID_1038 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.HEC_DIA_PotentialDiagnosisID)).ToArray()
	group el_L5GDfDID_1038 by new 
	{ 
		el_L5GDfDID_1038.HEC_DIA_PotentialDiagnosisID,

	}
	into gfunct_L5GDfDID_1038
	select new L5GDfDID_1038
	{     
		HEC_DIA_PotentialDiagnosisID = gfunct_L5GDfDID_1038.Key.HEC_DIA_PotentialDiagnosisID ,
		ICD10_Code = gfunct_L5GDfDID_1038.FirstOrDefault().ICD10_Code ,
		PotentialDiagnosis_Description = gfunct_L5GDfDID_1038.FirstOrDefault().PotentialDiagnosis_Description ,
		PotentialDiagnosis_Name = gfunct_L5GDfDID_1038.FirstOrDefault().PotentialDiagnosis_Name ,

		States = 
		(
			from el_States in gfunct_L5GDfDID_1038.Where(element => !EqualsDefaultValue(element.HEC_DIA_Diagnosis_StateID)).ToArray()
			group el_States by new 
			{ 
				el_States.HEC_DIA_Diagnosis_StateID,

			}
			into gfunct_States
			select new L5GDfDID_1038_States
			{     
				DiagnosisState_Name = gfunct_States.FirstOrDefault().DiagnosisState_Name ,
				DiagnosisState_Abbreviation = gfunct_States.FirstOrDefault().DiagnosisState_Abbreviation ,
				HEC_DIA_Diagnosis_StateID = gfunct_States.Key.HEC_DIA_Diagnosis_StateID ,

			}
		).ToArray(),
		Localization = 
		(
			from el_Localization in gfunct_L5GDfDID_1038.Where(element => !EqualsDefaultValue(element.HEC_DIA_Diagnosis_LocalizationID)).ToArray()
			group el_Localization by new 
			{ 
				el_Localization.HEC_DIA_Diagnosis_LocalizationID,

			}
			into gfunct_Localization
			select new L5GDfDID_1038_Localization
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
	public class FR_L5GDfDID_1038_Array : FR_Base
	{
		public L5GDfDID_1038[] Result	{ get; set; } 
		public FR_L5GDfDID_1038_Array() : base() {}

		public FR_L5GDfDID_1038_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5GDfDID_1038 for attribute P_L5GDfDID_1038
		[DataContract]
		public class P_L5GDfDID_1038 
		{
			//Standard type parameters
			[DataMember]
			public Guid DiagnosisID { get; set; } 

		}
		#endregion
		#region SClass L5GDfDID_1038 for attribute L5GDfDID_1038
		[DataContract]
		public class L5GDfDID_1038 
		{
			[DataMember]
			public L5GDfDID_1038_States[] States { get; set; }
			[DataMember]
			public L5GDfDID_1038_Localization[] Localization { get; set; }

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
		#region SClass L5GDfDID_1038_States for attribute States
		[DataContract]
		public class L5GDfDID_1038_States 
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
		#region SClass L5GDfDID_1038_Localization for attribute Localization
		[DataContract]
		public class L5GDfDID_1038_Localization 
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
