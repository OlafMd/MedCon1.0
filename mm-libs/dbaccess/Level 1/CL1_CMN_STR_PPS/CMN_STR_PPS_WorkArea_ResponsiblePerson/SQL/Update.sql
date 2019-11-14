UPDATE 
	cmn_str_pps_workarea_responsiblepersons
SET 
	WorkArea_RefID=@WorkArea_RefID,
	CMN_BPT_EMP_Employee_RefID=@CMN_BPT_EMP_Employee_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_STR_PPS_WorkArea_ResponsiblePersonID = @CMN_STR_PPS_WorkArea_ResponsiblePersonID