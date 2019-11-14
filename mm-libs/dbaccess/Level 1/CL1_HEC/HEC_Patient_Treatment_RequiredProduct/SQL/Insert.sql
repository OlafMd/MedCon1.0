INSERT INTO 
	hec_patient_treatment_requiredproducts
	(
		HEC_Patient_Treatment_RequiredProductID,
		HEC_Patient_Treatment_RefID,
		HEC_Product_RefID,
		ProductProvidingPharmacy_RefID,
		BoundTo_CustomerOrderPosition_RefID,
		ExpectedDateOfDelivery,
		Quantity,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_Patient_Treatment_RequiredProductID,
		@HEC_Patient_Treatment_RefID,
		@HEC_Product_RefID,
		@ProductProvidingPharmacy_RefID,
		@BoundTo_CustomerOrderPosition_RefID,
		@ExpectedDateOfDelivery,
		@Quantity,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)