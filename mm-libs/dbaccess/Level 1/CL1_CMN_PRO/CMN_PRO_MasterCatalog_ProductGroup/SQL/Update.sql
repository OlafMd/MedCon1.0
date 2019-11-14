UPDATE 
	cmn_pro_mastercatalog_productgroups
SET 
	CMN_PRO_MasterCatalog_RefID=@CMN_PRO_MasterCatalog_RefID,
	ProductGroup_Name_DictID=@ProductGroup_Name,
	ProductGroup_Parent_RefID=@ProductGroup_Parent_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_MasterCatalog_ProductGroupID = @CMN_PRO_MasterCatalog_ProductGroupID