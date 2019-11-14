/* 
 * Generated on 1/20/2017 2:31:26 PM
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

namespace DataImporter.DBMethods.Patient.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PatientParticipationConsents_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PatientParticipationConsents_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_PA_GPPCoT_1026_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_PA_GPPCoT_1026_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "DataImporter.DBMethods.Patient.Atomic.Retrieval.SQL.cls_Get_PatientParticipationConsents_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<PA_GPPCoT_1026> results = new List<PA_GPPCoT_1026>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "participationFrom","partiicipationThrough","ContractName","contractValidFrom","contractValidThrough","HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID","contractID","PatientID" });
				while(reader.Read())
				{
					PA_GPPCoT_1026 resultItem = new PA_GPPCoT_1026();
					//0:Parameter participationFrom of type DateTime
					resultItem.participationFrom = reader.GetDate(0);
					//1:Parameter partiicipationThrough of type DateTime
					resultItem.partiicipationThrough = reader.GetDate(1);
					//2:Parameter ContractName of type String
					resultItem.ContractName = reader.GetString(2);
					//3:Parameter contractValidFrom of type DateTime
					resultItem.contractValidFrom = reader.GetDate(3);
					//4:Parameter contractValidThrough of type DateTime
					resultItem.contractValidThrough = reader.GetDate(4);
					//5:Parameter HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID of type Guid
					resultItem.HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID = reader.GetGuid(5);
					//6:Parameter contractID of type Guid
					resultItem.contractID = reader.GetGuid(6);
					//7:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(7);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_PatientParticipationConsents_on_Tenant",ex);
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
		public static FR_PA_GPPCoT_1026_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_PA_GPPCoT_1026_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_PA_GPPCoT_1026_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_PA_GPPCoT_1026_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_PA_GPPCoT_1026_Array functionReturn = new FR_PA_GPPCoT_1026_Array();
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

				throw new Exception("Exception occured in method cls_Get_PatientParticipationConsents_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_PA_GPPCoT_1026_Array : FR_Base
	{
		public PA_GPPCoT_1026[] Result	{ get; set; } 
		public FR_PA_GPPCoT_1026_Array() : base() {}

		public FR_PA_GPPCoT_1026_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass PA_GPPCoT_1026 for attribute PA_GPPCoT_1026
		[DataContract]
		public class PA_GPPCoT_1026 
		{
			//Standard type parameters
			[DataMember]
			public DateTime participationFrom { get; set; } 
			[DataMember]
			public DateTime partiicipationThrough { get; set; } 
			[DataMember]
			public String ContractName { get; set; } 
			[DataMember]
			public DateTime contractValidFrom { get; set; } 
			[DataMember]
			public DateTime contractValidThrough { get; set; } 
			[DataMember]
			public Guid HEC_CRT_InsuranceToBrokerContract_ParticipatingPatientID { get; set; } 
			[DataMember]
			public Guid contractID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_PA_GPPCoT_1026_Array cls_Get_PatientParticipationConsents_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_PA_GPPCoT_1026_Array invocationResult = cls_Get_PatientParticipationConsents_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

