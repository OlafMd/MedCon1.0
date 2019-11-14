UPDATE 
	hec_cas_case_statushistory
SET 
	Case_RefID=@Case_RefID,
	IsCustom=@IsCustom,
	IfCustom_Status_RefID=@IfCustom_Status_RefID,
	IsBilled=@IsBilled,
	IsClearedForBilling=@IsClearedForBilling,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_CAS_Case_StatusHistoryID = @HEC_CAS_Case_StatusHistoryID