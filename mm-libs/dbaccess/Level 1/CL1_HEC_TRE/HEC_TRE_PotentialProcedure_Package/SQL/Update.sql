UPDATE 
	hec_tre_potentialprocedure_packages
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Parent_RefID=@Parent_RefID,
	Name_DictID=@Name,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_TRE_PotentialProcedure_PackageID = @HEC_TRE_PotentialProcedure_PackageID