INSERT INTO 
	cmn_pro_product_release_2_developertask
	(
		AssignmentID,
		CMN_PRO_Product_Release_RefID,
		TMS_PRO_DeveloperTask_RefID,
		IsDeleted,
		Creation_Timestamp,
		Tenant_RefID
	)
VALUES 
	(
		@AssignmentID,
		@CMN_PRO_Product_Release_RefID,
		@TMS_PRO_DeveloperTask_RefID,
		@IsDeleted,
		@Creation_Timestamp,
		@Tenant_RefID
	)