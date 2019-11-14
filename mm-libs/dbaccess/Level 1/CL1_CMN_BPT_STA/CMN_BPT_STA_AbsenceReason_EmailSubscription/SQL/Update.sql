UPDATE 
	cmn_bpt_sta_absencereason_emailsubscriptions
SET 
	CMN_STR_Office_RefID=@CMN_STR_Office_RefID,
	AbsenceReason_RefID=@AbsenceReason_RefID,
	EmailAddresses=@EmailAddresses,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	CMN_BPT_STA_AbsenceReason_EmailSubscriptionID = @CMN_BPT_STA_AbsenceReason_EmailSubscriptionID