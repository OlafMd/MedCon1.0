UPDATE 
	hec_bil_potentialcodes
SET 
	PotentialCode_Catalog_RefID=@PotentialCode_Catalog_RefID,
	CodeName_DictID=@CodeName,
	CodeLabel=@CodeLabel,
	BillingCode=@BillingCode,
	PointValue=@PointValue,
	Price_RefID=@Price_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_BIL_PotentialCodeID = @HEC_BIL_PotentialCodeID