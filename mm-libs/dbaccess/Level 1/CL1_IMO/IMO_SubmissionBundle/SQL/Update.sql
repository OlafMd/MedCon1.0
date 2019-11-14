UPDATE 
	imo_submissionbundles
SET 
	WorkerAccount_RefID=@WorkerAccount_RefID,
	Language_RefID=@Language_RefID,
	Bundle_Name=@Bundle_Name,
	Bundle_Description=@Bundle_Description,
	DueDate=@DueDate,
	GrabbedAtDate=@GrabbedAtDate,
	GrabbedByAccount_RefID=@GrabbedByAccount_RefID,
	IsGlobalBundle=@IsGlobalBundle,
	IsCompleted=@IsCompleted,
	IsGrabbed=@IsGrabbed,
	Creation_Timestamp=@Creation_Timestamp,
	IsDeleted=@IsDeleted,
	Tenant_RefID=@Tenant_RefID
WHERE 
	IMO_SubmissionBundleID = @IMO_SubmissionBundleID