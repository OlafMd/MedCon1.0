UPDATE 
	hec_sub_substance_names
SET 
	HEC_SUB_Substance_RefID=@HEC_SUB_Substance_RefID,
	IsPrimarySubstanceName=@IsPrimarySubstanceName,
	SubstanceName_Origin_DictID=@SubstanceName_Origin,
	SubstanceName_Label_DictID=@SubstanceName_Label,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_SUB_Substance_NameID = @HEC_SUB_Substance_NameID