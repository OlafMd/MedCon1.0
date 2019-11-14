UPDATE 
	pps_tsk_bok_workarearesources
SET 
	AvailableResourceCombination_RefID=@AvailableResourceCombination_RefID,
	CMN_STR_Workarea_RefID=@CMN_STR_Workarea_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	PPS_TSK_BOK_WorkareaResourceID = @PPS_TSK_BOK_WorkareaResourceID