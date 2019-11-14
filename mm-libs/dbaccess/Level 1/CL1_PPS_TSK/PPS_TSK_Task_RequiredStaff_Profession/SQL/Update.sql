UPDATE 
	pps_tsk_task_requiredstaff_professions
SET 
	RequiredStaff_RefID=@RequiredStaff_RefID,
	CMN_STR_Profession_RefID=@CMN_STR_Profession_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	PPS_TSK_Task_RequiredStaff_ProfessionID = @PPS_TSK_Task_RequiredStaff_ProfessionID