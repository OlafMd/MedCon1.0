UPDATE 
	hec_medicalpractises
SET 
	WeeklyOfficeHours_Template_RefID=@WeeklyOfficeHours_Template_RefID,
	Ext_CompanyInfo_RefID=@Ext_CompanyInfo_RefID,
	AssociatedWith_PhysitianAssociation_RefID=@AssociatedWith_PhysitianAssociation_RefID,
	ContactPerson_RefID=@ContactPerson_RefID,
	WeeklySurgeryHours_Template_RefID=@WeeklySurgeryHours_Template_RefID,
	Contact_EmergencyPhoneNumber=@Contact_EmergencyPhoneNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	IsHospital=@IsHospital,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	HEC_MedicalPractiseID = @HEC_MedicalPractiseID