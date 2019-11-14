UPDATE 
	cmn_bpt_businessparticipant_accesscodes
SET 
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	Source=@Source,
	IsDeviceAccessCode=@IsDeviceAccessCode,
	IsWebAccessCode=@IsWebAccessCode,
	IsValid=@IsValid,
	Code=@Code,
	ValidFrom=@ValidFrom,
	ValidThrough=@ValidThrough,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted,
	Modification_Timestamp=@Modification_Timestamp
WHERE 
	CMN_BPT_BusinessParticipant_AccessCodeID = @CMN_BPT_BusinessParticipant_AccessCodeID