
SELECT
  cmn_com_companyinfo_addresses.CMN_COM_CompanyInfo_AddressID,
  cmn_com_companyinfo_addresses.CompanyInfo_RefID,
  cmn_com_companyinfo_addresses.IsBilling,
  cmn_com_companyinfo_addresses.IsShipping,
  cmn_com_companyinfo_addresses.IsDefault,
  cmn_com_companyinfo_addresses.IsDeleted,
  cmn_universalcontactdetails.CareOf,
  cmn_universalcontactdetails.Street_Name,
  cmn_universalcontactdetails.Street_Number,
  cmn_universalcontactdetails.ZIP,
  cmn_universalcontactdetails.Town,
  cmn_universalcontactdetails.Country_639_1_ISOCode
FROM
  cmn_com_companyinfo_addresses
  LEFT JOIN cmn_universalcontactdetails
    ON cmn_com_companyinfo_addresses.Address_UCD_RefID = cmn_universalcontactdetails.CMN_UniversalContactDetailID AND
       cmn_universalcontactdetails.IsDeleted = 0
WHERE
  cmn_com_companyinfo_addresses.IsDeleted = 0 AND
  cmn_com_companyinfo_addresses.CompanyInfo_RefID = @CompanyInfoID AND
  cmn_com_companyinfo_addresses.IsDefault = IFNULL(@IsDefaultAddress,cmn_com_companyinfo_addresses.IsDefault)
  