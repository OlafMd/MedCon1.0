
		SELECT CMN_EconomicRegionID
			,ParentEconomicRegion_RefID
			,EconomicRegion_Name_DictID
			,EconomicRegion_Description_DictID
			,IsEconomicRegionCountry
			,Creation_Timestamp
			,IsDeleted
			,Tenant_RefID
			,Modification_Timestamp
		FROM cmn_economicregion
		WHERE Tenant_RefID = @TenantID
			AND IsDeleted = 0

  