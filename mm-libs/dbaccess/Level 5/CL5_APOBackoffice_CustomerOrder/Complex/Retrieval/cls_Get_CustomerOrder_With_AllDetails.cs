/* 
 * Generated on 6/20/2014 3:15:15 PM
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
using CL5_APOBackoffice_CustomerOrder.Atomic.Retrieval;
using CL2_CustomerOrder.Atomic.Retrieval;

namespace CL5_APOBackoffice_CustomerOrder.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CustomerOrder_With_AllDetails.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CustomerOrder_With_AllDetails
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5CO_GCOWAD_1330 Execute(DbConnection Connection,DbTransaction Transaction,P_L5CO_GCOWAD_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5CO_GCOWAD_1330();
            
            //Put your code here
            var customerOrderParam = new P_L5CO_GACOfToO_1214(); 
            customerOrderParam.OrderID = Parameter.OrderHeaderID;
            var customerOrder = cls_Get_AllCustomerOrders_for_Tenant_or_OrderID.Invoke(Connection, Transaction, customerOrderParam, securityTicket).Result.FirstOrDefault();
                       
            if (customerOrder != null)
            {
                var positionsQuery = new P_L2CO_GAOPfToO_1239();
                positionsQuery.OrderHeaderID = customerOrder.ORD_CUO_CustomerOrder_HeaderID;
                var customerOrderPositions = cls_Get_AllOrderPositions_for_Tenant_or_OrderHeader.Invoke(Connection, Transaction, positionsQuery, securityTicket).Result;

                var positionsWithDetailsQuery = new P_L5CO_GCOPwDfH_1421();
                positionsWithDetailsQuery.OrderHeaderID = customerOrder.ORD_CUO_CustomerOrder_HeaderID;
                var customerOrderPositionsWithDetails = cls_Get_CustomerOrderPositions_with_Details_for_HeaderID.Invoke(Connection, Transaction, positionsWithDetailsQuery, securityTicket).Result;

                returnValue.Result = new L5CO_GCOWAD_1330();
                returnValue.Result.Order = customerOrder;
                returnValue.Result.NumberOfOrderPositions = customerOrderPositions.Length;

                if (Parameter.PositionsDetailsFetched)
                {
                    returnValue.Result.OrderPositionsWithAllDetails = customerOrderPositionsWithDetails;
                }
                else
                {
                    returnValue.Result.OrderPositions = customerOrderPositions;
                }
               
            }
            
            return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5CO_GCOWAD_1330 Invoke(string ConnectionString,P_L5CO_GCOWAD_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOWAD_1330 Invoke(DbConnection Connection,P_L5CO_GCOWAD_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5CO_GCOWAD_1330 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5CO_GCOWAD_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5CO_GCOWAD_1330 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5CO_GCOWAD_1330 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5CO_GCOWAD_1330 functionReturn = new FR_L5CO_GCOWAD_1330();
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

				throw new Exception("Exception occured in method cls_Get_CustomerOrder_With_AllDetails",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5CO_GCOWAD_1330 : FR_Base
	{
		public L5CO_GCOWAD_1330 Result	{ get; set; }

		public FR_L5CO_GCOWAD_1330() : base() {}

		public FR_L5CO_GCOWAD_1330(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5CO_GCOWAD_1330 for attribute P_L5CO_GCOWAD_1330
		[DataContract]
		public class P_L5CO_GCOWAD_1330 
		{
			//Standard type parameters
			[DataMember]
			public Guid OrderHeaderID { get; set; } 
			[DataMember]
			public bool PositionsDetailsFetched { get; set; } 

		}
		#endregion
		#region SClass L5CO_GCOWAD_1330 for attribute L5CO_GCOWAD_1330
		[DataContract]
		public class L5CO_GCOWAD_1330 
		{
			//Standard type parameters
			[DataMember]
			public L5CO_GACOfToO_1214 Order { get; set; } 
			[DataMember]
			public L2CO_GAOPfToO_1239[] OrderPositions { get; set; } 
			[DataMember]
			public int NumberOfOrderPositions { get; set; } 
			[DataMember]
			public L5CO_GCOPwDfH_1421[] OrderPositionsWithAllDetails { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5CO_GCOWAD_1330 cls_Get_CustomerOrder_With_AllDetails(,P_L5CO_GCOWAD_1330 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5CO_GCOWAD_1330 invocationResult = cls_Get_CustomerOrder_With_AllDetails.Invoke(connectionString,P_L5CO_GCOWAD_1330 Parameter,securityTicket);
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
var parameter = new CL5_APOBackoffice_CustomerOrder.Complex.Retrieval.P_L5CO_GCOWAD_1330();
parameter.OrderHeaderID = ...;
parameter.PositionsDetailsFetched = ...;

*/
