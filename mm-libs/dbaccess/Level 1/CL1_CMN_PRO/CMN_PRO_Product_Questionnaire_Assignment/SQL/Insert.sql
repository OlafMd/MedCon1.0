INSERT INTO 
	cmn_pro_product_questionnaire_assignment
	(
		CMN_PRO_Product_Questionnaire_AssignmentID,
		CMN_PRO_Product_RefID,
		CMN_PRO_Product_Variant_RefID,
		CMN_QST_Questionnaire_Template_Version_RefID,
		IsActive,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@CMN_PRO_Product_Questionnaire_AssignmentID,
		@CMN_PRO_Product_RefID,
		@CMN_PRO_Product_Variant_RefID,
		@CMN_QST_Questionnaire_Template_Version_RefID,
		@IsActive,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)