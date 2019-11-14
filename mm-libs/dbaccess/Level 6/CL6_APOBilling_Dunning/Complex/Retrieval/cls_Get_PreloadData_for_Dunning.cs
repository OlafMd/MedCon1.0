/* 
 * Generated on 5/30/2014 6:29:24 PM
 * Danulabs CodeGen v2.0.0
 * Please report any bugs at <generator.support@danulabs.com>
 * Required Assemblies:
 * System.Runtime.Serialization
 * CSV2Core
 * CSV2Core_MySQL
 */
using System;
using System.Data.Common;
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL2_BillDunning.Atomic.Retrieval;

namespace CL6_APOBilling_Dunning.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_PreloadData_for_Dunning.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_PreloadData_for_Dunning
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6BD_GPDfD_1824 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L6BD_GPDfD_1824();
			//Put your code here

            returnValue.Result = new L6BD_GPDfD_1824();
            returnValue.Result.LevelStatuses = cls_Get_DuningLevel_with_ChildData_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6BD_GPDfD_1824 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6BD_GPDfD_1824 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6BD_GPDfD_1824 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6BD_GPDfD_1824 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6BD_GPDfD_1824 functionReturn = new FR_L6BD_GPDfD_1824();
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

				throw new Exception("Exception occured in method cls_Get_PreloadData_for_Dunning",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6BD_GPDfD_1824 : FR_Base
	{
		public L6BD_GPDfD_1824 Result	{ get; set; }

		public FR_L6BD_GPDfD_1824() : base() {}

		public FR_L6BD_GPDfD_1824(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass L6BD_GPDfD_1824 for attribute L6BD_GPDfD_1824
		[DataContract]
		public class L6BD_GPDfD_1824 
		{
			//Standard type parameters
			[DataMember]
			public L2BD_GDLwCDfT_1651[] LevelStatuses { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6BD_GPDfD_1824 cls_Get_PreloadData_for_Dunning(string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6BD_GPDfD_1824 invocationResult = cls_Get_PreloadData_for_Dunning.Invoke(connectionString,securityTicket);
		return invocationResult.result;
	} 
	catch(Exception ex)
	{
		//LOG The exception with your standard logger...
		throw;
	}
}
*/

