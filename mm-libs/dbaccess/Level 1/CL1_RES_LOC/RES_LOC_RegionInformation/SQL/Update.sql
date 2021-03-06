UPDATE 
	res_loc_regioninformation
SET 
	CMN_LOC_Region_RefID=@CMN_LOC_Region_RefID,
	RegionInformation_RegionArea_in_sqkm=@RegionInformation_RegionArea_in_sqkm,
	RegionInformation_TotalPopulation=@RegionInformation_TotalPopulation,
	RegionInformation_Population_per_sqkm=@RegionInformation_Population_per_sqkm,
	RegionInformation_RegionUnemploymentRatePercent=@RegionInformation_RegionUnemploymentRatePercent,
	RegionInformation_NumberOfHouseholds_Current=@RegionInformation_NumberOfHouseholds_Current,
	RegionInformation_NumberOfHouseholds_Forecast=@RegionInformation_NumberOfHouseholds_Forecast,
	RegionInformation_PurchasingPowerAmount_Current_RefID=@RegionInformation_PurchasingPowerAmount_Current_RefID,
	RegionInformation_PurchasingPowerAmount_Forecast_RefID=@RegionInformation_PurchasingPowerAmount_Forecast_RefID,
	RegionInformation_ResidentialRent_MinPrice_RefID=@RegionInformation_ResidentialRent_MinPrice_RefID,
	RegionInformation_ResidentialRent_AveragePrice_RefID=@RegionInformation_ResidentialRent_AveragePrice_RefID,
	RegionInformation_ResidentialRent_MaxPrice_RefID=@RegionInformation_ResidentialRent_MaxPrice_RefID,
	RegionInformation_NonResidentialRent_MinPrice_RefID=@RegionInformation_NonResidentialRent_MinPrice_RefID,
	RegionInformation_NonResidentialRent_AveragePrice_RefID=@RegionInformation_NonResidentialRent_AveragePrice_RefID,
	RegionInformation_NonResidentialRent_MaxPrice_RefID=@RegionInformation_NonResidentialRent_MaxPrice_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	RES_LOC_RegionInformationID = @RES_LOC_RegionInformationID