UPDATE 
	hec_cas_case_billcodes
SET 
	HEC_CAS_Case_RefID=@HEC_CAS_Case_RefID,
	HEC_BIL_BillPosition_BillCode_RefID=@HEC_BIL_BillPosition_BillCode_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_Case_BillCodeID = @HEC_CAS_Case_BillCodeID