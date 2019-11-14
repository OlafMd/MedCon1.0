UPDATE 
	cmn_numberranges
SET 
	NumberRange_UsageArea_RefID=@NumberRange_UsageArea_RefID,
	NumberRange_Name=@NumberRange_Name,
	Value_Current=@Value_Current,
	Value_Start=@Value_Start,
	Value_End=@Value_End,
	FixedPrefix=@FixedPrefix,
	Formatting_NumberLength=@Formatting_NumberLength,
	Formatting_LeadingFillCharacter=@Formatting_LeadingFillCharacter,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_NumberRangeID = @CMN_NumberRangeID