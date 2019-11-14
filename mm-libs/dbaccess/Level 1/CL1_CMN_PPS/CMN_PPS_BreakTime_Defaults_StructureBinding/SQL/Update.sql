UPDATE 
	cmn_pps_breaktime_defaults_structurebindings
SET 
	BoundTo_Office_RefID=@BoundTo_Office_RefID,
	BoundTo_WorkArea_RefID=@BoundTo_WorkArea_RefID,
	BoundTo_Workplace_RefID=@BoundTo_Workplace_RefID,
	BreakTime_Default_RefID=@BreakTime_Default_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_BreakTime_Defaults_StructureBindingID = @CMN_PPS_BreakTime_Defaults_StructureBindingID