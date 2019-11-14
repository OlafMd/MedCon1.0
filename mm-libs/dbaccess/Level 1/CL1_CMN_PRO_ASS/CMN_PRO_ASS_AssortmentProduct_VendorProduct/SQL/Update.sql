UPDATE 
	cmn_pro_ass_assortmentproduct_vendorproducts
SET 
	CMN_PRO_ASS_AssortmentProduct_RefID=@CMN_PRO_ASS_AssortmentProduct_RefID,
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_ASS_AssortmentProduct_VendorProductID = @CMN_PRO_ASS_AssortmentProduct_VendorProductID
