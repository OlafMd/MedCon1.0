INSERT INTO 
	cmn_pps_shifttemplate_workplaceassignments
	(
		CMN_PPS_ShiftTemplate_WorkplaceAssignmentID,
		CMN_STR_PPS_Workplace_RefID,
		CMN_PPS_ShiftTemplate_RefID,
		ShiftStart_Offset_sec,
		Required_StaffHeadCount,
		Shift_Assignment_Duration_sec,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_PPS_ShiftTemplate_WorkplaceAssignmentID,
		@CMN_STR_PPS_Workplace_RefID,
		@CMN_PPS_ShiftTemplate_RefID,
		@ShiftStart_Offset_sec,
		@Required_StaffHeadCount,
		@Shift_Assignment_Duration_sec,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)