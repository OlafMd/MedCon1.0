INSERT INTO 
	cmn_str_pps_workarea_responsiblepersons
	(
		CMN_STR_PPS_WorkArea_ResponsiblePersonID,
		WorkArea_RefID,
		CMN_BPT_EMP_Employee_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_STR_PPS_WorkArea_ResponsiblePersonID,
		@WorkArea_RefID,
		@CMN_BPT_EMP_Employee_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)