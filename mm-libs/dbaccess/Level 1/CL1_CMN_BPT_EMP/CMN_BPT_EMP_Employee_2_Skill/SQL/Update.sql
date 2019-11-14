UPDATE 
	cmn_bpt_emp_employee_2_skill
SET 
	Employee_RefID=@Employee_RefID,
	Skill_RefID=@Skill_RefID,
	QualificationObtainedAtDate=@QualificationObtainedAtDate,
	QualificationGrantedByAuthority=@QualificationGrantedByAuthority,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID