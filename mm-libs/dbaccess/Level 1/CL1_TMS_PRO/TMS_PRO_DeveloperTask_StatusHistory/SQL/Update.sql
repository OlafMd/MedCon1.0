UPDATE 
	tms_pro_developertask_statushistory
SET 
	DeveloperTask_RefID=@DeveloperTask_RefID,
	DeveloperTask_Status_RefID=@DeveloperTask_Status_RefID,
	CreatedFor_ProjectMember_RefID=@CreatedFor_ProjectMember_RefID,
	TriggeredBy_ProjectMember_RefID=@TriggeredBy_ProjectMember_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_DeveloperTask_StatusHistoryID = @TMS_PRO_DeveloperTask_StatusHistoryID