UPDATE 
	cmn_pro_productgroups
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	ProductGroup_Name_DictID=@ProductGroup_Name,
	ProductGroup_Description_DictID=@ProductGroup_Description,
	Parent_RefID=@Parent_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_ProductGroupID = @CMN_PRO_ProductGroupID