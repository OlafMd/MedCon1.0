
	SELECT count(cmn_pro_products.CMN_PRO_ProductID) AS NumberOfProducts
	FROM cmn_pro_products
	JOIN cmn_pro_ass_assortmentproducts ON cmn_pro_ass_assortmentproducts.Ext_CMN_PRO_Product_RefID=cmn_pro_products.CMN_PRO_ProductID
	AND cmn_pro_ass_assortmentproducts.Tenant_RefID=@TenantID
	AND cmn_pro_ass_assortmentproducts.IsDeleted=0
	JOIN cmn_pro_ass_assortment_2_assortmentproduct ON cmn_pro_ass_assortmentproducts.CMN_PRO_ASS_AssortmentProductID=cmn_pro_ass_assortment_2_assortmentproduct.CMN_PRO_ASS_Assortment_Product_RefID
	AND cmn_pro_ass_assortment_2_assortmentproduct.Tenant_RefID=@TenantID
	AND cmn_pro_ass_assortment_2_assortmentproduct.IsDeleted=0
	AND cmn_pro_ass_assortment_2_assortmentproduct.CMN_PRO_ASS_Assortment_RefID=@AssortmentID
	WHERE cmn_pro_products.IsDeleted = 0
	  AND cmn_pro_products.Tenant_RefID = @TenantID
	  AND cmn_pro_products.Product_Number=@ProductNumber
	  AND (@ProductID IS NULL
	       OR cmn_pro_products.CMN_PRO_ProductID!=@ProductID)

  