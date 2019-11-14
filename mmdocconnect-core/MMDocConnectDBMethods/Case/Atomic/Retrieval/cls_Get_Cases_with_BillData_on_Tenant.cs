/* 
 * Generated on 07/21/16 14:51:44
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

namespace MMDocConnectDBMethods.Case.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Cases_with_BillData_on_Tenant.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Cases_with_BillData_on_Tenant
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GCwBDoT_1451_Array Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GCwBDoT_1451_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_Cases_with_BillData_on_Tenant.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			List<CAS_GCwBDoT_1451> results = new List<CAS_GCwBDoT_1451>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "CaseID","PatientID","CaseNumber","BillPositionID" });
				while(reader.Read())
				{
					CAS_GCwBDoT_1451 resultItem = new CAS_GCwBDoT_1451();
					//0:Parameter CaseID of type Guid
					resultItem.CaseID = reader.GetGuid(0);
					//1:Parameter PatientID of type Guid
					resultItem.PatientID = reader.GetGuid(1);
					//2:Parameter CaseNumber of type String
					resultItem.CaseNumber = reader.GetString(2);
					//3:Parameter BillPositionID of type Guid
					resultItem.BillPositionID = reader.GetGuid(3);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Cases_with_BillData_on_Tenant",ex);
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
		public static FR_CAS_GCwBDoT_1451_Array Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GCwBDoT_1451_Array Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GCwBDoT_1451_Array Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GCwBDoT_1451_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GCwBDoT_1451_Array functionReturn = new FR_CAS_GCwBDoT_1451_Array();
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

				throw new Exception("Exception occured in method cls_Get_Cases_with_BillData_on_Tenant",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GCwBDoT_1451_Array : FR_Base
	{
		public CAS_GCwBDoT_1451[] Result	{ get; set; } 
		public FR_CAS_GCwBDoT_1451_Array() : base() {}

		public FR_CAS_GCwBDoT_1451_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass CAS_GCwBDoT_1451 for attribute CAS_GCwBDoT_1451
		[DataContract]
		public class CAS_GCwBDoT_1451 
		{
			//Standard type parameters
			[DataMember]
			public Guid CaseID { get; set; } 
			[DataMember]
			public Guid PatientID { get; set; } 
			[DataMember]
			public String CaseNumber { get; set; } 
			[DataMember]
			public Guid BillPositionID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GCwBDoT_1451_Array cls_Get_Cases_with_BillData_on_Tenant(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GCwBDoT_1451_Array invocationResult = cls_Get_Cases_with_BillData_on_Tenant.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

