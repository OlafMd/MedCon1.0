UPDATE 
	CMN_Country_2_EconomicRegion
SET 
	CMN_Country_RefID=@CMN_Country_RefID,
	CMN_EconomicRegion_RefID=@CMN_EconomicRegion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID