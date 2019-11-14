
      SELECT cmn_currencies.CMN_CurrencyID
      FROM cmn_tenants
      INNER JOIN cmn_universalcontactdetails ON (cmn_universalcontactdetails.CMN_UniversalContactDetailID = cmn_tenants.UniversalContactDetail_RefID)
      INNER JOIN cmn_countries ON (cmn_universalcontactdetails.Country_639_1_ISOCode = cmn_countries.Country_ISOCode_Alpha2)
	      AND cmn_countries.Tenant_RefID = @TenantID
	      AND cmn_countries.IsDeleted = 0
      INNER JOIN cmn_currencies ON (cmn_countries.Default_Currency_RefID = cmn_currencies.CMN_CurrencyID)
	      AND cmn_currencies.IsDeleted = 0
	      AND cmn_currencies.Tenant_RefID = @TenantID
      WHERE cmn_tenants.CMN_TenantID = @TenantID
	      AND cmn_tenants.IsDeleted = 0
  