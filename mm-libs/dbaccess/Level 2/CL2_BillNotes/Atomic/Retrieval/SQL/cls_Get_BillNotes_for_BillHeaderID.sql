
	SELECT Bil_notes.BIL_Note
		,Bil_notes.BillHeader_RefID
		,Bil_notes.BillPosition_RefID
		,Bil_notes.CreatedBy_BusinessParticipant_RefID
		,Bil_notes.Creation_Timestamp
		,Bil_notes.IsDeleted
		,Bil_notes.NoteText
		,Bil_notes.SequenceOrderNumber
		,Bil_notes.Tenant_RefID
		,Bil_notes.Title
    ,CMN_BPT_BusinessParticipants.DisplayName AS CreatedBy
	FROM Bil_notes
  INNER JOIN CMN_BPT_BusinessParticipants ON Bil_notes.CreatedBy_BusinessParticipant_RefID = CMN_BPT_BusinessParticipants.CMN_BPT_BusinessParticipantID
   AND CMN_BPT_BusinessParticipants.IsDeleted = 0 
   AND CMN_BPT_BusinessParticipants.Tenant_RefID = @TenantID
	WHERE Bil_notes.IsDeleted = 0
		AND Bil_notes.Tenant_RefID = @TenantID
		AND Bil_notes.BillHeader_RefID = @BillHeaderID
  ORDER BY Bil_notes.Creation_Timestamp DESC
  