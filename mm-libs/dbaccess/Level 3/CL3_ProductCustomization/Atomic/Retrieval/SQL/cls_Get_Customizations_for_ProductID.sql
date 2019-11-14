
	SELECT cmn_pro_cus_customizations.CMN_PRO_CUS_CustomizationID,
	       cmn_pro_cus_customizations.InstantiatedFrom_CustomizationTemplate_RefID,
	       cmn_pro_cus_customizations.Product_RefID,
	      cmn_pro_cus_customizations.Customization_Name_DictID,
       cmn_pro_cus_customizations.Customization_Description_DictID,
	       cmn_pro_cus_customizations.OrderSequence,
	       cmn_pro_cus_customization_variants.CMN_PRO_CUS_Customization_VariantID,
	       cmn_pro_cus_customization_variants.CustomizationVariant_Name_DictID,
	       cmn_pro_cus_customization_variants.OrderSequence as VariantOrderSequence
	FROM cmn_pro_cus_customizations
	LEFT JOIN cmn_pro_cus_customization_variants ON cmn_pro_cus_customizations.CMN_PRO_CUS_CustomizationID = cmn_pro_cus_customization_variants.Customization_RefID
	AND cmn_pro_cus_customization_variants.Tenant_RefID = @TenantID
	AND cmn_pro_cus_customization_variants.IsDeleted = 0
	WHERE cmn_pro_cus_customizations.Tenant_RefID = @TenantID
	  AND cmn_pro_cus_customizations.IsDeleted = 0
	  AND cmn_pro_cus_customizations.Product_RefID=@ProductID
  