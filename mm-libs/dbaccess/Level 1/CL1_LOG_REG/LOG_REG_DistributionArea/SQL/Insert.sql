INSERT INTO 
	log_reg_distributionareas
	(
		LOG_REG_DistributionAreaID,
		DistributionArea_Name_DictID,
		DistributionArea_Description_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@LOG_REG_DistributionAreaID,
		@DistributionArea_Name,
		@DistributionArea_Description,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)