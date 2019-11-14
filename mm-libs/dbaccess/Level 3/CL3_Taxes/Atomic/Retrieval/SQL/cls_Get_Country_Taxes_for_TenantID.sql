
  select
	acc_tax_taxes.ACC_TAX_TaxeID,
	acc_tax_taxes.EconomicRegion_RefID,
	acc_tax_taxes.TaxName_DictID,
	acc_tax_taxes.TaxRate,
	acc_tax_taxes.IsDeleted,
	acc_tax_taxes.Tenant_RefID,
	cmn_economicregion.EconomicRegion_Name_DictID,
	cmn_economicregion.EconomicRegion_Description_DictID,
	cmn_economicregion.IsEconomicRegionCountry,
  cmn_countries.CMN_CountryID,
  cmn_countries.Country_Name_DictID
  from cmn_countries
  left join cmn_country_2_economicregion on cmn_countries.CMN_CountryID = cmn_country_2_economicregion.CMN_Country_RefID 
            and cmn_country_2_economicregion.IsDeleted = 0
  left join cmn_economicregion on cmn_country_2_economicregion.CMN_EconomicRegion_RefID = cmn_economicregion.CMN_EconomicRegionID
            and cmn_economicregion.IsDeleted = 0
 left join acc_tax_taxes on acc_tax_taxes.EconomicRegion_RefID = cmn_economicregion.CMN_EconomicRegionID
            and acc_tax_taxes.IsDeleted = 0
  where cmn_countries.IsDeleted = 0
        and cmn_countries.Tenant_RefID = @TenantID
  