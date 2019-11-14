/* 
 * Generated on 6/2/2014 4:29:49 PM
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
using CL3_Payments.Complex.Manipulation;

namespace CL5_APOBilling_Bill.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_CloseBills.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_CloseBills
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L5BL_CB_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Bool();

            foreach (var billHeaderID in Parameter.BillHeaderIDs)
            {
                #region Delete current status assignment
                
                var query = new CL1_BIL.ORM_BIL_BillHeader_2_BillStatus.Query();
                query.BIL_BillHeader_RefID = billHeaderID;
                query.IsCurrentStatus = true;
                query.IsDeleted = false;
                query.Tenant_RefID = securityTicket.TenantID;
                var currentStatus = CL1_BIL.ORM_BIL_BillHeader_2_BillStatus.Query.Search(Connection, Transaction, query).Single();
                currentStatus.IsCurrentStatus = false;
                currentStatus.Save(Connection, Transaction);

                #endregion

                #region Create new status - Closed
                
                var newStatus = new CL1_BIL.ORM_BIL_BillHeader_2_BillStatus();
                newStatus.AssignmentID = Guid.NewGuid();
                newStatus.BIL_BillHeader_RefID = billHeaderID;
                newStatus.IsCurrentStatus = true;

                #region Get status' ID closed by Global Property Matching ID

                var query2 = new CL1_BIL.ORM_BIL_BillStatus.Query();
                query2.GlobalPropertyMatchingID = DLCore_DBCommons.Utils.EnumUtils.GetEnumDescription(DLCore_DBCommons.APODemand.EBillStatus.Closed);
                query2.IsDeleted = false;
                query2.Tenant_RefID = securityTicket.TenantID;
                var statusClosed = CL1_BIL.ORM_BIL_BillStatus.Query.Search(Connection, Transaction, query2).Single();
                
                #endregion

                newStatus.BIL_BillStatus_RefID = statusClosed.BIL_BillStatusID;
                newStatus.Creation_Timestamp = DateTime.Now;
                newStatus.Tenant_RefID = securityTicket.TenantID;
                newStatus.Save(Connection, Transaction);

                #endregion

                #region Create bookings for bill on closing

                var param = new P_L3PY_CBfB_0959
                {
                    BillHeaderID = billHeaderID
                };
                cls_Create_Bookings_for_Bill_on_Closing.Invoke(Connection, Transaction, param, securityTicket);

                #endregion
                
            }

            returnValue.Result = true;
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Bool Invoke(string ConnectionString,P_L5BL_CB_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L5BL_CB_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L5BL_CB_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5BL_CB_1313 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cls_CloseBills",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		#region SClass P_L5BL_CB_1313 for attribute P_L5BL_CB_1313
		[DataContract]
		public class P_L5BL_CB_1313 
		{
			//Standard type parameters
			[DataMember]
			public Guid[] BillHeaderIDs { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cls_CloseBills(,P_L5BL_CB_1313 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cls_CloseBills.Invoke(connectionString,P_L5BL_CB_1313 Parameter,securityTicket);
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
var parameter = new CL5_APOBilling_Bill.Complex.Manipulation.P_L5BL_CB_1313();
parameter.BillHeaderIDs = ...;

*/
