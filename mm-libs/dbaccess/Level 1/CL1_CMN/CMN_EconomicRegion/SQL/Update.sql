UPDATE 
	CMN_EconomicRegion
SET 
	ParentEconomicRegion_RefID=@ParentEconomicRegion_RefID,
	EconomicRegion_Name_DictID=@EconomicRegion_Name,
	EconomicRegion_Description_DictID=@EconomicRegion_Description,
	IsEconomicRegionCountry=@IsEconomicRegionCountry,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_EconomicRegionID = @CMN_EconomicRegionID