
Select
 count(*) as LeaveCount
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
    cmn_bpt_emp_employee_leaverequests.RequestedFor_Employee_RefID Inner Join
  cmn_bpt_emp_employees ByEmployee On ByEmployee.CMN_BPT_EMP_EmployeeID =
    cmn_bpt_emp_employee_leaverequests.RequestedBy_Employee_RefID Inner Join
  cmn_cal_event_approvalprocess_types
    On cmn_cal_event_approvals.ApprovalProcess_Type_RefID =
    cmn_cal_event_approvalprocess_types.CMN_CAL_Event_ApprovalProcess_TypeID
  Inner Join
  cmn_cal_apr_responsiblepersons
    On cmn_cal_event_approvalprocess_types.IfResponsiblePersonBased_RefID =
    cmn_cal_apr_responsiblepersons.CMN_CAL_APR_ResponsiblePersonID
Where
  ForEmployee.CMN_BPT_EMP_EmployeeID = @EmployeeID And
  (cmn_cal_event_approval_actions.IsDeleted = 0 Or
    cmn_cal_event_approval_actions.IsDeleted Is Null) And
  ForEmployee.IsDeleted = 0 And
  ByEmployee.IsDeleted = 0 And
  cmn_bpt_emp_employee_leaverequests.IsDeleted = 0 And
  cmn_cal_event_approvals.IsDeleted = 0 And
  cmn_cal_events.IsDeleted = 0 And
  (Covers.IsDeleted = 0 Or
    Covers.IsDeleted Is Null) And
  cmn_bpt_sta_absencereasons.IsDeleted = 0 And
  (cmn_bpt_emp_employee_leaverequest_employeecovers.IsDeleted = 0 Or
    cmn_bpt_emp_employee_leaverequest_employeecovers.IsDeleted Is Null) And
  cmn_cal_event_approvalprocess_types.IsResponsiblePersonBased = 1 And
  cmn_cal_event_approvalprocess_types.IsDeleted = 0 And
  cmn_cal_apr_responsiblepersons.IsDeleted = 0 And
  cmn_bpt_emp_employee_leaverequests.Tenant_RefID = @TenantID And
  cmn_cal_event_approvals.IsApprovalProcessCanceledByUser = 0 And cmn_cal_events.StartTime > @StartDate
  