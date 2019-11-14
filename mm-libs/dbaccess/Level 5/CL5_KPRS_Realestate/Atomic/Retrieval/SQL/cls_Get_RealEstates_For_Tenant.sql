
	Select
  res_realestateproperties.RES_RealestatePropertyID,
  res_realestateproperties.InformationSubmittedBy_Account_RefID,
  res_realestateproperties.RealestateProperty_Address_RefID,
  res_realestateproperties.RealestateProperty_Location_RefID,
  res_realestateproperties.RealestateProperty_GroundValuePrice_RefID,
  res_realestateproperties.RealestateProperty_AverageAreaRentPrice_RefID,
  res_realestateproperties.Geolocation_Lattitude,
  res_realestateproperties.Geolocation_Longitude,
  res_realestateproperties.RealestateProperty_Title,
  res_realestateproperties.RealestateProperty_InternalID,
  res_realestateproperties.RealestateProperty_ConstructionDate,
  res_realestateproperties.RealestateProperty_RefurbishmentDate,
  res_realestateproperties.RealestateProperty_LivingSpace_in_sqm,
  res_realestateproperties.RealestateProperty_InformationDate,
  res_realestateproperties.RealestateProperty_NumberOfResidentialUnits,
  usr_accounts.Username,
  cmn_per_personinfo.FirstName,
  cmn_per_personinfo.LastName,
  cmn_per_personinfo.CMN_PER_PersonInfoID,
  res_realestateproperties.Creation_Timestamp,
  res_realestateproperties.IsLocked,
  res_realestateproperties.IsArchived
From
  res_realestateproperties Inner Join
  usr_accounts
    On usr_accounts.USR_AccountID =
    res_realestateproperties.InformationSubmittedBy_Account_RefID Inner Join
  cmn_per_personinfo_2_account On cmn_per_personinfo_2_account.USR_Account_RefID
    = usr_accounts.USR_AccountID Inner Join
  cmn_per_personinfo On cmn_per_personinfo.CMN_PER_PersonInfoID =
    cmn_per_personinfo_2_account.CMN_PER_PersonInfo_RefID
Where
  res_realestateproperties.IsDeleted = 0 And
  res_realestateproperties.Tenant_RefID = @TenantID
  