UPDATE 
	tms_pro_project_notes
SET 
	Ext_CMN_Note_RefID=@Ext_CMN_Note_RefID,
	Project_RefID=@Project_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	TMS_PRO_Project_NoteID = @TMS_PRO_Project_NoteID