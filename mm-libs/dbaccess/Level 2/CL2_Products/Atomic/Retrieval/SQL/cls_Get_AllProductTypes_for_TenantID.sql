
	Select
	  cmn_pro_product_types.CMN_PRO_Product_TypeID,
	  cmn_pro_product_types.ProductType_Name_DictID,
	  cmn_pro_product_types.ProductType_Description_DictID
	From
	  cmn_pro_product_types
	Where
	  cmn_pro_product_types.IsDeleted = 0 And
	  cmn_pro_product_types.Tenant_RefID = @TenantID
  