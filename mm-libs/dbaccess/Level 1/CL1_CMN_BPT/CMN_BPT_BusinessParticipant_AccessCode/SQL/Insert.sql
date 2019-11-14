INSERT INTO 
	cmn_bpt_businessparticipant_accesscodes
	(
		CMN_BPT_BusinessParticipant_AccessCodeID,
		BusinessParticipant_RefID,
		Source,
		IsDeviceAccessCode,
		IsWebAccessCode,
		IsValid,
		Code,
		ValidFrom,
		ValidThrough,
		Creation_Timestamp,
		Tenant_RefID,
		IsDeleted,
		Modification_Timestamp
	)
VALUES 
	(
		@CMN_BPT_BusinessParticipant_AccessCodeID,
		@BusinessParticipant_RefID,
		@Source,
		@IsDeviceAccessCode,
		@IsWebAccessCode,
		@IsValid,
		@Code,
		@ValidFrom,
		@ValidThrough,
		@Creation_Timestamp,
		@Tenant_RefID,
		@IsDeleted,
		@Modification_Timestamp
	)