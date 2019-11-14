
Select
  cmn_addresses.Country_ISOCode,
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.CMN_AddressID,
  cmn_per_personinfo_2_address.IsAddress_Contact,
  cmn_per_personinfo_2_address.IsAddress_Billing,
  cmn_per_personinfo_2_address.IsAddress_Shipping,
  cmn_per_personinfo_2_address.AddressLabel,
  cmn_per_personinfo_2_address.AssignmentID,
  cmn_per_personinfo_2_address.IsPrimary,
  cmn_addresses.Country_Name
From
  cmn_addresses Inner Join
  cmn_per_personinfo_2_address On cmn_addresses.CMN_AddressID =
    cmn_per_personinfo_2_address.CMN_Address_RefID
Where
  cmn_per_personinfo_2_address.CMN_PER_PersonInfo_RefID = @PersonInfoID And
  cmn_per_personinfo_2_address.IsDeleted = 0 And
  cmn_addresses.IsDeleted = 0 And
  cmn_addresses.Tenant_RefID = @TenantID
  