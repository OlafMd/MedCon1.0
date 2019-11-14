UPDATE 
	pps_tsk_bok_staffresources
SET 
	AvailableResourceCombination_RefID=@AvailableResourceCombination_RefID,
	CMN_BPT_EMP_Employee_RefID=@CMN_BPT_EMP_Employee_RefID,
	CreatedFor_TaskTemplateRequiredStaff_RefID=@CreatedFor_TaskTemplateRequiredStaff_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	PPS_TSK_BOK_StaffResourceID = @PPS_TSK_BOK_StaffResourceID