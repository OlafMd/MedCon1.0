UPDATE 
	cmn_pro_ass_distributionprices
SET 
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_ASS_DistributionPriceID = @CMN_PRO_ASS_DistributionPriceID