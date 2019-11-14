/* 
 * Generated on 5/20/2014 11:20:26 AM
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
using PlannicoModel.Models;
using CL1_CMN_BPT;
using CL1_CMN_PER;
using CL1_CMN_BPT_STA;
using CL1_CMN_CAL;

namespace CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LeaveRequests_By_ID.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LeaveRequests_By_ID
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L6LR_GLR_ID_1339 Execute(DbConnection Connection,DbTransaction Transaction,P_L6LR_GLR_ID_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode
            var returnValue = new FR_L6LR_GLR_ID_1339();
            returnValue.Result = new L6LR_GLR_ID_1339();

            
                //Covers
                ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query leaveRequestQuery = new ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query();
                leaveRequestQuery.CMN_BPT_EMP_Employee_LeaveRequestID = Parameter.LeaveID;
                leaveRequestQuery.Tenant_RefID = securityTicket.TenantID;
                leaveRequestQuery.IsDeleted = false;
                ORM_CMN_BPT_EMP_Employee_LeaveRequest leaveRequest = ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query.Search(Connection, Transaction, leaveRequestQuery).FirstOrDefault();
                ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
                employee.Load(Connection, Transaction, leaveRequest.RequestedFor_Employee_RefID);
                    L5LR_GLRFSP_1532 result = new L5LR_GLRFSP_1532();
                    result.ForEmployeeID = employee.CMN_BPT_EMP_EmployeeID;
                    result.ForEmployee_BusinessParticipant_RefID = employee.BusinessParticipant_RefID;
                    result.ForEmployee_Staff_Number = employee.Staff_Number;
                    result.ForEmployee_StandardFunction = employee.StandardFunction;
                    result.LeaveRequestCreationSource = leaveRequest.LeaveRequestCreationSource;
                    ORM_CMN_BPT_BusinessParticipant bpart = new ORM_CMN_BPT_BusinessParticipant();
                    bpart.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                    ORM_CMN_PER_PersonInfo per = new ORM_CMN_PER_PersonInfo();
                    per.Load(Connection, Transaction, bpart.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                    result.FirstName = per.FirstName;
                    result.LastName = per.LastName;

                    result.CMN_CAL_Event_RefID = leaveRequest.CMN_CAL_Event_RefID;
                    result.CMN_CAL_Event_Approval_RefID = leaveRequest.CMN_CAL_Event_Approval_RefID;
                    //result.AbsenceReason_Type_RefID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;
                    result.Comment = leaveRequest.Comment;
                    result.RequestedBy_Employee_RefID = leaveRequest.RequestedBy_Employee_RefID;
                    result.CMN_BPT_EMP_Employee_LeaveRequestID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                    ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover.Query covers = new ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover.Query();
                    covers.CMN_BPT_EMP_Employee_LeaveRequests = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                    covers.Tenant_RefID = securityTicket.TenantID;
                    covers.IsDeleted = false;
                    List<ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover> employeeCovers = ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover.Query.Search(Connection, Transaction, covers);
                    result.Cover = new L5LR_GLRFSP_1532_Cover();
                    if (employeeCovers.Count != 0)
                    {
                        ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover employeeCover = employeeCovers[0];
                        result.Cover.CMN_BPT_EMP_EmployeeID = employeeCover.EmployeeCover_RefID;
                        result.Cover.CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID = employeeCover.CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID;
                        result.Cover.SequenceNumber = employeeCover.SequenceNumber;
                    }

                    ORM_CMN_BPT_STA_AbsenceReason absenceReason = new ORM_CMN_BPT_STA_AbsenceReason();
                    absenceReason.Load(Connection, Transaction, leaveRequest.CMN_BPT_STA_AbsenceReason_RefID);

                    result.CMN_BPT_STA_AbsenceReason_RefID = absenceReason.CMN_BPT_STA_AbsenceReasonID;
                    result.ShortName = absenceReason.ShortName;
                    result.ReasonName = absenceReason.Name;
                    result.ReasonDesc = absenceReason.Description;
                    result.AbsenceReason_Type_RefID = absenceReason.AbsenceReason_Type_RefID;
                    result.ColorCode = absenceReason.ColorCode;
                    result.Parent_RefID = absenceReason.Parent_RefID;
                    result.IsAuthorizationRequired = absenceReason.IsAuthorizationRequired;
                    result.IsIncludedInCapacityCalculation = absenceReason.IsIncludedInCapacityCalculation;
                    result.IsAllowedAbsence = absenceReason.IsAllowedAbsence;
                    result.IsDeactivated = absenceReason.IsDeactivated;
                    result.IsCarryOverEnabled = absenceReason.IsCarryOverEnabled;
                    result.IsCaryOverLimited = absenceReason.IsCaryOverLimited;
                    result.IfCarryOverLimited_MaximumAmount_Hrs = absenceReason.IfCarryOverLimited_MaximumAmount_Hrs;

                    ORM_CMN_CAL_Event Event = new ORM_CMN_CAL_Event();
                    Event.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_RefID);

                    result.CalendarInstance_RefID = Event.CalendarInstance_RefID;
                    result.StartTime = Event.StartTime;
                    result.EndTime = Event.EndTime;
                    result.R_EventDuration_sec = Event.R_EventDuration_sec;

                    ORM_CMN_CAL_Event_Approval eventApproval = new ORM_CMN_CAL_Event_Approval();
                    eventApproval.Load(Connection, Transaction, leaveRequest.CMN_CAL_Event_Approval_RefID);

                    result.Action = new L5LR_GLRFSP_1532_Action();

                    result.IsApproved = eventApproval.IsApproved;
                    result.IsApprovalProcessOpened = eventApproval.IsApprovalProcessOpened;
                    result.IsApprovalProcessDenied = eventApproval.IsApprovalProcessDenied;

                    ORM_CMN_CAL_Event_Approval_Action.Query approvalQuery = new ORM_CMN_CAL_Event_Approval_Action.Query();
                    approvalQuery.EventApproval_RefID = eventApproval.CMN_CAL_Event_ApprovalID;
                    approvalQuery.Tenant_RefID = securityTicket.TenantID;
                    approvalQuery.IsDeleted = false;
                    List<ORM_CMN_CAL_Event_Approval_Action> apporvalActions = ORM_CMN_CAL_Event_Approval_Action.Query.Search(Connection, Transaction, approvalQuery);
                    if (apporvalActions.Count != 0)
                    {
                        ORM_CMN_CAL_Event_Approval_Action approvalAction = apporvalActions[0];
                        result.Action.ActionTriggeredBy_Account_RefID = approvalAction.ActionTriggeredBy_Account_RefID;
                        result.Action.CMN_CAL_Event_Approval_ActionID = approvalAction.CMN_CAL_Event_Approval_ActionID;
                        result.Action.IsApproval = approvalAction.IsApproval;
                        result.Action.IsRevocation = approvalAction.IsRevocation;
                        result.Action.IsDenial = approvalAction.IsDenial;
                        result.Action.Approval_Action_Commnet = approvalAction.Comment;
                    }
            
            returnValue.Result.Leave = result;
            //Put your code here
            return returnValue;
            #endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L6LR_GLR_ID_1339 Invoke(string ConnectionString,P_L6LR_GLR_ID_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L6LR_GLR_ID_1339 Invoke(DbConnection Connection,P_L6LR_GLR_ID_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L6LR_GLR_ID_1339 Invoke(DbConnection Connection, DbTransaction Transaction,P_L6LR_GLR_ID_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L6LR_GLR_ID_1339 Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L6LR_GLR_ID_1339 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L6LR_GLR_ID_1339 functionReturn = new FR_L6LR_GLR_ID_1339();
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

				throw new Exception("Exception occured in method cls_Get_LeaveRequests_By_ID",ex);
			}
			return functionReturn;
		}
		#endregion
	}

	#region Custom Return Type
	[Serializable]
	public class FR_L6LR_GLR_ID_1339 : FR_Base
	{
		public L6LR_GLR_ID_1339 Result	{ get; set; }

		public FR_L6LR_GLR_ID_1339() : base() {}

		public FR_L6LR_GLR_ID_1339(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		#region SClass P_L6LR_GLR_ID_1339 for attribute P_L6LR_GLR_ID_1339
		[DataContract]
		public class P_L6LR_GLR_ID_1339 
		{
			//Standard type parameters
			[DataMember]
			public Guid LeaveID { get; set; } 

		}
		#endregion
		#region SClass L6LR_GLR_ID_1339 for attribute L6LR_GLR_ID_1339
		[DataContract]
		public class L6LR_GLR_ID_1339 
		{
			//Standard type parameters
			[DataMember]
			public L5LR_GLRFSP_1532 Leave { get; set; } 

		}
		#endregion

	#endregion
}

/* Support Web Invocation Methods (Copy&Paste)
[OperationContract]
FR_L6LR_GLR_ID_1339 cls_Get_LeaveRequests_By_ID(,P_L6LR_GLR_ID_1339 Parameter, string sessionToken = null)
{
	try
	{
		var securityTicket = Verify(sessionToken);
		FR_L6LR_GLR_ID_1339 invocationResult = cls_Get_LeaveRequests_By_ID.Invoke(connectionString,P_L6LR_GLR_ID_1339 Parameter,securityTicket);
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
var parameter = new CLE_L6_PlannicoMobile_LeaveRequest.Complex.Retrieval.P_L6LR_GLR_ID_1339();
parameter.LeaveID = ...;

*/
