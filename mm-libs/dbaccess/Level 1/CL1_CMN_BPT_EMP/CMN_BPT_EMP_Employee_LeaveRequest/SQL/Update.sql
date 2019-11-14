UPDATE 
	cmn_bpt_emp_employee_leaverequests
SET 
	RequestedBy_Employee_RefID=@RequestedBy_Employee_RefID,
	RequestedFor_Employee_RefID=@RequestedFor_Employee_RefID,
	CMN_CAL_Event_RefID=@CMN_CAL_Event_RefID,
	CMN_CAL_Event_Approval_RefID=@CMN_CAL_Event_Approval_RefID,
	CMN_BPT_STA_AbsenceReason_RefID=@CMN_BPT_STA_AbsenceReason_RefID,
	Comment=@Comment,
	LeaveRequestCreationSource=@LeaveRequestCreationSource,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_EMP_Employee_LeaveRequestID = @CMN_BPT_EMP_Employee_LeaveRequestID