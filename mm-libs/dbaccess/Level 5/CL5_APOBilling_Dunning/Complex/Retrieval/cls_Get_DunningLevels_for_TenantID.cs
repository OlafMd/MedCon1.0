/* 
 * Generated on 5/29/2014 3:25:10 PM
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
using CSV2Core.Core;
using System.Runtime.Serialization;
using CL2_BillDunning.Atomic.Retrieval;

namespace CL5_APOBilling_Dunning.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_DunningLevels_for_TenantID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_DunningLevels_for_TenantID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BD_GDLfTID_1453 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BD_GDLfTID_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5BD_GDLfTID_1453();

            var dunningLevels = cls_Get_DuningLevel_with_ChildData_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.Where(dl => dl.OrderSequence > Parameter.CurrentLevel);

            returnValue.Result = new L5BD_GDLfTID_1453();
            returnValue.Result.DunningLevels = dunningLevels.ToArray();

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5BD_GDLfTID_1453 Invoke(string ConnectionString,P_L5BD_GDLfTID_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BD_GDLfTID_1453 Invoke(DbConnection Connection,P_L5BD_GDLfTID_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BD_GDLfTID_1453 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BD_GDLfTID_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BD_GDLfTID_1453 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BD_GDLfTID_1453 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BD_GDLfTID_1453 functionReturn = new FR_L5BD_GDLfTID_1453();
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

				throw new Exception("Exception occured in method cls_Get_DunningLevels_for_TenantID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BD_GDLfTID_1453 : FR_Base
	{
		public L5BD_GDLfTID_1453 Result	{ get; set; }

		public FR_L5BD_GDLfTID_1453() : base() {}

		public FR_L5BD_GDLfTID_1453(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BD_GDLfTID_1453 for attribute P_L5BD_GDLfTID_1453
		[DataContract]
		public class P_L5BD_GDLfTID_1453 
		{
			//Standard type parameters
			[DataMember]
			public int CurrentLevel { get; set; } 

		}
		#endregion
		#region SClass L5BD_GDLfTID_1453 for attribute L5BD_GDLfTID_1453
		[DataContract]
		public class L5BD_GDLfTID_1453 
		{
			//Standard type parameters
			[DataMember]
			public L2BD_GDLwCDfT_1651[] DunningLevels { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BD_GDLfTID_1453 cls_Get_DunningLevels_for_TenantID(,P_L5BD_GDLfTID_1453 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BD_GDLfTID_1453 invocationResult = cls_Get_DunningLevels_for_TenantID.Invoke(connectionString,P_L5BD_GDLfTID_1453 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Dunning.Complex.Retrieval.P_L5BD_GDLfTID_1453();
parameter.CurrentLevel = ...;

*/
