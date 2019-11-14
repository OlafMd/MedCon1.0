UPDATE 
	hec_tre_potentialprocedures
SET 
	PotentialProcedureITL=@PotentialProcedureITL,
	PotentialProcedure_Name_DictID=@PotentialProcedure_Name,
	PotentialProcedure_Description_DictID=@PotentialProcedure_Description,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_TRE_PotentialProcedureID = @HEC_TRE_PotentialProcedureID