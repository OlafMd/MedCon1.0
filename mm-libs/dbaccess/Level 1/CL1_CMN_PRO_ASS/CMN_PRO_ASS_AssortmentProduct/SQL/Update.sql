UPDATE 
	cmn_pro_ass_assortmentproducts
SET 
	Ext_CMN_PRO_Product_RefID=@Ext_CMN_PRO_Product_RefID,
	DistributionPrice_RefID=@DistributionPrice_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_PRO_ASS_AssortmentProductID = @CMN_PRO_ASS_AssortmentProductID