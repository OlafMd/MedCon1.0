INSERT INTO 
	cmn_str_pps_workplace_activities
	(
		CMN_STR_PPS_Workplace_ActivityID,
		WorkplaceActivity_Name_DictID,
		WorkplaceActivity_Description_DicID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_PPS_Workplace_ActivityID,
		@WorkplaceActivity_Name,
		@WorkplaceActivity_Description_DicID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)