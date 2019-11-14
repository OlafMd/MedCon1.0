/* 
 * Generated on 12/27/2013 2:06:05 PM
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
using PlannicoModel.Models;

namespace CL5_VacationPlanner_Tenant.Atomic.Retrieval
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_CalculationTimeFramesForLeaveRequest.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_CalculationTimeFramesForLeaveRequest
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5TN_GCTFFLR_1358 Execute(DbConnection Connection,DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
            var returnValue = new FR_L5TN_GCTFFLR_1358();

			//Put your code here
            L5TN_GCTFFT_1529[] calculationTimeFrames = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result;
            List<L5TN_GCTFFT_1529> calculationTimeFramesResult = new List<L5TN_GCTFFT_1529>();

            ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query leaveRequestQuery = new ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query();
            leaveRequestQuery.Tenant_RefID = securityTicket.TenantID;
            leaveRequestQuery.IsDeleted = false;
            List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> leaveRequestList = ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query.Search(Connection, Transaction, leaveRequestQuery);

            List<ORM_CMN_CAL_Event> eventList = new List<ORM_CMN_CAL_Event>();
            foreach (var leaveRequestItem in leaveRequestList)
            {
                ORM_CMN_CAL_Event_Approval approval = new ORM_CMN_CAL_Event_Approval();
                approval.Load(Connection,Transaction,leaveRequestItem.CMN_CAL_Event_Approval_RefID);
                if (!approval.IsApprovalProcessDenied && !approval.IsApprovalProcessCanceledByUser)
                {
                    ORM_CMN_CAL_Event eventItem = new ORM_CMN_CAL_Event();
                    var eventResult = eventItem.Load(Connection, Transaction, leaveRequestItem.CMN_CAL_Event_RefID);
                    if (eventResult.Status != FR_Status.Success || eventItem.CMN_CAL_EventID == Guid.Empty)
                        continue;
                    eventList.Add(eventItem);
                }
            }

            if(eventList.Count > 0)
            foreach (var timeFrame in calculationTimeFrames)
            {
                if (eventList.Any(e=>e.StartTime.Year == timeFrame.CalculationTimeframe_StartDate.Year))
                {
                    calculationTimeFramesResult.Add(timeFrame);
                }
            }

            if (calculationTimeFramesResult.Count == 0)
            {
                calculationTimeFramesResult.Add(calculationTimeFrames.Where(i=>i.IsCalculationTimeframe_Active).FirstOrDefault());
            }

            returnValue.Result = new L5TN_GCTFFLR_1358();
            returnValue.Result.CalculationTimeFrames = calculationTimeFramesResult.ToArray();
            
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5TN_GCTFFLR_1358 Invoke(string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5TN_GCTFFLR_1358 Invoke(DbConnection Connection,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5TN_GCTFFLR_1358 Invoke(DbConnection Connection, DbTransaction Transaction,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5TN_GCTFFLR_1358 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5TN_GCTFFLR_1358 functionReturn = new FR_L5TN_GCTFFLR_1358();
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

				functionReturn = Execute(Connection, Transaction,securityTicket);


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
	public class FR_L5TN_GCTFFLR_1358 : FR_Base
	{
		public L5TN_GCTFFLR_1358 Result	{ get; set; }

		public FR_L5TN_GCTFFLR_1358() : base() {}

		public FR_L5TN_GCTFFLR_1358(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L5TN_GCTFFLR_1358 cls_Get_CalculationTimeFramesForLeaveRequest(string sessionToken = null)
{
	 var securityTicket = ...;
	 FR_L5TN_GCTFFLR_1358 result = cls_Get_CalculationTimeFramesForLeaveRequest.Invoke(connectionString,securityTicket);
	 return result;
}
*/