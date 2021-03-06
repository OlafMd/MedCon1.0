INSERT INTO 
	cmn_pro_cus_customization_variants
	(
		CMN_PRO_CUS_Customization_VariantID,
		Customization_RefID,
		CustomizationVariant_Name_DictID,
		OrderSequence,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_PRO_CUS_Customization_VariantID,
		@Customization_RefID,
		@CustomizationVariant_Name,
		@OrderSequence,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)