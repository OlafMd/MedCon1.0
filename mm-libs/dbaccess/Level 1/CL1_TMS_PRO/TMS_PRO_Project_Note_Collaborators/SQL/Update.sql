UPDATE 
	tms_pro_project_note_collaborators
SET 
	ProjectNote_RefID=@ProjectNote_RefID,
	Account_RefID=@Account_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMS_PRO_Project_Note_CollaboratorID = @TMS_PRO_Project_Note_CollaboratorID