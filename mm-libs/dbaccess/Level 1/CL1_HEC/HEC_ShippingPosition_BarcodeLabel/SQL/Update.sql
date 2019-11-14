UPDATE 
	hec_shippingposition_barcodelabels
SET 
	Doctor_RefID=@Doctor_RefID,
	ShippingPosition_BarcodeLabel=@ShippingPosition_BarcodeLabel,
	LOG_SHP_Shipment_Position_RefID=@LOG_SHP_Shipment_Position_RefID,
	R_IsSubmission_Complete=@R_IsSubmission_Complete,
	Bound_QuestionnaireTemplateVersion_RefID=@Bound_QuestionnaireTemplateVersion_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_ShippingPosition_BarcodeLabelID = @HEC_ShippingPosition_BarcodeLabelID