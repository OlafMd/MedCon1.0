
	Select
        cmn_numberrange_usageareas.CMN_NumberRange_UsageAreaID,
        cmn_numberrange_usageareas.UsageArea_Name_DictID,
        cmn_numberrange_usageareas.IsDeleted,
        cmn_numberrange_usageareas.Tenant_RefID
    From
        cmn_numberrange_usageareas
	Where cmn_numberrange_usageareas.Tenant_RefID = @TenantID And cmn_numberrange_usageareas.IsDeleted = 0
  