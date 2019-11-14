UPDATE 
	tms_pro_businesstasks
SET 
	IdentificationNumber=@IdentificationNumber,
	DOC_Structure_Header_RefID=@DOC_Structure_Header_RefID,
	BusinessTasksPackage_RefID=@BusinessTasksPackage_RefID,
	Project_RefID=@Project_RefID,
	Estimated_StartDate=@Estimated_StartDate,
	Estimated_EndDate=@Estimated_EndDate,
	Task_Name_DictID=@Task_Name,
	Task_Description_DictID=@Task_Description,
	Task_Type_RefID=@Task_Type_RefID,
	Task_Status_RefID=@Task_Status_RefID,
	Task_Deadline=@Task_Deadline,
	IsArchived=@IsArchived,
	CreatedByAccount_RefID=@CreatedByAccount_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_BusinessTaskID = @TMS_PRO_BusinessTaskID