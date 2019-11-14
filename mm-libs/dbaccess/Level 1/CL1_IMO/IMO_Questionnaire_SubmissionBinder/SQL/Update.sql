UPDATE 
	imo_questionnaire_submissionbinders
SET 
	Newest_Questionnaire_Submission_RefID=@Newest_Questionnaire_Submission_RefID,
	IsBinderArchived=@IsBinderArchived,
	IsLocked_ForResubmission=@IsLocked_ForResubmission,
	IsLocked_ForDownloading=@IsLocked_ForDownloading,
	IsCheckedOut=@IsCheckedOut,
	CheckedOut_ByAccount_RefID=@CheckedOut_ByAccount_RefID,
	CheckedOut_Date=@CheckedOut_Date,
	Locked_ByAccount_RefID=@Locked_ByAccount_RefID,
	Locked_Date=@Locked_Date,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_Questionnaire_SubmissionBinderID = @IMO_Questionnaire_SubmissionBinderID