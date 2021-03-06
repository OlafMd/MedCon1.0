INSERT INTO 
	hec_bil_potentialcodes
	(
		HEC_BIL_PotentialCodeID,
		PotentialCode_Catalog_RefID,
		CodeName_DictID,
		CodeLabel,
		BillingCode,
		PointValue,
		Price_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_BIL_PotentialCodeID,
		@PotentialCode_Catalog_RefID,
		@CodeName,
		@CodeLabel,
		@BillingCode,
		@PointValue,
		@Price_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)