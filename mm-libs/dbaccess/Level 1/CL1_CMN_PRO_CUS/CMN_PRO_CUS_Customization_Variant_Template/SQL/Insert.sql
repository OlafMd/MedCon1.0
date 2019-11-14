INSERT INTO 
	cmn_pro_cus_customization_variant_templates
	(
		CMN_PRO_CUS_Customization_Variant_TemplateID,
		Customization_Template_RefID,
		CustomizationVariantTemplate_Name_DictID,
		OrderSequence,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_PRO_CUS_Customization_Variant_TemplateID,
		@Customization_Template_RefID,
		@CustomizationVariantTemplate_Name,
		@OrderSequence,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)