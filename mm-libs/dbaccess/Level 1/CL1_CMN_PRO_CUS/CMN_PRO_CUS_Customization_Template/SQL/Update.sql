UPDATE 
	cmn_pro_cus_customization_templates
SET 
	CustomizationTemplate_Name_DictID=@CustomizationTemplate_Name,
	CustomizationTemplate_Description_DictID=@CustomizationTemplate_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_CUS_Customization_TemplateID = @CMN_PRO_CUS_Customization_TemplateID