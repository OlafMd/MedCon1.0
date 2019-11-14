UPDATE 
	cmn_bpt_ctm_catalogproductextensionrequest_products
SET 
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	CatalogProductExtensionRequest_RefID=@CatalogProductExtensionRequest_RefID,
	Comment=@Comment,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID = @CMN_BPT_CTM_CatalogProductExtensionRequest_ProductID