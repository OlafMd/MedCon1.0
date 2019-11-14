UPDATE 
	cmn_bpt_emp_employmentrelationships
SET 
	IsLockedFor_TemplateUpdates=@IsLockedFor_TemplateUpdates,
	Employee_RefID=@Employee_RefID,
	Work_StartDate=@Work_StartDate,
	Work_EndDate=@Work_EndDate,
	HasWorkRelationEnded=@HasWorkRelationEnded,
	InstanceOf_EmploymentRelationships_Template_RefID=@InstanceOf_EmploymentRelationships_Template_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_EMP_EmploymentRelationshipID = @CMN_BPT_EMP_EmploymentRelationshipID