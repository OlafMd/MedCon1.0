UPDATE 
	cmn_pro_product_types
SET 
	ProductType_Name_DictID=@ProductType_Name,
	ProductType_Description_DictID=@ProductType_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_PRO_Product_TypeID = @CMN_PRO_Product_TypeID