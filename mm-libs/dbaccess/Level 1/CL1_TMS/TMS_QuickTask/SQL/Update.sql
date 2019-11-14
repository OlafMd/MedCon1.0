UPDATE 
	tms_quicktasks
SET 
	IdentificationNumber=@IdentificationNumber,
	IsManuallyEntered=@IsManuallyEntered,
	QuickTask_Title_DictID=@QuickTask_Title,
	QuickTask_Description_DictID=@QuickTask_Description,
	QuickTask_Type_RefID=@QuickTask_Type_RefID,
	R_QuickTask_InvestedTime_min=@R_QuickTask_InvestedTime_min,
	QuickTask_CreatedByAccount_RefID=@QuickTask_CreatedByAccount_RefID,
	QuickTask_DocumentStructureHeader_RefID=@QuickTask_DocumentStructureHeader_RefID,
	QuickTask_StartTime=@QuickTask_StartTime,
	AssignedTo_Project_RefID=@AssignedTo_Project_RefID,
	AssignedTo_BusinessTask_RefID=@AssignedTo_BusinessTask_RefID,
	AssignedTo_Feature_RefID=@AssignedTo_Feature_RefID,
	AssignedTo_DeveloperTask_RefID=@AssignedTo_DeveloperTask_RefID,
	Tenant_RefID=@Tenant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted
WHERE 
	TMS_QuickTaskID = @TMS_QuickTaskID