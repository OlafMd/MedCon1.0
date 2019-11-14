UPDATE 
	log_reg_distributionarea_2_country
SET 
	LOG_REG_DistributionArea_RefID=@LOG_REG_DistributionArea_RefID,
	CMN_Country_RefID=@CMN_Country_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID