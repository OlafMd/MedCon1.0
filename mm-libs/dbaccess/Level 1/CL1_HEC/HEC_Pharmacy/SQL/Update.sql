UPDATE 
	hec_pharmacies
SET 
	Ext_CompanyInfo_RefID=@Ext_CompanyInfo_RefID,
	ContactPerson_BusinessParticipant_RefID=@ContactPerson_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	HEC_PharmacyID = @HEC_PharmacyID