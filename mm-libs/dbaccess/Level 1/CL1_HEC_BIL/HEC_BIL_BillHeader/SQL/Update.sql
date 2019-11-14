UPDATE 
	hec_bil_billheaders
SET 
	Ext_BIL_BillHeader_RefID=@Ext_BIL_BillHeader_RefID,
	IsToBill_ToPatient=@IsToBill_ToPatient,
	IsToBill_ToHealthInsurance=@IsToBill_ToHealthInsurance,
	Patient_RefID=@Patient_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_BIL_BillHeaderID = @HEC_BIL_BillHeaderID