INSERT INTO 
	hec_patient_prescription_positions
	(
		HEC_Patient_Prescription_PositionID,
		PrescriptionHeader_RefID,
		HEC_Product_RefID,
		ProductProvidingPharmacy_RefID,
		BoundTo_CustomerOrderPosition_RefID,
		IfSubstance_Substance_RefiD,
		IsSubstance,
		IsHealthcareProduct,
		IfSubstance_Unit,
		InitializedFrom_PatientMedication_RefID,
		IfSubstance_Strength,
		DosageText,
		Dosage_RefID,
		Modification_Timestamp,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@HEC_Patient_Prescription_PositionID,
		@PrescriptionHeader_RefID,
		@HEC_Product_RefID,
		@ProductProvidingPharmacy_RefID,
		@BoundTo_CustomerOrderPosition_RefID,
		@IfSubstance_Substance_RefiD,
		@IsSubstance,
		@IsHealthcareProduct,
		@IfSubstance_Unit,
		@InitializedFrom_PatientMedication_RefID,
		@IfSubstance_Strength,
		@DosageText,
		@Dosage_RefID,
		@Modification_Timestamp,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)