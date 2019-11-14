UPDATE 
	cmn_pro_product_2_productannotation
SET 
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Annotation_RefID=@CMN_PRO_Product_Annotation_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_PRO_Product_Release_RefID=@CMN_PRO_Product_Release_RefID,
	ProductAnnotation_Value=@ProductAnnotation_Value,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID