UPDATE 
	hec_bil_billpositions
SET 
	Ext_BIL_BillPosition_RefID=@Ext_BIL_BillPosition_RefID,
	PositionFor_Patient_RefID=@PositionFor_Patient_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_BIL_BillPositionID = @HEC_BIL_BillPositionID