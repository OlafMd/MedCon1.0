UPDATE 
	tms_pro_developertask_involvements_investedworktime
SET 
	TMS_PRO_DeveloperTask_Involvement_RefID=@TMS_PRO_DeveloperTask_Involvement_RefID,
	CMN_BPT_InvestedWorkTime_RefID=@CMN_BPT_InvestedWorkTime_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	AssignmentID = @AssignmentID