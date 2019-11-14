
	Select
	  cmn_notes.CMN_NoteID,
	  cmn_noterevisions.Version,
	  cmn_notes.CreatedBy_BusinessParticipant_RefID,
	  cmn_notes.Creation_Timestamp,
	  Max(cmn_noterevisions.Creation_Timestamp),
	  tms_pro_project_note_collaborators.TMS_PRO_Project_Note_CollaboratorID
	From
	  cmn_notes Inner Join
	  cmn_noterevisions On cmn_notes.CMN_NoteID = cmn_noterevisions.Note_RefID
	  Inner Join
	  tms_pro_project_notes
	    On cmn_notes.CMN_NoteID = tms_pro_project_notes.Ext_CMN_Note_RefID
	  Right Join
	  tms_pro_project_note_collaborators
	    On tms_pro_project_notes.TMS_PRO_Project_NoteID =
	    tms_pro_project_note_collaborators.ProjectNote_RefID Inner Join
	  usr_accounts
	    On usr_accounts.USR_AccountID =
	    tms_pro_project_note_collaborators.Account_RefID And
	    usr_accounts.BusinessParticipant_RefID =
	    cmn_notes.CreatedBy_BusinessParticipant_RefID
	Where
	  (cmn_notes.CreatedBy_BusinessParticipant_RefID = @AccountID Or
	    tms_pro_project_note_collaborators.Account_RefID = @AccountID) And
	  cmn_notes.Tenant_RefID = @TenantID And
	  usr_accounts.IsDeleted = 0
  