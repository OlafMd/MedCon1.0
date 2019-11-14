UPDATE 
	log_reg_distributionareas
SET 
	DistributionArea_Name_DictID=@DistributionArea_Name,
	DistributionArea_Description_DictID=@DistributionArea_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	LOG_REG_DistributionAreaID = @LOG_REG_DistributionAreaID