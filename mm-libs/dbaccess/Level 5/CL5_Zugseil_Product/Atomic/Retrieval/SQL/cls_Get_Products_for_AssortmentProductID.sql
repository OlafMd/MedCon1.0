
	SELECT cmn_pro_ass_assortmentproduct_vendorproducts.CMN_PRO_Product_RefID
 ,cmn_pro_ass_assortmentproduct_vendorproducts.CMN_PRO_ASS_AssortmentProduct_VendorProductID
 ,cmn_pro_products.Product_Name_DictID
 ,cmn_pro_products.Product_Description_DictID
 ,cmn_pro_products.Product_Number
 ,cmn_pro_products.IsDeleted
 ,CMN_PRO_Product_Variants.CMN_PRO_Product_VariantID
 ,CMN_PRO_Product_Variants.VariantName_DictID
FROM cmn_pro_ass_assortmentproduct_vendorproducts
INNER JOIN cmn_pro_products ON (
  cmn_pro_ass_assortmentproduct_vendorproducts.CMN_PRO_Product_RefID = cmn_pro_products.CMN_PRO_ProductID
  AND cmn_pro_products.IsDeleted = 0
  AND cmn_pro_products.Tenant_RefID = @TenantID
  )
LEFT JOIN CMN_PRO_Product_Variants ON cmn_pro_products.CMN_PRO_ProductID = CMN_PRO_Product_Variants.CMN_PRO_Product_RefID
 AND CMN_PRO_Product_Variants.IsDeleted = 0
 AND CMN_PRO_Product_Variants.Tenant_RefID = @TenantID
 AND CMN_PRO_Product_Variants.IsStandardProductVariant = 0
WHERE (cmn_pro_ass_assortmentproduct_vendorproducts.CMN_PRO_ASS_AssortmentProduct_RefID = @AssortmentProductID)
 AND (cmn_pro_ass_assortmentproduct_vendorproducts.Tenant_RefID = @TenantID)
 AND (cmn_pro_ass_assortmentproduct_vendorproducts.IsDeleted = 0)
	      	   
  