UPDATE 
	cmn_pro_product_annotations
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	ProductAnnotation_Abbreviation=@ProductAnnotation_Abbreviation,
	ProductAnnotation_Name_DictID=@ProductAnnotation_Name_DictID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	IsValueBoolean=@IsValueBoolean,
	IsValueNumber=@IsValueNumber
WHERE 
	CMN_PRO_Product_AnnotationID = @CMN_PRO_Product_AnnotationID