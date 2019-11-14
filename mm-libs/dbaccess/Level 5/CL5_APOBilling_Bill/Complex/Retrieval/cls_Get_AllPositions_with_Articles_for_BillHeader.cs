/* 
 * Generated on 12/6/2014 11:27:40
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
using CL5_APOBilling_CustomerOrderReturn.Complex.Retrieval;

namespace CL5_APOBilling_Bill.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_AllPositions_with_Articles_for_BillHeader.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_AllPositions_with_Articles_for_BillHeader
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5BL_GAPwAfBH_1118 Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_GAPwAfBH_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5BL_GAPwAfBH_1118();
            //Put your code here
            #region getResults
            
            var shipmentParam = new P_L5BL_GBPwAfBH_1848() { BillHeaderID = Parameter.BillHeaderID };
            var shipmentPositions = cls_Get_BillPositions_with_Articles_for_BillHeader.Invoke(Connection, Transaction, shipmentParam, securityTicket);
            
            var orderReturnParam = new P_L5OR_GCORPwAfBH_1051() { BillHeaderID = Parameter.BillHeaderID };
            var orderReturnPositions = cls_Get_CustomerOrderReturnPosition_with_Articles_for_BillHeader.Invoke(Connection, Transaction, orderReturnParam, securityTicket);

            #endregion

            #region set results

            returnValue.Result = new L5BL_GAPwAfBH_1118();
            returnValue.Result.ShipmentBillPositions = shipmentPositions.Result;
            returnValue.Result.OrderReturnBillPosition = orderReturnPositions.Result;
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
		public static FR_L5BL_GAPwAfBH_1118 Invoke(string ConnectionString,P_L5BL_GAPwAfBH_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5BL_GAPwAfBH_1118 Invoke(DbConnection Connection,P_L5BL_GAPwAfBH_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5BL_GAPwAfBH_1118 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_GAPwAfBH_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5BL_GAPwAfBH_1118 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_GAPwAfBH_1118 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5BL_GAPwAfBH_1118 functionReturn = new FR_L5BL_GAPwAfBH_1118();
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

				throw new Exception("Exception occured in method cls_Get_AllPositions_with_Articles_for_BillHeader",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5BL_GAPwAfBH_1118 : FR_Base
	{
		public L5BL_GAPwAfBH_1118 Result	{ get; set; }

		public FR_L5BL_GAPwAfBH_1118() : base() {}

		public FR_L5BL_GAPwAfBH_1118(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L5BL_GAPwAfBH_1118 for attribute P_L5BL_GAPwAfBH_1118
		[DataContract]
		public class P_L5BL_GAPwAfBH_1118 
		{
			//Standard type parameters
			[DataMember]
			public Guid BillHeaderID { get; set; } 

		}
		#endregion
		#region SClass L5BL_GAPwAfBH_1118 for attribute L5BL_GAPwAfBH_1118
		[DataContract]
		public class L5BL_GAPwAfBH_1118 
		{
			//Standard type parameters
			[DataMember]
			public CL5_APOBilling_Bill.Complex.Retrieval.L5BL_GBPwAfBH_1848[] ShipmentBillPositions { get; set; } 
			[DataMember]
			public CL5_APOBilling_CustomerOrderReturn.Complex.Retrieval.L5OR_GCORPwAfBH_1051[] OrderReturnBillPosition { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5BL_GAPwAfBH_1118 cls_Get_AllPositions_with_Articles_for_BillHeader(,P_L5BL_GAPwAfBH_1118 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L5BL_GAPwAfBH_1118 invocationResult = cls_Get_AllPositions_with_Articles_for_BillHeader.Invoke(connectionString,P_L5BL_GAPwAfBH_1118 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Retrieval.P_L5BL_GAPwAfBH_1118();
parameter.BillHeaderID = ...;

*/
