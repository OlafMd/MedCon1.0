
    
Select
  tms_pro_project_notes.TMS_PRO_Project_NoteID,
  cmn_notes.Current_NoteRevision_RefID,
  cmn_notes.CMN_NoteID,
  tms_pro_project_notes.Project_RefID,
  cmn_notes.Creation_Timestamp,
  cmn_notes.Modification_Timestamp,
  cmn_notes.CreatedBy_BusinessParticipant_RefID
From
  cmn_notes Inner Join
  tms_pro_project_notes On tms_pro_project_notes.Ext_CMN_Note_RefID =
    cmn_notes.CMN_NoteID Inner Join
  cmn_bpt_businessparticipants On cmn_notes.CreatedBy_BusinessParticipant_RefID
    = cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID Inner Join
  usr_accounts On usr_accounts.BusinessParticipant_RefID =
    cmn_bpt_businessparticipants.CMN_BPT_BusinessParticipantID
Where
  usr_accounts.USR_AccountID = @AccountID And
  usr_accounts.Tenant_RefID = @TenantID
  And
  usr_accounts.IsDeleted = 0 And
  cmn_notes.IsDeleted = 0 And
  tms_pro_project_notes.IsDeleted = 0 And
  cmn_bpt_businessparticipants.IsDeleted = 0
    
  