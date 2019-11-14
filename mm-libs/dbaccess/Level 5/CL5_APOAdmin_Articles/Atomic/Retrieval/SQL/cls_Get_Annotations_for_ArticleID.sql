
	SELECT cmn_pro_product_annotations.CMN_PRO_Product_AnnotationID,
	       cmn_pro_product_annotations.ProductAnnotation_Name_DictID,
	       cmn_pro_product_2_productannotation.AssignmentID,
	       cmn_pro_product_2_productannotation.CMN_PRO_Product_RefID,
	       cmn_pro_product_2_productannotation.ProductAnnotation_Value
	FROM cmn_pro_product_annotations
	     LEFT JOIN cmn_pro_product_2_productannotation 
	     ON cmn_pro_product_annotations.CMN_PRO_Product_AnnotationID = cmn_pro_product_2_productannotation.CMN_PRO_Product_Annotation_RefID 
	        AND cmn_pro_product_2_productannotation.IsDeleted = 0
	        AND cmn_pro_product_2_productannotation.CMN_PRO_Product_RefID = @ProductID
	WHERE cmn_pro_product_annotations.IsDeleted = 0
	      AND cmn_pro_product_annotations.Tenant_RefID = @TenantID   
  