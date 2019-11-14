UPDATE 
	cmn_bpt_emp_employee_leaverequest_employeecovers
SET 
	CMN_BPT_EMP_Employee_LeaveRequests=@CMN_BPT_EMP_Employee_LeaveRequests,
	EmployeeCover_RefID=@EmployeeCover_RefID,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID = @CMN_BPT_EMP_Employee_LeaveRequest_EmployeeCoverID