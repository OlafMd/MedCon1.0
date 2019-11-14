UPDATE 
	cmn_pro_pac_packageinfo
SET 
	PackageContent_MeasuredInUnit_RefID=@PackageContent_MeasuredInUnit_RefID,
	PackageContent_Amount=@PackageContent_Amount,
	PackageContent_DisplayLabel=@PackageContent_DisplayLabel,
	Creation_Timestamp=@Creation_Timestamp,
	Modification_Timestamp=@Modification_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PRO_PAC_PackageInfoID = @CMN_PRO_PAC_PackageInfoID