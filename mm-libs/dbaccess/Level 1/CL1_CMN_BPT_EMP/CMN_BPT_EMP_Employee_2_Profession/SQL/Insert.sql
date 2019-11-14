INSERT INTO 
	cmn_bpt_emp_employee_2_profession
	(
		AssignmentID,
		Employee_RefID,
		Profession_RefID,
		ProfessionObtainedAtDate,
		IsPrimary,
		ProfessionGrantedByAuthority,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@Employee_RefID,
		@Profession_RefID,
		@ProfessionObtainedAtDate,
		@IsPrimary,
		@ProfessionGrantedByAuthority,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)