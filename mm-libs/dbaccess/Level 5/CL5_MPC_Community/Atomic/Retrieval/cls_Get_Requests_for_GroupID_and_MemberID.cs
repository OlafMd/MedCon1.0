/* 
 * Generated on 24.03.2015 14:50:25
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

namespace CL5_MPC_Community.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_Requests_for_GroupID_and_MemberID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_Requests_for_GroupID_and_MemberID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5AC_GRfGaMs_1449_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5AC_GRfGaMs_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_L5AC_GRfGaMs_1449_Array();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "CL5_MPC_Community.Atomic.Retrieval.SQL.cls_Get_Requests_for_GroupID_and_MemberID.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"GroupID", Parameter.GroupID);

			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"MemberID", Parameter.MemberID);



			List<L5AC_GRfGaMs_1449> results = new List<L5AC_GRfGaMs_1449>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "HEC_CMT_GroupSubscription_RequestID","Role_GlobalPropertyMatchingID" });
				while(reader.Read())
				{
					L5AC_GRfGaMs_1449 resultItem = new L5AC_GRfGaMs_1449();
					//0:Parameter HEC_CMT_GroupSubscription_RequestID of type Guid
					resultItem.HEC_CMT_GroupSubscription_RequestID = reader.GetGuid(0);
					//1:Parameter Role_GlobalPropertyMatchingID of type string
					resultItem.Role_GlobalPropertyMatchingID = reader.GetString(1);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_Requests_for_GroupID_and_MemberID",ex);
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
		public static FR_L5AC_GRfGaMs_1449_Array Invoke(string ConnectionString,P_L5AC_GRfGaMs_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5AC_GRfGaMs_1449_Array Invoke(DbConnection Connection,P_L5AC_GRfGaMs_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5AC_GRfGaMs_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5AC_GRfGaMs_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5AC_GRfGaMs_1449_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5AC_GRfGaMs_1449 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5AC_GRfGaMs_1449_Array functionReturn = new FR_L5AC_GRfGaMs_1449_Array();
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

				throw new Exception("Exception occured in method cls_Get_Requests_for_GroupID_and_MemberID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5AC_GRfGaMs_1449_Array : FR_Base
	{
		public L5AC_GRfGaMs_1449[] Result	{ get; set; } 
		public FR_L5AC_GRfGaMs_1449_Array() : base() {}

		public FR_L5AC_GRfGaMs_1449_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5AC_GRfGaMs_1449 for attribute P_L5AC_GRfGaMs_1449
		[DataContract]
		public class P_L5AC_GRfGaMs_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid GroupID { get; set; } 
			[DataMember]
			public Guid MemberID { get; set; } 

		}
		#endregion
		#region SClass L5AC_GRfGaMs_1449 for attribute L5AC_GRfGaMs_1449
		[DataContract]
		public class L5AC_GRfGaMs_1449 
		{
			//Standard type parameters
			[DataMember]
			public Guid HEC_CMT_GroupSubscription_RequestID { get; set; } 
			[DataMember]
			public string Role_GlobalPropertyMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5AC_GRfGaMs_1449_Array cls_Get_Requests_for_GroupID_and_MemberID(,P_L5AC_GRfGaMs_1449 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5AC_GRfGaMs_1449_Array invocationResult = cls_Get_Requests_for_GroupID_and_MemberID.Invoke(connectionString,P_L5AC_GRfGaMs_1449 Parameter,securityTicket);
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
var parameter = new CL5_MPC_Community.Atomic.Retrieval.P_L5AC_GRfGaMs_1449();
parameter.GroupID = ...;
parameter.MemberID = ...;

*/
