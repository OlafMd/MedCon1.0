/* 
 * Generated on 8/15/2013 1:12:56 PM
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
    /// var result = cls_Get_AllDiagnosis_for_PatientID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllDiagnosis_for_PatientID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5DG_GADfP_0950_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5DG_GADfP_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5DG_GADfP_0950_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_Lucentis_Diagnosis.Atomic.Retrieval.SQL.cls_Get_AllDiagnosis_for_PatientID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"PatientID", Parameter.PatientID);


			List<L5DG_GADfP_0950> results = new List<L5DG_GADfP_0950>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_Patient_DiagnosisID","HEC_DIA_PotentialDiagnosisID","ICD10_Code","PotentialDiagnosis_Name_DictID","HEC_DIA_Diagnosis_StateID","DiagnosisState_Abbreviation","DiagnosisState_Name_DictID","HEC_DIA_Diagnosis_LocalizationID","DiagnosisLocalization_Name_DictID","CreationDate","DiagnosedOnDate","DoctorFirstName","DoctorLastName","HEC_DoctorID" });
				while(reader.Read())
				{
					L5DG_GADfP_0950 resultItem = new L5DG_GADfP_0950();
					//0:Parameter HEC_Patient_DiagnosisID of type Guid
					resultItem.HEC_Patient_DiagnosisID = reader.GetGuid(0);
					//1:Parameter HEC_DIA_PotentialDiagnosisID of type Guid
					resultItem.HEC_DIA_PotentialDiagnosisID = reader.GetGuid(1);
					//2:Parameter ICD10_Code of type String
					resultItem.ICD10_Code = reader.GetString(2);
					//3:Parameter PotentialDiagnosis_Name_DictID of type Dict
					resultItem.PotentialDiagnosis_Name_DictID = reader.GetDictionary(3);
					resultItem.PotentialDiagnosis_Name_DictID.SourceTable = "hec_dia_potentialdiagnoses";
					loader.Append(resultItem.PotentialDiagnosis_Name_DictID);
					//4:Parameter HEC_DIA_Diagnosis_StateID of type Guid
					resultItem.HEC_DIA_Diagnosis_StateID = reader.GetGuid(4);
					//5:Parameter DiagnosisState_Abbreviation of type String
					resultItem.DiagnosisState_Abbreviation = reader.GetString(5);
					//6:Parameter DiagnosisState_Name of type Dict
					resultItem.DiagnosisState_Name = reader.GetDictionary(6);
					resultItem.DiagnosisState_Name.SourceTable = "hec_dia_diagnosis_states";
					loader.Append(resultItem.DiagnosisState_Name);
					//7:Parameter HEC_DIA_Diagnosis_LocalizationID of type Guid
					resultItem.HEC_DIA_Diagnosis_LocalizationID = reader.GetGuid(7);
					//8:Parameter DiagnosisLocalization_Name of type Dict
					resultItem.DiagnosisLocalization_Name = reader.GetDictionary(8);
					resultItem.DiagnosisLocalization_Name.SourceTable = "hec_dia_diagnosis_localizations";
					loader.Append(resultItem.DiagnosisLocalization_Name);
					//9:Parameter CreationDate of type DateTime
					resultItem.CreationDate = reader.GetDate(9);
					//10:Parameter DiagnosedOnDate of type DateTime
					resultItem.DiagnosedOnDate = reader.GetDate(10);
					//11:Parameter DoctorFirstName of type String
					resultItem.DoctorFirstName = reader.GetString(11);
					//12:Parameter DoctorLastName of type String
					resultItem.DoctorLastName = reader.GetString(12);
					//13:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(13);

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

			returnStatus.Result = results.ToArray();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5DG_GADfP_0950_Array Invoke(string ConnectionString,P_L5DG_GADfP_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5DG_GADfP_0950_Array Invoke(DbConnection Connection,P_L5DG_GADfP_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5DG_GADfP_0950_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5DG_GADfP_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5DG_GADfP_0950_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5DG_GADfP_0950 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5DG_GADfP_0950_Array functionReturn = new FR_L5DG_GADfP_0950_Array();
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

	#region Custom Return Type
	[Serializable]
	public class FR_L5DG_GADfP_0950_Array : FR_Base
	{
		public L5DG_GADfP_0950[] Result	{ get; set; } 
		public FR_L5DG_GADfP_0950_Array() : base() {}

		public FR_L5DG_GADfP_0950_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5DG_GADfP_0950 for attribute P_L5DG_GADfP_0950
		[DataContract]
		public class P_L5DG_GADfP_0950 
		{
			//Standard type parameters
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion
		#region SClass L5DG_GADfP_0950 for attribute L5DG_GADfP_0950
		[DataContract]
		public class L5DG_GADfP_0950 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_Patient_DiagnosisID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_PotentialDiagnosisID { get; set; } 
			[DataMember]
			public String ICD10_Code { get; set; } 
			[DataMember]
			public Dict PotentialDiagnosis_Name_DictID { get; set; } 
			[DataMember]
			public Guid HEC_DIA_Diagnosis_StateID { get; set; } 
			[DataMember]
			public String DiagnosisState_Abbreviation { get; set; } 
			[DataMember]
			public Dict DiagnosisState_Name { get; set; } 
			[DataMember]
			public Guid HEC_DIA_Diagnosis_LocalizationID { get; set; } 
			[DataMember]
			public Dict DiagnosisLocalization_Name { get; set; } 
			[DataMember]
			public DateTime CreationDate { get; set; } 
			[DataMember]
			public DateTime DiagnosedOnDate { get; set; } 
			[DataMember]
			public String DoctorFirstName { get; set; } 
			[DataMember]
			public String DoctorLastName { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 

		}
		#endregion

	#endregion
}
