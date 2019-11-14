UPDATE 
	tms_pro_businesstaskpackages
SET 
	Parent_RefID=@Parent_RefID,
	Project_RefID=@Project_RefID,
	OrderSequence=@OrderSequence,
	Label=@Label,
	CreatedByAccount_RefID=@CreatedByAccount_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	TMS_PRO_BusinessTaskPackageID = @TMS_PRO_BusinessTaskPackageID