/* 
 * Generated on 5/20/2014 11:03:59 AM
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
using CL3_CustomerOrder.Atomic.Retrieval;

namespace CL6_Backoffice_ShipmentsOverview.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrderData_and_ShipmentHeaders_for_CustomerOrderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrderData_and_ShipmentHeaders_for_CustomerOrderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL6_GCODaSHfCO_0753 Execute(DbConnection Connection,DbTransaction Transaction,P_CL6_GCODaSHfCO_0753 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_CL6_GCODaSHfCO_0753();
            returnValue.Result = new CL6_GCODaSHfCO_0753();

            #region Get Header Data
            var resultHeader = cls_Get_CustomerOrderData_for_HeaderID
                .Invoke(Connection, Transaction, new P_CL3_GCODfH_1537() { CustomerOrderHeaderID = Parameter.CustomerOrderHeaderID }, securityTicket);
            if (resultHeader.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get ShipmentHeaders
            var resultShipments = cls_Get_ShipmentHeader_with_BillHeaders_for_CustomerOrderHeaderID
                .Invoke(Connection, Transaction, new P_CL6_GSHwBHNfCOH_1141() { CustomerOrderHeaderID = Parameter.CustomerOrderHeaderID }, securityTicket);
            if (resultShipments.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result.CustomerOrderData = resultHeader.Result;
                return returnValue;
            }
            #endregion

            returnValue.Result = new CL6_GCODaSHfCO_0753()
            {
                CustomerOrderData = resultHeader.Result,
                ShipmentHeaders = resultShipments.Result
            };

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CL6_GCODaSHfCO_0753 Invoke(string ConnectionString,P_CL6_GCODaSHfCO_0753 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL6_GCODaSHfCO_0753 Invoke(DbConnection Connection,P_CL6_GCODaSHfCO_0753 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL6_GCODaSHfCO_0753 Invoke(DbConnection Connection, DbTransaction Transaction,P_CL6_GCODaSHfCO_0753 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL6_GCODaSHfCO_0753 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL6_GCODaSHfCO_0753 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL6_GCODaSHfCO_0753 functionReturn = new FR_CL6_GCODaSHfCO_0753();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrderData_and_ShipmentHeaders_for_CustomerOrderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL6_GCODaSHfCO_0753 : FR_Base
	{
		public CL6_GCODaSHfCO_0753 Result	{ get; set; }

		public FR_CL6_GCODaSHfCO_0753() : base() {}

		public FR_CL6_GCODaSHfCO_0753(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL6_GCODaSHfCO_0753 for attribute P_CL6_GCODaSHfCO_0753
		[DataContract]
		public class P_CL6_GCODaSHfCO_0753 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 
			[DataMember]
			public string GlobalPropertyMatchingID { get; set; } 

		}
		#endregion
		#region SClass CL6_GCODaSHfCO_0753 for attribute CL6_GCODaSHfCO_0753
		[DataContract]
		public class CL6_GCODaSHfCO_0753 
		{
			//Standard type parameters
			[DataMember]
			public CL3_CustomerOrder.Atomic.Retrieval.CL3_GCODfH_1537 CustomerOrderData { get; set; } 
			[DataMember]
			public CL6_Backoffice_ShipmentsOverview.Complex.Retrieval.CL6_GSHwBHNfCOH_1141[] ShipmentHeaders { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL6_GCODaSHfCO_0753 cls_Get_CustomerOrderData_and_ShipmentHeaders_for_CustomerOrderID(,P_CL6_GCODaSHfCO_0753 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL6_GCODaSHfCO_0753 invocationResult = cls_Get_CustomerOrderData_and_ShipmentHeaders_for_CustomerOrderID.Invoke(connectionString,P_CL6_GCODaSHfCO_0753 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_ShipmentsOverview.Complex.Retrieval.P_CL6_GCODaSHfCO_0753();
parameter.CustomerOrderHeaderID = ...;
parameter.GlobalPropertyMatchingID = ...;

*/
