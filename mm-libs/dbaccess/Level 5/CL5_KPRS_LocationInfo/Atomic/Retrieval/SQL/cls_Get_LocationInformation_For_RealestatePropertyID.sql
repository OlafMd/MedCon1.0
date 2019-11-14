
	Select
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_PostalCode,
  cmn_addresses.City_Name,
  cmn_addresses.City_AdministrativeDistrict,
  cmn_addresses.Province_Name,
  res_loc_regioninformation.RegionInformation_RegionArea_in_sqkm,
  res_loc_regioninformation.RegionInformation_TotalPopulation,
  res_loc_regioninformation.RegionInformation_Population_per_sqkm,
  res_loc_regioninformation.RegionInformation_RegionUnemploymentRatePercent,
  res_loc_regioninformation.RegionInformation_NumberOfHouseholds_Current,
  res_loc_regioninformation.RegionInformation_NumberOfHouseholds_Forecast,
  res_loc_regioninformation.RegionInformation_PurchasingPowerAmount_Current_RefID,
  res_loc_regioninformation.RegionInformation_PurchasingPowerAmount_Forecast_RefID,
  res_loc_regioninformation.RegionInformation_ResidentialRent_MinPrice_RefID,
  res_loc_regioninformation.RegionInformation_ResidentialRent_AveragePrice_RefID,
  res_loc_regioninformation.RegionInformation_ResidentialRent_MaxPrice_RefID,
  res_loc_regioninformation.RegionInformation_NonResidentialRent_MinPrice_RefID,
  res_loc_regioninformation.RegionInformation_NonResidentialRent_AveragePrice_RefID,
  res_loc_regioninformation.RegionInformation_NonResidentialRent_MaxPrice_RefID,
  cmn_addresses.City_Region,
  cmn_addresses.CMN_AddressID,
  cmn_loc_regions.CMN_LOC_RegionID,
  res_loc_locationinformation.RES_LOC_LocationInformationID,
  cmn_loc_location.CMN_LOC_LocationID,
  cmn_loc_regions.Country_RefID
From
  res_realestateproperties Inner Join
  cmn_loc_location On cmn_loc_location.CMN_LOC_LocationID =
    res_realestateproperties.RealestateProperty_Location_RefID Inner Join
  cmn_addresses On cmn_addresses.CMN_AddressID = cmn_loc_location.Address_RefID
  Inner Join
  cmn_loc_regions On cmn_loc_regions.CMN_LOC_RegionID =
    cmn_loc_location.Region_RefID Inner Join
  res_loc_regioninformation On cmn_loc_regions.CMN_LOC_RegionID =
    res_loc_regioninformation.CMN_LOC_Region_RefID Inner Join
  res_loc_locationinformation On cmn_loc_location.CMN_LOC_LocationID =
    res_loc_locationinformation.CMN_LOC_Location_RefID Inner Join
  res_loc_locationinformation_2_emmission
    On res_loc_locationinformation.RES_LOC_LocationInformationID =
    res_loc_locationinformation_2_emmission.RES_LOC_LocationInformation_RefID
  Inner Join
  res_loc_locationinformation_2_meansoftransportation
    On res_loc_locationinformation.RES_LOC_LocationInformationID =
    res_loc_locationinformation_2_meansoftransportation.RES_LOC_LocationInformation_RefID Inner Join
  res_loc_locationinformation_2_neighborhoodquality
    On res_loc_locationinformation.RES_LOC_LocationInformationID =
    res_loc_locationinformation_2_neighborhoodquality.RES_LOC_LocationInformation_RefID Inner Join
  res_loc_locationinformation_2_surroundinginfrastructure
    On res_loc_locationinformation.RES_LOC_LocationInformationID =
    res_loc_locationinformation_2_surroundinginfrastructure.RES_LOC_LocationInformation_RefID
Where
  res_realestateproperties.IsDeleted = 0 And
  cmn_loc_location.IsDeleted = 0 And
  cmn_addresses.IsDeleted = 0 And
  cmn_loc_regions.IsDeleted = 0 And
  res_loc_locationinformation.IsDeleted = 0 And
  res_loc_regioninformation.IsDeleted = 0 And
  res_loc_locationinformation_2_surroundinginfrastructure.IsDeleted = 0 And
  res_loc_locationinformation_2_neighborhoodquality.IsDeleted = 0 And
  res_loc_locationinformation_2_meansoftransportation.IsDeleted = 0 And
  res_loc_locationinformation_2_emmission.IsDeleted = 0 And
  res_realestateproperties.RES_RealestatePropertyID = @RealestatePropertyID And
  res_realestateproperties.Tenant_RefID = @TenantID
  