INSERT INTO 
	cmn_str_pps_workarea_2_costcenter
	(
		AssignmentID,
		CostCenter_RefID,
		WorkArea_RefID,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@CostCenter_RefID,
		@WorkArea_RefID,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)