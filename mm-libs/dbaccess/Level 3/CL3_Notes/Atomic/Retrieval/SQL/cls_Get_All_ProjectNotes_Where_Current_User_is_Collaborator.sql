
    
Select
  tms_pro_project_notes.TMS_PRO_Project_NoteID,
  cmn_notes.Current_NoteRevision_RefID,
  cmn_notes.CMN_NoteID,
  tms_pro_project_notes.Project_RefID,
  cmn_notes.Creation_Timestamp,
  cmn_notes.Modification_Timestamp,
  cmn_notes.CreatedBy_BusinessParticipant_RefID,
  tms_pro_project_note_collaborators.TMS_PRO_Project_Note_CollaboratorID
From
  cmn_notes Inner Join
  tms_pro_project_notes On tms_pro_project_notes.Ext_CMN_Note_RefID =
    cmn_notes.CMN_NoteID Inner Join
  tms_pro_project_note_collaborators
    On tms_pro_project_note_collaborators.ProjectNote_RefID =
    tms_pro_project_notes.TMS_PRO_Project_NoteID Inner Join
  usr_accounts On tms_pro_project_note_collaborators.Account_RefID =
    usr_accounts.USR_AccountID
Where
  usr_accounts.USR_AccountID = @AccountID
   And
  usr_accounts.Tenant_RefID = @TenantID
  And
  usr_accounts.IsDeleted = 0 And
  cmn_notes.IsDeleted = 0 And
  tms_pro_project_notes.IsDeleted = 0 And
  tms_pro_project_note_collaborators.IsDeleted = 0
    
  