UPDATE 
	cmn_pro_product_2_productcode
SET 
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_ProductCode_RefID=@CMN_PRO_ProductCode_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID