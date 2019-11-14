INSERT INTO 
	cmn_bpt_emp_employmentrelationship_2_workingcontract
	(
		AssignmentID,
		EmploymentRelationship_RefID,
		WorkingContract_RefID,
		IsContract_Active,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@EmploymentRelationship_RefID,
		@WorkingContract_RefID,
		@IsContract_Active,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)