INSERT INTO 
	cmn_pro_product_annotations
	(
		CMN_PRO_Product_AnnotationID,
		GlobalPropertyMatchingID,
		ProductAnnotation_Abbreviation,
		ProductAnnotation_Name_DictID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		IsValueBoolean,
		IsValueNumber
	)
VALUES 
	(
		@CMN_PRO_Product_AnnotationID,
		@GlobalPropertyMatchingID,
		@ProductAnnotation_Abbreviation,
		@ProductAnnotation_Name_DictID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@IsValueBoolean,
		@IsValueNumber
	)