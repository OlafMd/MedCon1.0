INSERT INTO 
	cmn_pps_shifttemplate_groups
	(
		CMN_PPS_ShiftTemplate_GroupID,
		GroupShortName,
		GroupName_DictID,
		CMN_STR_Office_RefID,
		CMN_STR_Workarea_RefID,
		CMN_STR_Workplace_RefID,
		IsDefault_ForMonday,
		IsDefault_ForTuesday,
		IsDefault_ForWednesday,
		IsDefault_ForThursday,
		IsDefault_ForFriday,
		IsDefault_ForSaturday,
		IsDefault_ForSunday,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_PPS_ShiftTemplate_GroupID,
		@GroupShortName,
		@GroupName,
		@CMN_STR_Office_RefID,
		@CMN_STR_Workarea_RefID,
		@CMN_STR_Workplace_RefID,
		@IsDefault_ForMonday,
		@IsDefault_ForTuesday,
		@IsDefault_ForWednesday,
		@IsDefault_ForThursday,
		@IsDefault_ForFriday,
		@IsDefault_ForSaturday,
		@IsDefault_ForSunday,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)