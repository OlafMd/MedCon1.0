
Select
  cmn_bpt_emp_employee_leaverequests.CMN_BPT_EMP_Employee_LeaveRequestID
From
  cmn_bpt_emp_employee_leaverequests Inner Join
  cmn_cal_event_approvals
    On cmn_bpt_emp_employee_leaverequests.CMN_CAL_Event_Approval_RefID =
    cmn_cal_event_approvals.CMN_CAL_Event_ApprovalID
Where
  cmn_bpt_emp_employee_leaverequests.CMN_BPT_STA_AbsenceReason_RefID = @ReasonID
  And
  (cmn_cal_event_approvals.IsApprovalProcessOpened = 1 Or
    cmn_cal_event_approvals.IsApproved = 1) And
  cmn_bpt_emp_employee_leaverequests.IsDeleted = 0 And
  cmn_cal_event_approvals.IsDeleted = 0 And
  cmn_bpt_emp_employee_leaverequests.Tenant_RefID = @TenantID
  