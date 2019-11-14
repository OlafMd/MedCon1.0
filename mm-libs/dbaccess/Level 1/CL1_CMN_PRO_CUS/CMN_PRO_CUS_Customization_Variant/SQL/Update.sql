UPDATE 
	cmn_pro_cus_customization_variants
SET 
	Customization_RefID=@Customization_RefID,
	CustomizationVariant_Name_DictID=@CustomizationVariant_Name,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_CUS_Customization_VariantID = @CMN_PRO_CUS_Customization_VariantID