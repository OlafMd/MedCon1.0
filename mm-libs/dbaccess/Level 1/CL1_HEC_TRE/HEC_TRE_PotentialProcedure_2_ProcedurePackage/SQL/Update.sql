UPDATE 
	hec_tre_potentialprocedure_2_procedurepackage
SET 
	HEC_TRE_PotentialProcedure_Package_RefID=@HEC_TRE_PotentialProcedure_Package_RefID,
	HEC_TRE_PotentialProcedure_RefID=@HEC_TRE_PotentialProcedure_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID