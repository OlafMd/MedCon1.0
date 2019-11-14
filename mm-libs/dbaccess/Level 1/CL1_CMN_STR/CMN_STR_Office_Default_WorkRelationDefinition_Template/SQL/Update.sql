UPDATE 
	cmn_str_office_default_workrelationdefinition_template
SET 
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	CMN_BPT_EMP_Employee_WorkRelationDefinition_Template_RefID=@CMN_BPT_EMP_Employee_WorkRelationDefinition_Template_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID