UPDATE 
	hec_shippingposition_questionnairesubmissions
SET 
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	CMN_QST_Questionnaire_Submission_RefID=@CMN_QST_Questionnaire_Submission_RefID,
	Doctor_RefID=@Doctor_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_ShippingPosition_QuestionnaireSubmissionID = @HEC_ShippingPosition_QuestionnaireSubmissionID