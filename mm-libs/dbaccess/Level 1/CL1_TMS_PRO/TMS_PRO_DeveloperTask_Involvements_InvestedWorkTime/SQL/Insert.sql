INSERT INTO 
	tms_pro_developertask_involvements_investedworktime
	(
		AssignmentID,
		TMS_PRO_DeveloperTask_Involvement_RefID,
		CMN_BPT_InvestedWorkTime_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@TMS_PRO_DeveloperTask_Involvement_RefID,
		@CMN_BPT_InvestedWorkTime_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)