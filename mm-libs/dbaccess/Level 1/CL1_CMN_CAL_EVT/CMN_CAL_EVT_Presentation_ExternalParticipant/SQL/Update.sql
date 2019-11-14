UPDATE 
	cmn_cal_evt_presentation_externalparticipants
SET 
	Presentation_RefID=@Presentation_RefID,
	Participant_UCD_RefID=@Participant_UCD_RefID,
	RegistrationDate=@RegistrationDate,
	RegisteredBy_BusinessParticipant_RefID=@RegisteredBy_BusinessParticipant_RefID,
	IsRegisteredThroughWebsite=@IsRegisteredThroughWebsite,
	RegistrationSource=@RegistrationSource,
	Creation_Timestamp=@Creation_Timestamp,
	Tenant_RefID=@Tenant_RefID,
	IsDeleted=@IsDeleted
WHERE 
	CMN_CAL_EVT_Presentation_ParticipantID = @CMN_CAL_EVT_Presentation_ParticipantID