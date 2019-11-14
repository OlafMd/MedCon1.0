UPDATE 
	cmn_bpt_emp_employees
SET 
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	Staff_Number=@Staff_Number,
	Primary_Office_RefID=@Primary_Office_RefID,
	Primary_WorkArea_RefID=@Primary_WorkArea_RefID,
	Primary_Workplace_RefID=@Primary_Workplace_RefID,
	StandardFunction=@StandardFunction,
	EmployeeDocument_Structure_RefID=@EmployeeDocument_Structure_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_EmployeeID = @CMN_BPT_EMP_EmployeeID