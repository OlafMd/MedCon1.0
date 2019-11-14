UPDATE 
	hec_patient_treatment_requiredproducts
SET 
	HEC_Patient_Treatment_RefID=@HEC_Patient_Treatment_RefID,
	HEC_Product_RefID=@HEC_Product_RefID,
	ProductProvidingPharmacy_RefID=@ProductProvidingPharmacy_RefID,
	BoundTo_CustomerOrderPosition_RefID=@BoundTo_CustomerOrderPosition_RefID,
	ExpectedDateOfDelivery=@ExpectedDateOfDelivery,
	Quantity=@Quantity,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_Patient_Treatment_RequiredProductID = @HEC_Patient_Treatment_RequiredProductID