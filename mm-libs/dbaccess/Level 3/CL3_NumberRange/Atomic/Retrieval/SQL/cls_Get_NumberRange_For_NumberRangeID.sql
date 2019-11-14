
	Select
        cmn_numberranges.CMN_NumberRangeID,
        cmn_numberranges.NumberRange_UsageArea_RefID,
        cmn_numberranges.NumberRange_Name,
        cmn_numberranges.Value_Current,
        cmn_numberranges.Value_Start,
        cmn_numberranges.Value_End,
        cmn_numberranges.FixedPrefix,
        cmn_numberranges.Tenant_RefID,
        cmn_numberranges.IsDeleted,
        cmn_numberranges.Formatting_LeadingFillCharacter,
        cmn_numberranges.Formatting_NumberLength
    From
        cmn_numberranges
	Where cmn_numberranges.Tenant_RefID = @TenantID And cmn_numberranges.IsDeleted = 0
		  And cmn_numberranges.NumberRange_UsageArea_RefID = @NumberRange_UsageAreaID		 
  