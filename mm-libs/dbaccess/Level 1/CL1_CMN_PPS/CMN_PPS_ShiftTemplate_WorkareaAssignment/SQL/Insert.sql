INSERT INTO 
	cmn_pps_shifttemplate_workareaassignments
	(
		CMN_PPS_ShiftTemplate_WorkareaAssignmentID,
		CMN_PPS_ShiftTemplate_RefID,
		CMN_BPT_PPS_WorkArea_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_PPS_ShiftTemplate_WorkareaAssignmentID,
		@CMN_PPS_ShiftTemplate_RefID,
		@CMN_BPT_PPS_WorkArea_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)