/* 
 * Generated on 3/21/2014 9:35:33 AM
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
using CL1_CMN_BPT_EMP;
using CL1_CMN_CAL;
using CL1_CMN_BPT_STA;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Check_LeaveRequest_Count.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Check_LeaveRequest_Count
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LR_CLRC_1517 Execute(DbConnection Connection,DbTransaction Transaction,P_L5LR_CLRC_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			//Leave UserCode region to enable user code saving
			#region UserCode 
			var returnValue = new FR_L5LR_CLRC_1517();
            returnValue.Result = new L5LR_CLRC_1517();

            int retVal = 0;

			//Put your code here
            ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query leaveRequestQuery = new ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query();
            leaveRequestQuery.RequestedFor_Employee_RefID = Parameter.EmployeeID;
            leaveRequestQuery.Tenant_RefID = securityTicket.TenantID;
            leaveRequestQuery.IsDeleted = false;
            List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> leaveRequests = ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query.Search(Connection, Transaction, leaveRequestQuery);

            FR_Base evetResult;
            FR_Base eventApprovalResult;
            foreach (var leaveRequest in leaveRequests)
            {
                ORM_CMN_CAL_Event Event = new ORM_CMN_CAL_Event();
                evetResult = Event.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_RefID);

                if (evetResult.Status == FR_Status.Success && Event.CMN_CAL_EventID != Guid.Empty && Event.StartTime.Ticks > Parameter.StartDate.Ticks)
                {
                    ORM_CMN_CAL_Event_Approval eventApproval = new ORM_CMN_CAL_Event_Approval();
                    eventApprovalResult = eventApproval.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_Approval_RefID);

                    if (eventApprovalResult.Status == FR_Status.Success && eventApproval.CMN_CAL_Event_ApprovalID != Guid.Empty
                        && !eventApproval.IsApprovalProcessCanceledByUser && !eventApproval.IsApprovalProcessDenied)
                        retVal++;
                }
            }

            returnValue.Result.LeaveCount = retVal;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LR_CLRC_1517 Invoke(string ConnectionString,P_L5LR_CLRC_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LR_CLRC_1517 Invoke(DbConnection Connection,P_L5LR_CLRC_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LR_CLRC_1517 Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LR_CLRC_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LR_CLRC_1517 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LR_CLRC_1517 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LR_CLRC_1517 functionReturn = new FR_L5LR_CLRC_1517();
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L5LR_CLRC_1517 : FR_Base
	{
		public L5LR_CLRC_1517 Result	{ get; set; }

		public FR_L5LR_CLRC_1517() : base() {}

		public FR_L5LR_CLRC_1517(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5LR_CLRC_1517 cls_Check_LeaveRequest_Count(P_L5LR_CLRC_1517 Parameter,string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5LR_CLRC_1517 result = cls_Check_LeaveRequest_Count.Invoke(connectionString,P_L5LR_CLRC_1517 Parameter,securityTicket);
	 return result;
}
*/