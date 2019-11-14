
Select
  cmn_com_companyinfo_addresses.IsBilling,
  cmn_com_companyinfo_addresses.IsShipping,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Country_639_1_ISOCode,
  cmn_com_companyinfo_addresses.IsDefault,
  cmn_com_companyinfo_addresses.IsContact,
  cmn_universalcontactdetails.CMN_UniversalContactDetailID,
  cmn_universalcontactdetails.Country_Name,
  cmn_com_companyinfo_addresses.CMN_COM_CompanyInfo_AddressID,
  cmn_com_companyinfo_addresses.Address_Description
From
  cmn_com_companyinfo_addresses Inner Join
  cmn_universalcontactdetails On cmn_com_companyinfo_addresses.Address_UCD_RefID
    = cmn_universalcontactdetails.CMN_UniversalContactDetailID
Where
  cmn_com_companyinfo_addresses.CompanyInfo_RefID = @CompanyInfoID And
  cmn_com_companyinfo_addresses.IsDeleted = 0 And
  cmn_universalcontactdetails.IsDeleted = 0 And
  cmn_universalcontactdetails.Tenant_RefID = @TenantID
  