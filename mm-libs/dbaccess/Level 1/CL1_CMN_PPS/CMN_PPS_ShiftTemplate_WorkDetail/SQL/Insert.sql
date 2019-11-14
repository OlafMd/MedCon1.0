INSERT INTO 
	cmn_pps_shifttemplate_workdetails
	(
		CMN_PPS_ShiftTemplate_WorkDetailID,
		CMN_PPS_ShiftTemplate_RefID,
		ShiftStart_Offset_sec,
		Duration_in_sec,
		WorkDetail_Note_Title,
		WorkDetail_Note_Content,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@CMN_PPS_ShiftTemplate_WorkDetailID,
		@CMN_PPS_ShiftTemplate_RefID,
		@ShiftStart_Offset_sec,
		@Duration_in_sec,
		@WorkDetail_Note_Title,
		@WorkDetail_Note_Content,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)