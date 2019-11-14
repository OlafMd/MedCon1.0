
	SELECT CMN_AddressID,
	       Street_Name,
	       Street_Number,
	       City_AdministrativeDistrict,
	       City_Region,
	       City_Name,
	       City_PostalCode,
	       Province_Name,
	       Country_Name,
	       Country_ISOCode,
	       Creation_Timestamp,
	       IsDeleted,
	       Tenant_RefID,
	       Province_EconomicRegion_RefID
	  FROM cmn_addresses
	  Where Tenant_RefID = Tenant_RefID AND CMN_AddressID = IfNull(@AddressID, CMN_AddressID) and IsDeleted = 0
  