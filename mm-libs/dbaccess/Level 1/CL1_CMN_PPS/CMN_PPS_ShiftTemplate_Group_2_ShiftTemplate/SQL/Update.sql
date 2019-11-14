UPDATE 
	cmn_pps_shifttemplate_group_2_shifttemplate
SET 
	CMN_PPS_ShiftTemplate_RefID=@CMN_PPS_ShiftTemplate_RefID,
	CMN_PPS_ShiftTemplate_Group_RefID=@CMN_PPS_ShiftTemplate_Group_RefID,
	Proposed_StaffHeadCount=@Proposed_StaffHeadCount,
	SequenceNumber=@SequenceNumber,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	AssignmentID = @AssignmentID