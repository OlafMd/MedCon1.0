
    Select
      cmn_numberranges.Value_Current,
      cmn_numberranges.Value_Start,
      cmn_numberranges.Value_End,
      cmn_numberranges.FixedPrefix,
      cmn_numberranges.Formatting_NumberLength,
      cmn_numberranges.Formatting_LeadingFillCharacter,
      cmn_numberranges.CMN_NumberRangeID
    From
      cmn_numberrange_usageareas Left Join
      cmn_numberranges On cmn_numberranges.NumberRange_UsageArea_RefID =
        cmn_numberrange_usageareas.CMN_NumberRange_UsageAreaID And
        cmn_numberranges.IsDeleted = 0
    Where
      cmn_numberrange_usageareas.IsDeleted = 0 And
      cmn_numberrange_usageareas.Tenant_RefID = @TenantID And
      cmn_numberrange_usageareas.GlobalStaticMatchingID = @GlobalStaticMatchingID
  