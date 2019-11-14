
	Select
	  cmn_units.CMN_UnitID,
	  cmn_units.Label_DictID,
	  cmn_units.Abbreviation_DictID,
	  cmn_units.ISOCode
	From
	  cmn_units
	Where
	  cmn_units.IsDeleted = 0 And
	  cmn_units.Tenant_RefID = @TenantID
  