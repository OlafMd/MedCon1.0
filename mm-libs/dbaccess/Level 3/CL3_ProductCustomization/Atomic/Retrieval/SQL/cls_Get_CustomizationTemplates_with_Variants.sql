
	SELECT cmn_pro_cus_customization_templates.CMN_PRO_CUS_Customization_TemplateID,
	       cmn_pro_cus_customization_templates.CustomizationTemplate_Name_DictID,
	       cmn_pro_cus_customization_templates.CustomizationTemplate_Description_DictID,
	       cmn_pro_cus_customization_variant_templates.CMN_PRO_CUS_Customization_Variant_TemplateID,
	       cmn_pro_cus_customization_variant_templates.CustomizationVariantTemplate_Name_DictID,
	       cmn_pro_cus_customization_variant_templates.OrderSequence
	FROM cmn_pro_cus_customization_templates
	LEFT JOIN cmn_pro_cus_customization_variant_templates ON cmn_pro_cus_customization_templates.CMN_PRO_CUS_Customization_TemplateID = cmn_pro_cus_customization_variant_templates.Customization_Template_RefID
	AND cmn_pro_cus_customization_variant_templates.Tenant_RefID = @TenantID
	AND cmn_pro_cus_customization_variant_templates.IsDeleted = 0
	WHERE cmn_pro_cus_customization_templates.Tenant_RefID = @TenantID
	  AND cmn_pro_cus_customization_templates.IsDeleted = 0
  