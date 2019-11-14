UPDATE 
	hec_sub_substance_texts
SET 
	Substance_RefID=@Substance_RefID,
	SubstanceText_DictID=@SubstanceText,
	SubstanceText_Status=@SubstanceText_Status,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_SUB_Substance_TextID = @HEC_SUB_Substance_TextID