INSERT INTO 
	hec_act_usedproduct_2_producttrackinginstance
	(
		AssignmentID,
		HEC_ACT_UsedProduct_RefID,
		LOG_ProductTrackingInstance_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@AssignmentID,
		@HEC_ACT_UsedProduct_RefID,
		@LOG_ProductTrackingInstance_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)