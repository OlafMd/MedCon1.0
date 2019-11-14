UPDATE 
	tms_pro_project_status
SET 
	Label_DictID=@Label,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_Project_StatusID = @TMS_PRO_Project_StatusID