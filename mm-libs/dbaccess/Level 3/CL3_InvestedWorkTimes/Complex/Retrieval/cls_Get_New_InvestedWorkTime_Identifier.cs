/* 
 * Generated on 7/16/2014 9:58:47 AM
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
using CL1_CMN_BPT;

namespace CL3_InvestedWorkTimes.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_New_InvestedWorkTime_Identifier.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_New_InvestedWorkTime_Identifier
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3IWT_GNIWTI_0958 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L3IWT_GNIWTI_0958();
			//Put your code here
            returnValue.Result = new L3IWT_GNIWTI_0958();
            ORM_CMN_BPT_InvestedWorkTime.Query WorkTimeQuery = new ORM_CMN_BPT_InvestedWorkTime.Query();
            WorkTimeQuery.Tenant_RefID = securityTicket.TenantID;
            var count = ORM_CMN_BPT_InvestedWorkTime.Query.Search(Connection, Transaction, WorkTimeQuery).Count() + 1;

            String Identifier = "0000000000" + count.ToString();
            Identifier = Identifier.Substring(Identifier.Length - 10);
            returnValue.Result.IWT_Identifier = Identifier;
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3IWT_GNIWTI_0958 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3IWT_GNIWTI_0958 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3IWT_GNIWTI_0958 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3IWT_GNIWTI_0958 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3IWT_GNIWTI_0958 functionReturn = new FR_L3IWT_GNIWTI_0958();
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

				throw new Exception("Exception occured in method cls_Get_New_InvestedWorkTime_Identifier",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3IWT_GNIWTI_0958 : FR_Base
	{
		public L3IWT_GNIWTI_0958 Result	{ get; set; }

		public FR_L3IWT_GNIWTI_0958() : base() {}

		public FR_L3IWT_GNIWTI_0958(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3IWT_GNIWTI_0958 for attribute L3IWT_GNIWTI_0958
		[DataContract]
		public class L3IWT_GNIWTI_0958 
		{
			//Standard type parameters
			[DataMember]
			public String IWT_Identifier { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3IWT_GNIWTI_0958 cls_Get_New_InvestedWorkTime_Identifier(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3IWT_GNIWTI_0958 invocationResult = cls_Get_New_InvestedWorkTime_Identifier.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

