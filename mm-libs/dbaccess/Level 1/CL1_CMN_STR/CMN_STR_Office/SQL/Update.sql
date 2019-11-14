UPDATE 
	cmn_str_offices
SET 
	OfficeITL=@OfficeITL,
	Parent_RefID=@Parent_RefID,
	Country_RefID=@Country_RefID,
	Region_RefID=@Region_RefID,
	Default_BillingAddress_RefID=@Default_BillingAddress_RefID,
	Default_ShippingAddress_RefID=@Default_ShippingAddress_RefID,
	CMN_CAL_CalendarInstance_RefID=@CMN_CAL_CalendarInstance_RefID,
	Default_PhoneNumber=@Default_PhoneNumber,
	Default_FaxNumber=@Default_FaxNumber,
	Default_Website=@Default_Website,
	Default_Email=@Default_Email,
	Office_Name_DictID=@Office_Name,
	Office_Description_DictID=@Office_Description,
	Office_ShortName=@Office_ShortName,
	IsMockObject=@IsMockObject,
	Office_InternalName=@Office_InternalName,
	Office_InternalNumber=@Office_InternalNumber,
	Comment=@Comment,
	DisplayImage_Document_RefID=@DisplayImage_Document_RefID,
	IsMedicalPractice=@IsMedicalPractice,
	IfMedicalPractise_HEC_MedicalPractice_RefID=@IfMedicalPractise_HEC_MedicalPractice_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_STR_OfficeID = @CMN_STR_OfficeID