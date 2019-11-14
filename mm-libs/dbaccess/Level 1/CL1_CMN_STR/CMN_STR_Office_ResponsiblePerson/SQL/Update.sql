UPDATE 
	cmn_str_office_responsiblepersons
SET 
	Office_RefID=@Office_RefID,
	CMN_BPT_EMP_Employee_RefID=@CMN_BPT_EMP_Employee_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_Office_ResponsiblePersonID = @CMN_STR_Office_ResponsiblePersonID