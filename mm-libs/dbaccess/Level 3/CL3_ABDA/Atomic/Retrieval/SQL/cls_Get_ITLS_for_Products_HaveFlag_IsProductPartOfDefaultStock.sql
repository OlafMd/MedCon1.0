
	Select
	  cmn_pro_products.ProductITL
	From
	  cmn_pro_products
	Where
	  cmn_pro_products.Tenant_RefID = @TenantID And
	  cmn_pro_products.IsDeleted = 0 And
	  cmn_pro_products.IsProductPartOfDefaultStock = 1
  