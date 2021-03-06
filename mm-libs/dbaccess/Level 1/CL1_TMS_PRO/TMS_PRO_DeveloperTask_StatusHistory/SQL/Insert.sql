INSERT INTO 
	tms_pro_developertask_statushistory
	(
		TMS_PRO_DeveloperTask_StatusHistoryID,
		DeveloperTask_RefID,
		DeveloperTask_Status_RefID,
		CreatedFor_ProjectMember_RefID,
		TriggeredBy_ProjectMember_RefID,
		Comment,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@TMS_PRO_DeveloperTask_StatusHistoryID,
		@DeveloperTask_RefID,
		@DeveloperTask_Status_RefID,
		@CreatedFor_ProjectMember_RefID,
		@TriggeredBy_ProjectMember_RefID,
		@Comment,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)