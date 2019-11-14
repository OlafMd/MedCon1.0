
		SELECT
		  cmn_numberranges.CMN_NumberRangeID,
		  cmn_numberranges.NumberRange_UsageArea_RefID,
		  cmn_numberranges.NumberRange_Name,
		  cmn_numberranges.Value_Current,
		  cmn_numberranges.Value_Start,
		  cmn_numberranges.Value_End,
		  cmn_numberranges.FixedPrefix,
		  cmn_numberranges.Formatting_NumberLength,
		  cmn_numberranges.Formatting_LeadingFillCharacter,
		  cmn_numberranges.Creation_Timestamp,
		  cmn_numberranges.IsDeleted,
		  cmn_numberranges.Tenant_RefID
		FROM
		  cmn_numberranges
		WHERE
		  Tenant_RefID = @TenantID AND
		  IsDeleted = 0
  