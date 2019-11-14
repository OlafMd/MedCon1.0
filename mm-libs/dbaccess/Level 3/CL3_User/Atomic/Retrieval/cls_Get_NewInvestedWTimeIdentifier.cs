/* 
 * Generated on 8/12/2014 10:30:13
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

namespace CL3_User.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_NewInvestedWTimeIdentifier.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_NewInvestedWTimeIdentifier
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3US_GNIWTI_1706 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L3US_GNIWTI_1706();
            returnValue.Result = new L3US_GNIWTI_1706();

            ORM_CMN_BPT_InvestedWorkTime.Query query = new ORM_CMN_BPT_InvestedWorkTime.Query();
            query.Tenant_RefID = securityTicket.TenantID;
            var count = ORM_CMN_BPT_InvestedWorkTime.Query.Search(Connection, Transaction, query).Count() + 1;

            String identifier = "0000000000" + count.ToString();

            identifier = identifier.Substring(identifier.Length - 10);

            returnValue.Result = new L3US_GNIWTI_1706();

            returnValue.Result.Identifier = identifier;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3US_GNIWTI_1706 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3US_GNIWTI_1706 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3US_GNIWTI_1706 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3US_GNIWTI_1706 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3US_GNIWTI_1706 functionReturn = new FR_L3US_GNIWTI_1706();
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

				throw new Exception("Exception occured in method cls_Get_NewInvestedWTimeIdentifier",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3US_GNIWTI_1706 : FR_Base
	{
		public L3US_GNIWTI_1706 Result	{ get; set; }

		public FR_L3US_GNIWTI_1706() : base() {}

		public FR_L3US_GNIWTI_1706(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L3US_GNIWTI_1706 for attribute L3US_GNIWTI_1706
		[DataContract]
		public class L3US_GNIWTI_1706 
		{
			//Standard type parameters
			[DataMember]
			public String Identifier { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3US_GNIWTI_1706 cls_Get_NewInvestedWTimeIdentifier(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3US_GNIWTI_1706 invocationResult = cls_Get_NewInvestedWTimeIdentifier.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

