UPDATE 
	tms_pro_project_2_projectgroup
SET 
	TMS_PRO_Project_Group_RefID=@TMS_PRO_Project_Group_RefID,
	TMS_PRO_Project_RefID=@TMS_PRO_Project_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID