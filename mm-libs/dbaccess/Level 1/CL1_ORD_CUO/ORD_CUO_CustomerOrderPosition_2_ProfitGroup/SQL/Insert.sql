INSERT INTO 
	ord_cuo_customerorderposition_2_profitgroup
	(
		AssignmentID,
		CMN_CUO_CustomerOrder_Position_RefID,
		CMN_ORD_PRCfitGroup_RefID,
		AttributablePercentageShare,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@CMN_CUO_CustomerOrder_Position_RefID,
		@CMN_ORD_PRCfitGroup_RefID,
		@AttributablePercentageShare,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)