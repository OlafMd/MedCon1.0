INSERT INTO 
	cmn_bpt_emp_employees
	(
		CMN_BPT_EMP_EmployeeID,
		BusinessParticipant_RefID,
		Staff_Number,
		Primary_Office_RefID,
		Primary_WorkArea_RefID,
		Primary_Workplace_RefID,
		StandardFunction,
		EmployeeDocument_Structure_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_BPT_EMP_EmployeeID,
		@BusinessParticipant_RefID,
		@Staff_Number,
		@Primary_Office_RefID,
		@Primary_WorkArea_RefID,
		@Primary_Workplace_RefID,
		@StandardFunction,
		@EmployeeDocument_Structure_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)