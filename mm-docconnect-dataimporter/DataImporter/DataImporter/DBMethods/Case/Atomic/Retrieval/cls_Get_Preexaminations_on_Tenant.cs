/* 
 * Generated on 1/20/2017 2:33:28 PM
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

namespace DataImporter.DBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Preexaminations_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Preexaminations_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GPEoT_1816_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GPEoT_1816_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Preexaminations_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GPEoT_1816> results = new List<CAS_GPEoT_1816>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "IM_PotentialDiagnosisLocalization_Code","Patient_RefID","HEC_ACT_PlannedActionID","PlannedFor_Date","HEC_CAS_Case_BillCodeID","BIL_BillPosition_TransmitionStatusID","Case_RefID","HEC_CAS_Case_RelevantPerformedActionID","HEC_ACT_PerformedAction_DiagnosisUpdateID","HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID","IfPerformed_PerformedAction_RefID","CaseNumber","HEC_DoctorID","IsActive","TransmitionCode" });
				while(reader.Read())
				{
					CAS_GPEoT_1816 resultItem = new CAS_GPEoT_1816();
					//0:Parameter IM_PotentialDiagnosisLocalization_Code of type String
					resultItem.IM_PotentialDiagnosisLocalization_Code = reader.GetString(0);
					//1:Parameter Patient_RefID of type Guid
					resultItem.Patient_RefID = reader.GetGuid(1);
					//2:Parameter HEC_ACT_PlannedActionID of type Guid
					resultItem.HEC_ACT_PlannedActionID = reader.GetGuid(2);
					//3:Parameter PlannedFor_Date of type DateTime
					resultItem.PlannedFor_Date = reader.GetDate(3);
					//4:Parameter HEC_CAS_Case_BillCodeID of type Guid
					resultItem.HEC_CAS_Case_BillCodeID = reader.GetGuid(4);
					//5:Parameter BIL_BillPosition_TransmitionStatusID of type Guid
					resultItem.BIL_BillPosition_TransmitionStatusID = reader.GetGuid(5);
					//6:Parameter Case_RefID of type Guid
					resultItem.Case_RefID = reader.GetGuid(6);
					//7:Parameter HEC_CAS_Case_RelevantPerformedActionID of type Guid
					resultItem.HEC_CAS_Case_RelevantPerformedActionID = reader.GetGuid(7);
					//8:Parameter HEC_ACT_PerformedAction_DiagnosisUpdateID of type Guid
					resultItem.HEC_ACT_PerformedAction_DiagnosisUpdateID = reader.GetGuid(8);
					//9:Parameter HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID of type Guid
					resultItem.HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID = reader.GetGuid(9);
					//10:Parameter IfPerformed_PerformedAction_RefID of type Guid
					resultItem.IfPerformed_PerformedAction_RefID = reader.GetGuid(10);
					//11:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(11);
					//12:Parameter HEC_DoctorID of type Guid
					resultItem.HEC_DoctorID = reader.GetGuid(12);
					//13:Parameter IsActive of type Boolean
					resultItem.IsActive = reader.GetBoolean(13);
					//14:Parameter TransmitionCode of type int
					resultItem.TransmitionCode = reader.GetInteger(14);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Preexaminations_on_Tenant",ex);
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
		public static FR_CAS_GPEoT_1816_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GPEoT_1816_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GPEoT_1816_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GPEoT_1816_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GPEoT_1816_Array functionReturn = new FR_CAS_GPEoT_1816_Array();
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

				throw new Exception("Exception occured in method cls_Get_Preexaminations_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GPEoT_1816_Array : FR_Base
	{
		public CAS_GPEoT_1816[] Result	{ get; set; } 
		public FR_CAS_GPEoT_1816_Array() : base() {}

		public FR_CAS_GPEoT_1816_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GPEoT_1816 for attribute CAS_GPEoT_1816
		[DataContract]
		public class CAS_GPEoT_1816 
		{
			//Standard type parameters
			[DataMember]
			public String IM_PotentialDiagnosisLocalization_Code { get; set; } 
			[DataMember]
			public Guid Patient_RefID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PlannedActionID { get; set; } 
			[DataMember]
			public DateTime PlannedFor_Date { get; set; } 
			[DataMember]
			public Guid HEC_CAS_Case_BillCodeID { get; set; } 
			[DataMember]
			public Guid BIL_BillPosition_TransmitionStatusID { get; set; } 
			[DataMember]
			public Guid Case_RefID { get; set; } 
			[DataMember]
			public Guid HEC_CAS_Case_RelevantPerformedActionID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PerformedAction_DiagnosisUpdateID { get; set; } 
			[DataMember]
			public Guid HEC_ACT_PerformedAction_DiagnosisUpdate_LocalizationID { get; set; } 
			[DataMember]
			public Guid IfPerformed_PerformedAction_RefID { get; set; } 
			[DataMember]
			public String CaseNumber { get; set; } 
			[DataMember]
			public Guid HEC_DoctorID { get; set; } 
			[DataMember]
			public Boolean IsActive { get; set; } 
			[DataMember]
			public int TransmitionCode { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GPEoT_1816_Array cls_Get_Preexaminations_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GPEoT_1816_Array invocationResult = cls_Get_Preexaminations_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

