
Select
  Covers.StandardFunction,
  Covers.Staff_Number,
  Covers.BusinessParticipant_RefID,
  Covers.CMN_BPT_EMP_EmployeeID,
  cmn_bpt_emp_employee_leaverequest_employeecovers.SequenceNumber,
  cmn_bpt_emp_employee_leaverequest_employeecovers.CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID,
  cmn_bpt_sta_absencereasons.ShortName,
  cmn_bpt_sta_absencereasons.Name_DictID,
  cmn_bpt_sta_absencereasons.Description_DictID,
  cmn_bpt_sta_absencereasons.ColorCode,
  cmn_bpt_sta_absencereasons.Parent_RefID,
  cmn_bpt_sta_absencereasons.IsAuthorizationRequired,
  cmn_bpt_sta_absencereasons.IsIncludedInCapacityCalculation,
  cmn_bpt_sta_absencereasons.AbsenceReason_Type_RefID,
  cmn_bpt_sta_absencereasons.IsAllowedAbsence,
  cmn_bpt_sta_absencereasons.IsDeactivated,
  cmn_bpt_sta_absencereasons.IsCarryOverEnabled,
  cmn_bpt_sta_absencereasons.IsCaryOverLimited,
  cmn_bpt_sta_absencereasons.IfCarryOverLimited_MaximumAmount_Hrs,
  cmn_bpt_emp_employee_leaverequests.CMN_BPT_EMP_Employee_LeaveRequestID,
  cmn_bpt_emp_employee_leaverequests.CMN_CAL_Event_RefID,
  cmn_bpt_emp_employee_leaverequests.CMN_CAL_Event_Approval_RefID,
  cmn_bpt_emp_employee_leaverequests.CMN_BPT_STA_AbsenceReason_RefID,
  cmn_bpt_emp_employee_leaverequests.Comment,
  cmn_cal_events.StartTime,
  cmn_cal_events.EndTime,
  cmn_cal_events.R_EventDuration_sec,
  cmn_cal_events.CalendarInstance_RefID,
  cmn_cal_event_approval_actions.ActionTriggeredBy_Account_RefID,
  cmn_cal_event_approval_actions.CMN_CAL_Event_Approval_ActionID,
  cmn_cal_event_approval_actions.IsApproval,
  cmn_cal_event_approval_actions.IsRevocation,
  cmn_cal_event_approval_actions.IsDenial,
  cmn_cal_event_approval_actions.Comment As Approval_Action_Commnet,
  cmn_cal_event_approvals.IsApproved,
  cmn_cal_event_approvals.IsApprovalProcessOpened,
  cmn_cal_event_approvals.IsApprovalProcessDenied,
  ForEmployee.BusinessParticipant_RefID As
  ForEmployee_BusinessParticipant_RefID,
  ForEmployee.Staff_Number As ForEmployee_Staff_Number,
  ForEmployee.StandardFunction As ForEmployee_StandardFunction,
  ForEmployee.CMN_BPT_EMP_EmployeeID As ForEmployeeID,
  cmn_cal_event_approvals.IsApprovalProcessCanceledByUser
From
  cmn_bpt_emp_employee_leaverequests Left Join
  cmn_bpt_emp_employee_leaverequest_employeecovers
    On cmn_bpt_emp_employee_leaverequests.CMN_BPT_EMP_Employee_LeaveRequestID =
    cmn_bpt_emp_employee_leaverequest_employeecovers.CMN_BPT_EMP_Employee_LeaveRequests Left Join
  cmn_bpt_emp_employees Covers
    On cmn_bpt_emp_employee_leaverequest_employeecovers.EmployeeCover_RefID =
    Covers.CMN_BPT_EMP_EmployeeID Left Join
  cmn_bpt_sta_absencereasons
    On cmn_bpt_emp_employee_leaverequests.CMN_BPT_STA_AbsenceReason_RefID =
    cmn_bpt_sta_absencereasons.CMN_BPT_STA_AbsenceReasonID Left Join
  cmn_cal_events On cmn_bpt_emp_employee_leaverequests.CMN_CAL_Event_RefID =
    cmn_cal_events.CMN_CAL_EventID Left Join
  cmn_cal_event_approvals
    On cmn_bpt_emp_employee_leaverequests.CMN_CAL_Event_Approval_RefID =
    cmn_cal_event_approvals.CMN_CAL_Event_ApprovalID Left Join
  cmn_cal_event_approval_actions
    On cmn_cal_event_approval_actions.EventApproval_RefID =
    cmn_cal_event_approvals.CMN_CAL_Event_ApprovalID Inner Join
  cmn_bpt_emp_employees ForEmployee On ForEmployee.CMN_BPT_EMP_EmployeeID =
    cmn_bpt_emp_employee_leaverequests.RequestedFor_Employee_RefID
Where
  (cmn_cal_event_approval_actions.IsDeleted = 0 Or
    cmn_cal_event_approval_actions.IsDeleted Is Null) And
  ForEmployee.IsDeleted = 0 And
  cmn_bpt_emp_employee_leaverequests.IsDeleted = 0 And
  cmn_cal_event_approvals.IsDeleted = 0 And
  cmn_cal_events.IsDeleted = 0 And
  (Covers.IsDeleted = 0 Or
    Covers.IsDeleted Is Null) And
  cmn_bpt_sta_absencereasons.IsDeleted = 0 And
  (cmn_bpt_emp_employee_leaverequest_employeecovers.IsDeleted = 0 Or
    cmn_bpt_emp_employee_leaverequest_employeecovers.IsDeleted Is Null) And
  cmn_bpt_emp_employee_leaverequests.Tenant_RefID = @TenantID And
  cmn_cal_event_approvals.IsApprovalProcessCanceledByUser = 0
  