/* 
 * Generated on 14-Apr-14 15:23:09
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

namespace CL5_VacationPlanner_LeaveRequest.Atomic.Manipulation
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Save_Employee_LeaveRequest.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Save_Employee_LeaveRequest
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_Guid Execute(DbConnection Connection,DbTransaction Transaction,P_L5LR_SELR_255 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_Guid();

            var eventItem = new ORM_CMN_CAL_Event();
            if (Parameter.EventID != Guid.Empty)
            {
                var result = eventItem.Load(Connection, Transaction, Parameter.EventID);
                if (result.Status != FR_Status.Success || eventItem.CMN_CAL_EventID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            eventItem.CalendarInstance_RefID = Parameter.CalendarInstance_RefID;
            eventItem.EndTime = Parameter.EndTime;
            eventItem.IsDeleted = false;
            eventItem.IsRepetitive = Parameter.IsRepetitive;
            eventItem.Repetition_RefID = Parameter.Repetition_RefID;
            eventItem.StartTime = Parameter.StartTime;
            eventItem.Tenant_RefID = securityTicket.TenantID;
            eventItem.Creation_Timestamp = DateTime.Now;
            eventItem.Save(Connection, Transaction);

            var approvalItem = new ORM_CMN_CAL_Event_Approval();
            if (Parameter.Event_Approval_RefID != Guid.Empty)
            {
                var result = approvalItem.Load(Connection, Transaction, Parameter.Event_Approval_RefID);
                if (result.Status != FR_Status.Success || approvalItem.CMN_CAL_Event_ApprovalID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            approvalItem.Event_RefID = eventItem.CMN_CAL_EventID;
            approvalItem.IsApprovalProcessDenied = Parameter.IsApprovalProcessDenied;
            approvalItem.IsApprovalProcessOpened = Parameter.IsApprovalProcessOpened;
            approvalItem.IsApproved = Parameter.IsApproved;
            approvalItem.IsApprovalProcessCanceledByUser = Parameter.IsApprovalProcessCanceledByUser;
            approvalItem.IsDeleted = false;
            approvalItem.Creation_Timestamp = DateTime.Now;
            approvalItem.Tenant_RefID = securityTicket.TenantID;
            approvalItem.ApprovalProcess_Type_RefID = Parameter.ApprovalProcessTypeID;
            approvalItem.Save(Connection, Transaction);

            

            var requestItem = new ORM_CMN_BPT_EMP_Employee_LeaveRequest();
            if (Parameter.Employee_LeaveRequestID != Guid.Empty)
            {
                var result = requestItem.Load(Connection, Transaction, Parameter.Employee_LeaveRequestID);
                if (result.Status != FR_Status.Success || requestItem.CMN_BPT_EMP_Employee_LeaveRequestID == Guid.Empty)
                {
                    var error = new FR_Guid();
                    error.ErrorMessage = "No Such ID";
                    error.Status = FR_Status.Error_Internal;
                    return error;
                }
            }
            requestItem.CMN_BPT_STA_AbsenceReason_RefID = Parameter.AbsenceReason_RefID;
            requestItem.CMN_CAL_Event_Approval_RefID = approvalItem.CMN_CAL_Event_ApprovalID;
            requestItem.CMN_CAL_Event_RefID = eventItem.CMN_CAL_EventID;
            requestItem.Comment = Parameter.Comment;
            requestItem.IsDeleted = false;
            requestItem.RequestedBy_Employee_RefID = Parameter.RequestedBy_Employee_RefID;
            requestItem.RequestedFor_Employee_RefID = Parameter.RequestedFor_Employee_RefID;
            requestItem.Tenant_RefID = securityTicket.TenantID;
            requestItem.Creation_Timestamp = DateTime.Now;
            requestItem.LeaveRequestCreationSource = Parameter.LeaveRequestCreationSource;
            requestItem.Save(Connection, Transaction);

            if (Parameter.EmployeeCover_RefID != Guid.Empty)
            {

                var coverItem = new ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover();
                if (Parameter.Employee_LeaveRequest_EmployeeCoverID != Guid.Empty)
                {
                    var result = coverItem.Load(Connection, Transaction, Parameter.Employee_LeaveRequest_EmployeeCoverID);
                    if (result.Status != FR_Status.Success || coverItem.CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID == Guid.Empty)
                    {
                        var error = new FR_Guid();
                        error.ErrorMessage = "No Such ID";
                        error.Status = FR_Status.Error_Internal;
                        return error;
                    }
                }
                coverItem.CMN_BPT_EMP_Employee_LeaveRequests = requestItem.CMN_BPT_EMP_Employee_LeaveRequestID;
                coverItem.EmployeeCover_RefID = Parameter.EmployeeCover_RefID;
                coverItem.IsDeleted = false;
                coverItem.SequenceNumber = Parameter.SequenceNumber;
                coverItem.Tenant_RefID = securityTicket.TenantID;
                coverItem.Creation_Timestamp = DateTime.Now;
                coverItem.Save(Connection, Transaction);
            }
            returnValue.Result = requestItem.CMN_BPT_EMP_Employee_LeaveRequestID;

			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_Guid Invoke(string ConnectionString,P_L5LR_SELR_255 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection,P_L5LR_SELR_255 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LR_SELR_255 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_Guid Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LR_SELR_255 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
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

				throw ex;
			}
			return functionReturn;
		}
		#endregion
	}

	#region Support Classes
		

	#endregion
}
