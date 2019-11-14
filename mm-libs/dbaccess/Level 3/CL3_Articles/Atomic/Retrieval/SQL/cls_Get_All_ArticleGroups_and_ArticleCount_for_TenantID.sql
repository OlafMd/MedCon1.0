
	Select
	  cmn_pro_productgroups.ProductGroup_Name_DictID,
	  cmn_pro_productgroups.CMN_PRO_ProductGroupID,
	   cmn_pro_productgroups.GlobalPropertyMatchingID,
	  Count(cmn_pro_products.CMN_PRO_ProductID) As NumberOfArticles
	From
	  cmn_pro_productgroups Left Join
	  cmn_pro_product_2_productgroup On cmn_pro_productgroups.CMN_PRO_ProductGroupID
	    = cmn_pro_product_2_productgroup.CMN_PRO_ProductGroup_RefID And
	    cmn_pro_product_2_productgroup.IsDeleted = 0 Left Join
	  cmn_pro_products On cmn_pro_product_2_productgroup.CMN_PRO_Product_RefID =
	    cmn_pro_products.CMN_PRO_ProductID And cmn_pro_products.IsDeleted = 0
	Where
	  cmn_pro_productgroups.IsDeleted = 0 And
	  (cmn_pro_productgroups.GlobalPropertyMatchingID Is Null Or
	    cmn_pro_productgroups.GlobalPropertyMatchingID = '') And
	  cmn_pro_productgroups.Tenant_RefID = @TenantID
	Group By
	  cmn_pro_productgroups.ProductGroup_Name_DictID,
	  cmn_pro_productgroups.CMN_PRO_ProductGroupID,
	  cmn_pro_productgroups.GlobalPropertyMatchingID,
	  cmn_pro_productgroups.Tenant_RefID
  