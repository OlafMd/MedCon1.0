UPDATE 
	hec_dia_typicalpotentialprocedures
SET 
	PotentialDiagnosis_RefID=@PotentialDiagnosis_RefID,
	PotentialProcedure_RefID=@PotentialProcedure_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_DIA_TypicalPotentialProcedureID = @HEC_DIA_TypicalPotentialProcedureID