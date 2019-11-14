/* 
 * Generated on 28/7/2014 10:01:37
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
using CL1_ORD_PRC;
using CL2_NumberRange.Complex.Retrieval;
using CL2_Currency.Atomic.Retrieval;

namespace CL3_ProcurementOrder.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_ProcurementOrder_Header.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_ProcurementOrder_Header
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L3PO_SPOH_0323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_Guid();
			//Put your code here
            #region Get Current Bussines Participant

            var businessParticipantId = CL1_USR.ORM_USR_Account.Query.Search(Connection, Transaction,
                new CL1_USR.ORM_USR_Account.Query()
                {
                    USR_AccountID = securityTicket.AccountID,
                    Tenant_RefID = securityTicket.TenantID,
                    IsDeleted = false
                }).Single().BusinessParticipant_RefID;

            #endregion

            #region Get Currency
            var currency = cls_Get_DefaultCurrency_for_Tenant.Invoke(Connection, Transaction, securityTicket).Result.CMN_CurrencyID;
            #endregion

            #region Get Current Increasing Number

            var currentIncreasingNumber = cls_Get_and_Increase_IncreasingNumber_for_UsageArea.Invoke(Connection, Transaction
                , new P_L2NR_GaIINfUA_1454()
                {
                    GlobalStaticMatchingID = Parameter.GlobalStaticMatchingID
                }, securityTicket)
                .Result.Current_IncreasingNumber;

            #endregion

            #region Get status for Active Procurement global property matching id

            var statusActiveProcurement = CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query.Search(Connection, Transaction,
                new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_Status.Query
                {
                    GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EProcurementStatus.Active),
                    IsDeleted = false,
                    Tenant_RefID = securityTicket.TenantID
                }).Single();

            #endregion

            #region Create Procurement Order Header

            var newHeader = new ORM_ORD_PRC_ProcurementOrder_Header()
            {
                ORD_PRC_ProcurementOrder_HeaderID = Guid.NewGuid(),
                IsDeleted = false,
                Current_ProcurementOrderStatus_RefID = statusActiveProcurement.ORD_PRC_ProcurementOrder_StatusID,
                Tenant_RefID = securityTicket.TenantID,
                Creation_Timestamp = DateTime.Now,
                ProcurementOrder_Supplier_RefID = Parameter.SupplierID,
                ProcurementOrder_Number = currentIncreasingNumber,
                TotalValue_BeforeTax = 0,
                ProcurementOrder_Date = DateTime.Now,
                CreatedBy_BusinessParticipant_RefID = businessParticipantId,
                ProcurementOrder_Currency_RefID = currency,
                IsCreatedForExpectedDelivery = true
            };
            newHeader.Save(Connection, Transaction);

            #endregion

            #region Procurement order header's status history - active

            var statusHistory = new CL1_ORD_PRC.ORM_ORD_PRC_ProcurementOrder_StatusHistory
            {
                ORD_PRC_ProcurementOrder_StatusHistoryID = Guid.NewGuid(),
                ProcurementOrder_Header_RefID = newHeader.ORD_PRC_ProcurementOrder_HeaderID,
                ProcurementOrder_Status_RefID = statusActiveProcurement.ORD_PRC_ProcurementOrder_StatusID,
                Tenant_RefID = securityTicket.TenantID
            };
            statusHistory.Save(Connection, Transaction);

            #endregion

            returnValue.Result = newHeader.ORD_PRC_ProcurementOrder_HeaderID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L3PO_SPOH_0323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L3PO_SPOH_0323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L3PO_SPOH_0323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L3PO_SPOH_0323 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_Guid functionReturn = new FR_Guid();
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

				throw new Exception("Exception occured in method cls_Save_ProcurementOrder_Header",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L3PO_SPOH_0323 for attribute P_L3PO_SPOH_0323
		[DataContract]
		public class P_L3PO_SPOH_0323 
		{
			//Standard type parameters
			[DataMember]
			public Guid SupplierID { get; set; } 
			[DataMember]
			public string GlobalStaticMatchingID { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Guid cls_Save_ProcurementOrder_Header(,P_L3PO_SPOH_0323 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Guid invocationResult = cls_Save_ProcurementOrder_Header.Invoke(connectionString,P_L3PO_SPOH_0323 Parameter,securityTicket);
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
var parameter = new CL3_ProcurementOrder.Complex.Manipulation.P_L3PO_SPOH_0323();
parameter.SupplierID = ...;
parameter.GlobalStaticMatchingID = ...;

*/
