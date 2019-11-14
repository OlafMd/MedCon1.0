INSERT INTO 
	imo_questionnaire_submissionbinders
	(
		IMO_Questionnaire_SubmissionBinderID,
		Newest_Questionnaire_Submission_RefID,
		IsBinderArchived,
		IsLocked_ForResubmission,
		IsLocked_ForDownloading,
		IsCheckedOut,
		CheckedOut_ByAccount_RefID,
		CheckedOut_Date,
		Locked_ByAccount_RefID,
		Locked_Date,
		Creation_Timestamp,
		IsDeleted,
		Tenant_RefID
	)
VALUES 
	(
		@IMO_Questionnaire_SubmissionBinderID,
		@Newest_Questionnaire_Submission_RefID,
		@IsBinderArchived,
		@IsLocked_ForResubmission,
		@IsLocked_ForDownloading,
		@IsCheckedOut,
		@CheckedOut_ByAccount_RefID,
		@CheckedOut_Date,
		@Locked_ByAccount_RefID,
		@Locked_Date,
		@Creation_Timestamp,
		@IsDeleted,
		@Tenant_RefID
	)