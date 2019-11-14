UPDATE 
	bil_billposition_2_patienttreatment
SET 
	BIL_BillPosition_RefID=@BIL_BillPosition_RefID,
	HEC_Patient_Treatment_RefID=@HEC_Patient_Treatment_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	AssignmentID = @AssignmentID