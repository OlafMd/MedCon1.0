
	Select
	  cmn_pro_products.CMN_PRO_ProductID,
	  cmn_pro_products.ProductITL,
	  cmn_pro_products.Product_Number
	From
	  cmn_pro_products Inner Join
	  cmn_pro_product_2_productgroup
	    On cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID And
	    cmn_pro_product_2_productgroup.IsDeleted = 0 Inner Join
	  cmn_pro_productgroups On cmn_pro_productgroups.CMN_PRO_ProductGroupID =
	    cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID And
	    cmn_pro_productgroups.IsDeleted = 0
	Where
	  cmn_pro_products.Tenant_RefID = @TenantID And
	  cmn_pro_productgroups.GlobalPropertyMatchingID =
	  IfNull(@ProductGroupGlobalPropertyID,
	  cmn_pro_productgroups.GlobalPropertyMatchingID) And
	  cmn_pro_products.IsDeleted = 0 And
	  cmn_pro_products.IsProduct_Article = 1 And
	  cmn_pro_products.IsProductAvailableForOrdering = 1
  