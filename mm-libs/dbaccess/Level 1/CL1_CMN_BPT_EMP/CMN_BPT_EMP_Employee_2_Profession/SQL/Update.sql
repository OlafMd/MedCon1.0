UPDATE 
	cmn_bpt_emp_employee_2_profession
SET 
	Employee_RefID=@Employee_RefID,
	Profession_RefID=@Profession_RefID,
	ProfessionObtainedAtDate=@ProfessionObtainedAtDate,
	IsPrimary=@IsPrimary,
	ProfessionGrantedByAuthority=@ProfessionGrantedByAuthority,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID