/* 
 * Generated on 09/29/16 09:36:55
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
    /// var result = cls_Get_BillPositionNumbers_waiting_Hip_Response.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_BillPositionNumbers_waiting_Hip_Response
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CAS_GBPNwHipR_1853 Execute(DbConnection Connection,DbTransaction Transaction,P_CAS_GBPNwHipR_1853 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			var returnStatus = new FR_CAS_GBPNwHipR_1853();

			DbCommand command = Connection.CreateCommand();
			command.Connection = Connection;
			command.Transaction = Transaction;
			var commandLocation = "MMDocConnectDBMethods.Case.Atomic.Retrieval.SQL.cls_Get_BillPositionNumbers_waiting_Hip_Response.sql";
			command.CommandText = new System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(commandLocation)).ReadToEnd();
			CSV2Core_MySQL.Support.DBSQLSupport.SetParameter(command,"ticket", securityTicket);
			command.CommandTimeout = QueryTimeout;

			command.CommandText = System.Text.RegularExpressions.Regex.Replace(command.CommandText,"=[ \t]*@BillNumbers"," IN $$BillNumbers$$");
			CSV2Core_MySQL.Support.DBSQLSupport.AppendINStatement(command, "$BillNumbers$",Parameter.BillNumbers);


			List<CAS_GBPNwHipR_1853> results = new List<CAS_GBPNwHipR_1853>();
			var loader = new CSV2Core_MySQL.Dictionaries.MultiTable.Loader.DictionaryLoader(Connection,Transaction);
			var reader = new CSV2Core_MySQL.Support.DBSQLReader(command.ExecuteReader());
			try
			{
				reader.SetOrdinals(new string[] { "position_count" });
				while(reader.Read())
				{
					CAS_GBPNwHipR_1853 resultItem = new CAS_GBPNwHipR_1853();
					//0:Parameter position_count of type int
					resultItem.position_count = reader.GetInteger(0);

					results.Add(resultItem);
				}


			} 
			catch(Exception ex)
			{
				reader.Close();
				throw new Exception("Exception occured durng data retrieval in method cls_Get_BillPositionNumbers_waiting_Hip_Response",ex);
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
		public static FR_CAS_GBPNwHipR_1853 Invoke(string ConnectionString,P_CAS_GBPNwHipR_1853 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CAS_GBPNwHipR_1853 Invoke(DbConnection Connection,P_CAS_GBPNwHipR_1853 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CAS_GBPNwHipR_1853 Invoke(DbConnection Connection, DbTransaction Transaction,P_CAS_GBPNwHipR_1853 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CAS_GBPNwHipR_1853 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CAS_GBPNwHipR_1853 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CAS_GBPNwHipR_1853 functionReturn = new FR_CAS_GBPNwHipR_1853();
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

				throw new Exception("Exception occured in method cls_Get_BillPositionNumbers_waiting_Hip_Response",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CAS_GBPNwHipR_1853 : FR_Base
	{
		public CAS_GBPNwHipR_1853 Result	{ get; set; }

		public FR_CAS_GBPNwHipR_1853() : base() {}

		public FR_CAS_GBPNwHipR_1853(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CAS_GBPNwHipR_1853 for attribute P_CAS_GBPNwHipR_1853
		[DataContract]
		public class P_CAS_GBPNwHipR_1853 
		{
			//Standard type parameters
			[DataMember]
			public String[] BillNumbers { get; set; } 

		}
		#endregion
		#region SClass CAS_GBPNwHipR_1853 for attribute CAS_GBPNwHipR_1853
		[DataContract]
		public class CAS_GBPNwHipR_1853 
		{
			//Standard type parameters
			[DataMember]
			public int position_count { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CAS_GBPNwHipR_1853 cls_Get_BillPositionNumbers_waiting_Hip_Response(,P_CAS_GBPNwHipR_1853 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CAS_GBPNwHipR_1853 invocationResult = cls_Get_BillPositionNumbers_waiting_Hip_Response.Invoke(connectionString,P_CAS_GBPNwHipR_1853 Parameter,securityTicket);
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
var parameter = new MMDocConnectDBMethods.Case.Atomic.Retrieval.P_CAS_GBPNwHipR_1853();
parameter.BillNumbers = ...;

*/
