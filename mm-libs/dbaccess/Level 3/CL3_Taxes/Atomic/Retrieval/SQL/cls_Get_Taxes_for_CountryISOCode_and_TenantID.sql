
	Select
  acc_tax_taxes.ACC_TAX_TaxeID,
  acc_tax_taxes.TaxName_DictID,
  acc_tax_taxes.TaxRate,
  cmn_countries.CMN_CountryID,
  cmn_countries.Country_Name_DictID,
  cmn_economicregion.CMN_EconomicRegionID
From
  acc_tax_taxes Inner Join
  cmn_economicregion On acc_tax_taxes.EconomicRegion_RefID =
    cmn_economicregion.CMN_EconomicRegionID And cmn_economicregion.IsDeleted = 0
  Inner Join
  cmn_country_2_economicregion On cmn_economicregion.CMN_EconomicRegionID =
    cmn_country_2_economicregion.CMN_EconomicRegion_RefID And
    cmn_country_2_economicregion.IsDeleted = 0 Inner Join
  cmn_countries On cmn_country_2_economicregion.CMN_Country_RefID =
    cmn_countries.CMN_CountryID And cmn_countries.IsDeleted = 0
Where
  ((acc_tax_taxes.ACC_TAX_TaxeID Is Not Null And
      acc_tax_taxes.Tenant_RefID = @TenantID And
      acc_tax_taxes.IsDeleted = 0) Or
    acc_tax_taxes.ACC_TAX_TaxeID Is Null) And
  cmn_countries.IsDeleted = 0 And
  cmn_countries.Tenant_RefID = @TenantID And
  Upper(cmn_countries.Country_ISOCode_Alpha2) = Upper(@CountryISOCode)
  