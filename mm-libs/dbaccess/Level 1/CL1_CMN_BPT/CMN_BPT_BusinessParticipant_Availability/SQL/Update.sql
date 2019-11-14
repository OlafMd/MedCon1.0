UPDATE 
	cmn_bpt_businessparticipant_availabilities
SET 
	BusinessParticipant_RefID=@BusinessParticipant_RefID,
	CMN_CAL_AVA_Availability_RefID=@CMN_CAL_AVA_Availability_RefID,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_BPT_BusinessParticipant_AvailabilityID = @CMN_BPT_BusinessParticipant_AvailabilityID