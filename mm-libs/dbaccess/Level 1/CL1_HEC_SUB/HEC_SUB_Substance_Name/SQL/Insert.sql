INSERT INTO 
	hec_sub_substance_names
	(
		HEC_SUB_Substance_NameID,
		HEC_SUB_Substance_RefID,
		IsPrimarySubstanceName,
		SubstanceName_Origin_DictID,
		SubstanceName_Label_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@HEC_SUB_Substance_NameID,
		@HEC_SUB_Substance_RefID,
		@IsPrimarySubstanceName,
		@SubstanceName_Origin,
		@SubstanceName_Label,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)