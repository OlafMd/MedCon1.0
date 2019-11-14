UPDATE 
	hec_sub_substance_groups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	SubstanceGroup_Name_DictID=@SubstanceGroup_Name,
	SubstanceGroup_Description_DictID=@SubstanceGroup_Description,
	SubstanceGroupTypeStatus=@SubstanceGroupTypeStatus,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	HEC_SUB_Substance_GroupID = @HEC_SUB_Substance_GroupID