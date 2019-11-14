INSERT INTO 
	cmn_pro_ass_distributionprices
	(
		CMN_PRO_ASS_DistributionPriceID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_PRO_ASS_DistributionPriceID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)