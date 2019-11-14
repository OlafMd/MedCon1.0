UPDATE 
	cmn_bpt_businessparticipant_spokenlanguages
SET 
	CMN_Language_RefID=@CMN_Language_RefID,
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_BusinessParticipant_SpokenLanguageID = @CMN_BPT_BusinessParticipant_SpokenLanguageID