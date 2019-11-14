UPDATE 
	hec_ctr_i2bc_coveredpotentialbillcodes_2_universalproperty
SET 
	CoveredPotentialBillCode_RefID=@CoveredPotentialBillCode_RefID,
	CoveredPotentialBillCode_UniversalProperty_RefID=@CoveredPotentialBillCode_UniversalProperty_RefID,
	Value_String=@Value_String,
	Value_Number=@Value_Number,
	Value_Boolean=@Value_Boolean,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID