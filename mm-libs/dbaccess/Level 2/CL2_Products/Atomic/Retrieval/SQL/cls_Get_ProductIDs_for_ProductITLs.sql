
	Select
	  cmn_pro_products.CMN_PRO_ProductID,
	  cmn_pro_products.ProductITL
	From
	  cmn_pro_products
	Where
	  cmn_pro_products.ProductITL = @ProductITLList And
	  cmn_pro_products.IsProductAvailableForOrdering = 1 And
	  cmn_pro_products.IsDeleted = 0 And
	  cmn_pro_products.Tenant_RefID = @TenantID
  