UPDATE 
	cmn_per_religion_2_economicregion
SET 
	CMN_PER_Religion_RefID=@CMN_PER_Religion_RefID,
	CMN_EconomicRegion_RefID=@CMN_EconomicRegion_RefID,
	Religion_Code=@Religion_Code,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID