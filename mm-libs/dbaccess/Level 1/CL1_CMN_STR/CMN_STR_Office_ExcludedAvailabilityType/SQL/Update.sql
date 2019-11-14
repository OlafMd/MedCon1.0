UPDATE 
	cmn_str_office_excludedavailabilitytypes
SET 
	Office_RefID=@Office_RefID,
	Excluded_Availability_Type_RefID=@Excluded_Availability_Type_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_Office_ExcludedAvailabilityTypeID = @CMN_STR_Office_ExcludedAvailabilityTypeID