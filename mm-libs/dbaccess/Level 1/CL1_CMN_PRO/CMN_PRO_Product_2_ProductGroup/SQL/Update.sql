UPDATE 
	cmn_pro_product_2_productgroup
SET 
	CMN_PRO_ProductGroup_RefID=@CMN_PRO_ProductGroup_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID