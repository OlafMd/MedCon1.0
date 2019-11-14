UPDATE 
	hec_tre_potentialprocedure_2_medicalpracticetype
SET 
	HEC_MedicalPractice_Type_RefID=@HEC_MedicalPractice_Type_RefID,
	HEC_TRE_PotentialProcedure_RefID=@HEC_TRE_PotentialProcedure_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID