
	Select
	  cmn_pro_product_annotations.CMN_PRO_Product_AnnotationID,
	  cmn_pro_product_annotations.GlobalPropertyMatchingID,
	  cmn_pro_product_annotations.ProductAnnotation_Abbreviation,
	  cmn_pro_product_annotations.ProductAnnotation_Name_DictID,
	  cmn_pro_product_annotations.Creation_Timestamp,
	  cmn_pro_product_annotations.Tenant_RefID,
	  cmn_pro_product_annotations.IsValueBoolean,
	  cmn_pro_product_annotations.IsValueNumber
	From
	  cmn_pro_product_annotations
	Where
	  cmn_pro_product_annotations.IsDeleted = 0 And
	  cmn_pro_product_annotations.Tenant_RefID = @TenantID
  