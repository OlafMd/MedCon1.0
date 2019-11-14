
    
Select
  cmn_noterevisions.CMN_NoteRevisionID,
  cmn_noterevisions.Title,
  cmn_noterevisions.Content,
  cmn_noterevisions.CreatedBy_BusinessParticipant_RefID,
  cmn_noterevisions.Version,
  cmn_noterevisions.Creation_Timestamp,
  cmn_noterevisions.Modification_Timestamp
From
  cmn_noterevisions Inner Join
  cmn_notes On cmn_notes.CMN_NoteID = cmn_noterevisions.Note_RefID
Where
  cmn_notes.CMN_NoteID = @NoteID And
  cmn_noterevisions.IsDeleted = 0 And
  cmn_notes.Tenant_RefID = @TenantID And
  cmn_notes.IsDeleted = 0
  
  