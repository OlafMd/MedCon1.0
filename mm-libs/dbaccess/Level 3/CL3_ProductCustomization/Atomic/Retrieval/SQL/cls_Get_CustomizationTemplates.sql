
	SELECT cmn_pro_cus_customization_templates.CMN_PRO_CUS_Customization_TemplateID,      
         cmn_pro_cus_customization_templates.CustomizationTemplate_Name_DictID,
	       cmn_pro_cus_customization_templates.CustomizationTemplate_Description_DictID
	FROM cmn_pro_cus_customization_templates
	WHERE cmn_pro_cus_customization_templates.Tenant_RefID = @TenantID
	  AND cmn_pro_cus_customization_templates.IsDeleted = 0
  