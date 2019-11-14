/* 
 * Generated on 5/19/2014 1:06:07 PM
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
using CL3_ShippingOrder.Atomic.Retrieval;

namespace CL6_Backoffice_ShipmentsOverview.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_ShipmentHeader_with_BillHeaders_for_CustomerOrderHeaderID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_ShipmentHeader_with_BillHeaders_for_CustomerOrderHeaderID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_CL6_GSHwBHNfCOH_1141_Array Execute(DbConnection Connection,DbTransaction Transaction,P_CL6_GSHwBHNfCOH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_CL6_GSHwBHNfCOH_1141_Array();

            #region Get Shipment Headers
            var resultShipmentHeaders = cls_Get_ShipmentHeaders_for_CustomerOrderHeaderID
                .Invoke(Connection
                , Transaction
                , new P_L3CO_GSHfCOH_0734() 
                { 
                    CustomerOrderHeaderID = Parameter.CustomerOrderHeaderID,
                }
                , securityTicket);
            if (resultShipmentHeaders.Status != FR_Status.Success || resultShipmentHeaders.Result.Count() <= 0)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Get Shipment Header Bill Headers
            var inputParameter = new P_CL3_GBHNfSH_1131() 
            {
                ShipmentHeaderIDs = resultShipmentHeaders.Result.Select(rsh => rsh.LOG_SHP_Shipment_HeaderID).Distinct().ToArray()
            };
            var resultBillHeaders = cls_Get_BillHeaders_for_ShipmentHeaderIDs.Invoke(Connection, Transaction, inputParameter, securityTicket);
            if (resultShipmentHeaders.Status != FR_Status.Success)
            {
                returnValue.Status = FR_Status.Error_Internal;
                returnValue.Result = null;
                return returnValue;
            }
            #endregion

            #region Set Result
            var resultList = new List<CL6_GSHwBHNfCOH_1141>();
            foreach (var header in resultShipmentHeaders.Result)
            {
                resultList.Add(new CL6_GSHwBHNfCOH_1141() { 
                    ShipmentHeader = header,
                    ShipmentHeaderInvoiceNumbers = resultBillHeaders.Result.Where(rbh => rbh.LOG_SHP_Shipment_HeaderID == header.LOG_SHP_Shipment_HeaderID).ToArray()
                });
            }
            returnValue.Result = resultList.ToArray();
            returnValue.Status = FR_Status.Success;
            #endregion

            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_CL6_GSHwBHNfCOH_1141_Array Invoke(string ConnectionString,P_CL6_GSHwBHNfCOH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_CL6_GSHwBHNfCOH_1141_Array Invoke(DbConnection Connection,P_CL6_GSHwBHNfCOH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_CL6_GSHwBHNfCOH_1141_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_CL6_GSHwBHNfCOH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_CL6_GSHwBHNfCOH_1141_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_CL6_GSHwBHNfCOH_1141 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_CL6_GSHwBHNfCOH_1141_Array functionReturn = new FR_CL6_GSHwBHNfCOH_1141_Array();
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

				throw new Exception("Exception occured in method cls_Get_ShipmentHeader_with_BillHeaders_for_CustomerOrderHeaderID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_CL6_GSHwBHNfCOH_1141_Array : FR_Base
	{
		public CL6_GSHwBHNfCOH_1141[] Result	{ get; set; } 
		public FR_CL6_GSHwBHNfCOH_1141_Array() : base() {}

		public FR_CL6_GSHwBHNfCOH_1141_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_CL6_GSHwBHNfCOH_1141 for attribute P_CL6_GSHwBHNfCOH_1141
		[DataContract]
		public class P_CL6_GSHwBHNfCOH_1141 
		{
			//Standard type parameters
			[DataMember]
			public Guid CustomerOrderHeaderID { get; set; } 

		}
		#endregion
		#region SClass CL6_GSHwBHNfCOH_1141 for attribute CL6_GSHwBHNfCOH_1141
		[DataContract]
		public class CL6_GSHwBHNfCOH_1141 
		{
			//Standard type parameters
			[DataMember]
            public CL3_CustomerOrder.Atomic.Retrieval.L3CO_GSHfCOH_0734 ShipmentHeader { get; set; } 
			[DataMember]
			public CL3_ShippingOrder.Atomic.Retrieval.CL3_GBHNfSH_1131[] ShipmentHeaderInvoiceNumbers { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_CL6_GSHwBHNfCOH_1141_Array cls_Get_ShipmentHeader_with_BillHeaders_for_CustomerOrderHeaderID(,P_CL6_GSHwBHNfCOH_1141 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_CL6_GSHwBHNfCOH_1141_Array invocationResult = cls_Get_ShipmentHeader_with_BillHeaders_for_CustomerOrderHeaderID.Invoke(connectionString,P_CL6_GSHwBHNfCOH_1141 Parameter,securityTicket);
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
var parameter = new CL6_Backoffice_ShipmentsOverview.Complex.Retrieval.P_CL6_GSHwBHNfCOH_1141();
parameter.CustomerOrderHeaderID = ...;

*/
