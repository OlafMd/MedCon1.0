UPDATE 
	cmn_bpt_publicoffices
SET 
	GlobalPropertyMatchingID=@GlobalPropertyMatchingID,
	CMN_BPT_BusinessParticipant_RefID=@CMN_BPT_BusinessParticipant_RefID,
	PublicOffice_InternalKey=@PublicOffice_InternalKey,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_PublicOfficeID = @CMN_BPT_PublicOfficeID