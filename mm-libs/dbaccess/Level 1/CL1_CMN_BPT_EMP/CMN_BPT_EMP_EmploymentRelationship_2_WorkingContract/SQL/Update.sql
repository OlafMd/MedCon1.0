UPDATE 
	cmn_bpt_emp_employmentrelationship_2_workingcontract
SET 
	EmploymentRelationship_RefID=@EmploymentRelationship_RefID,
	WorkingContract_RefID=@WorkingContract_RefID,
	IsContract_Active=@IsContract_Active,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID