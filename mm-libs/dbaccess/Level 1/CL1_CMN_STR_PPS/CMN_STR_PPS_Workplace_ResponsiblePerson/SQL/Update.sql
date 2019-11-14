UPDATE 
	cmn_str_pps_workplace_responsiblepersons
SET 
	Workplace_RefID=@Workplace_RefID,
	CMN_BPT_EMP_Employee_RefID=@CMN_BPT_EMP_Employee_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_PPS_Workplace_ResponsiblePersonID = @CMN_STR_PPS_Workplace_ResponsiblePersonID