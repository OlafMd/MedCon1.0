INSERT INTO 
	bil_billposition_2_patienttreatment
	(
		AssignmentID,
		BIL_BillPosition_RefID,
		HEC_Patient_Treatment_RefID,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted
	)
VALUES 
	(
		@AssignmentID,
		@BIL_BillPosition_RefID,
		@HEC_Patient_Treatment_RefID,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted
	)