UPDATE 
	cmn_pro_productcode_types
SET 
	ProductCode_TypeName=@ProductCode_TypeName,
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_PRO_ProductCode_TypeID = @CMN_PRO_ProductCode_TypeID