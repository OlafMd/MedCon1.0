/* 
 * Generated on 8/30/2013 11:29:35 AM
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
using CL5_VacationPlanner_LeaveRequest.Atomic.Manipulation;
using CL6_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Tenant.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Retrieval;
using CL5_VacationPlanner_Contract.Atomic.Manipulation;

namespace CL6_VacationPlanner_LeaveRequest.Complex.Manipulation
{
	/// <summary>
    /// 
    /// <example>
	/// string connectionString = ...;
    /// var result = cle_Save_LeaveRequest_ApproveAction.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cle_Save_LeaveRequest_ApproveAction
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Bool Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_SLRAA_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_Bool();
            returnValue.Result = false;

            if (Parameter.LeaveRequestID != Guid.Empty)
            {
      
                var lrQuery = new ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query();
                lrQuery.CMN_BPT_EMP_Employee_LeaveRequestID = Parameter.LeaveRequestID;
                lrQuery.Tenant_RefID = securityTicket.TenantID;
                lrQuery.IsDeleted = false;
                var leaveRequestsRes = ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query.Search(Connection, Transaction, lrQuery);
                ORM_CMN_BPT_EMP_Employee_LeaveRequest leaveRequest = leaveRequestsRes[0];

                P_L5LR_SEAA_1351 ApprovalActionParam = new P_L5LR_SEAA_1351();
                ApprovalActionParam.Approval_Action_Commnet = "";
                ApprovalActionParam.CMN_CAL_Event_Approval_ActionID = Guid.Empty;
                ApprovalActionParam.EventApproval_RefID = leaveRequest.CMN_CAL_Event_Approval_RefID;
                ApprovalActionParam.IsApproval = true;
                ApprovalActionParam.IsDenial = false;
                ApprovalActionParam.IsRevocation = false;
                cls_Save_Employee_ApprovalAction.Invoke(Connection, Transaction, ApprovalActionParam, securityTicket);



                var tenantSettings = cls_Get_Settings_For_Tenant.Invoke(Connection, Transaction, securityTicket).Result;

                var approvalActionsQuery = new ORM_CMN_CAL_Event_Approval_Action.Query();
                approvalActionsQuery.EventApproval_RefID = leaveRequest.CMN_CAL_Event_Approval_RefID;
                approvalActionsQuery.Tenant_RefID = securityTicket.TenantID;
                approvalActionsQuery.IsDeleted = false;
                approvalActionsQuery.IsApproval = true;
                var approvalActionsRes = ORM_CMN_CAL_Event_Approval_Action.Query.Search(Connection, Transaction, approvalActionsQuery);

                if (approvalActionsRes.Count >= tenantSettings.NumberOfResponsiblePersonsRequiredToApprove)
                {
                    var approvalItem = new ORM_CMN_CAL_Event_Approval();
                    if (leaveRequest.CMN_CAL_Event_Approval_RefID != Guid.Empty)
                    {
                        var result = approvalItem.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_Approval_RefID);
                        if (result.Status != FR_Status.Success || approvalItem.CMN_CAL_Event_ApprovalID == Guid.Empty)
                        {
                            var error = new FR_Guid();
                            error.ErrorMessage = "No Such ID";
                            error.Status = FR_Status.Error_Internal;
                            return returnValue;
                        }
                    }
                    approvalItem.IsApprovalProcessDenied = false;
                    approvalItem.IsApprovalProcessOpened = false;
                    approvalItem.IsApproved = true;
                    approvalItem.IsApprovalProcessCanceledByUser = false;
                    approvalItem.Save(Connection, Transaction);

                    // update statistics ************************************************
                    var calQuery = new ORM_CMN_CAL_Event.Query();
                    calQuery.CMN_CAL_EventID = leaveRequest.CMN_CAL_Event_RefID;
                    var calendarRes = ORM_CMN_CAL_Event.Query.Search(Connection, Transaction, calQuery);
                    ORM_CMN_CAL_Event calendarEvent = calendarRes[0];
                    var timeFrame = cls_Get_CalculationTimeFramesForTenant.Invoke(Connection, Transaction, securityTicket).Result.Where(x => x.CalculationTimeframe_StartDate.Year == calendarEvent.StartTime.Year).FirstOrDefault();
                    
                    P_L5EM_GEATFSbRTFE_1423 statParam = new P_L5EM_GEATFSbRTFE_1423();
                    statParam.absenceReasonID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;
                    statParam.employeeID = leaveRequest.RequestedFor_Employee_RefID;
                    statParam.timeFrameID = timeFrame.CMN_CAL_CalculationTimeframeID;
                    var statistics = cls_Get_Employee_AbsenceReason_TimeframeStatistic_byReasonTimeFrameEmployee.Invoke(Connection, Transaction, statParam, securityTicket).Result;
                    if (statistics != null)
                    {
                        P_L5EM_SEARTFS_1356 updateStatisticsParam = new P_L5EM_SEARTFS_1356();
                        updateStatisticsParam.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID = statistics.CMN_BPT_EMP_Employee_AbsenceReason_TimeframeStatisticsID;
                        updateStatisticsParam.Employee_RefID = statistics.Employee_RefID;
                        updateStatisticsParam.CalculationTimeframe_RefID = statistics.CalculationTimeframe_RefID;
                        updateStatisticsParam.AbsenceReason_RefID = statistics.AbsenceReason_RefID;

                        updateStatisticsParam.R_AbsenceCarryOver_InDays = statistics.R_AbsenceCarryOver_InDays;
                        updateStatisticsParam.R_AbsenceCarryOver_InHours = statistics.R_AbsenceCarryOver_InHours;

                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InDays = statistics.R_TotalAllowedAbsenceTime_InDays - Parameter.durationInDays;
                        updateStatisticsParam.R_TotalAllowedAbsenceTime_InHours = statistics.R_TotalAllowedAbsenceTime_InHours - Parameter.durationInHours;
                        if (!Parameter.dontRemoveRequested)
                        {
                            updateStatisticsParam.R_RequestReservedAbsence_InDays = statistics.R_RequestReservedAbsence_InDays - Parameter.durationInDays;
                            updateStatisticsParam.R_RequestReservedAbsence_InHours = statistics.R_RequestReservedAbsence_InHours - Parameter.durationInHours;
                        }
                        updateStatisticsParam.R_AbsenceTimeUsed_InDays = statistics.R_AbsenceTimeUsed_InDays + Parameter.durationInDays;
                        updateStatisticsParam.R_AbsenceTimeUsed_InHours = statistics.R_AbsenceTimeUsed_InHours + Parameter.durationInHours;

                        var res = cls_Save_Employee_AbsenceReason_TimeframeStatistic.Invoke(Connection, Transaction, updateStatisticsParam, securityTicket);
                        // statistics update end :)
                    }
                    returnValue.Result = true;
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
		public static FR_Bool Invoke(string ConnectionString,P_L6LR_SLRAA_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection,P_L6LR_SLRAA_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_SLRAA_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Bool Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_SLRAA_1306 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw new Exception("Exception occured in method cle_Save_LeaveRequest_ApproveAction",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
	

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_Bool cle_Save_LeaveRequest_ApproveAction(,P_L6LR_SLRAA_1306 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_Bool invocationResult = cle_Save_LeaveRequest_ApproveAction.Invoke(connectionString,P_L6LR_SLRAA_1306 Parameter,securityTicket);
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
var parameter = new CL6_VacationPlanner_LeaveRequest.Complex.Manipulation.P_L6LR_SLRAA_1306();
parameter.LeaveRequestID = ...;
parameter.durationInDays = ...;
parameter.durationInHours = ...;

*/