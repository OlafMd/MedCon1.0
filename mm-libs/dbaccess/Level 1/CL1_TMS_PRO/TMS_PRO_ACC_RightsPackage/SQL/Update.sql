UPDATE 
	tms_pro_acc_rightspackages
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	Name_DictID=@Name,
	Description_DictID=@Description,
	HierarchyLevel=@HierarchyLevel,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_ACC_RightsPackageID = @TMS_PRO_ACC_RightsPackageID