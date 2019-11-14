Select
  usr_accounts.Username,
  usr_accounts.USR_AccountID,
  res_realestateproperties.RealestateProperty_Title,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_AdministrativeDistrict,
  cmn_addresses.City_Region,
  cmn_addresses.City_Name,
  cmn_addresses.Province_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Country_Name,
  cmn_addresses.Country_ISOCode,
  res_bld_buildings.Building_Name,
  res_realestateproperties.RES_RealestatePropertyID,
  res_realestateproperties.Creation_Timestamp,
  res_bld_buildings.RES_BLD_BuildingID,
  res_bld_buildings.Building_BalconyPortionPercent,
  res_realestateproperties.Geolocation_Lattitude,
  res_realestateproperties.Geolocation_Longitude
From
  cmn_addresses Inner Join
  cmn_loc_location On cmn_loc_location.Address_RefID =
    cmn_addresses.CMN_AddressID Right Join
  res_realestateproperties
    On res_realestateproperties.RealestateProperty_Location_RefID =
    cmn_loc_location.CMN_LOC_LocationID Left Join
  usr_accounts On res_realestateproperties.InformationSubmittedBy_Account_RefID
    = usr_accounts.USR_AccountID Right Join
  res_bld_building_revisionheaders
    On res_bld_building_revisionheaders.RealestateProperty_RefID =
    res_realestateproperties.RES_RealestatePropertyID Right Join
  res_bld_buildings
    On res_bld_building_revisionheaders.CurrentBuildingVersion_RefID =
    res_bld_buildings.RES_BLD_BuildingID
Where
  res_realestateproperties.IsDeleted = 0 And
res_bld_building_revisionheaders.IsDeleted = 0 And
res_bld_buildings.IsDeleted = 0 And
res_realestateproperties.Tenant_RefID = @TenantID
And  usr_accounts.Username  LIKE @UploaderUserName COLLATE UTF8_GENERAL_CI  
  And  res_realestateproperties.RealestateProperty_Title LIKE @Title COLLATE UTF8_GENERAL_CI  
And cmn_addresses.Street_Name  LIKE @StreetName    COLLATE UTF8_GENERAL_CI  
  And  cmn_addresses.Street_Number LIKE @StreetNumber COLLATE UTF8_GENERAL_CI  
  And  cmn_addresses.City_Name LIKE @City COLLATE UTF8_GENERAL_CI  
 And  cmn_addresses.Province_Name LIKE @Province COLLATE UTF8_GENERAL_CI  
 And cmn_addresses.City_Region LIKE @Region  COLLATE UTF8_GENERAL_CI  
 And  cmn_addresses.City_PostalCode LIKE @ZipCode COLLATE UTF8_GENERAL_CI  