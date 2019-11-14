INSERT INTO 
	cmn_str_pps_workdetail_activities
	(
		CMN_STR_PPS_WorkDetail_ActivityID,
		CMN_PPS_ShiftTemplate_WorkDetail_RefID,
		CMN_STR_PPS_Workplace_RefID,
		CMN_STR_PPS_Activity_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_STR_PPS_WorkDetail_ActivityID,
		@CMN_PPS_ShiftTemplate_WorkDetail_RefID,
		@CMN_STR_PPS_Workplace_RefID,
		@CMN_STR_PPS_Activity_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)