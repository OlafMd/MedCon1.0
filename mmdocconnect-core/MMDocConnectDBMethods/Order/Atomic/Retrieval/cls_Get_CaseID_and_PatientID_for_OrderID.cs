/* 
 * Generated on 03/22/17 14:14:13
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

namespace MMDocConnectDBMethods.Order.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CaseID_and_PatientID_for_OrderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CaseID_and_PatientID_for_OrderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_OR_GCIDaPIDfOID_1412 Execute(DbConnection Connection,DbTransaction Transaction,P_OR_GCIDaPIDfOID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_OR_GCIDaPIDfOID_1412();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Order.Atomic.Retrieval.SQL.cls_Get_CaseID_and_PatientID_for_OrderID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"OrderID", Parameter.OrderID);



			List<OR_GCIDaPIDfOID_1412> results = new List<OR_GCIDaPIDfOID_1412>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "case_id","patient_id" });
				while(reader.Read())
				{
					OR_GCIDaPIDfOID_1412 resultItem = new OR_GCIDaPIDfOID_1412();
					//0:Parameter case_id of type Guid
					resultItem.case_id = reader.GetGuid(0);
					//1:Parameter patient_id of type Guid
					resultItem.patient_id = reader.GetGuid(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_CaseID_and_PatientID_for_OrderID",ex);
			}
			reader.Close();
			//Load all the dictionaries from the datatables
			loader.Load();

			returnStatus.Result = results.FirstOrDefault();
			return returnStatus;
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_OR_GCIDaPIDfOID_1412 Invoke(string ConnectionString,P_OR_GCIDaPIDfOID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_OR_GCIDaPIDfOID_1412 Invoke(DbConnection Connection,P_OR_GCIDaPIDfOID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_OR_GCIDaPIDfOID_1412 Invoke(DbConnection Connection, DbTransaction Transaction,P_OR_GCIDaPIDfOID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_OR_GCIDaPIDfOID_1412 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_OR_GCIDaPIDfOID_1412 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_OR_GCIDaPIDfOID_1412 functionReturn = new FR_OR_GCIDaPIDfOID_1412();
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

				throw new Exception("Exception occured in method cls_Get_CaseID_and_PatientID_for_OrderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_OR_GCIDaPIDfOID_1412 : FR_Base
	{
		public OR_GCIDaPIDfOID_1412 Result	{ get; set; }

		public FR_OR_GCIDaPIDfOID_1412() : base() {}

		public FR_OR_GCIDaPIDfOID_1412(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_OR_GCIDaPIDfOID_1412 for attribute P_OR_GCIDaPIDfOID_1412
		[DataContract]
		public class P_OR_GCIDaPIDfOID_1412 
		{
			//Standard type parameters
			[DataMember]
			public Guid OrderID { get; set; } 

		}
		#endregion
		#region SClass OR_GCIDaPIDfOID_1412 for attribute OR_GCIDaPIDfOID_1412
		[DataContract]
		public class OR_GCIDaPIDfOID_1412 
		{
			//Standard type parameters
			[DataMember]
			public Guid case_id { get; set; } 
			[DataMember]
			public Guid patient_id { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_OR_GCIDaPIDfOID_1412 cls_Get_CaseID_and_PatientID_for_OrderID(,P_OR_GCIDaPIDfOID_1412 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_OR_GCIDaPIDfOID_1412 invocationResult = cls_Get_CaseID_and_PatientID_for_OrderID.Invoke(connectionString,P_OR_GCIDaPIDfOID_1412 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Order.Atomic.Retrieval.P_OR_GCIDaPIDfOID_1412();
parameter.OrderID = ...;

*/
