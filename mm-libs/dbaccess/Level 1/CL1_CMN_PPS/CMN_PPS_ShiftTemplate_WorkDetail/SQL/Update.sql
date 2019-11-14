UPDATE 
	cmn_pps_shifttemplate_workdetails
SET 
	CMN_PPS_ShiftTemplate_RefID=@CMN_PPS_ShiftTemplate_RefID,
	ShiftStart_Offset_sec=@ShiftStart_Offset_sec,
	Duration_in_sec=@Duration_in_sec,
	WorkDetail_Note_Title=@WorkDetail_Note_Title,
	WorkDetail_Note_Content=@WorkDetail_Note_Content,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_PPS_ShiftTemplate_WorkDetailID = @CMN_PPS_ShiftTemplate_WorkDetailID