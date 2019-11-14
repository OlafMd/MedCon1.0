UPDATE 
	cmn_pro_productcodes
SET 
	ProductCode_Type_RefID=@ProductCode_Type_RefID,
	ProductCode_Value=@ProductCode_Value,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_PRO_ProductCodeID = @CMN_PRO_ProductCodeID