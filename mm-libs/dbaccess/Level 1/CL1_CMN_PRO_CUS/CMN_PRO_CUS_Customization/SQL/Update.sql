UPDATE 
	cmn_pro_cus_customizations
SET 
	InstantiatedFrom_CustomizationTemplate_RefID=@InstantiatedFrom_CustomizationTemplate_RefID,
	Product_RefID=@Product_RefID,
	Customization_Name_DictID=@Customization_Name,
	Customization_Description_DictID=@Customization_Description,
	OrderSequence=@OrderSequence,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_CUS_CustomizationID = @CMN_PRO_CUS_CustomizationID