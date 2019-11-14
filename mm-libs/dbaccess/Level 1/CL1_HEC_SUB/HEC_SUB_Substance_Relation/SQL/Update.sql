UPDATE 
	hec_sub_substance_relations
SET 
	FirstSubstance_RefID=@FirstSubstance_RefID,
	SecondSubstance_RefID=@SecondSubstance_RefID,
	Unit_RefID=@Unit_RefID,
	Value=@Value,
	RelationType=@RelationType,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_SUB_Substance_RelationID = @HEC_SUB_Substance_RelationID