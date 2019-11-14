UPDATE 
	cmn_str_pps_activities
SET 
	Activity_ShortName=@Activity_ShortName,
	Activity_Name_DictID=@Activity_Name,
	Activity_Description_DicID=@Activity_Description_DicID,
	IsAbsenceActivity=@IsAbsenceActivity,
	AbsenceReason_RefID=@AbsenceReason_RefID,
	IsSkill=@IsSkill,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_STR_PPS_ActivityID = @CMN_STR_PPS_ActivityID