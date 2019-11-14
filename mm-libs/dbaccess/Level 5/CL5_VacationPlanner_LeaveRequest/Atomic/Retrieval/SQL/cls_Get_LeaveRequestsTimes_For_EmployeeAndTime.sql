
Select
	cmn_bpt_emp_employee_leaverequests.Comment,
	cmn_cal_events.StartTime,
	cmn_cal_events.EndTime,
  cmn_bpt_emp_employee_leaverequests.CMN_BPT_EMP_Employee_LeaveRequestID
From
	cmn_bpt_emp_employee_leaverequests Inner Join
	cmn_cal_events On cmn_bpt_emp_employee_leaverequests.CMN_CAL_Event_RefID =
		cmn_cal_events.CMN_CAL_EventID Inner Join
	cmn_cal_event_approvals
		On cmn_bpt_emp_employee_leaverequests.CMN_CAL_Event_Approval_RefID =
		cmn_cal_event_approvals.CMN_CAL_Event_ApprovalID
Where
	(cmn_cal_event_approvals.IsApprovalProcessDenied != 1 And
	cmn_bpt_emp_employee_leaverequests.IsDeleted = 0 And
	cmn_cal_event_approvals.IsDeleted = 0 And
	cmn_cal_events.IsDeleted = 0 And
	cmn_bpt_emp_employee_leaverequests.RequestedFor_Employee_RefID = @EmployeeID
	And
	not(@StartTime < cmn_cal_events.StartTime And
	@EndTime < cmn_cal_events.StartTime) and
	not(@StartTime > cmn_cal_events.EndTime And
	@EndTime > cmn_cal_events.EndTime)) And
  cmn_cal_event_approvals.IsApprovalProcessCanceledByUser = 0
	