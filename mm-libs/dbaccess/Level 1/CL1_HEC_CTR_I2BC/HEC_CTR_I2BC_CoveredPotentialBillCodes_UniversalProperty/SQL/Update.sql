UPDATE 
	hec_ctr_i2bc_coveredpotentialbillcodes_universalproperties
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	PropertyName=@PropertyName,
	IsValue_String=@IsValue_String,
	IsValue_Number=@IsValue_Number,
	IsValue_Boolean=@IsValue_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID = @HEC_CTR_I2BC_CoveredPotentialBillCodes_UniversalPropertyID