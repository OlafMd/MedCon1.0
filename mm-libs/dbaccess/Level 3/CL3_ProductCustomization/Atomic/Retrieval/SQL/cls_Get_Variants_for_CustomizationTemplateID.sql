
	SELECT cmn_pro_cus_customization_variant_templates.CMN_PRO_CUS_Customization_Variant_TemplateID,
	       cmn_pro_cus_customization_variant_templates.CustomizationVariantTemplate_Name_DictID,
	       cmn_pro_cus_customization_variant_templates.OrderSequence
	FROM cmn_pro_cus_customization_variant_templates
	WHERE cmn_pro_cus_customization_variant_templates.Tenant_RefID = @TenantID
	  AND cmn_pro_cus_customization_variant_templates.IsDeleted = 0
	  AND cmn_pro_cus_customization_variant_templates.Customization_Template_RefID = @CustomizationTemplateID
	ORDER BY cmn_pro_cus_customization_variant_templates.OrderSequence
  