UPDATE 
	tms_pro_project_2_projectmembertargetworkload
SET 
	TMS_PRO_Project_RefID=@TMS_PRO_Project_RefID,
	TMS_PRO_ProjectMember_TargetWorkload_RefID=@TMS_PRO_ProjectMember_TargetWorkload_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID