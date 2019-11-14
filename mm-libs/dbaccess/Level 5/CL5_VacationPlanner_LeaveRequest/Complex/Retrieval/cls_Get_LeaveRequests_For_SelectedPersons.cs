/* 
 * Generated on 14-Apr-14 15:58:35
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
using CL1_CMN_BPT;
using CL1_CMN_BPT_EMP;
using CL1_CMN_PER;
using CL1_CMN_BPT_STA;
using CL1_CMN_CAL;
using PlannicoModel.Models;

namespace CL5_VacationPlanner_LeaveRequest.Complex.Retrieval
{
	/// <summary>
    /// No description found in <meta/> tag
    /// <example>
	/// string connectionString = ...;
    /// var result = cls_Get_LeaveRequests_For_SelectedPersons.Invoke(connectionString).Result;
    /// </example>
    /// </summary>
	[DataContract]
	public class cls_Get_LeaveRequests_For_SelectedPersons
	{
		public static readonly int QueryTimeout = 60;

		#region Method Execution
		protected static FR_L5LR_GLRFSP_1532_Array Execute(DbConnection Connection,DbTransaction Transaction,P_L5LR_GLRFSP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null){
			#region UserCode 
			var returnValue = new FR_L5LR_GLRFSP_1532_Array();

            List<L5LR_GLRFSP_1532> resultList = new List<L5LR_GLRFSP_1532>();
            Parameter.EmployeeIDList=Parameter.EmployeeIDList.Select(i=>i).Distinct().ToArray();

            foreach(var employeeID in Parameter.EmployeeIDList){
                ORM_CMN_BPT_EMP_Employee employee = new ORM_CMN_BPT_EMP_Employee();
                employee.Load(Connection, Transaction, employeeID);
                if (employee.CMN_BPT_EMP_EmployeeID == Guid.Empty)
                    continue;



                //Covers
                ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query leaveRequestQuery = new ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query();
                leaveRequestQuery.RequestedFor_Employee_RefID = employee.CMN_BPT_EMP_EmployeeID;
                leaveRequestQuery.Tenant_RefID = securityTicket.TenantID;
                leaveRequestQuery.IsDeleted = false;
                List<ORM_CMN_BPT_EMP_Employee_LeaveRequest> leaveRequests = ORM_CMN_BPT_EMP_Employee_LeaveRequest.Query.Search(Connection, Transaction, leaveRequestQuery);
                foreach(var leaveRequest in leaveRequests ){
                    L5LR_GLRFSP_1532 result = new L5LR_GLRFSP_1532();
                    result.ForEmployeeID = employee.CMN_BPT_EMP_EmployeeID;
                    result.ForEmployee_BusinessParticipant_RefID = employee.BusinessParticipant_RefID;
                    result.ForEmployee_Staff_Number = employee.Staff_Number;
                    result.ForEmployee_StandardFunction = employee.StandardFunction;
                    result.LeaveRequestCreationSource = leaveRequest.LeaveRequestCreationSource;
                    ORM_CMN_BPT_BusinessParticipant bpart = new ORM_CMN_BPT_BusinessParticipant();
                    bpart.Load(Connection, Transaction, employee.BusinessParticipant_RefID);

                    ORM_CMN_PER_PersonInfo per = new ORM_CMN_PER_PersonInfo();
                    per.Load(Connection,Transaction, bpart.IfNaturalPerson_CMN_PER_PersonInfo_RefID);
                    result.FirstName = per.FirstName;
                    result.LastName = per.LastName;

                    result.CMN_CAL_Event_RefID = leaveRequest.CMN_CAL_Event_RefID;
                    result.CMN_CAL_Event_Approval_RefID = leaveRequest.CMN_CAL_Event_Approval_RefID;
                    result.CMN_CAL_Event_Approval_RefID = leaveRequest.CMN_BPT_STA_AbsenceReason_RefID;
                    result.Comment = leaveRequest.Comment;
                    result.RequestedBy_Employee_RefID = leaveRequest.RequestedBy_Employee_RefID;
                    result.CMN_BPT_EMP_Employee_LeaveRequestID = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                    ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover.Query covers = new ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover.Query();
                    covers.CMN_BPT_EMP_Employee_LeaveRequests = leaveRequest.CMN_BPT_EMP_Employee_LeaveRequestID;
                    covers.Tenant_RefID = securityTicket.TenantID;
                    covers.IsDeleted = false;
                    List<ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover> employeeCovers = ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover.Query.Search(Connection, Transaction, covers);
                    result.Cover=new L5LR_GLRFSP_1532_Cover();
                    if(employeeCovers.Count!=0){
                        ORM_CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCover employeeCover=employeeCovers[0];
                        result.Cover.CMN_BPT_EMP_EmployeeID=employeeCover.EmployeeCover_RefID;
                        result.Cover.CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID=employeeCover.CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID;
                        result.Cover.SequenceNumber=employeeCover.SequenceNumber;
                    }

                    ORM_CMN_BPT_STA_AbsenceReason absenceReason=new ORM_CMN_BPT_STA_AbsenceReason();
                    absenceReason.Load(Connection,Transaction,leaveRequest.CMN_BPT_STA_AbsenceReason_RefID);
                    if(absenceReason.CMN_BPT_STA_AbsenceReasonID==Guid.Empty)
                        continue;
                    result.CMN_BPT_STA_AbsenceReason_RefID = absenceReason.CMN_BPT_STA_AbsenceReasonID;
                    result.ShortName=absenceReason.ShortName;
                    result.ReasonName=absenceReason.Name;
                    result.ReasonDesc=absenceReason.Description;
                    result.AbsenceReason_Type_RefID=absenceReason.AbsenceReason_Type_RefID;
                    result.ColorCode=absenceReason.ColorCode;
                    result.Parent_RefID=absenceReason.Parent_RefID;
                    result.IsAuthorizationRequired=absenceReason.IsAuthorizationRequired;
                    result.IsIncludedInCapacityCalculation=absenceReason.IsIncludedInCapacityCalculation;
                    result.IsAllowedAbsence=absenceReason.IsAllowedAbsence;
                    result.IsDeactivated=absenceReason.IsDeactivated;
                    result.IsCarryOverEnabled=absenceReason.IsCarryOverEnabled;
                    result.IsCaryOverLimited=absenceReason.IsCaryOverLimited;
                    result.IfCarryOverLimited_MaximumAmount_Hrs=absenceReason.IfCarryOverLimited_MaximumAmount_Hrs;

                    ORM_CMN_CAL_Event Event=new ORM_CMN_CAL_Event();
                    Event.Load(Connection,Transaction,leaveRequest.CMN_CAL_Event_RefID);
                    if(Event.CMN_CAL_EventID==Guid.Empty)
                        continue;

                    result.CalendarInstance_RefID=Event.CalendarInstance_RefID;
                    result.StartTime=Event.StartTime;
                    result.EndTime=Event.EndTime;
                    result.R_EventDuration_sec=Event.R_EventDuration_sec;

                    ORM_CMN_CAL_Event_Approval eventApproval=new ORM_CMN_CAL_Event_Approval();
                    eventApproval.Load(Connection,Transaction,leaveRequest.CMN_CAL_Event_Approval_RefID);
                    if(eventApproval.CMN_CAL_Event_ApprovalID==Guid.Empty)
                        continue;

                    result.Action=new L5LR_GLRFSP_1532_Action();

                    result.IsApproved=eventApproval.IsApproved;
                    result.IsApprovalProcessOpened=eventApproval.IsApprovalProcessOpened;
                    result.IsApprovalProcessDenied=eventApproval.IsApprovalProcessDenied;

                    if (eventApproval.IsApprovalProcessCanceledByUser)
                        continue;

                    ORM_CMN_CAL_Event_Approval_Action.Query approvalQuery=new ORM_CMN_CAL_Event_Approval_Action.Query();
                    approvalQuery.EventApproval_RefID=eventApproval.CMN_CAL_Event_ApprovalID;
                    approvalQuery.Tenant_RefID=securityTicket.TenantID;
                    approvalQuery.IsDeleted=false;
                    List<ORM_CMN_CAL_Event_Approval_Action> apporvalActions = ORM_CMN_CAL_Event_Approval_Action.Query.Search(Connection, Transaction, approvalQuery);
                    if(apporvalActions.Count!=0){
                        ORM_CMN_CAL_Event_Approval_Action approvalAction=apporvalActions[0];
                        result.Action.ActionTriggeredBy_Account_RefID=approvalAction.ActionTriggeredBy_Account_RefID;
                        result.Action.CMN_CAL_Event_Approval_ActionID=approvalAction.CMN_CAL_Event_Approval_ActionID;
                        result.Action.IsApproval=approvalAction.IsApproval;
                        result.Action.IsRevocation=approvalAction.IsRevocation;
                        result.Action.IsDenial=approvalAction.IsDenial;
                        result.Action.Approval_Action_Commnet=approvalAction.Comment;
                    }
                    if(!result.Action.IsRevocation)
                    resultList.Add(result);
    

                }


            }
            returnValue.Result=resultList.ToArray();
			//Put your code here
			return returnValue;
			#endregion UserCode
		}
		#endregion

		#region Method Invocation Wrappers
		///<summary>
		/// Opens the connection/transaction for the given connectionString, and closes them when complete
		///<summary>
		public static FR_L5LR_GLRFSP_1532_Array Invoke(string ConnectionString,P_L5LR_GLRFSP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(null, null, ConnectionString,Parameter,securityTicket);
		}
		///<summary>
		/// Ivokes the method with the given Connection, leaving it open if no exceptions occured
		///<summary>
		public static FR_L5LR_GLRFSP_1532_Array Invoke(DbConnection Connection,P_L5LR_GLRFSP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, null, null,Parameter,securityTicket);
		}
		///<summary>
		/// Invokes the method for the given Connection, and Transaction, leaving them open/not commited if no exceptions occured
		///<summary>
		public static FR_L5LR_GLRFSP_1532_Array Invoke(DbConnection Connection, DbTransaction Transaction,P_L5LR_GLRFSP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			return Invoke(Connection, Transaction, null,Parameter,securityTicket);
		}
		///<summary>
		/// Method Invocation of wrapper classes
		///<summary>
		protected static FR_L5LR_GLRFSP_1532_Array Invoke(DbConnection Connection, DbTransaction Transaction, string ConnectionString,P_L5LR_GLRFSP_1532 Parameter,CSV2Core.SessionSecurity.SessionSecurityTicket securityTicket = null)
		{
			bool cleanupConnection = Connection == null;
			bool cleanupTransaction = Transaction == null;

			FR_L5LR_GLRFSP_1532_Array functionReturn = new FR_L5LR_GLRFSP_1532_Array();
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

	#region Raw Grouping Class
	[Serializable]
	public class L5LR_GLRFSP_1532_raw 
	{
		public string ShortName; 
		public Dict ReasonName; 
		public Dict ReasonDesc; 
		public string FirstName; 
		public string LastName; 
		public string ColorCode; 
		public Guid Parent_RefID; 
		public bool IsAuthorizationRequired; 
		public bool IsIncludedInCapacityCalculation; 
		public Guid AbsenceReason_Type_RefID; 
		public bool IsAllowedAbsence; 
		public bool IsDeactivated; 
		public bool IsCarryOverEnabled; 
		public bool IsCaryOverLimited; 
		public double IfCarryOverLimited_MaximumAmount_Hrs; 
		public Guid CMN_BPT_EMP_Employee_LeaveRequestID; 
		public Guid CMN_CAL_Event_RefID; 
		public Guid CMN_CAL_Event_Approval_RefID; 
		public Guid CMN_BPT_STA_AbsenceReason_RefID; 
		public string Comment; 
		public DateTime StartTime; 
		public DateTime EndTime; 
		public long R_EventDuration_sec; 
		public Guid CalendarInstance_RefID; 
		public bool IsApprovalProcessDenied; 
		public Guid ForEmployeeID; 
		public Guid RequestedBy_Employee_RefID; 
		public Guid ForEmployee_BusinessParticipant_RefID; 
		public string ForEmployee_Staff_Number; 
		public string ForEmployee_StandardFunction; 
		public bool IsApproved; 
		public bool IsApprovalProcessOpened; 
		public String LeaveRequestCreationSource; 
		public string StandardFunction; 
		public Guid BusinessParticipant_RefID; 
		public Guid CMN_BPT_EMP_EmployeeID; 
		public int SequenceNumber; 
		public Guid CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID; 
		public Guid ActionTriggeredBy_Account_RefID; 
		public Guid CMN_CAL_Event_Approval_ActionID; 
		public bool IsApproval; 
		public bool IsRevocation; 
		public bool IsDenial; 
		public string Approval_Action_Commnet; 


		private static bool EqualsDefaultValue<T>(T value)
	    {
	        return EqualityComparer<T>.Default.Equals(value, default(T));
	    }

		public static L5LR_GLRFSP_1532[] Convert(List<L5LR_GLRFSP_1532_raw> rawResult)
		{	
		    var gfunct_rawResult = rawResult;
			var groupResult = from el_L5LR_GLRFSP_1532 in gfunct_rawResult.Where(element => !EqualsDefaultValue(element.CMN_BPT_EMP_Employee_LeaveRequestID)).ToArray()
	group el_L5LR_GLRFSP_1532 by new 
	{ 
		el_L5LR_GLRFSP_1532.CMN_BPT_EMP_Employee_LeaveRequestID,

	}
	into gfunct_L5LR_GLRFSP_1532
	select new L5LR_GLRFSP_1532
	{     
		ShortName = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ShortName ,
		ReasonName = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ReasonName ,
		ReasonDesc = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ReasonDesc ,
		FirstName = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().FirstName ,
		LastName = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().LastName ,
		ColorCode = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ColorCode ,
		Parent_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().Parent_RefID ,
		IsAuthorizationRequired = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsAuthorizationRequired ,
		IsIncludedInCapacityCalculation = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsIncludedInCapacityCalculation ,
		AbsenceReason_Type_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().AbsenceReason_Type_RefID ,
		IsAllowedAbsence = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsAllowedAbsence ,
		IsDeactivated = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsDeactivated ,
		IsCarryOverEnabled = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsCarryOverEnabled ,
		IsCaryOverLimited = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsCaryOverLimited ,
		IfCarryOverLimited_MaximumAmount_Hrs = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IfCarryOverLimited_MaximumAmount_Hrs ,
		CMN_BPT_EMP_Employee_LeaveRequestID = gfunct_L5LR_GLRFSP_1532.Key.CMN_BPT_EMP_Employee_LeaveRequestID ,
		CMN_CAL_Event_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().CMN_CAL_Event_RefID ,
		CMN_CAL_Event_Approval_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().CMN_CAL_Event_Approval_RefID ,
		CMN_BPT_STA_AbsenceReason_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().CMN_BPT_STA_AbsenceReason_RefID ,
		Comment = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().Comment ,
		StartTime = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().StartTime ,
		EndTime = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().EndTime ,
		R_EventDuration_sec = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().R_EventDuration_sec ,
		CalendarInstance_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().CalendarInstance_RefID ,
		IsApprovalProcessDenied = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsApprovalProcessDenied ,
		ForEmployeeID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ForEmployeeID ,
		RequestedBy_Employee_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().RequestedBy_Employee_RefID ,
		ForEmployee_BusinessParticipant_RefID = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ForEmployee_BusinessParticipant_RefID ,
		ForEmployee_Staff_Number = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ForEmployee_Staff_Number ,
		ForEmployee_StandardFunction = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().ForEmployee_StandardFunction ,
		IsApproved = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsApproved ,
		IsApprovalProcessOpened = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().IsApprovalProcessOpened ,
		LeaveRequestCreationSource = gfunct_L5LR_GLRFSP_1532.FirstOrDefault().LeaveRequestCreationSource ,

		Cover = 
		(
			from el_Cover in gfunct_L5LR_GLRFSP_1532.Where(element => !EqualsDefaultValue(element.BusinessParticipant_RefID)).ToArray()
			group el_Cover by new 
			{ 
				el_Cover.BusinessParticipant_RefID,

			}
			into gfunct_Cover
			select new L5LR_GLRFSP_1532_Cover
			{     
				StandardFunction = gfunct_Cover.FirstOrDefault().StandardFunction ,
				BusinessParticipant_RefID = gfunct_Cover.Key.BusinessParticipant_RefID ,
				CMN_BPT_EMP_EmployeeID = gfunct_Cover.FirstOrDefault().CMN_BPT_EMP_EmployeeID ,
				SequenceNumber = gfunct_Cover.FirstOrDefault().SequenceNumber ,
				CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID = gfunct_Cover.FirstOrDefault().CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID ,

			}
		).FirstOrDefault(),
		Action = 
		(
			from el_Action in gfunct_L5LR_GLRFSP_1532.Where(element => !EqualsDefaultValue(element.ActionTriggeredBy_Account_RefID)).ToArray()
			group el_Action by new 
			{ 
				el_Action.ActionTriggeredBy_Account_RefID,

			}
			into gfunct_Action
			select new L5LR_GLRFSP_1532_Action
			{     
				ActionTriggeredBy_Account_RefID = gfunct_Action.Key.ActionTriggeredBy_Account_RefID ,
				CMN_CAL_Event_Approval_ActionID = gfunct_Action.FirstOrDefault().CMN_CAL_Event_Approval_ActionID ,
				IsApproval = gfunct_Action.FirstOrDefault().IsApproval ,
				IsRevocation = gfunct_Action.FirstOrDefault().IsRevocation ,
				IsDenial = gfunct_Action.FirstOrDefault().IsDenial ,
				Approval_Action_Commnet = gfunct_Action.FirstOrDefault().Approval_Action_Commnet ,

			}
		).FirstOrDefault(),

	};

			return groupResult.ToArray();
		}
	}
	#endregion

	#region Custom Return Type
	[Serializable]
	public class FR_L5LR_GLRFSP_1532_Array : FR_Base
	{
		public L5LR_GLRFSP_1532[] Result	{ get; set; } 
		public FR_L5LR_GLRFSP_1532_Array() : base() {}

		public FR_L5LR_GLRFSP_1532_Array(Exception ex): base(ex) {}

	}
	#endregion

	#region Support Classes
		

	#endregion
}
