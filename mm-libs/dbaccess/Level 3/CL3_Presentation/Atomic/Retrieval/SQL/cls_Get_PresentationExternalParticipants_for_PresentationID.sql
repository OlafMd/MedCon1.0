
Select
  cmn_universalcontactdetails.First_Name,
  cmn_universalcontactdetails.Last_Name,
  cmn_universalcontactdetails.Contact_Email,
  cmn_universalcontactdetails.Contact_Telephone,
  cmn_cal_evt_presentation_externalparticipants.CMN_CAL_EVT_Presentation_ParticipantID,
  cmn_cal_evt_presentation_externalparticipants.RegistrationDate
From
  cmn_universalcontactdetails Inner Join
  cmn_cal_evt_presentation_externalparticipants
    On cmn_cal_evt_presentation_externalparticipants.Participant_UCD_RefID =
    cmn_universalcontactdetails.CMN_UniversalContactDetailID And
    cmn_universalcontactdetails.IsDeleted = 0 And
    cmn_universalcontactdetails.Tenant_RefID = @TenantID
Where
  cmn_cal_evt_presentation_externalparticipants.Tenant_RefID = @TenantID And
  cmn_cal_evt_presentation_externalparticipants.IsDeleted = 0 And
  cmn_cal_evt_presentation_externalparticipants.Presentation_RefID =
  @Presentation_ID
  
  