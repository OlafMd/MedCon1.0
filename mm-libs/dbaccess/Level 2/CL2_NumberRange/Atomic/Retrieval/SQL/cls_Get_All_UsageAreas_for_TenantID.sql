
	Select
	  cmn_numberrange_usageareas.CMN_NumberRange_UsageAreaID,
	  cmn_numberrange_usageareas.GlobalStaticMatchingID,
	  cmn_numberrange_usageareas.UsageArea_Name_DictID,
	  cmn_numberrange_usageareas.UsageArea_Description_DictID,
	  cmn_numberrange_usageareas.Creation_Timestamp,
	  cmn_numberrange_usageareas.Tenant_RefID
	From
	  cmn_numberrange_usageareas
	Where
	  cmn_numberrange_usageareas.IsDeleted = 0 And
	  cmn_numberrange_usageareas.Tenant_RefID = @TenantID
  