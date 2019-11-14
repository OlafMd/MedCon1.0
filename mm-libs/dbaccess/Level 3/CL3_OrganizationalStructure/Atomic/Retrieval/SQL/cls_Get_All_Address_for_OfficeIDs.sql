
Select
  cmn_addresses.Street_Name,
  cmn_addresses.Street_Number,
  cmn_str_office_addresses.IsShippingAddress,
  cmn_str_office_addresses.IsBillingAddress,
  cmn_str_office_addresses.IsSpecialAddress,
  cmn_str_office_addresses.IfSpecialAddress_Name,
  cmn_addresses.City_Name,
  cmn_addresses.City_PostalCode,
  cmn_addresses.Country_Name,
  cmn_str_offices.CMN_STR_OfficeID,
  cmn_addresses.CMN_AddressID,
  cmn_addresses.CareOf,
  cmn_addresses.Country_ISOCode,
  cmn_str_office_addresses.IsDefault
From
  cmn_addresses Inner Join
  cmn_str_office_addresses On cmn_addresses.CMN_AddressID =
    cmn_str_office_addresses.CMN_Address_RefID And
    cmn_str_office_addresses.Tenant_RefID = @TenantID And
    cmn_str_office_addresses.IsDeleted = 0 Inner Join
  cmn_str_offices On cmn_str_offices.CMN_STR_OfficeID =
  cmn_str_office_addresses.Office_RefID And cmn_str_offices.CMN_STR_OfficeID = @OfficeIDs And cmn_str_offices.Tenant_RefID = @TenantID And
    cmn_str_offices.IsDeleted = 0
Where
  cmn_addresses.IsDeleted = 0 And
  cmn_addresses.Tenant_RefID = @TenantID

  