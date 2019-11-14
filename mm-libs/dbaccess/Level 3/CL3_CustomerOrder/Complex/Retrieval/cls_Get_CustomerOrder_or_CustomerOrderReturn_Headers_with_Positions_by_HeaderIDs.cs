/* 
 * Generated on 6/19/2014 7:24:20 AM
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
using CL3_CustomerOrder.Atomic.Retrieval;

namespace CL3_CustomerOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_by_HeaderIDs.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_by_HeaderIDs
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L3CO_GCOoCORHwPbH_1622 Execute(DbConnection Connection,DbTransaction Transaction,P_L3CO_GCOoCORHwPbH_1622 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
            #region UserCode
            var returnValue = new FR_L3CO_GCOoCORHwPbH_1622();
            var result = new L3CO_GCOoCORHwPbH_1622();

            #region Get CustomerOrder Headers with Positions
            L3CO_GCOHwPbH_1604[] resultCustomerOrderHeaders = null;
            if (Parameter.CustomerOrderHeaderIDs != null && Parameter.CustomerOrderHeaderIDs.Length > 0)
            {
                resultCustomerOrderHeaders =
                    cls_Get_CustomerOrderHeaders_with_Positions_by_HeaderIDs.Invoke(
                    Connection,
                    Transaction,
                    new P_L3CO_GCOHwPbH_1604() { CustomerOrderHeaderIDs = Parameter.CustomerOrderHeaderIDs.ToArray() },
                    securityTicket).Result;
            }
            #endregion

            #region Get CustomerOrderReturn Headers with Positions
            L3CO_GCORHwPbH_1610[] resultCustomerOrderReturnHeaders = null;
            if (Parameter.CustomerOrderReturnHeaderIDs != null && Parameter.CustomerOrderReturnHeaderIDs.Length > 0)
            {
                resultCustomerOrderReturnHeaders =
                    cls_Get_CustomerOrderReturnHeaders_with_Positions_by_HeaderIDs.Invoke(
                    Connection,
                    Transaction,
                    new P_L3CO_GCORHwPbH_1610() { CustomerOrderReturnHeaderIDs = Parameter.CustomerOrderReturnHeaderIDs.ToArray() },
                    securityTicket).Result;
            }
            #endregion

            result.CustomerOrderHeaders = resultCustomerOrderHeaders;
            result.CustomerOrderReturnHeaders = resultCustomerOrderReturnHeaders;
            returnValue.Result = result;
            returnValue.Status = FR_Status.Success;

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L3CO_GCOoCORHwPbH_1622 Invoke(string ConnectionString,P_L3CO_GCOoCORHwPbH_1622 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L3CO_GCOoCORHwPbH_1622 Invoke(DbConnection Connection,P_L3CO_GCOoCORHwPbH_1622 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L3CO_GCOoCORHwPbH_1622 Invoke(DbConnection Connection, DbTransaction Transaction,P_L3CO_GCOoCORHwPbH_1622 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L3CO_GCOoCORHwPbH_1622 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3CO_GCOoCORHwPbH_1622 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L3CO_GCOoCORHwPbH_1622 functionReturn = new FR_L3CO_GCOoCORHwPbH_1622();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_by_HeaderIDs",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L3CO_GCOoCORHwPbH_1622 : FR_Base
	{
		public L3CO_GCOoCORHwPbH_1622 Result	{ get; set; }

		public FR_L3CO_GCOoCORHwPbH_1622() : base() {}

		public FR_L3CO_GCOoCORHwPbH_1622(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L3CO_GCOoCORHwPbH_1622 for attribute P_L3CO_GCOoCORHwPbH_1622
		[DataContract]
		public class P_L3CO_GCOoCORHwPbH_1622 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] CustomerOrderHeaderIDs { get; set; } 
			[DataMember]
			public Guid[] CustomerOrderReturnHeaderIDs { get; set; } 

		}
		#endregion
		#region SClass L3CO_GCOoCORHwPbH_1622 for attribute L3CO_GCOoCORHwPbH_1622
		[DataContract]
		public class L3CO_GCOoCORHwPbH_1622 
		{
			//Standard type parameters
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GCOHwPbH_1604[] CustomerOrderHeaders { get; set; } 
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GCORHwPbH_1610[] CustomerOrderReturnHeaders { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L3CO_GCOoCORHwPbH_1622 cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_by_HeaderIDs(,P_L3CO_GCOoCORHwPbH_1622 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L3CO_GCOoCORHwPbH_1622 invocationResult = cls_Get_CustomerOrder_or_CustomerOrderReturn_Headers_with_Positions_by_HeaderIDs.Invoke(connectionString,P_L3CO_GCOoCORHwPbH_1622 Parameter,securityTicket);
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
var parameter = new CL3_CustomerOrder.Complex.Retrieval.P_L3CO_GCOoCORHwPbH_1622();
parameter.CustomerOrderHeaderIDs = ...;
parameter.CustomerOrderReturnHeaderIDs = ...;

*/
