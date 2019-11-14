UPDATE 
	cmn_pro_product_questionnaire_assignment
SET 
	CMN_PRO_Product_RefID=@CMN_PRO_Product_RefID,
	CMN_PRO_Product_Variant_RefID=@CMN_PRO_Product_Variant_RefID,
	CMN_QST_Questionnaire_Template_Version_RefID=@CMN_QST_Questionnaire_Template_Version_RefID,
	IsActive=@IsActive,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_PRO_Product_Questionnaire_AssignmentID = @CMN_PRO_Product_Questionnaire_AssignmentID