UPDATE 
	cmn_bpt_sta_absencereason_types
SET 
	AbsenceReason_Type_Name_DictID=@AbsenceReason_Type_Name,
	AbsenceReason_Type_Description_DictID=@AbsenceReason_Type_Description,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_STA_AbsenceReason_TypeID = @CMN_BPT_STA_AbsenceReason_TypeID