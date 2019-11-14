/* 
 * Generated on 2/27/2015 03:54:16
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
using CL1_ORD_PRC;

namespace CL5_Zugseil_ProcurementOrder.Atomic.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Update_ProcurementOrder_Status.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Update_ProcurementOrder_Status
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5PO_UPOS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Bool();

			//Put your code here
            var status = ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction, new ORM_ORD_PRC_ProcurementOrder_Status.Query()
                {
                    Tenant_RefID = securityTicket.TenantID,
                    GlobalPropertyMatchingID = Parameter.Status,
                    IsDeleted = false
                }).SingleOrDefault();

            if (status != null)
            {
                var procurementOrderHeader = new ORM_ORD_PRC_ProcurementOrder_Header();
                procurementOrderHeader.Load(Connection, Parameter.ProcurementOrderHeaderID);

                //if procurement order header with given ID doesn't exist, don't make changes in database
                if (procurementOrderHeader != null)
                {
                    ORM_ORD_PRC_ProcurementOrder_StatusHistory statusHistory = new ORM_ORD_PRC_ProcurementOrder_StatusHistory();
                    statusHistory.Tenant_RefID = securityTicket.TenantID;
                    statusHistory.ORD_PRC_ProcurementOrder_StatusHistoryID = Guid.NewGuid();
                    statusHistory.ProcurementOrder_Header_RefID = Parameter.ProcurementOrderHeaderID;
                    statusHistory.ProcurementOrder_Status_RefID = status.ORD_PRC_ProcurementOrder_StatusID;
                    statusHistory.Save(Connection, Transaction);

                    procurementOrderHeader.Current_ProcurementOrderStatus_RefID = status.ORD_PRC_ProcurementOrder_StatusID;
                    procurementOrderHeader.Save(Connection, Transaction);
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
		public static FR_Bool Invoke(string ConnectionString,P_L5PO_UPOS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5PO_UPOS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5PO_UPOS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5PO_UPOS_1546 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Bool functionReturn = new FR_Bool();
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

				throw new Exception("Exception occured in method cls_Update_ProcurementOrder_Status",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5PO_UPOS_1546 for attribute P_L5PO_UPOS_1546
		[DataContract]
		public class P_L5PO_UPOS_1546 
		{
			//Standard type parameters
			[DataMember]
			public Guid ProcurementOrderHeaderID { get; set; } 
			[DataMember]
			public string Status { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_Update_ProcurementOrder_Status(,P_L5PO_UPOS_1546 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_Update_ProcurementOrder_Status.Invoke(connectionString,P_L5PO_UPOS_1546 Parameter,securityTicket);
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
var parameter = new CL5_Zugseil_ProcurementOrder.Atomic.Manipulation.P_L5PO_UPOS_1546();
parameter.ProcurementOrderHeaderID = ...;
parameter.Status = ...;

*/
